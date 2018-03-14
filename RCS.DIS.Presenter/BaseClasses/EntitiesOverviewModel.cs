using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using RCS.DIS.Presenter.ViewModels;

namespace RCS.DIS.Presenter.BaseClasses
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
