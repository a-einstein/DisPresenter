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
            SearchCommand = new DelegateCommand(Search);
        }

        public static readonly DependencyProperty SearchStringProperty =
            DependencyProperty.Register("SearchString", typeof(string), typeof(MainWindow));

        public string SearchString
        {
            get { return (string)GetValue(SearchStringProperty); }
            set { SetValue(SearchStringProperty, value); }
        }

        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(MainWindow));

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public void Search()
        {
            var number = new RetrieveServiceClient().DiagnoseOmschrijvingContainsNumber(SearchString);

            if (number > 100)
                Message = $"Found {number}. Please refine your query.";
            else
            {
                Message = $"Found {number}. Please select a diagnose.";
                Diagnoses = new RetrieveServiceClient().DiagnoseOmschrijvingContainsEntities(SearchString);
            }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MainWindow), new PropertyMetadata("Enter part of the omschrijving to look for."));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty DiagnosesProperty =
            DependencyProperty.Register("Diagnoses", typeof(Diagnose[]), typeof(MainWindow), new PropertyMetadata(new Diagnose[0]));

        public Diagnose[] Diagnoses
        {
            get { return (Diagnose[])GetValue(DiagnosesProperty); }
            set { SetValue(DiagnosesProperty, value); }
        }
    }
}
