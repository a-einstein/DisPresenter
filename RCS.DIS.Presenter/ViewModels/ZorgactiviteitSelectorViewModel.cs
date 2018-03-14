using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter.ViewModels
{
    class ZorgactiviteitSelectorViewModel : EntitySelectorViewModel<Zorgactiviteit>
    {
        public ZorgactiviteitSelectorViewModel()
        {
            FilterName = nameof(Zorgactiviteit);
        }

        protected override ObservableCollection<DataGridColumn> GetGridColumns()
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

        protected override OmschrijvingContainsNumberDelegate NumberDelegate => retrieveServiceClient.ZorgactiviteitOmschrijvingContainsNumber;
        protected override OmschrijvingContainsEntitiesDelegate EntitiesDelegate => retrieveServiceClient.ZorgactiviteitOmschrijvingContainsEntities;
    }
}
