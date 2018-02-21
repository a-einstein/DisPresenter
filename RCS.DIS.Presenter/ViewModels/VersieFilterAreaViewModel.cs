using System.Windows;

namespace RCS.DIS.Presenter.ViewModels
{
    class VersieFilterAreaViewModel : DependencyObject
    {
        public static readonly DependencyProperty VersiesProperty =
            DependencyProperty.Register(nameof(Versies), typeof(string[]), typeof(MainWindow));

        public string[] Versies
        {
            get { return (string[])GetValue(VersiesProperty); }
            set { SetValue(VersiesProperty, value); }
        }

        public static readonly DependencyProperty VersieSelectedProperty =
            DependencyProperty.Register(nameof(VersieSelected), typeof(string), typeof(MainWindow));

        public string VersieSelected
        {
            get { return (string)GetValue(VersieSelectedProperty); }
            set { SetValue(VersieSelectedProperty, value); }
        }
    }
}
