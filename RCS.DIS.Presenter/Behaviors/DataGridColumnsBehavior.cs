using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace RCS.DIS.Presenter.Behaviors
{
    //https://stackoverflow.com/questions/320089/how-do-i-bind-a-wpf-datagrid-to-a-variable-number-of-columns

    public class DataGridColumnsBehavior : Behavior<DataGrid>
    {
        public static readonly DependencyProperty BindableColumnsProperty =
            DependencyProperty.RegisterAttached("BindableColumns",
                                                typeof(ObservableCollection<DataGridColumn>),
                                                typeof(DataGridColumnsBehavior),
                                                new UIPropertyMetadata(null, BindableColumnsPropertyChanged));

        /// <summary>
        /// Collection to store collection change handlers - to be able to unsubscribe later.
        /// </summary>
        private static readonly Dictionary<DataGrid, NotifyCollectionChangedEventHandler> collectionChangedHandlers;

        static DataGridColumnsBehavior()
        {
            collectionChangedHandlers = new Dictionary<DataGrid, NotifyCollectionChangedEventHandler>();
        }

        private static void BindableColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = source as DataGrid;

            ObservableCollection<DataGridColumn> oldColumns = e.OldValue as ObservableCollection<DataGridColumn>;

            if (oldColumns != null)
            {
                // Remove all columns.
                dataGrid.Columns.Clear();

                // Unsubscribe from old collection.
                NotifyCollectionChangedEventHandler handler;

                if (collectionChangedHandlers.TryGetValue(dataGrid, out handler))
                {
                    oldColumns.CollectionChanged -= handler;
                    collectionChangedHandlers.Remove(dataGrid);
                }
            }

            ObservableCollection<DataGridColumn> newColumns = e.NewValue as ObservableCollection<DataGridColumn>;

            dataGrid.Columns.Clear();

            if (newColumns != null)
            {
                // Add columns from this source.
                foreach (DataGridColumn column in newColumns)
                    dataGrid.Columns.Add(column);

                // Subscribe to future changes.
                NotifyCollectionChangedEventHandler handler = (_, eventArgs) => OnCollectionChanged(eventArgs, dataGrid);
                collectionChangedHandlers[dataGrid] = handler;
                newColumns.CollectionChanged += handler;
            }
        }

        static void OnCollectionChanged(NotifyCollectionChangedEventArgs eventArgs, DataGrid dataGrid)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    dataGrid.Columns.Clear();
                    foreach (DataGridColumn column in eventArgs.NewItems)
                        dataGrid.Columns.Add(column);
                    break;

                case NotifyCollectionChangedAction.Add:
                    foreach (DataGridColumn column in eventArgs.NewItems)
                        dataGrid.Columns.Add(column);
                    break;

                case NotifyCollectionChangedAction.Move:
                    dataGrid.Columns.Move(eventArgs.OldStartingIndex, eventArgs.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (DataGridColumn column in eventArgs.OldItems)
                        dataGrid.Columns.Remove(column);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    dataGrid.Columns[eventArgs.NewStartingIndex] = eventArgs.NewItems[0] as DataGridColumn;
                    break;
            }
        }

        public static void SetBindableColumns(DependencyObject element, ObservableCollection<DataGridColumn> value)
        {
            element.SetValue(BindableColumnsProperty, value);
        }

        public static ObservableCollection<DataGridColumn> GetBindableColumns(DependencyObject dataGrid)
        {
            return (ObservableCollection<DataGridColumn>)dataGrid.GetValue(BindableColumnsProperty);
        }
    }
}
