using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using WKEU_BESR.Events;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Views
{
    public partial class MenuPage : ContentPage
    {
        public IPubSub PubSub { get; set; }

        public MenuPage(IPubSub pubSub)
        {
            InitializeComponent();
            PubSub = pubSub;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemTapped += ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return;
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MenuViewModel model = (MenuViewModel)BindingContext;
            PubSub.UnSubScribe<Message>(model);
        }
    }
}
