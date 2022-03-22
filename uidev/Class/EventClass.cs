using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uidev.Class
{
    public class ChangeSizeEventArgs
    {

        public enum CenterBackward
        {
            Center = 0,
            Backward,
        }

        public CenterBackward centerBackward;

        public ChangeSizeEventArgs(CenterBackward cb)
        {
            centerBackward = cb;
        }

    }
}
