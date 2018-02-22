using RCS.DIS.Presenter.RetrieveService.ServiceReference;

namespace RCS.DIS.Presenter.ViewModels
{
    public abstract class OverviewModel<entityType> : SearchViewModel<entityType>
    {
        protected OverviewModel()
        {
            StartMessage = "Searching will be with the current Filter values.";
        }

        protected GeneralFilterAreaViewModel GeneralSelector;
        protected TableSelectorViewModel<Diagnose> DiagnoseSelector;
        protected TableSelectorViewModel<Specialisme> SpecialismeSelector;
        protected TableSelectorViewModel<Zorgproduct> ZorgproductSelector;

        protected RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();
    }
}
