using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using RCS.DIS.Presenter.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter
{
    public partial class MainWindow : Window
    {
        #region Construction
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            SetVersiesView();
            SetDiagnosesView();
            SetSpecialismesView();
        }

        RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();

        #endregion

        #region Versies
        private void SetVersiesView()
        {
            Versies = retrieveServiceClient.Versies();
        }

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

        #region Diagnoses
        private void SetDiagnosesView()
        {
            var tableSelectorViewModel = new TableSelectorViewModel<Diagnose>
                ("Diagnose", retrieveServiceClient.DiagnoseOmschrijvingContainsNumber, retrieveServiceClient.DiagnoseOmschrijvingContainsEntities)
                { SelectorGridColumns = DiagnoseGridColumns(), FilterGridColumns = DiagnoseGridColumns() };

            DiagnosesTab.DataContext = tableSelectorViewModel;
            DiagnoseFilterArea.DataContext = tableSelectorViewModel;
        }

        ObservableCollection<DataGridColumn> DiagnoseGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("DiagnoseCode"), Header="Diagnose" },
                new DataGridTextColumn() { Binding= new Binding("SpecialismeCode"), Header="Specialisme" },
                new DataGridTextColumn() { Binding= new Binding("Omschrijving"), Header="Omschrijving" },
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }
        #endregion

        #region Specialismes
        private void SetSpecialismesView()
        {
            var tableSelectorViewModel = new TableSelectorViewModel<Specialisme>
                ("Specialisme", retrieveServiceClient.SpecialismeOmschrijvingContainsNumber, retrieveServiceClient.SpecialismeOmschrijvingContainsEntities)
            { SelectorGridColumns = SpecialismeGridColumns(), FilterGridColumns = SpecialismeGridColumns() };

            SpecialismesTab.DataContext = tableSelectorViewModel;
            SpecialismeFilterArea.DataContext = tableSelectorViewModel;
        }

        ObservableCollection<DataGridColumn> SpecialismeGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("SpecialismeCode"), Header="Specialisme" },
                new DataGridTextColumn() { Binding= new Binding("Omschrijving"), Header="Omschrijving" },
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }
        #endregion
    }
}
