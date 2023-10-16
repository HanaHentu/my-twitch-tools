using HandyControl.Controls;
using MyTwitchTools.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly DialogNavigationStore _dialogNavigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentDialogViewModel => _dialogNavigationStore.CurrentViewModel;
        public bool IsDialogOpen => _dialogNavigationStore.IsOpen;

        public MainViewModel(NavigationStore navigationStore, DialogNavigationStore dialogNavigationStore)
        {
            _navigationStore = navigationStore;
            _dialogNavigationStore = dialogNavigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _dialogNavigationStore.CurrentViewModelChanged += OnCurrentDialogViewModelChanged;
        }

        private void OnCurrentDialogViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentDialogViewModel));
            OnPropertyChanged(nameof(IsDialogOpen));

            if (IsDialogOpen)
                Dialog.Show(CurrentDialogViewModel, "DialogContainer");
            else
                Dialog.Close("DialogContainer");
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
