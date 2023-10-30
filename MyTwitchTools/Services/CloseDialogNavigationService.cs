using MyTwitchTools.Stores;

namespace MyTwitchTools.Services
{
    public class CloseDialogNavigationService : INavigationService
    {
        private readonly DialogNavigationStore _dialogNavigationStore;

        public CloseDialogNavigationService(DialogNavigationStore dialogNavigationStore)
        {
            _dialogNavigationStore = dialogNavigationStore;
        }

        public void Navigate()
        {
            _dialogNavigationStore.Close();
        }
    }
}
