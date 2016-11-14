using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Xamarin.Forms;
using WKEU_BESR.Common;
using WKEU_BESR.Events;
using WKEU_BESR.Models;
using WKEU_BESR.Services;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.Services.RestService;
using WKEU_BESR.Views;
using WKEU_BESR.Services.PageDialogService;
using WKEU_BESR.Services.Network;

namespace WKEU_BESR.ViewModels
{
    internal sealed class MasterDetailViewModel : BaseViewModel
    {
        private bool _isMenuVisible;
        private Page _detailPage;
        private Page _menuPage;
        private MasterBehavior _menuBehavior;
        private readonly IViewFactory _viewFactory;

        private INavigationService _navigation;
        private IPubSub _pubSub;
        private IPageDialogService _pageDialogService;

        //private IConnectivityService _connectivityService;

        public MasterDetailViewModel(
            IPubSub pubSub,
            IViewFactory viewFactory,
            IPageDialogService pageDialogService,
            IConnectivityService connectivityService)
        {
            _viewFactory = viewFactory;
            MenuBehavior = MasterBehavior.Default;
            _pubSub = pubSub;
            _pageDialogService = pageDialogService;

            Page master = viewFactory.Resolve<MenuViewModel>();
  
            MenuPage = master;


            DetailPage = _viewFactory.Resolve<MainPageViewModel>();


            _pubSub.SubScribe<NavigationMessage>(this, SubscribeCallBack);
            _pubSub.SubScribe<ConnectivityChangedMessage>(this, NetworkChangedCallBack);

        }


        public async void NetworkChangedCallBack(ConnectivityChangedMessage msg)
        {
            if (!msg.IsConnected)
            {
                await _pageDialogService.DisplayAlertAsync("Сеть", "Отсутствует подключение к интернету.", "Ok");
            }
        }

        //private async void VerifyToken(string token)
        //{            
        //    if (token != null && _connectivityService.IsConnected)
        //    {
        //        var res = await _rest.VerifyUserToken(token);

        //        if (res == null) {
        //            Device.BeginInvokeOnMainThread(async ()=> {
        //                await _navigation.PushModalAsync<LoginViewModel>(); 
        //            });                    
        //        }
        //        else {
        //            UserSetting.IsLoggedIn = true;
        //            _pubSub.Publish(new Events.MessageAuthrized());
        //        }
        //    }
        //    else {
        //        Device.BeginInvokeOnMainThread(async () => {
        //            await _navigation.PushModalAsync<LoginViewModel>(); 
        //        });
        //    }
        //}

        //private string RestoreUserSettingsFromCache()
        //{
        //    var userCache = cacheService.CheckLoggedUser();

        //    if (userCache == null) { return null; }
        //    else
        //    {
        //        UserSetting.LocalId = userCache.LocalId;
        //        UserSetting.Token = userCache.Token;
        //        UserSetting.UserPhone = userCache.UserPhone;
        //        UserSetting.SelectedCity = userCache.SelectedCity;
        //        UserSetting.SelectedCurrency = userCache.SelectedCurrency;
        //    }

        //    return userCache.Token;
        //}

        public bool IsMenuVisible
        {
            get { return _isMenuVisible; }
            set
            {
                _isMenuVisible = value;
                OnPropertyChanged();
            }
        }

        public Page DetailPage
        {
            get { return _detailPage; }
            set
            {
                _detailPage = value;
                OnPropertyChanged();
            }
        }

        public Page MenuPage
        {
            get { return _menuPage; }
            set
            {
                _menuPage = value;
                OnPropertyChanged();
            }
        }



        public MasterBehavior MenuBehavior
        {
            get { return _menuBehavior; }
            set
            {
                _menuBehavior = value;
                OnPropertyChanged();
            }
        }

        private Page _currentPage;

        private async void SubscribeCallBack(NavigationMessage message)
        {

            if (message.TargetType != null)
            {
                await Task.Run(() =>
                {
                    Page nextPage =
                    _viewFactory.Resolve(
                        message.TargetType,
                        message.StateAction);

                    var stack = DetailPage.Navigation.NavigationStack;

                    if (nextPage.GetType() != DetailPage.GetType())//(stack.Any() && stack[stack.Count - 1].GetType() != nextPage.GetType())
                    {
                        DetailPage = nextPage;
                        _currentPage = nextPage;
                    }

                    MenuPage.Title = nextPage.Title;
                    //IsLoading = false;
                    //if (stack.Count > 1)
                    //    DetailPage.Navigation.RemovePage(stack[0]);

                });
            }

            IsMenuVisible = false;

        }
    }
}
