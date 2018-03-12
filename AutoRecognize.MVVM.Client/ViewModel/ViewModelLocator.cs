/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:AutoRecognize.MVVM.Client.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using AutoRecognize.MVVM.Client.Model;

namespace AutoRecognize.MVVM.Client.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FlipLoginViewModel>();
            SimpleIoc.Default.Register<LoginControlVModel>();
            SimpleIoc.Default.Register<AdminControlVModel>();

            SimpleIoc.Default.Register<BothWayBindViewModel>();
            SimpleIoc.Default.Register<PackagedValidateViewModel>();

            SimpleIoc.Default.Register<CommandViewModel>();

        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public FlipLoginViewModel FlipLogin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FlipLoginViewModel>();
            }
        }
        public LoginControlVModel LoginControl
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginControlVModel>();
            }
        }
        public AdminControlVModel AdminControl
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdminControlVModel>();
            }
        }

        public BothWayBindViewModel BothWayBind
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BothWayBindViewModel>();
            }
        }
        public PackagedValidateViewModel PackagedValidate
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PackagedValidateViewModel>();
            }
        }
        public CommandViewModel Command
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommandViewModel>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            
        }
    }
}