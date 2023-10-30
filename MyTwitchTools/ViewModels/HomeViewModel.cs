using MyTwitchTools.Commands;
using MyTwitchTools.Services;
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
