using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using WKEU_BESR.Events;
using WKEU_BESR.Services;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;

namespace WKEU_BESR.ViewModels
{
    internal abstract class BaseViewModel : IViewModel
    {
        private string _title;
        private bool _isLoading;
        private bool _hasNavigationBar;
        public IPubSub PubSub { get; set; }


        protected BaseViewModel(INavigationService navigationService, IPubSub pubsub) : this()
        {            
            PubSub = pubsub;
        }

        protected BaseViewModel()
        {

        }
     
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public bool HasNavigationBar
        {
            get { return _hasNavigationBar; }
            set
            {
                _hasNavigationBar = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            action(this as T);
        }

    
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = PropertyChanged;
            eventHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            MemberExpression expression = propertyExpression.Body as MemberExpression;
            string propertyName = expression?.Member.Name;
            OnPropertyChanged(propertyName);
        }
    }
}