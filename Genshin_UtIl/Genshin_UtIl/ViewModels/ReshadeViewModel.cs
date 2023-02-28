using CommunityToolkit.Mvvm.ComponentModel;

namespace Genshin_UtIl.ViewModels
{
    public class ReshadeViewModel : ObservableObject
    {
        private bool isRestartReshadeEnabled;

        public bool IsRestartReshadeEnabled
        {
            get => isRestartReshadeEnabled;
            set => SetProperty(ref isRestartReshadeEnabled, value);
        }
    }
}
