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
        public OwnerProfileViewModel OwnerProfile => ViewModel<OwnerProfileViewModel>.Get();
        public MapViewModel Map => ViewModel<MapViewModel>.Get();
        public OrderDetailsViewModel OrderDetails => ViewModel<OrderDetailsViewModel>.Get();
        public RateWasherViewModel RateWasher => ViewModel<RateWasherViewModel>.Get();
        public OwnerMenuViewModel OwnerMenu => ViewModel<OwnerMenuViewModel>.Get();
        public PastWashesViewModel PastWashes => ViewModel<PastWashesViewModel>.Get();
        public FutureWashesViewModel FutureWashes => ViewModel<FutureWashesViewModel>.Get();
        public SupportViewModel Support => ViewModel<SupportViewModel>.Get();
        public FaqViewModel Faq => ViewModel<FaqViewModel>.Get();
        public PromoCodeViewModel PromoCode => ViewModel<PromoCodeViewModel>.Get();
        public AvailabilityViewModel Availability => ViewModel<AvailabilityViewModel>.Get();
        public WasherProfileViewModel WasherProfile => ViewModel<WasherProfileViewModel>.Get();
        public WasherMenuViewModel WasherMenu => ViewModel<WasherMenuViewModel>.Get();
        public TakePictureWashingDoneViewModel TakePictureWashingDone => ViewModel<TakePictureWashingDoneViewModel>.Get();
        public EarningsViewModel Earnings => ViewModel<EarningsViewModel>.Get();
        public AcceptWashViewModel AcceptWash => ViewModel<AcceptWashViewModel>.Get();


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