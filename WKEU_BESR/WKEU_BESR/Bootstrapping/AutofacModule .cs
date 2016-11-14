using Autofac;
using WKEU_BESR.Services;
using WKEU_BESR.Views;
using Xamarin.Forms;

namespace WKEU_BESR.Bootstrapping
{
    internal sealed class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Service registration
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();



            // Navigation registration
            builder.Register(context => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}