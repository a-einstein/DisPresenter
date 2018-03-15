using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter.ViewModels
{
    class DiagnoseSelectorViewModel : EntitySelectorViewModel<Diagnose>
    {
        public DiagnoseSelectorViewModel()
        {
            FilterName = nameof(Diagnose);
        }

        protected override ObservableCollection<DataGridColumn> GetGridColumns()
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

        protected override OmschrijvingContainsNumberDelegate NumberDelegate => retrieveServiceClient.DiagnoseOmschrijvingContainsNumberAsync;
        protected override OmschrijvingContainsEntitiesDelegate EntitiesDelegate => retrieveServiceClient.DiagnoseOmschrijvingContainsEntitiesAsync;
    }
}
