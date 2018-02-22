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

            SetGeneralViews();
            SetDiagnosesViews();
            SetSpecialismesViews();
            SetZorgactiviteitenViews();
            SetZorgproductenViews();

            SetDbcOverzichtenViews();
        }

        RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();
        #endregion

        #region General
        private void SetGeneralViews()
        {
            GeneralSelector = new GeneralFilterAreaViewModel();

            GeneralSelector.Jaren = retrieveServiceClient.Jaren();
            GeneralSelector.Versies = retrieveServiceClient.Versies();

            VersieFilterArea.DataContext = GeneralSelector;
        }

        public GeneralFilterAreaViewModel GeneralSelector { get; private set; }
        #endregion 

        #region Diagnoses
        private void SetDiagnosesViews()
        {
            DiagnoseSelector = new TableSelectorViewModel<Diagnose>
                ("Diagnose", retrieveServiceClient.DiagnoseOmschrijvingContainsNumber, retrieveServiceClient.DiagnoseOmschrijvingContainsEntities)
            { GridColumns = DiagnoseGridColumns(), FilterGridColumns = DiagnoseGridColumns() };

            DiagnosesTab.DataContext = DiagnoseSelector;
            DiagnoseFilterArea.DataContext = DiagnoseSelector;
        }

        public TableSelectorViewModel<Diagnose> DiagnoseSelector { get; private set; }

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
        private void SetSpecialismesViews()
        {
            SpecialismeSelector = new TableSelectorViewModel<Specialisme>
                ("Specialisme", retrieveServiceClient.SpecialismeOmschrijvingContainsNumber, retrieveServiceClient.SpecialismeOmschrijvingContainsEntities)
            { GridColumns = SpecialismeGridColumns(), FilterGridColumns = SpecialismeGridColumns() };

            SpecialismesTab.DataContext = SpecialismeSelector;
            SpecialismeFilterArea.DataContext = SpecialismeSelector;
        }

        public TableSelectorViewModel<Specialisme> SpecialismeSelector { get; private set; }

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

        #region Zorgactiviteiten
        private void SetZorgactiviteitenViews()
        {
            ZorgactiviteitSelector = new TableSelectorViewModel<Zorgactiviteit>
                ("Zorgactiviteit", retrieveServiceClient.ZorgactiviteitOmschrijvingContainsNumber, retrieveServiceClient.ZorgactiviteitOmschrijvingContainsEntities)
            { GridColumns = ZorgactiviteitGridColumns(), FilterGridColumns = ZorgactiviteitGridColumns() };

            ZorgactiviteitenTab.DataContext = ZorgactiviteitSelector;
            ZorgactiviteitFilterArea.DataContext = ZorgactiviteitSelector;
        }

        public TableSelectorViewModel<Zorgactiviteit> ZorgactiviteitSelector { get; private set; }

        ObservableCollection<DataGridColumn> ZorgactiviteitGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("ZorgactiviteitCode"), Header="Activiteit" },
                new DataGridTextColumn() { Binding= new Binding("Omschrijving"), Header="Omschrijving" },
                new DataGridTextColumn() { Binding= new Binding("ZorgprofielklasseCode"), Header="Klasse"},
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }
        #endregion

        #region Zorgproducten
        private void SetZorgproductenViews()
        {
            ZorgproductSelector = new TableSelectorViewModel<Zorgproduct>
                ("Zorgproduct", retrieveServiceClient.ZorgproductOmschrijvingContainsNumber, retrieveServiceClient.ZorgproductOmschrijvingContainsEntities)
            { GridColumns = ZorgproductGridColumns(), FilterGridColumns = ZorgproductGridColumns() };

            ZorgproductenTab.DataContext = ZorgproductSelector;
            ZorgproductFilterArea.DataContext = ZorgproductSelector;
        }

        public TableSelectorViewModel<Zorgproduct> ZorgproductSelector { get; private set; }

        ObservableCollection<DataGridColumn> ZorgproductGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("ZorgproductCode"), Header="Product" },
                new DataGridTextColumn() { Binding= new Binding("OmschrijvingConsument"), Header="Consumentenomschrijving" },
                new DataGridTextColumn() { Binding= new Binding("OmschrijvingLatijn"), Header="Latijnse omschrijving" },
                new DataGridTextColumn() { Binding= new Binding("DeclaratiecodeVerzekerd"), Header="Verzekerde code"},
                new DataGridTextColumn() { Binding= new Binding("DeclaratiecodeOnverzekerd"), Header="Onverzekerde code"},
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }
        #endregion

        #region DbcOverzichten
        private void SetDbcOverzichtenViews()
        {
            var viewModel = new DbcOverzichtViewModel(
                GeneralSelector,
                DiagnoseSelector,
                SpecialismeSelector,
                ZorgactiviteitSelector,
                ZorgproductSelector)
            { GridColumns = DbcOverzichtGridColumns() };

            DbcOverzichtenTab.DataContext = viewModel;
        }

        ObservableCollection<DataGridColumn> DbcOverzichtGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("Jaar"), Header="Jaar" },
                new DataGridTextColumn() { Binding= new Binding("SpecialismeCode"), Header="Specialisme" },
                new DataGridTextColumn() { Binding= new Binding("DiagnoseCode"), Header="Diagnose" },
                new DataGridTextColumn() { Binding= new Binding("ZorgproductCode"), Header="Product" },
                new DataGridTextColumn() { Binding= new Binding("Patienten"), Header="Patienten" },
                new DataGridTextColumn() { Binding= new Binding("Subtrajecten"), Header="Subtrajecten" },
                new DataGridTextColumn() { Binding= new Binding("ZorgactiviteitCode"), Header="Activiteit" },
                new DataGridTextColumn() { Binding= new Binding("Zorgactiviteiten"), Header="Activiteiten" },
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }
        #endregion
    }
}
