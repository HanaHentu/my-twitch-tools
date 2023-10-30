using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;

namespace MyTwitchTools.Commands
{
    public class ToggleAccountStateCommand : CommandBase
    {
        private readonly AccountsListingViewModel _viewModel;
        private readonly AccountsStore _accountsStore;

        public ToggleAccountStateCommand(AccountsListingViewModel viewModel, AccountsStore accountsStore)
        {
            _viewModel = viewModel;
            _accountsStore = accountsStore;

            _viewModel.PropertyChanged += (sender, args) => OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter) => _viewModel.SelectedAccount != null;

        public override void Execute(object parameter)
        {
            _accountsStore.ToggleAccountStatus(_viewModel.SelectedAccount);
        }
    }
}
