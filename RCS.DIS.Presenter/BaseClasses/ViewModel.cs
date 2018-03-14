using System.ComponentModel;
using System.Windows;

namespace RCS.DIS.Presenter.BaseClasses
{
    public abstract class ViewModel : DependencyObject, INotifyPropertyChanged
    {
        public virtual void Initialize()
        { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
