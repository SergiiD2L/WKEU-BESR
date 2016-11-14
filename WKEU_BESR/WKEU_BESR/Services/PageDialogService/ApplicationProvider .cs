using Xamarin.Forms;

namespace WKEU_BESR.Services.PageDialogService
{
    internal sealed class ApplicationProvider : IApplicationProvider
    {
        public Page MainPage
        {
            get { return Application.Current.MainPage; }
            set { Application.Current.MainPage = value; }
        }
    }
}