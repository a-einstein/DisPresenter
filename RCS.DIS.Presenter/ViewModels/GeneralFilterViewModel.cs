using RCS.DIS.Presenter.BaseClasses;
using System.Threading.Tasks;
using System.Windows;

namespace RCS.DIS.Presenter.ViewModels
{
    public class GeneralFilterViewModel : SearchViewModel
    {
        public override async void Initialize()
        {
            // Prevent repeated calls when ViewModel is shared.
            if (!initialized)
                // Because method is async it does not block the application to complete full graphical start.
                await Search();

            // Note this might not be reached because of a previous exception, in particular CommunicationException.
            base.Initialize();
        }

        protected override async Task Retrieve()
        {
            // Unconditionally fill option lists.
            Jaren = await retrieveServiceClient.JarenAsync();
            Versies = await retrieveServiceClient.VersiesAsync();
        }

        #region Jaren
        public static readonly DependencyProperty JarenProperty =
            DependencyProperty.Register(nameof(Jaren), typeof(short[]), typeof(GeneralFilterViewModel));

        public short[] Jaren
        {
            get { return (short[])GetValue(JarenProperty); }
            set
            {
                SetValue(JarenProperty, value);

                // TODO Why is this just needed for this property?
                RaisePropertyChanged(nameof(Versies));
            }
        }

        public static readonly DependencyProperty JaarSelectedProperty =
            DependencyProperty.Register(nameof(JaarSelected), typeof(short), typeof(GeneralFilterViewModel));

        public short JaarSelected
        {
            get { return (short)GetValue(JaarSelectedProperty); }
            set { SetValue(JaarSelectedProperty, value); }
        }
        #endregion

        #region Versies
        public static readonly DependencyProperty VersiesProperty =
            DependencyProperty.Register(nameof(Versies), typeof(string[]), typeof(GeneralFilterViewModel));

        public string[] Versies
        {
            get { return (string[])GetValue(VersiesProperty); }
            set
            {
                SetValue(VersiesProperty, value);

                // TODO Why is this just needed for this property?
                RaisePropertyChanged(nameof(Versies));
            }
        }

        public static readonly DependencyProperty VersieSelectedProperty =
            DependencyProperty.Register(nameof(VersieSelected), typeof(string), typeof(GeneralFilterViewModel));

        public string VersieSelected
        {
            get { return (string)GetValue(VersieSelectedProperty); }
            set { SetValue(VersieSelectedProperty, value); }
        }
        #endregion
    }
}
