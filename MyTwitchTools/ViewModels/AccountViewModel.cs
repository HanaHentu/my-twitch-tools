using MyTwitchTools.Models;

namespace MyTwitchTools.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public Account Account { get; }

        public AccountViewModel(Account account)
        {
            Account = account;
        }
    }
}
