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
        public Brush BackgroundColor => new SolidColorBrush(_userThemeStore.CurrentUserTheme?.AccentColor ?? Colors.DodgerBlue);
        public ICommand ColorAccentCommand { get; }

        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get
            {
                _isDarkTheme = _userThemeStore.CurrentUserTheme?.IsDarkTheme ?? false;
                return _isDarkTheme;
            }
            set
            {
                if (_userThemeStore.CurrentUserTheme != null)
                {
                    _userThemeStore.CurrentUserTheme.IsDarkTheme = _isDarkTheme = value;
                }
                else _isDarkTheme = value;
            }
        }
        public string SelectedTheme
        {
            get => IsDarkTheme ? "Dark" : "Light";
            set
            {
                _userThemeStore.CurrentUserTheme.IsDarkTheme = IsDarkTheme = value == "Dark";
                ThemeManager.Current.ApplicationTheme = _userThemeStore.CurrentUserTheme.IsDarkTheme ? ApplicationTheme.Dark : ApplicationTheme.Light;
                _userThemeStore.SaveSettings();
            }
        }

        public SettingsViewModel(UserThemeStore userThemeStore)
        {
            _userThemeStore = userThemeStore;
            ColorAccentCommand = new ColorAccentCommand(userThemeStore, this);
            _userThemeStore.CurrentThemeChanged += OnCurrentThemeChanged;
        }

        public void OnCurrentThemeChanged()
        {
            OnPropertyChanged(nameof(BackgroundColor));
            OnPropertyChanged(nameof(IsDarkTheme));
            OnPropertyChanged(nameof(SelectedTheme));
        }

        public override void Dispose()
        {
            _userThemeStore.CurrentThemeChanged -= OnCurrentThemeChanged;

            base.Dispose();
        }
    }
}
