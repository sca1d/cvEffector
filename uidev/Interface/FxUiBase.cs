using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uidev.Interface
{
    interface FxUiBase
    {

        bool Enabled { get; set; }

        bool Border { get; set; }

        bool DontOpenMenuMode { get; }

        Controls.FxMenu Menu { get; set; }

        void Init();

    }
}
