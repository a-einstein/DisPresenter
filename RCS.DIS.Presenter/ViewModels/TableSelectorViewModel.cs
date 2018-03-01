using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RCS.DIS.Presenter.ViewModels
{
    public class TableSelectorViewModel<entityType> : SearchViewModel<entityType>
    {
        public TableSelectorViewModel(
            string filterName,
            OmschrijvingContainsNumberDelegate numberDelegate,
            OmschrijvingContainsEntitiesDelegate entitiesDelegate)
        {
            FilterName = filterName;
            NumberDelegate = numberDelegate;
            EntitiesDelegate = entitiesDelegate;

            StartMessage = "Enter part of the Omschrijving to look for.";
        }

        public static readonly DependencyProperty FilterNameProperty =
            DependencyProperty.Register(nameof(FilterName), typeof(string), typeof(TableSelectorViewModel<entityType>));

        public string FilterName
        {
            get { return (string)GetValue(FilterNameProperty); }
            set { SetValue(FilterNameProperty, value); }
        }

        public delegate int OmschrijvingContainsNumberDelegate(string SearchString);
        private OmschrijvingContainsNumberDelegate NumberDelegate;

        public delegate entityType[] OmschrijvingContainsEntitiesDelegate(string SearchString);
        private OmschrijvingContainsEntitiesDelegate EntitiesDelegate;

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

        public override void Search()
        {
            base.Search();

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
