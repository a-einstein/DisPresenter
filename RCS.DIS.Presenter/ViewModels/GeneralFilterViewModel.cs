using System.Windows;

namespace RCS.DIS.Presenter.ViewModels
{
    public class GeneralFilterViewModel : SearchViewModel
    {
        public override void Initialize()
        {
            base.Initialize();

            Search();
        }

        protected override void Retrieve()
        {
            Jaren = retrieveServiceClient.Jaren();
            Versies = retrieveServiceClient.Versies();
        }

        #region Jaren
        public static readonly DependencyProperty JarenProperty =
            DependencyProperty.Register(nameof(Jaren), typeof(short[]), typeof(GeneralFilterViewModel));

        public short[] Jaren
        {
            get { return (short[])GetValue(JarenProperty); }
            set
            {
                SetValue(JarenProperty, value);

                // TODO Why is this just needed for this property?
                RaisePropertyChanged(nameof(Versies));
            }
        }

        public static readonly DependencyProperty JaarSelectedProperty =
            DependencyProperty.Register(nameof(JaarSelected), typeof(short), typeof(GeneralFilterViewModel));

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
            set
            {
                SetValue(VersiesProperty, value);

                // TODO Why is this just needed for this property?
                RaisePropertyChanged(nameof(Versies));
            }
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
