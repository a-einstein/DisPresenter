using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using RCS.DIS.Presenter.ViewModels;
using System.ComponentModel;

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

        protected EntitiesOverviewModel(
            GeneralFilterViewModel generalSelector,
            EntitySelectorViewModel<Diagnose> diagnoseSelector,
            EntitySelectorViewModel<Specialisme> specialismeSelector,
            EntitySelectorViewModel<Zorgproduct> zorgproductSelector)
        {
            GeneralSelector = generalSelector;
            GeneralSelector.PropertyChanged += Selector_PropertyChanged;

            DiagnoseSelector = diagnoseSelector;
            DiagnoseSelector.PropertyChanged += Selector_PropertyChanged;

            SpecialismeSelector = specialismeSelector;
            SpecialismeSelector.PropertyChanged += Selector_PropertyChanged;

            ZorgproductSelector = zorgproductSelector;
            ZorgproductSelector.PropertyChanged += Selector_PropertyChanged;
        }

        protected void Selector_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SearchCommand.RaiseCanExecuteChanged();
        }

        protected override bool SearchEnabled()
        {
            return
                base.SearchEnabled() &&

                GeneralSelector?.JaarSelected != 0 &&
                GeneralSelector?.VersieSelected != null &&
                DiagnoseSelector?.Selected != null &&
                SpecialismeSelector?.Selected != null &&
                ZorgproductSelector?.Selected != null;
        }
    }
}
