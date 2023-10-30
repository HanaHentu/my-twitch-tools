using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;
using System;

namespace MyTwitchTools.Services
{
    public class DialogNavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        private readonly DialogNavigationStore _dialogNavigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public DialogNavigationService(DialogNavigationStore dialogNavigationStore, Func<TViewModel> createViewModel)
        {
            _dialogNavigationStore = dialogNavigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _dialogNavigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
