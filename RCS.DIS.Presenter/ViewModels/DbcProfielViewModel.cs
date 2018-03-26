using RCS.DIS.Presenter.BaseClasses;
using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter.ViewModels
{
    class DbcProfielViewModel : EntitiesOverviewModel<DbcProfiel>
    {
        public DbcProfielViewModel(
            GeneralFilterViewModel generalSelector,
            EntitySelectorViewModel<Diagnose> diagnoseSelector,
            EntitySelectorViewModel<Specialisme> specialismeSelector,
            EntitySelectorViewModel<Zorgactiviteit> zorgactiviteitSelector,
            EntitySelectorViewModel<Zorgproduct> zorgproductSelector)
            : base(
                generalSelector,
                diagnoseSelector,
                specialismeSelector,
                zorgproductSelector)
        {
            ZorgactiviteitSelector = zorgactiviteitSelector;
            ZorgactiviteitSelector.PropertyChanged += Selector_PropertyChanged;
        }

        protected override ObservableCollection<DataGridColumn> GetGridColumns()
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
            };

            return columns;
        }

        protected EntitySelectorViewModel<Zorgactiviteit> ZorgactiviteitSelector;

        protected override bool SearchEnabled()
        {
            return
                base.SearchEnabled() &&
                
                ZorgactiviteitSelector?.Selected != null;
        }

        protected override async Task Retrieve()
        {
            var number = await retrieveServiceClient.DbcProfielNumberAsync(
                GeneralSelector.JaarSelected,
                SpecialismeSelector.Selected.SpecialismeCode,
                DiagnoseSelector.Selected.DiagnoseCode,
                ZorgproductSelector.Selected.ZorgproductCode,
                ZorgactiviteitSelector.Selected.ZorgactiviteitCode,
                GeneralSelector.VersieSelected);

            // TODO Someway this does not work.
            ResultMessage = $"Found {number}.";

            if (number == 0 || number > maximumRecords)
                ResultMessage = $"{ResultMessage}\nPlease refine your query.";
            else
                Entities = await retrieveServiceClient.DbcProfielEntitiesAsync(
                    GeneralSelector.JaarSelected,
                    SpecialismeSelector.Selected.SpecialismeCode,
                    DiagnoseSelector.Selected.DiagnoseCode,
                    ZorgproductSelector.Selected.ZorgproductCode,
                    ZorgactiviteitSelector.Selected.ZorgactiviteitCode,
                    GeneralSelector.VersieSelected);
        }
    }
}
