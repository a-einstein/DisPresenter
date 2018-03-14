using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter.ViewModels
{
    public class DbcOverzichtViewModel : EntitiesOverviewModel<DbcOverzicht>
    {
        // Have this constructor to better enforce values than in properties alone.
        // However they can still be null.
        // They might become default not null in some version of C#.
        // TODO Check this.
        public DbcOverzichtViewModel(
            GeneralFilterViewModel generalSelector,
            EntitySelectorViewModel<Diagnose> diagnoseSelector,
            EntitySelectorViewModel<Specialisme> specialismeSelector,
            EntitySelectorViewModel<Zorgproduct> zorgproductSelector)
        {
            GeneralSelector = generalSelector;
            DiagnoseSelector = diagnoseSelector;
            SpecialismeSelector = specialismeSelector;
            ZorgproductSelector = zorgproductSelector;
        }

        protected override ObservableCollection<DataGridColumn> GetGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("Jaar"), Header="Jaar" },
                new DataGridTextColumn() { Binding= new Binding("SpecialismeCode"), Header="Specialisme" },
                new DataGridTextColumn() { Binding= new Binding("PatientenPerSpecialisme"), Header="Pat/Spec" },
                new DataGridTextColumn() { Binding= new Binding("SubtrajectenPerSpecialisme"), Header="Subtraj/Spec" },
                new DataGridTextColumn() { Binding= new Binding("DiagnoseCode"), Header="Diagnose" },
                new DataGridTextColumn() { Binding= new Binding("PatientenPerDiagnose"), Header="Pat/Diag" },
                new DataGridTextColumn() { Binding= new Binding("SubtrajectenPerDiagnose"), Header="Subtraj/Diag" },
                new DataGridTextColumn() { Binding= new Binding("ZorgproductCode"), Header="Product" },
                new DataGridTextColumn() { Binding= new Binding("PatientenPerZorgproduct"), Header="Pat/Prod" },
                new DataGridTextColumn() { Binding= new Binding("SubtrajectenPerZorgproduct"), Header="Subtraj/Prod" },
                new DataGridTextColumn() { Binding= new Binding("Verkoopprijs"), Header="Prijs" },
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }

        protected override void Retrieve()
        {
            var number = retrieveServiceClient.DbcOverzichtNumber(
                GeneralSelector.JaarSelected,
                SpecialismeSelector.Selected.SpecialismeCode,
                DiagnoseSelector.Selected.DiagnoseCode,
                ZorgproductSelector.Selected.ZorgproductCode,
                GeneralSelector.VersieSelected);

            // TODO Someway this does not work.
            ResultMessage = $"Found {number}.";

            if (number == 0 || number > maximumRecords)
                ResultMessage = $"{ResultMessage}\nPlease refine your query.";
            else
                Entities = retrieveServiceClient.DbcOverzichtEntities(
                    GeneralSelector.JaarSelected,
                    SpecialismeSelector.Selected.SpecialismeCode,
                    DiagnoseSelector.Selected.DiagnoseCode,
                    ZorgproductSelector.Selected.ZorgproductCode,
                    GeneralSelector.VersieSelected);
        }
    }
}
