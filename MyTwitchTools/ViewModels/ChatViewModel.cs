using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using System.Windows.Input;

namespace MyTwitchTools.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public string ExampleName => "There will be a chat!";
        public ICommand NavigateHomeCommand { get; }

        public ChatViewModel(INavigationService homeNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }
    }
}