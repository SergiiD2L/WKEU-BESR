using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using WKEU_BESR.Events;
using WKEU_BESR.Models;
using WKEU_BESR.Services;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.Services.PageDialogService;
using WKEU_BESR.Views;
using System.Collections.ObjectModel;

namespace WKEU_BESR.ViewModels
{
    internal sealed class MenuViewModel : BaseViewModel
    {
        private MenuPageItem _selectedMenuItem;
        private readonly IPubSub _pubSub;
        private readonly INavigationService _navigationService;

        private readonly IPageDialogService _pageDialogService;
        private readonly IViewFactory _viewFactory;
    
        public MenuViewModel(
            IPubSub pubSub,
            INavigationService navigationService, 
            IPageDialogService pageDialogService,
            IViewFactory viewFactory
            )
        {
            _pageDialogService = pageDialogService;
            _pubSub = pubSub;
            _navigationService = navigationService;
            _viewFactory = viewFactory;
            InitMenuItems();
        }

       
        private void InitMenuItems()
        {
            var menuItems = new List<MenuPageItem>();
            MenuPageItems = new ObservableCollection<MenuPageItem>();          

            var homeItem = new MenuPageItem
            {
                Title = "Home",//Resources.Resource.SignOut,
                TargetType = typeof(MainPageViewModel),
                ActionType = ActionTypes.Navigation,
                IconSource = "home.png"
            };
            MenuPageItems.Add(homeItem);

        }


        public ICommand MenuItemSelectedCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedMenuItem == null)
                    {
                        return;
                    }
                    Title = SelectedMenuItem.Title;
                    switch (SelectedMenuItem.ActionType)
                    {
                        case ActionTypes.SignIn:
                            break;
                        case ActionTypes.SignOut:                            
                            break;
                        case ActionTypes.Navigation:
                             _pubSub.Publish(new NavigationMessage(SelectedMenuItem.TargetType)); 
                            break;
                    }

                    SelectedMenuItem = null;
                });
            }
        }

        private ObservableCollection<MenuPageItem> _menuPageItems;
        public ObservableCollection<MenuPageItem> MenuPageItems
        {
            get { return _menuPageItems; }
            set
            {
                _menuPageItems = value;
                OnPropertyChanged();
            }
        }

        public MenuPageItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {              
                _selectedMenuItem = value;
                OnPropertyChanged();
                MenuItemSelectedCommand.Execute(null); 
            }
        }
    }
}
