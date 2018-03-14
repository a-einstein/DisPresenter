using Prism.Commands;
using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using RCS.DIS.Presenter.ViewModels;
using System.Windows;

namespace RCS.DIS.Presenter
{
    public partial class MainWindow : Window
    {
        #region Construction
        public MainWindow()
        {
            InitializeComponent();

            SetGeneralFilterViews();

            SetDiagnosesViews();
            SetSpecialismesViews();
            SetZorgactiviteitenViews();
            SetZorgproductenViews();

            SetDbcOverzichtenViews();
            SetDbcProfielenViews();
        }

        private void OpenCriteriaTab(object entityTab)
        {
            ActivityTabControl.SelectedItem = CriteriaTab;
            CriteriaTabControl.SelectedItem = entityTab;
        }
        #endregion

        #region GeneralFilter
        private void SetGeneralFilterViews()
        {
            GeneralSelector = new GeneralFilterViewModel();

            generalFilterArea.ViewModel = GeneralSelector;
        }

        public GeneralFilterViewModel GeneralSelector { get; private set; }
        #endregion

        #region Diagnoses
        private void SetDiagnosesViews()
        {
            DiagnoseSelector = new DiagnoseSelectorViewModel()
            {
                OpenEntitiesCommand = new DelegateCommand(() => OpenCriteriaTab(diagnosesView))
            };

            diagnosesView.ViewModel = DiagnoseSelector;
            diagnoseView.ViewModel = DiagnoseSelector;
        }

        public EntitySelectorViewModel<Diagnose> DiagnoseSelector { get; private set; }
        #endregion

        #region Specialismes
        private void SetSpecialismesViews()
        {
            SpecialismeSelector = new SpecialismeSelectorViewModel
            {
                OpenEntitiesCommand = new DelegateCommand(() => OpenCriteriaTab(specialismesView))
            };

            specialismesView.ViewModel = SpecialismeSelector;
            specialismeView.ViewModel = SpecialismeSelector;
        }

        public EntitySelectorViewModel<Specialisme> SpecialismeSelector { get; private set; }
        #endregion

        #region Zorgactiviteiten
        private void SetZorgactiviteitenViews()
        {
            ZorgactiviteitSelector = new ZorgactiviteitSelectorViewModel()
            {
                OpenEntitiesCommand = new DelegateCommand(() => OpenCriteriaTab(zorgactiviteitenView)),
                Note = $"Note there does not need to be a selection here for {dbcOverzichtenTab.Header}."
            };

            zorgactiviteitenView.ViewModel = ZorgactiviteitSelector;
            zorgactiviteitView.ViewModel = ZorgactiviteitSelector;
        }

        public EntitySelectorViewModel<Zorgactiviteit> ZorgactiviteitSelector { get; private set; }
        #endregion

        #region Zorgproducten
        private void SetZorgproductenViews()
        {
            ZorgproductSelector = new ZorgproductSelectorViewModel()
            {
                OpenEntitiesCommand = new DelegateCommand(() => OpenCriteriaTab(zorgproductenView))
            };

            zorgproductenView.ViewModel = ZorgproductSelector;
            zorgproductView.ViewModel = ZorgproductSelector;
        }

        public EntitySelectorViewModel<Zorgproduct> ZorgproductSelector { get; private set; }
        #endregion

        #region DbcOverzichten
        private void SetDbcOverzichtenViews()
        {
            var viewModel = new DbcOverzichtViewModel(
                GeneralSelector,
                DiagnoseSelector,
                SpecialismeSelector,
                ZorgproductSelector);

            dbcOverzichtenView.ViewModel = viewModel;
        }
        #endregion

        #region DbcProfielen
        private void SetDbcProfielenViews()
        {
            var viewModel = new DbcProfielViewModel(
                GeneralSelector,
                DiagnoseSelector,
                SpecialismeSelector,
                ZorgactiviteitSelector,
                ZorgproductSelector);

            dbcProfielenView.ViewModel = viewModel;
        }
        #endregion
    }
}
