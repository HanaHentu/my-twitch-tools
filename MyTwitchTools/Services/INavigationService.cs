using MyTwitchTools.ViewModels;

namespace MyTwitchTools.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}