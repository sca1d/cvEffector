using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uidev.Class;
using uidev.TimeLineControls;
using uidev.TimeLineControls.Options;

namespace uidev.TimeLineControls.Options
{
    public class TL_VideoItemOptions
    {

        #region Hide
        public delegate void ChangedHideEvent(bool v);
        public ChangedHideEvent ChangedHide;

        private bool _hide = false;
        public bool Hide
        {
            get
            {
                return _hide;
            }
            set
            {
                _hide = value;
                ChangedHide?.Invoke(value);
            }
        }
        #endregion

        #region Mode
        public delegate void ChangedCompositeModeEvent(CompositeMode m);
        public ChangedCompositeModeEvent ChangedComposite;

        private CompositeMode _compMode = CompositeMode.normal;
        public CompositeMode CompMode
        {
            get
            {
                return _compMode;
            }
            set
            {
                _compMode = value;
                ChangedComposite?.Invoke(value);
            }
        }
        #endregion

        #region VideoProps
        public delegate void ChangedVideoPropetiesEvent(VideoProperties v);
        public ChangedVideoPropetiesEvent ChangedVideoProps;

        private VideoProperties _videoProps;
        public VideoProperties VideoProps
        {
            get
            {
                return _videoProps;
            }
            set
            {
                _videoProps = value;
                ChangedVideoProps?.Invoke(value);
            }
        }
        #endregion

    }
}
