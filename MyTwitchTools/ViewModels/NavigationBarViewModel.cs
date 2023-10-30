using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System.Windows.Input;
using System.Windows.Media;

namespace MyTwitchTools.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly UserThemeStore _userThemeStore;
        public Brush SideBrushColor => new SolidColorBrush(_userThemeStore?.AccentColor ?? Colors.DodgerBlue);
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountsListingCommand { get; }
        public ICommand NavigateChatCommand { get; }
        public ICommand NavigateSettingsCommand { get; }

        public NavigationBarViewModel(UserThemeStore userThemeStore,
            INavigationService homeNavigationService,
            INavigationService accountsListingNavigationService,
            INavigationService chatNavigationService,
            INavigationService settingsNavigationService)
        {
            _userThemeStore = userThemeStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountsListingCommand = new NavigateCommand(accountsListingNavigationService);
            NavigateChatCommand = new NavigateCommand(chatNavigationService);
            NavigateSettingsCommand = new NavigateCommand(settingsNavigationService);

            _userThemeStore.CurrentThemeChanged += OnCurrentThemeChanged;
        }

        private void OnCurrentThemeChanged()
        {
            OnPropertyChanged(nameof(SideBrushColor));
        }

        public override void Dispose()
        {
            _userThemeStore.CurrentThemeChanged -= OnCurrentThemeChanged;

            base.Dispose();
        }
    }
}