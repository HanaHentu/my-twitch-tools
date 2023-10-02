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
        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get
            {
                return _isDarkMode;
            }
            set
            {
                _isDarkMode = value;
                CurrentThemeChanged?.Invoke();
            }
        }
        private Color _accentColor;
        public Color AccentColor
        {
            get
            {
                return _accentColor;
            }
            set
            {
                _accentColor = value;
                CurrentThemeChanged?.Invoke();
            }
        }

        public event Action CurrentThemeChanged;

        internal void SaveSettings()
        {
            Settings.Default.accentColorTheme = MediaColorToDrawingColor(AccentColor);
            Settings.Default.modeTheme = IsDarkMode;
            Settings.Default.Save();
            Load();
        }

        internal void Load()
        {
            IsDarkMode = Settings.Default.modeTheme;
            AccentColor = DrawingColorToMediaColor(Settings.Default.accentColorTheme);
            ThemeManager.Current.AccentColor = new SolidColorBrush(AccentColor);
            ThemeManager.Current.ApplicationTheme = IsDarkMode ? ApplicationTheme.Dark : ApplicationTheme.Light;
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
