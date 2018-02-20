using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Windows;

namespace RCS.DIS.Presenter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
 
            var retrieveServiceClient = new RetrieveServiceClient();

            Versies = retrieveServiceClient.Versies();

            var tableSelectorViewModel = new TableSelectorViewModel<Diagnose>(retrieveServiceClient.DiagnoseOmschrijvingContainsNumber, retrieveServiceClient.DiagnoseOmschrijvingContainsEntities);
            (DiagnosesTab.Content as TableSelectorView).DataContext = tableSelectorViewModel;
            DiagnoseFilterArea.DataContext = tableSelectorViewModel;
        }

        #region Versies
        public static readonly DependencyProperty VersiesProperty =
            DependencyProperty.Register("Versies", typeof(string[]), typeof(MainWindow));

        public string[] Versies
        {
            get { return (string[])GetValue(VersiesProperty); }
            set { SetValue(VersiesProperty, value); }
        }
        #endregion
    }
}
