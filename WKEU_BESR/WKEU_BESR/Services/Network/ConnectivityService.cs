using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using WKEU_BESR.Events;
using WKEU_BESR.Services.MessagingCenter;

namespace WKEU_BESR.Services.Network
{
    internal sealed class ConnectivityService : IConnectivityService
    {
        public ConnectivityService(IPubSub publishSubscribe)
        {
            PublishSubscribe = publishSubscribe;
            CrossConnectivity.Current.ConnectivityChanged -= CurrentOnConnectivityChanged;
            CrossConnectivity.Current.ConnectivityChanged += CurrentOnConnectivityChanged;
        }
        
        public IPubSub PublishSubscribe { get; }

        public bool IsConnected => CrossConnectivity.Current.IsConnected;

        private void CurrentOnConnectivityChanged(
            object sender, 
            ConnectivityChangedEventArgs connectivityChangedEventArgs)
        {
            PublishSubscribe.Publish(new ConnectivityChangedMessage { IsConnected = connectivityChangedEventArgs.IsConnected });
        }
    }
}