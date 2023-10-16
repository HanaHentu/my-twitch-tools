using MyTwitchTools.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
