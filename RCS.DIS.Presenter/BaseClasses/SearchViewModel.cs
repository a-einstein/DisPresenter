using Prism.Commands;
using RCS.DIS.Presenter.RetrieveService.ServiceReference;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RCS.DIS.Presenter.BaseClasses
{
    public abstract class SearchViewModel : ViewModel
    {
        protected SearchViewModel()
        {
            // TODO add enablement.
            // TODO Would like to assign as default.
            SearchCommand = new DelegateCommand(async () => await Search());
        }

        static protected RetrieveServiceClient retrieveServiceClient = new RetrieveServiceClient();

        private static void CheckService()
        {
            // TODO This works when starting up without an active service, but it fails when interrupted with "unsecured or incorrectly secured fault was received from the other party".
            if (retrieveServiceClient.State == CommunicationState.Faulted)
            {
                retrieveServiceClient.Abort();

                // There seems to be no other way to recover.
                retrieveServiceClient = new RetrieveServiceClient();
            }
        }

        public static readonly DependencyProperty SearchCommandProperty =
             DependencyProperty.Register(nameof(SearchCommand), typeof(ICommand), typeof(SearchViewModel));

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
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
