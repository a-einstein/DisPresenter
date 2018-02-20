using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace RCS.DIS.Presenter
{
    public class TableSelectorViewModel<entityType> : DependencyObject
    {
        public delegate int OmschrijvingContainsNumberDelegate(string SearchString);
        public delegate entityType[] OmschrijvingContainsEntitiesDelegate(string SearchString);

        public TableSelectorViewModel(OmschrijvingContainsNumberDelegate numberDelegate, OmschrijvingContainsEntitiesDelegate entitiesDelegate)
        {
            NumberDelegate = numberDelegate;
            EntitiesDelegate = entitiesDelegate;

            // TODO add enablement.
            SearchCommand = new DelegateCommand(Search);

            OpenEntitiesCommand = new DelegateCommand(OpenEntities);
        }

        private OmschrijvingContainsNumberDelegate NumberDelegate;
        private OmschrijvingContainsEntitiesDelegate EntitiesDelegate;

        public static readonly DependencyProperty SearchStringProperty =
            DependencyProperty.Register(nameof(SearchString), typeof(string), typeof(TableSelectorViewModel<entityType>));

        public string SearchString
        {
            get { return (string)GetValue(SearchStringProperty); }
            set { SetValue(SearchStringProperty, value); }
        }

        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register(nameof(SearchCommand), typeof(ICommand), typeof(TableSelectorViewModel<entityType>));

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public void Search()
        {
            var number = NumberDelegate(SearchString);

            if (number == 0 || number > 100)
                Message = $"Found {number}. Please refine your query.";
            else
            {
                Message = $"Found {number}. Please select a diagnose.";
                Entities = EntitiesDelegate(SearchString);
            }
        }

        public static readonly DependencyProperty OpenEntitiesCommandProperty =
            DependencyProperty.Register(nameof(OpenEntitiesCommand), typeof(ICommand), typeof(TableSelectorViewModel<entityType>));

        public ICommand OpenEntitiesCommand
        {
            get { return (ICommand)GetValue(OpenEntitiesCommandProperty); }
            set { SetValue(OpenEntitiesCommandProperty, value); }
        }

        // Note this only works in codebehind.
        // Doing so with just bindings seems at least awkward, even with a CommandParameter.
        public void OpenEntities()
        {
            //CriteriaTabControl.SelectedItem = DiagnosesTab;
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(TableSelectorViewModel<entityType>), new PropertyMetadata("Enter part of the omschrijving to look for."));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty EntitiesProperty =
            DependencyProperty.Register(nameof(Entities), typeof(entityType[]), typeof(TableSelectorViewModel<entityType>), new PropertyMetadata(new entityType[0]));

        public entityType[] Entities
        {
            get { return (entityType[])GetValue(EntitiesProperty); }
            set { SetValue(EntitiesProperty, value); }
        }

        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register(nameof(Selected), typeof(Diagnose), typeof(TableSelectorViewModel<entityType>), new PropertyMetadata(new PropertyChangedCallback(SetSelectedSource)));

        public entityType Selected
        {
            get { return (entityType)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        private static void SetSelectedSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = d as TableSelectorViewModel<entityType>;
            viewModel.SelectedSource = new entityType[] { viewModel.Selected };
        }

        public static readonly DependencyProperty SelectedSourceProperty =
            DependencyProperty.Register(nameof(SelectedSource), typeof(entityType[]), typeof(TableSelectorViewModel<entityType>));

        public entityType[] SelectedSource
        {
            get { return (entityType[])GetValue(SelectedSourceProperty); }
            set { SetValue(SelectedSourceProperty, value); }
        }
    }
}
