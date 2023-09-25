using HandyControl.Themes;
using MyTwitchTools.Models;
using MyTwitchTools.Properties;
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace MyTwitchTools.Stores
{
    public class UserThemeStore
    {
        private UserTheme _currentUserTheme;
        public UserTheme CurrentUserTheme
        {
            get => _currentUserTheme;
            set
            {
                _currentUserTheme = value;
                CurrentThemeChanged?.Invoke();
            }
        }

        public event Action CurrentThemeChanged;

        internal void SaveSettings()
        {
            Settings.Default.accentColorTheme = MediaColorToDrawingColor(CurrentUserTheme.AccentColor);
            Settings.Default.modeTheme = CurrentUserTheme.IsDarkTheme;
            Settings.Default.Save();
        }

        internal void Load()
        {
            if (CurrentUserTheme == null)
            {
                UserTheme userTheme = new UserTheme()
                {
                    AccentColor = DrawingColorToMediaColor(Settings.Default.accentColorTheme),
                    IsDarkTheme = Settings.Default.modeTheme
                };
                CurrentUserTheme = userTheme;
            }
            else
            {
                CurrentUserTheme.AccentColor = DrawingColorToMediaColor(Settings.Default.accentColorTheme);
                CurrentUserTheme.IsDarkTheme = Settings.Default.modeTheme;
            }
            ThemeManager.Current.AccentColor = new SolidColorBrush(CurrentUserTheme.AccentColor);
            ThemeManager.Current.ApplicationTheme = CurrentUserTheme.IsDarkTheme ? ApplicationTheme.Dark : ApplicationTheme.Light;
        }

        internal Color DrawingColorToMediaColor(System.Drawing.Color selectedColor)
        {
            return Color.FromArgb(
                    selectedColor.A,
                    selectedColor.R,
                    selectedColor.G,
                    selectedColor.B
                );
        }

        internal System.Drawing.Color MediaColorToDrawingColor(Color selectedColor)
        {
            return System.Drawing.Color.FromArgb(
                    selectedColor.A,
                    selectedColor.R,
                    selectedColor.G,
                    selectedColor.B
                );
        }
    }
}
