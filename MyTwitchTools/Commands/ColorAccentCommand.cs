using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;
using System.Windows;
using System.Windows.Media;

namespace MyTwitchTools.Commands
{
    public class ColorAccentCommand : CommandBase
    {
        private readonly SettingsViewModel _viewModel;
        private readonly UserThemeStore _userThemeStore;

        public ColorAccentCommand(UserThemeStore userThemeStore, SettingsViewModel viewModel)
        {
            _userThemeStore = userThemeStore;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ColorPicker picker = SingleOpenHelper.CreateControl<ColorPicker>();
            picker.SelectedBrush = new SolidColorBrush(_userThemeStore.CurrentUserTheme.AccentColor);
            PopupWindow window = new PopupWindow
            {
                PopupElement = picker,
                BorderThickness = new Thickness(0),
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                MinWidth = 0,
                MinHeight = 0,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Select Accent Color"
            };
            picker.SelectedColorChanged += delegate (object sender, FunctionEventArgs<Color> e)
            {
                ThemeManager.Current.AccentColor = new SolidColorBrush(e.Info);
                _userThemeStore.CurrentUserTheme.AccentColor = e.Info;
                _viewModel.OnCurrentThemeChanged();
            };
            picker.Confirmed += delegate
            {
                _userThemeStore.SaveSettings();
                window.Close();
            };
            picker.Canceled += delegate
            {
                _userThemeStore.Load();
                _viewModel.OnCurrentThemeChanged();
                window.Close();
            };
            window.Show();
        }
    }
}
