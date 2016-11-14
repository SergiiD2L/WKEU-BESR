using System;
using System.ComponentModel;

namespace WKEU_BESR.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Title { get; set; }

        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}