using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RCS.DIS.Presenter.BaseClasses
{
    public abstract class EntitiesSearchViewModel<entityType> : SearchViewModel
    {
        protected EntitiesSearchViewModel()
        {
            GridColumns = GetGridColumns();
        }

        public static readonly DependencyProperty GridColumnsProperty =
            DependencyProperty.Register(nameof(GridColumns), typeof(ObservableCollection<DataGridColumn>), typeof(EntitiesSearchViewModel<entityType>));

        public ObservableCollection<DataGridColumn> GridColumns
        {
            get { return (ObservableCollection<DataGridColumn>)GetValue(GridColumnsProperty); }
            set { SetValue(GridColumnsProperty, value); }
        }

        protected abstract ObservableCollection<DataGridColumn> GetGridColumns();

        protected int maximumRecords = 200;

        // TODO Need enablement for required keys.
        // TODO Handle empty keys as far as useful.
        public override async Task Search()
        {
            ResultMessage = null;
            Entities = null;

            await base.Search();
        }

        public static readonly DependencyProperty EntitiesProperty =
            DependencyProperty.Register(nameof(Entities), typeof(entityType[]), typeof(EntitiesSearchViewModel<entityType>));

        public entityType[] Entities
        {
            get { return (entityType[])GetValue(EntitiesProperty); }
            set
            {
                SetValue(EntitiesProperty, value);

                // TODO Why is this just needed for this property?
                RaisePropertyChanged(nameof(Entities));
            }
        }

        public static readonly DependencyProperty StartMessageProperty =
            DependencyProperty.Register(nameof(StartMessage), typeof(string), typeof(EntitiesSearchViewModel<entityType>));

        public string StartMessage
        {
            get { return (string)GetValue(StartMessageProperty); }
            set { SetValue(StartMessageProperty, value); }
        }

        public static readonly DependencyProperty ResultMessageProperty =
            DependencyProperty.Register(nameof(ResultMessage), typeof(string), typeof(EntitiesSearchViewModel<entityType>));

        public string ResultMessage
        {
            get { return (string)GetValue(ResultMessageProperty); }
            set { SetValue(ResultMessageProperty, value); }
        }
    }
}
