using Prism.Commands;
using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace RCS.DIS.Presenter.BaseClasses
{
    public abstract class SearchViewModel : ViewModel
    {
        protected SearchViewModel()
        {
            // TODO Would like to assign as default.
            SearchCommand = new DelegateCommand(async () => await Search(), SearchEnabled);
        }

        static protected RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();

        private void CheckService()
        {
            // TODO This works when starting up without an active service, but it fails when interrupted with "unsecured or incorrectly secured fault was received from the other party".
            if (retrieveServiceClient.State == CommunicationState.Faulted)
            {
                retrieveServiceClient.Abort();

                // There seems to be no other way to recover.
                retrieveServiceClient = new RetrieveServiceClient();

                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        protected virtual bool SearchEnabled()
        {
            return retrieveServiceClient?.State != CommunicationState.Faulted;
        }

        public static readonly DependencyProperty SearchCommandProperty =
             DependencyProperty.Register(nameof(SearchCommand), typeof(DelegateCommand), typeof(SearchViewModel));

        public DelegateCommand SearchCommand
        {
            get { return (DelegateCommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public virtual async Task Search()
        {
            CheckService();

            await Retrieve();
        }

        protected abstract Task Retrieve();
    }
}
