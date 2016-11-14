namespace WKEU_BESR.Events
{
    internal sealed class ConnectivityChangedMessage : IMessage
    {
        public bool IsConnected { get; set; }
    }
}