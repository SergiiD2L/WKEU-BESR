using System;
using System.Linq;
using System.Threading.Tasks;
using WKEU_BESR.Views;
using Xamarin.Forms;
using WKEU_BESR.Services;
using WKEU_BESR.Services.PageDialogService;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Services
{
    internal sealed class NavigationService : INavigationService
    {
        private readonly Lazy<INavigation> _navigation;
        public INavigation _navigation1 { get; set; }
        private readonly IViewFactory _viewFactory;
        private readonly IApplicationProvider _applicationProvider;
        private Page currentPage;

        //public NavigationService(IViewFactory viewFactory, IApplicationProvider applicationProvider) :
        //    this(
        //        new Lazy<INavigation>(() => DependencyService.Get<INavigation>()), 
        //        viewFactory, applicationProvider)
        //{
        //}

        public NavigationService(
            Lazy<INavigation> navigation, 
            IViewFactory viewFactory,
            IApplicationProvider applicationProvider)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
            _applicationProvider = applicationProvider;
        }

        private INavigation Navigation => _navigation1;

        public async Task<IViewModel> PopPageAsync()
        {
            if (currentPage != null)
                return _navigation1.NavigationStack.Contains(currentPage) ? await PopAsync() : await PopModalAsync();
            return null;
        }

        public async Task<IViewModel> PopAsync()
        {
            Page view = await _navigation1.PopAsync(true);
            return view.BindingContext as IViewModel;
        }

        public async Task<IViewModel> PopModalAsync()
        {
            Page view = await _navigation1.PopModalAsync();
            return view.BindingContext as IViewModel;
        }

        public async Task<IViewModel> PopModalAsync(int count)
        {
            Page view;
            for (int i = 0; i < count; i++)
            {          
                view = await _navigation1.PopModalAsync(false);

                if (i == count) { return view.BindingContext as IViewModel;}                    
            }
            return null;
        }

        public async Task PopToRootAsync()
        {
            await _navigation1.PopToRootAsync(false);
        }

        public async Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
            currentPage = view;
            await _navigation1.PushAsync(view, true);

            return viewModel;
        }

        public bool HasPageInModalStack<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel
        {
            bool result = false;
            TViewModel viewModel;
            Page view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
            if (_navigation1.ModalStack.Contains(view))
            {
                result = true;
            }
            return result;
        }

        public async Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            Page view = _viewFactory.Resolve(viewModel);
            await _navigation1.PushAsync(view, true);
            currentPage = view;
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
            await _navigation1.PushModalAsync(view);
            currentPage = view;
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            Page view = _viewFactory.Resolve(viewModel);
            await _navigation1.PushModalAsync(view);
            currentPage = view;
            return viewModel;
        }

        public void RemovePage<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            Page view = _viewFactory.Resolve(viewModel);
            _navigation1.RemovePage(view);
        }

        public void RemovePage<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
            _navigation1.RemovePage(view);
        }

        public void InsertPageBefore(Type vieModel, Type viewModelBefore)
        {
            var page = _viewFactory.Resolve(vieModel);
            var beforePage = _viewFactory.Resolve(vieModel);

            _navigation1.InsertPageBefore(page, beforePage);
        }
        public void SetRootPage<TViewModel>(Action<TViewModel> setStateAction = null)
            where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page rootPage = _viewFactory.Resolve(out viewModel, setStateAction);
            var page = new NavigationPage(rootPage);
            page.BarBackgroundColor = Color.FromHex("#FF3B4148");
            page.BarTextColor = Color.White;
            page.Icon = "hamburger.png";
            App.Current.MainPage = page;
            
            //_applicationProvider.MainPage = page;            
        }
    }
}