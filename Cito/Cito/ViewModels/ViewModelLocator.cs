using System;
using System.Collections.Generic;
using System.Xml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
        }

        public MainViewModel Main => ViewModel<MainViewModel>.Get();
        public OwnerProfileViewModel Owner => ViewModel<OwnerProfileViewModel>.Get();


        public static void Cleanup()
        {
        }
    }

    public class ViewModel<T> where T : ViewModelBase
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