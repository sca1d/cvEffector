using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uidev.TimeLineControls
{
    interface TL_LayerItemBase
    {

        int srart_frame{ get; set; }
        int frame_width { get; set; }

        bool selected { get; set; }

    }
}
