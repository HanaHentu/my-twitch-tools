﻿using HandyControl.Controls;
using HandyControl.Tools.Command;
using MyTwitchTools.Commands;
using MyTwitchTools.Properties;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MyTwitchTools.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly UserThemeStore _userThemeStore;
        public Brush SideBrushColor => new SolidColorBrush(_userThemeStore?.AccentColor ?? Colors.DodgerBlue);
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateChatCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        public NavigationBarViewModel(AccountStore accountStore,
            UserThemeStore userThemeStore,
            INavigationService homeNavigationService,
            INavigationService chatNavigationService,
            INavigationService loginNavigationService,
            INavigationService settingsNavigationService)
        {
            _accountStore = accountStore;
            _userThemeStore = userThemeStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateChatCommand = new NavigateCommand(chatNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigateSettingsCommand = new NavigateCommand(settingsNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
            _userThemeStore.CurrentThemeChanged += OnCurrentThemeChanged;
        }

        private void OnCurrentThemeChanged()
        {
            OnPropertyChanged(nameof(SideBrushColor));
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            _userThemeStore.CurrentThemeChanged -= OnCurrentThemeChanged;

            base.Dispose();
        }
    }
}