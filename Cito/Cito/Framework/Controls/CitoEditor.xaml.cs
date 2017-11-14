using Cito.Framework.Utilities;
using Xamarin.Forms;

namespace Cito.Framework.Controls
{
    public partial class CitoEditor : Editor
    {
        public CitoEditor()
        {
            InitializeComponent();
            FontFamily = CitoFont.SetFont();
        }
    }
}
