using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace uidev.TimeLineControls.Options
{
    public class TL_ItemOptions
    {

        #region Solo
        public delegate void ChangedSoloEvent(bool v);
        public ChangedSoloEvent ChangedSolo;

        private bool _solo = false;
        public bool Solo
        {
            get
            {
                return _solo;
            }
            set
            {
                _solo = value;
                ChangedSolo?.Invoke(value);
            }
        }
        #endregion

        #region Lock
        public delegate void ChangedLockEvent(bool v);
        public ChangedLockEvent ChangedLock;

        private bool _lock = false;
        public bool Lock
        {
            get
            {
                return _lock;
            }
            set
            {
                _lock = value;
                ChangedLock?.Invoke(value);
            }
        }
        #endregion

        #region Effects
        #endregion

    }
}
