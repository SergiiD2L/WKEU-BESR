using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Services
{
    public interface INavigationService
    {
        INavigation _navigation1 { get; set; }
        Task<IViewModel> PopAsync();

        Task<IViewModel> PopModalAsync();

        Task<IViewModel> PopModalAsync(int count);

        Task<IViewModel> PopPageAsync();


        Task PopToRootAsync();

        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;

        bool HasPageInModalStack<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;

        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        void RemovePage<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        void RemovePage<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;

        void InsertPageBefore(Type vieModel, Type viewModelBefore);

        void SetRootPage<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;
    }
}