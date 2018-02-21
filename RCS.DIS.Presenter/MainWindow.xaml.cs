﻿using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RCS.DIS.Presenter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            var retrieveServiceClient = new RetrieveServiceClient();

            Versies = retrieveServiceClient.Versies();

            SetDiagnosesView(retrieveServiceClient);
        }

        #region Versies
        public static readonly DependencyProperty VersiesProperty =
            DependencyProperty.Register(nameof(Versies), typeof(string[]), typeof(MainWindow));

        public string[] Versies
        {
            get { return (string[])GetValue(VersiesProperty); }
            set { SetValue(VersiesProperty, value); }
        }

        public static readonly DependencyProperty VersieSelectedProperty =
            DependencyProperty.Register(nameof(VersieSelected), typeof(string), typeof(MainWindow));

        public string VersieSelected
        {
            get { return (string)GetValue(VersieSelectedProperty); }
            set { SetValue(VersieSelectedProperty, value); }
        }
        #endregion

        #region Diagnoses
        private void SetDiagnosesView(RetrieveServiceClient retrieveServiceClient)
        {
            var tableSelectorViewModel = new TableSelectorViewModel<Diagnose>
                (retrieveServiceClient.DiagnoseOmschrijvingContainsNumber, retrieveServiceClient.DiagnoseOmschrijvingContainsEntities)
                { SelectorGridColumns = DiagnoseGridColumns(), FilterGridColumns = DiagnoseGridColumns() };

            (DiagnosesTab.Content as TableSelectorView).DataContext = tableSelectorViewModel;
            DiagnoseFilterArea.DataContext = tableSelectorViewModel;
        }

        ObservableCollection<DataGridColumn> DiagnoseGridColumns()
        {
            var columns = new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn() { Binding= new Binding("DiagnoseCode"), Header="Diagnose" },
                new DataGridTextColumn() { Binding= new Binding("SpecialismeCode"), Header="Specialisme" },
                new DataGridTextColumn() { Binding= new Binding("Omschrijving"), Header="Omschrijving" },
                new DataGridTextColumn() { Binding= new Binding("Peildatum"), Header="Peildatum"},
                new DataGridTextColumn() { Binding= new Binding("Bestandsdatum"), Header="Bestandsdatum" },
                new DataGridTextColumn() { Binding= new Binding("Versie"), Header="Versie" }
            };

            return columns;
        }
        #endregion
    }
}
