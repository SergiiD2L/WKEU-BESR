using System;
using System.Threading.Tasks;
using Autofac;
using WKEU_BESR.ViewModels;
using WKEU_BESR.Views;
using Xamarin.Forms;
using WKEU_BESR.Services.RestService;
using Plugin.Geolocator;
using WKEU_BESR.Common;
using WKEU_BESR.Services;
using WKEU_BESR.Services.Network;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;

namespace WKEU_BESR.Bootstrapping
{
    internal sealed class Bootstrapper: AutofacBootstrapper
    {
        private readonly App _application;
        private readonly Module _platformSpecificModule;

        private IConnectivityService _connectivityService;
        private INavigationService _navigation;
        private IPubSub _pubSub;

        public Bootstrapper(App application, Module module = null)
        {
            _application = application;
            _platformSpecificModule = module;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<WoltersKluwerModule>();

            if (_platformSpecificModule != null)
            {
                builder.RegisterModule(_platformSpecificModule);
            }
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<MainPageViewModel, HomePage>();
            viewFactory.Register<MasterDetailViewModel, MainPage>();
            viewFactory.Register<MenuViewModel, MenuPage>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            CheckUser(container);
        }

        private  void CheckUser(IContainer container)
        {

            var viewFactory = container.Resolve<IViewFactory>();

            _connectivityService = container.Resolve<IConnectivityService>();

            _pubSub = container.Resolve<IPubSub>();

            Page page;

            page = viewFactory.Resolve<MasterDetailViewModel>();
            
            var navigationPage = new NavigationPage(page)
            {
                //BarBackgroundColor = Color.FromHex("#FF3B4148"),
                BarTextColor = Color.White,                
                //BackgroundColor = Color.FromHex("#FF2E3237") //#345EBF
            };

            _application.MainPage = navigationPage;

            _navigation = (NavigationService)container.Resolve<INavigationService>();
            _navigation._navigation1 = Application.Current.MainPage.Navigation;

        }

    }
}