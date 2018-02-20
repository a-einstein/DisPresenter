using Prism.Commands;
using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Windows;
using System.Windows.Input;

namespace RCS.DIS.Presenter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // TODO add enablement.
            DiagnosesSearchCommand = new DelegateCommand(SearchDiagnoses);

            OpenDiagnosesCommand = new DelegateCommand(OpenDiagnoses);

            Versies = new RetrieveServiceClient().Versies();
        }

        #region Versies
        public static readonly DependencyProperty VersiesProperty =
            DependencyProperty.Register("Versies", typeof(string[]), typeof(MainWindow));

        public string[] Versies
        {
            get { return (string[])GetValue(VersiesProperty); }
            set { SetValue(VersiesProperty, value); }
        }
        #endregion

        // TODO Should make this a separate view + viewmodel and use generic naming again..
        #region Diagnoses
        public static readonly DependencyProperty DiagnosesSearchStringProperty =
            DependencyProperty.Register(nameof(DiagnosesSearchString), typeof(string), typeof(MainWindow));

        public string DiagnosesSearchString
        {
            get { return (string)GetValue(DiagnosesSearchStringProperty); }
            set { SetValue(DiagnosesSearchStringProperty, value); }
        }

        public static readonly DependencyProperty DiagnosesSearchCommandProperty =
            DependencyProperty.Register(nameof(DiagnosesSearchCommand), typeof(ICommand), typeof(MainWindow));

        public ICommand DiagnosesSearchCommand
        {
            get { return (ICommand)GetValue(DiagnosesSearchCommandProperty); }
            set { SetValue(DiagnosesSearchCommandProperty, value); }
        }

        public void SearchDiagnoses()
        {
            var number = new RetrieveServiceClient().DiagnoseOmschrijvingContainsNumber(DiagnosesSearchString);

            if (number == 0 || number > 100)
                DiagnosesMessage = $"Found {number}. Please refine your query.";
            else
            {
                DiagnosesMessage = $"Found {number}. Please select a diagnose.";
                Diagnoses = new RetrieveServiceClient().DiagnoseOmschrijvingContainsEntities(DiagnosesSearchString);
            }
        }

        public static readonly DependencyProperty OpenDiagnosesCommandProperty =
            DependencyProperty.Register("OpenDiagnosesCommand", typeof(ICommand), typeof(MainWindow));

        public ICommand OpenDiagnosesCommand
        {
            get { return (ICommand)GetValue(OpenDiagnosesCommandProperty); }
            set { SetValue(OpenDiagnosesCommandProperty, value); }
        }

        // Note this only works in codebehind.
        // Doing so with just bindings seems at least awkward, even with a CommandParameter.
        private void OpenDiagnoses()
        {
            CriteriaTabControl.SelectedItem = DiagnosesTab;
        }

        public static readonly DependencyProperty DiagnosesMessageProperty =
            DependencyProperty.Register(nameof(DiagnosesMessage), typeof(string), typeof(MainWindow), new PropertyMetadata("Enter part of the omschrijving to look for."));

        public string DiagnosesMessage
        {
            get { return (string)GetValue(DiagnosesMessageProperty); }
            set { SetValue(DiagnosesMessageProperty, value); }
        }

        public static readonly DependencyProperty DiagnosesProperty =
            DependencyProperty.Register(nameof(Diagnoses), typeof(Diagnose[]), typeof(MainWindow), new PropertyMetadata(new Diagnose[0]));

        public Diagnose[] Diagnoses
        {
            get { return (Diagnose[])GetValue(DiagnosesProperty); }
            set { SetValue(DiagnosesProperty, value); }
        }

        public static readonly DependencyProperty SelectedDiagnoseProperty =
            DependencyProperty.Register(nameof(SelectedDiagnose), typeof(Diagnose), typeof(MainWindow), new PropertyMetadata(new PropertyChangedCallback(SetSelectedDiagnoseSource)));

        public Diagnose SelectedDiagnose
        {
            get { return (Diagnose)GetValue(SelectedDiagnoseProperty); }
            set { SetValue(SelectedDiagnoseProperty, value); }
        }

        private static void SetSelectedDiagnoseSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = d as MainWindow;
            viewModel.SelectedDiagnoseSource = new Diagnose[] { viewModel.SelectedDiagnose };
        }

        public static readonly DependencyProperty SelectedDiagnoseSourceProperty =
            DependencyProperty.Register(nameof(SelectedDiagnoseSource), typeof(Diagnose[]), typeof(MainWindow));

        public Diagnose[] SelectedDiagnoseSource
        {
            get { return (Diagnose[])GetValue(SelectedDiagnoseSourceProperty); }
            set { SetValue(SelectedDiagnoseSourceProperty, value); }
        }
        #endregion
    }
}
