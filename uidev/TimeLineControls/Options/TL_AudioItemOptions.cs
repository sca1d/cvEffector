using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uidev.Class;

namespace uidev.TimeLineControls.Options
{
    public class TL_AudioItemOptions
    {

        #region Mute
        public delegate void ChangedMuteEvent(bool v);
        public ChangedMuteEvent ChangedMute;

        private bool _mute = false;
        public bool Mute
        {
            get
            {
                return _mute;
            }
            set
            {
                _mute = value;
                ChangedMute?.Invoke(value);
            }
        }
        #endregion

        #region AudioProps
        public delegate void ChangedAudioPropertiesEvent(AudioProperties a);
        public ChangedAudioPropertiesEvent ChangedAudioProps;

        private AudioProperties _audioProps;
        public AudioProperties AudioProps
        {
            get
            {
                return _audioProps;
            }
            set
            {
                _audioProps = value;
                ChangedAudioProps?.Invoke(value);
            }
        }
        #endregion

    }
}
