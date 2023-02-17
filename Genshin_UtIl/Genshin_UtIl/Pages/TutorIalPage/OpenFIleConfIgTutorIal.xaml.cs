using Genshin_UtIl.UtIls;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages.TutorIalPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OpenFIleConfIgTutorIal : Page
    {
        public OpenFIleConfIgTutorIal()
        {
            this.InitializeComponent();

            GC.Collect();

            Paragraph para = (Paragraph) FolderStrIng.Blocks[0];

            ((Run) para.Inlines[0]).Text = "폴더 - " + ConfIg.Instance.GenshInFolder.GenshInFolder;

            para = (Paragraph) ReshadeFolderStrIng.Blocks[0];

            ((Run) para.Inlines[0]).Text = "폴더 - " + ConfIg.Instance.GenshInFolder.ReshadeFolder;
        }
    }
}
