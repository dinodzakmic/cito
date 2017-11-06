using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Cito.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }
        
        public PreloginViewModel Prelogin => ViewModel<PreloginViewModel>.Get();
        public UserTypeViewModel UserType => ViewModel<UserTypeViewModel>.Get();
        public CreateAccountViewModel CreateAccount => ViewModel<CreateAccountViewModel>.Get();
        public OwnerMenuViewModel OwnerMenu => ViewModel<OwnerMenuViewModel>.Get();
        
        public RateWasherViewModel RateWasherVM => ViewModel<RateWasherViewModel>.Get();

        public OrderDetailsViewModel OrderDetailsVM => ViewModel<OrderDetailsViewModel>.Get();

        public FaqViewModel FaqVM => ViewModel<FaqViewModel>.Get();

        public static void Cleanup()
        {
        }

    }

    public class ViewModel<T> where T : CitoViewModelBase
    {
        public static T Get()
        {
            if (!SimpleIoc.Default.IsRegistered<T>())
            {
                SimpleIoc.Default.Register<T>();
            }
            return ServiceLocator.Current.GetInstance<T>();
        }
    }


}