using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter.ViewModels
{
    class ZorgproductSelectorViewModel : EntitySelectorViewModel<Zorgproduct>
    {
        public ZorgproductSelectorViewModel()
        {
            FilterName = nameof(Zorgproduct);
        }

        protected override ObservableCollection<DataGridColumn> GetGridColumns()
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

        protected override OmschrijvingContainsNumberDelegate NumberDelegate => retrieveServiceClient.ZorgproductOmschrijvingContainsNumberAsync;
        protected override OmschrijvingContainsEntitiesDelegate EntitiesDelegate => retrieveServiceClient.ZorgproductOmschrijvingContainsEntitiesAsync;
    }
}
