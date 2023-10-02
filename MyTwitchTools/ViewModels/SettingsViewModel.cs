using HandyControl.Themes;
using MyTwitchTools.Commands;
using MyTwitchTools.Stores;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace MyTwitchTools.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly UserThemeStore _userThemeStore;
        public List<string> ThemeOptions { get; } = new List<string> { "Light", "Dark" };
        public Brush BackgroundColor => new SolidColorBrush(_userThemeStore?.AccentColor ?? Colors.DodgerBlue);
        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get
            {
                _isDarkTheme = _userThemeStore.IsDarkMode;
                return _isDarkTheme;
            }
            set
            {                
                _userThemeStore.IsDarkMode = _isDarkTheme = value;
            }
        }
        public string SelectedTheme
        {
            get => IsDarkTheme ? "Dark" : "Light";
            set
            {
                _userThemeStore.IsDarkMode = IsDarkTheme = value == "Dark";
                _userThemeStore.SaveSettings();
            }
        }

        public ICommand ColorAccentCommand { get; }

        public SettingsViewModel(UserThemeStore userThemeStore)
        {
            _userThemeStore = userThemeStore;
            ColorAccentCommand = new ColorAccentCommand(userThemeStore);
            _userThemeStore.CurrentThemeChanged += OnCurrentThemeChanged;
        }

        public void OnCurrentThemeChanged()
        {
            OnPropertyChanged(nameof(IsDarkTheme));
            OnPropertyChanged(nameof(BackgroundColor));
        }

        public override void Dispose()
        {
            _userThemeStore.CurrentThemeChanged -= OnCurrentThemeChanged;

            base.Dispose();
        }
    }
}
