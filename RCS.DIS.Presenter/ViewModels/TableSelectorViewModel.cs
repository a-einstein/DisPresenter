using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace RCS.DIS.Presenter.ViewModels
{
    public class TableSelectorViewModel<entityType> : DependencyObject
    {
        public delegate int OmschrijvingContainsNumberDelegate(string SearchString);
        public delegate entityType[] OmschrijvingContainsEntitiesDelegate(string SearchString);

        public TableSelectorViewModel(
            string entityName,
            OmschrijvingContainsNumberDelegate numberDelegate,
            OmschrijvingContainsEntitiesDelegate entitiesDelegate)
        {
            EntityName = entityName;
            NumberDelegate = numberDelegate;
            EntitiesDelegate = entitiesDelegate;

            // TODO add enablement.
            SearchCommand = new DelegateCommand(Search);
            OpenEntitiesCommand = new DelegateCommand(OpenEntities);
        }

        public static readonly DependencyProperty EntityNameProperty =
            DependencyProperty.Register(nameof(EntityName), typeof(string), typeof(TableSelectorViewModel<entityType>));

        public string EntityName
        {
            get { return (string)GetValue(EntityNameProperty); }
            set { SetValue(EntityNameProperty, value); }
        }

        private OmschrijvingContainsNumberDelegate NumberDelegate;
        private OmschrijvingContainsEntitiesDelegate EntitiesDelegate;

        public static readonly DependencyProperty SelectorGridColumnsProperty =
            DependencyProperty.Register(nameof(SelectorGridColumns), typeof(ObservableCollection<DataGridColumn>), typeof(TableSelectorViewModel<entityType>));

        /// <summary>
        /// Note the columns cannot be shared. Set 2 equal collections.
        /// </summary>
        public ObservableCollection<DataGridColumn> SelectorGridColumns
        {
            get { return (ObservableCollection<DataGridColumn>)GetValue(SelectorGridColumnsProperty); }
            set { SetValue(SelectorGridColumnsProperty, value); }
        }

        public static readonly DependencyProperty FilterGridColumnsProperty =
            DependencyProperty.Register(nameof(FilterGridColumns), typeof(ObservableCollection<DataGridColumn>), typeof(TableSelectorViewModel<entityType>));

        /// <summary>
        /// Note the columns cannot be shared. Set 2 equal collections.
        /// </summary>
        public ObservableCollection<DataGridColumn> FilterGridColumns
        {
            get { return (ObservableCollection<DataGridColumn>)GetValue(FilterGridColumnsProperty); }
            set { SetValue(FilterGridColumnsProperty, value); }
        }

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
            StartMessage = null;

            Entities = null;

            const int maximumRecords = 200;
            var number = NumberDelegate(SearchString);

            if (number == 0 || number > maximumRecords)
                ResultMessage = $"Found {number}. Please refine your query.";
            else
            {
                ResultMessage = $"Found {number}. Please select a diagnose, it will be added to the Filter tab.";

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

        public static readonly DependencyProperty StartMessageProperty =
            DependencyProperty.Register(nameof(StartMessage), typeof(string), typeof(TableSelectorViewModel<entityType>), new PropertyMetadata("Enter part of the omschrijving to look for."));

        public string StartMessage
        {
            get { return (string)GetValue(StartMessageProperty); }
            set { SetValue(StartMessageProperty, value); }
        }

        public static readonly DependencyProperty ResultMessageProperty =
            DependencyProperty.Register(nameof(ResultMessage), typeof(string), typeof(TableSelectorViewModel<entityType>));

        public string ResultMessage
        {
            get { return (string)GetValue(ResultMessageProperty); }
            set { SetValue(ResultMessageProperty, value); }
        }

        public static readonly DependencyProperty EntitiesProperty =
            DependencyProperty.Register(nameof(Entities), typeof(entityType[]), typeof(TableSelectorViewModel<entityType>));

        public entityType[] Entities
        {
            get { return (entityType[])GetValue(EntitiesProperty); }
            set { SetValue(EntitiesProperty, value); }
        }

        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register(nameof(Selected), typeof(entityType), typeof(TableSelectorViewModel<entityType>), new PropertyMetadata(new PropertyChangedCallback(SetSelectedSource)));

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
