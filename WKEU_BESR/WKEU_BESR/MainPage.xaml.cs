using System;
using Xamarin.Forms;
using WKEU_BESR.Services;
using WKEU_BESR.Views;

namespace WKEU_BESR
{
    public partial class MainPage : BindableMasterDetailPage
    {
        private readonly INavigationService _navigationService;
        public MainPage(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            //ToolbarItems.Add(new ToolbarItem("Profile", "userprofile.png", () => { }));
            //ToolbarItems.Add(new ToolbarItem("Profile", "userprofile.png", () => { }));

            //ToolbarItems.Add(new ToolbarItem("Profile", "userprofile.png", () => { }));

            //ToolbarItems.Add(new ToolbarItem("Profile", "", () => { }));

            //ToolbarItems.Add(new ToolbarItem("Profile", "userprofile.png", () => { }));

            //ToolbarItems.Add(new ToolbarItem("Profile", "userprofile.png", () => { }));
            //ToolbarItems.Add(new ToolbarItem("Profile", "userprofile.png", () => { }));            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetBackButtonTitle(this, string.Empty);
            //NavigationPage.SetHasBackButton(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            if(_navigationService._navigation1.NavigationStack.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }


    }
}
