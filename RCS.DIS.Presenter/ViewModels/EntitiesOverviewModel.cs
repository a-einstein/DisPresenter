using RCS.DIS.Presenter.RetrieveService.ServiceReference;

namespace RCS.DIS.Presenter.ViewModels
{
    public abstract class EntitiesOverviewModel<entityType> : EntitiesSearchViewModel<entityType>
    {
        protected EntitiesOverviewModel()
        {
            StartMessage = "Searching will be with the current Filter values.";
        }

        protected GeneralFilterViewModel GeneralSelector;
        protected EntitySelectorViewModel<Diagnose> DiagnoseSelector;
        protected EntitySelectorViewModel<Specialisme> SpecialismeSelector;
        protected EntitySelectorViewModel<Zorgproduct> ZorgproductSelector;
    }
}
