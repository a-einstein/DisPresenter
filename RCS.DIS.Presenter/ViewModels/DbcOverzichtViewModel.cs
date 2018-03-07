using RCS.DIS.Presenter.RetrieveService.ServiceReference;

namespace RCS.DIS.Presenter.ViewModels
{
    public class DbcOverzichtViewModel : OverviewModel<DbcOverzicht>
    {
        // Have this constructor to better enforce values than in properties alone.
        // However they can still be null.
        // They might become default not null in some version of C#.
        // TODO Check this.
        public DbcOverzichtViewModel(
            GeneralFilterAreaViewModel generalSelector,
            TableSelectorViewModel<Diagnose> diagnoseSelector,
            TableSelectorViewModel<Specialisme> specialismeSelector,
            TableSelectorViewModel<Zorgproduct> zorgproductSelector)
        {
            GeneralSelector = generalSelector;
            DiagnoseSelector = diagnoseSelector;
            SpecialismeSelector = specialismeSelector;
            ZorgproductSelector = zorgproductSelector;
        }

        protected override void Retrieve()
        {
            var number = retrieveServiceClient.DbcOverzichtNumber(
                GeneralSelector.JaarSelected,
                SpecialismeSelector.Selected.SpecialismeCode,
                DiagnoseSelector.Selected.DiagnoseCode,
                ZorgproductSelector.Selected.ZorgproductCode,
                GeneralSelector.VersieSelected);

            if (number == 0 || number > maximumRecords)
                ResultMessage = $"Found {number}. Please refine your query.";
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
