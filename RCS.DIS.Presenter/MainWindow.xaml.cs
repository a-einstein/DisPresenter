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

            SetVersiesView();
            SetDiagnosesView();
            SetSpecialismesView();
            SetZorgactiviteitsView();
            SetZorgproductsView();
        }

        RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();
        #endregion

        #region Versies
        private void SetVersiesView()
        {
            var viewModel = new VersieFilterAreaViewModel();
            viewModel.Versies = retrieveServiceClient.Versies();

            VersieFilterArea.DataContext = viewModel;
        }
        #endregion

        #region Diagnoses
        private void SetDiagnosesView()
        {
            var viewModel = new TableSelectorViewModel<Diagnose>
                ("Diagnose", retrieveServiceClient.DiagnoseOmschrijvingContainsNumber, retrieveServiceClient.DiagnoseOmschrijvingContainsEntities)
            { SelectorGridColumns = DiagnoseGridColumns(), FilterGridColumns = DiagnoseGridColumns() };

            DiagnosesTab.DataContext = viewModel;
            DiagnoseFilterArea.DataContext = viewModel;
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
            var viewModel = new TableSelectorViewModel<Specialisme>
                ("Specialisme", retrieveServiceClient.SpecialismeOmschrijvingContainsNumber, retrieveServiceClient.SpecialismeOmschrijvingContainsEntities)
            { SelectorGridColumns = SpecialismeGridColumns(), FilterGridColumns = SpecialismeGridColumns() };

            SpecialismesTab.DataContext = viewModel;
            SpecialismeFilterArea.DataContext = viewModel;
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

        #region Zorgactiviteiten
        private void SetZorgactiviteitsView()
        {
            var viewModel = new TableSelectorViewModel<Zorgactiviteit>
                ("Zorgactiviteit", retrieveServiceClient.ZorgactiviteitOmschrijvingContainsNumber, retrieveServiceClient.ZorgactiviteitOmschrijvingContainsEntities)
            { SelectorGridColumns = ZorgactiviteitGridColumns(), FilterGridColumns = ZorgactiviteitGridColumns() };

            ZorgactiviteitenTab.DataContext = viewModel;
            ZorgactiviteitFilterArea.DataContext = viewModel;
        }

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
        private void SetZorgproductsView()
        {
            var viewModel = new TableSelectorViewModel<Zorgproduct>
                ("Zorgproduct", retrieveServiceClient.ZorgproductOmschrijvingContainsNumber, retrieveServiceClient.ZorgproductOmschrijvingContainsEntities)
            { SelectorGridColumns = ZorgproductGridColumns(), FilterGridColumns = ZorgproductGridColumns() };

            ZorgproductenTab.DataContext = viewModel;
            ZorgproductFilterArea.DataContext = viewModel;
        }

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
    }
}
