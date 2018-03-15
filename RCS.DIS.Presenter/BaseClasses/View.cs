using System.Windows.Controls;

namespace RCS.DIS.Presenter.BaseClasses
{
    public abstract class View : UserControl
    {
        // This cannot be uses instead of DataContext from XAML.
        public ViewModel ViewModel
        {
            get { return DataContext as ViewModel; }
            set
            {
                DataContext = value;

                // Use this to have automatic initialization.
                // Note that overriding OnRender for this purpose caused a loop in case of exceptions.
                ViewModel.Initialize();
            }
        }
    }
}
