using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismDemoNetSt.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        // Offenbar nicht virtual???
        // Wichtigstes Merkmal Navig... statt INavig...  !!!!
        // I prefix nur im Interface !!!

        //public virtual void OnNavigatedFrom(NavigationParameters parameters)
        //{

        //}

        //public virtual void OnNavigatedTo(NavigationParameters parameters)
        //{

        //}

        //public virtual void OnNavigatingTo(NavigationParameters parameters)
        //{

        //}

        public virtual void Destroy()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Called when the implementer has been navigated away from.
        }
        // virtual nötig für override
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            //Called before the implementor has been navigated to - but not called when using 
            // device hardware or software back buttons.
        }
    }
}
