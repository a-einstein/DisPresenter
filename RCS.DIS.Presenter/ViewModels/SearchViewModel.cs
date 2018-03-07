using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RCS.DIS.Presenter.ViewModels
{
    public abstract class SearchViewModel<entityType> : DependencyObject
    {
        protected SearchViewModel()
        {
            // TODO add enablement.
            // TODO Would like to assign as default.
            SearchCommand = new DelegateCommand(Search);
        }

        public static readonly DependencyProperty GridColumnsProperty =
            DependencyProperty.Register(nameof(GridColumns), typeof(ObservableCollection<DataGridColumn>), typeof(TableSelectorViewModel<entityType>));

        public ObservableCollection<DataGridColumn> GridColumns
        {
            get { return (ObservableCollection<DataGridColumn>)GetValue(GridColumnsProperty); }
            set { SetValue(GridColumnsProperty, value); }
        }

        public static readonly DependencyProperty SearchCommandProperty =
             DependencyProperty.Register(nameof(SearchCommand), typeof(ICommand), typeof(TableSelectorViewModel<entityType>));

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        protected int maximumRecords = 200;

        public void Search()
        {
            Entities = null;
            ResultMessage = null;

            try
            {
                Retrieve();
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        protected abstract void Retrieve();

        void HandleException(Exception exception)
        {
            const string applicationName = "DIS Presenter";

            // Pity the No button cannot be made default.
            var result = MessageBox.Show($"There is a problem using our data service.\n\nDo you want the see the details?", $"{applicationName} - Error", MessageBoxButton.YesNo, MessageBoxImage.Error);

            if (result == MessageBoxResult.Yes)
                MessageBox.Show(exception.Message, $"{applicationName} - Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static readonly DependencyProperty EntitiesProperty =
            DependencyProperty.Register(nameof(Entities), typeof(entityType[]), typeof(TableSelectorViewModel<entityType>));

        public entityType[] Entities
        {
            get { return (entityType[])GetValue(EntitiesProperty); }
            set { SetValue(EntitiesProperty, value); }
        }

        public static readonly DependencyProperty StartMessageProperty =
            DependencyProperty.Register(nameof(StartMessage), typeof(string), typeof(TableSelectorViewModel<entityType>));

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
    }
}
