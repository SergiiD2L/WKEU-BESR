using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Content.Res;
using Java.Lang;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using WKEU_BESR.Services;
using WKEU_BESR.Services.Network;
using WKEU_BESR.Services.RestService;
using WKEU_BESR.Common;
using WKEU_BESR.Events;
using WKEU_BESR.Resources;
using WKEU_BESR.Models;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.Views;
using Exception = System.Exception;
using WKEU_BESR.Services.PageDialogService;

namespace WKEU_BESR.ViewModels
{
    internal sealed class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public readonly IConnectivityService _connectivityService;
        public readonly IPubSub _pubSub;    
        private IPageDialogService _pageDialogService;
        private readonly IViewFactory _viewFactory;

        public MainPageViewModel(
            INavigationService navigationService,
            IConnectivityService connectivityService, 
            IPubSub pubsub, 
            IPageDialogService pageDialogService,
            IViewFactory viewFactory)
        {

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _pubSub = pubsub;
            _connectivityService = connectivityService;
            _viewFactory = viewFactory;
            
        }        



    }
}
