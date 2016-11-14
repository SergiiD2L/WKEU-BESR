using Autofac;
using Xamarin.Forms;
using WKEU_BESR.Common;
using WKEU_BESR.Services;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.Services.Network;
using WKEU_BESR.Services.PageDialogService;
using WKEU_BESR.Services.RestService;
using WKEU_BESR.ViewModels;
using WKEU_BESR.Views;

namespace WKEU_BESR.Bootstrapping
{
    internal sealed class WoltersKluwerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Service registration
            builder.RegisterType<PubSub>().As<IPubSub>().SingleInstance();
            builder.RegisterType<ConnectivityService>().As<IConnectivityService>().SingleInstance();

            builder.RegisterType<ApplicationProvider>().As<IApplicationProvider>().SingleInstance();
            builder.RegisterType<PageDialogService>().As<IPageDialogService>().SingleInstance();

            // View model registration
            builder.RegisterType<MainPageViewModel>();
            builder.RegisterType<MasterDetailViewModel>();//.SingleInstance();
            builder.RegisterType<MenuViewModel>();//.SingleInstance();


            // View registration
            builder.RegisterType<HomePage>();
            builder.RegisterType<MenuPage>();
            builder.RegisterType<MainPage>();

        }

    }
}