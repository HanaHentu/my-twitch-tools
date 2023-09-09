using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.Services
{
    // To support multiple parameters, create an object to hold all the parameters and use that
    // object as the TParameter type
    public class ParameterNavigationService<TParameter, TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}
