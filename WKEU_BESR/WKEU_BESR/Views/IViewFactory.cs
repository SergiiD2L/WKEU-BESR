using System;
using Xamarin.Forms;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Views
{
    internal interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page;

        Page Resolve<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        Page Resolve(Type viewModelType);

        Page Resolve(Type viewModelType, Action<IViewModel> setStateAction = null);
    }
}