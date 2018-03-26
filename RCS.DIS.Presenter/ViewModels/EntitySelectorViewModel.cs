using RCS.DIS.Presenter.BaseClasses;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RCS.DIS.Presenter.ViewModels
{
    abstract public class EntitySelectorViewModel<entityType> : EntitiesSearchViewModel<entityType>
    {
        public EntitySelectorViewModel()
        {
            StartMessage = "Enter parts of the Omschrijving to look for, separated by spaces.\nEnclose parts containing spaces by double quotes.";

            // Note the same collection cannot be shared.
            FilterGridColumns = GetGridColumns();
        }

        public static readonly DependencyProperty FilterNameProperty =
            DependencyProperty.Register(nameof(FilterName), typeof(string), typeof(EntitySelectorViewModel<entityType>));

        public string FilterName
        {
            get { return (string)GetValue(FilterNameProperty); }
            set { SetValue(FilterNameProperty, value); }
        }

        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register(nameof(Note), typeof(string), typeof(EntitySelectorViewModel<entityType>));

        public string Note
        {
            get { return (string)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        public delegate Task<int> OmschrijvingContainsNumberDelegate(string SearchString);
        abstract protected OmschrijvingContainsNumberDelegate NumberDelegate { get; }

        public delegate Task<entityType[]> OmschrijvingContainsEntitiesDelegate(string SearchString);
        abstract protected OmschrijvingContainsEntitiesDelegate EntitiesDelegate { get; }

        public static readonly DependencyProperty FilterGridColumnsProperty =
            DependencyProperty.Register(nameof(FilterGridColumns), typeof(ObservableCollection<DataGridColumn>), typeof(EntitySelectorViewModel<entityType>));

        /// <summary>
        /// Note the columns cannot be shared. Set 2 seprate but equal collections.
        /// </summary>
        public ObservableCollection<DataGridColumn> FilterGridColumns
        {
            get { return (ObservableCollection<DataGridColumn>)GetValue(FilterGridColumnsProperty); }
            set { SetValue(FilterGridColumnsProperty, value); }
        }

        public static readonly DependencyProperty SearchStringProperty =
            DependencyProperty.Register(nameof(SearchString), typeof(string), typeof(EntitySelectorViewModel<entityType>), new PropertyMetadata(new PropertyChangedCallback(OnSearchStringChanged)));

        public string SearchString
        {
            get { return (string)GetValue(SearchStringProperty); }
            set { SetValue(SearchStringProperty, value); }
        }

        private static void OnSearchStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Note this did not work in the setter itself as DependencyProperty nor by explicitly call.
            (d as EntitySelectorViewModel<entityType>).SearchCommand.RaiseCanExecuteChanged();
        }

        protected override bool SearchEnabled()
        {
            return
                base.SearchEnabled() &&

                !string.IsNullOrEmpty(SearchString);
        }

        protected override async Task Retrieve()
        {
            var number = await NumberDelegate(SearchString);

            ResultMessage = $"Found {number}.";

            if (number == 0 || number > maximumRecords)
                ResultMessage = $"{ResultMessage}\nPlease refine your query.";
            else
            {
                ResultMessage = $"{ResultMessage}\nPlease select an entry, it will be added to the Filter tab.";

                Entities = await EntitiesDelegate(SearchString);
            }
        }

        public static readonly DependencyProperty OpenEntitiesCommandProperty =
            DependencyProperty.Register(nameof(OpenEntitiesCommand), typeof(ICommand), typeof(EntitySelectorViewModel<entityType>));

        public ICommand OpenEntitiesCommand
        {
            get { return (ICommand)GetValue(OpenEntitiesCommandProperty); }
            set { SetValue(OpenEntitiesCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register(nameof(Selected), typeof(entityType), typeof(EntitySelectorViewModel<entityType>), new PropertyMetadata(new PropertyChangedCallback(OnSelectedChanged)));

        public entityType Selected
        {
            get { return (entityType)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = d as EntitySelectorViewModel<entityType>;

            // TODO Does this need to be repeated at every change?
            viewModel.SelectedSource = new entityType[] { viewModel.Selected };

            // Note this did not work in the setter itself as DependencyProperty nor by explicitly call.
            viewModel.RaisePropertyChanged(nameof(Selected));
        }

        public static readonly DependencyProperty SelectedSourceProperty =
            DependencyProperty.Register(nameof(SelectedSource), typeof(entityType[]), typeof(EntitySelectorViewModel<entityType>));

        public entityType[] SelectedSource
        {
            get { return (entityType[])GetValue(SelectedSourceProperty); }
            set { SetValue(SelectedSourceProperty, value); }
        }
    }
}
