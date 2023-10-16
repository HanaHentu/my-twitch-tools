using MyTwitchTools.Commands;
using MyTwitchTools.Models;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTwitchTools.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => $"Welcome to my application.";

        public ICommand NavigateChatCommand { get; }


        public HomeViewModel(INavigationService chatNavigationService)
        {

            NavigateChatCommand = new NavigateCommand(chatNavigationService);
        }
    }
}
