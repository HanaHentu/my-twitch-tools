using MyTwitchTools.Commands;
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
    public class ChatViewModel : ViewModelBase
    {
        public string ExampleName => "There will be a chat!";
        public ICommand NavigateHomeCommand { get; }

        public ChatViewModel(INavigationService<HomeViewModel> homeNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}