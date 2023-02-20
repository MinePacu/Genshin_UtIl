using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
