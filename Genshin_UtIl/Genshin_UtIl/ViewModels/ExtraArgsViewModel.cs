using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using Genshin_UtIl.UtIls;

namespace Genshin_UtIl.ViewModels
{
    public partial class ExtraArgsViewModel : ObservableObject
    {
        private string _ExtraArgs;

        public string ExtraArgs
        {
            get => _ExtraArgs;
            set
            {
                SetProperty(ref _ExtraArgs, value);
                ConfIg.Instance.Args = value;
            }
        }

    }
}
