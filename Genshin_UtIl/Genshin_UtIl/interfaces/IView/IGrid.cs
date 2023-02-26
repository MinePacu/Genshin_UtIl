using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI.Xaml.Controls;

namespace Genshin_UtIl.interfaces.IView
{
    public interface IGrid
    {
        public static Grid DisplayListGrid { get; set; } = new();

        public static bool Initialized { get; set; } = false;
    }
}
