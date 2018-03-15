using System.ComponentModel;
using System.Windows;

namespace RCS.DIS.Presenter.BaseClasses
{
    public abstract class ViewModel : DependencyObject, INotifyPropertyChanged
    {
        protected bool initialized;

        public virtual void Initialize()
        {
            // Something to test for, call this LAST.
            initialized = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
