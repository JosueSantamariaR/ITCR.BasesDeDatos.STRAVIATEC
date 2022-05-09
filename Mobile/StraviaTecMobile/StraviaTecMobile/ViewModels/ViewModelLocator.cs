using System;
using System.Collections.Generic;
using System.Text;
using StraviaTecMobile.Services;
using TinyIoC;

namespace StraviaTecMobile.ViewModels
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;
        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();
            
            _container.Register<LoginPageViewModel>();
            _container.Register<SignUpPageViewModel>();

            _container.Register<INavigationService, NavigationService>();
        }
        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
