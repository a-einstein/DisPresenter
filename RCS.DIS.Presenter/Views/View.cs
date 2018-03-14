using RCS.DIS.Presenter.ViewModels;
using System.Windows.Controls;
using System.Windows.Media;

namespace RCS.DIS.Presenter.Views
{
    public abstract class View : UserControl
    {
        // This cannot be uses instead of DataContext from XAML.
        public ViewModel ViewModel
        {
            get { return DataContext as ViewModel; }
            set { DataContext = value; }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            ViewModel.Initialize();
        }
    }
}
