using RCS.DIS.Presenter.RetrieveService.ServiceReference;

namespace RCS.DIS.Presenter.ViewModels
{
    public abstract class OverviewModel<entityType> : SearchViewModel<entityType>
    {
        protected GeneralFilterAreaViewModel GeneralSelector;
        protected TableSelectorViewModel<Diagnose> DiagnoseSelector;
        protected TableSelectorViewModel<Specialisme> SpecialismeSelector;
        protected TableSelectorViewModel<Zorgactiviteit> ZorgactiviteitSelector;
        protected TableSelectorViewModel<Zorgproduct> ZorgproductSelector;

        protected RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();
    }
}
