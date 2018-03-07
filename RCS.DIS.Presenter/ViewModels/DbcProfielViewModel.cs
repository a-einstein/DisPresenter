using RCS.DIS.Presenter.RetrieveService.ServiceReference;

namespace RCS.DIS.Presenter.ViewModels
{
    class DbcProfielViewModel : OverviewModel<DbcProfiel>
    {
        public DbcProfielViewModel(
             GeneralFilterAreaViewModel generalSelector,
             TableSelectorViewModel<Diagnose> diagnoseSelector,
             TableSelectorViewModel<Specialisme> specialismeSelector,
             TableSelectorViewModel<Zorgactiviteit> zorgactiviteitSelector,
             TableSelectorViewModel<Zorgproduct> zorgproductSelector)
        {
            GeneralSelector = generalSelector;
            DiagnoseSelector = diagnoseSelector;
            SpecialismeSelector = specialismeSelector;
            ZorgactiviteitSelector = zorgactiviteitSelector;
            ZorgproductSelector = zorgproductSelector;
        }

        protected TableSelectorViewModel<Zorgactiviteit> ZorgactiviteitSelector;

        protected override void Retrieve()
        {
            var number = retrieveServiceClient.DbcProfielNumber(
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
                Entities = retrieveServiceClient.DbcProfielEntities(
                    GeneralSelector.JaarSelected,
                    SpecialismeSelector.Selected.SpecialismeCode,
                    DiagnoseSelector.Selected.DiagnoseCode,
                    ZorgproductSelector.Selected.ZorgproductCode,
                    ZorgactiviteitSelector.Selected.ZorgactiviteitCode,
                    GeneralSelector.VersieSelected);
        }
    }
}
