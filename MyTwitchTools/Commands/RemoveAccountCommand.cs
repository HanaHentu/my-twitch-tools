using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;

namespace MyTwitchTools.Commands
{
    public class RemoveAccountCommand : CommandBase
    {
        private readonly AccountsListingViewModel _viewModel;
        private readonly AccountsStore _accountsStore;

        public RemoveAccountCommand(AccountsListingViewModel viewModel, AccountsStore accountsStore)
        {
            _viewModel = viewModel;
            _accountsStore = accountsStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedAccount != null)
            {
                _accountsStore.Remove(_viewModel.SelectedAccount);
                _viewModel.SelectedAccount = null;
            }
        }
    }
}
