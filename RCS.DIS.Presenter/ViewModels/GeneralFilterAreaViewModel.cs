using System.Windows;

namespace RCS.DIS.Presenter.ViewModels
{
    public class GeneralFilterAreaViewModel : DependencyObject
    {
        #region Jaren
        public static readonly DependencyProperty JarenProperty =
            DependencyProperty.Register(nameof(Jaren), typeof(short[]), typeof(GeneralFilterAreaViewModel));

        public short[] Jaren
        {
            get { return (short[])GetValue(JarenProperty); }
            set { SetValue(JarenProperty, value); }
        }

        public static readonly DependencyProperty JaarSelectedProperty =
            DependencyProperty.Register(nameof(JaarSelected), typeof(short), typeof(GeneralFilterAreaViewModel));

        public short JaarSelected
        {
            get { return (short)GetValue(JaarSelectedProperty); }
            set { SetValue(JaarSelectedProperty, value); }
        }
        #endregion

        #region Versies
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
        #endregion
    }
}
