using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito.Framework.Controls
{
    public partial class CitoFrame : Frame
    {
        public bool HasFrame { get; set; } = true;
        public CitoFrame()
        {
            InitializeComponent();
        }
    }
}
