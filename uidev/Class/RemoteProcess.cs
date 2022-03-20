using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uidev.Class;

namespace uidev.Class {
    public class RemoteProcess {

        IpcRemoteObject RemoteObj { get; set; }

        public RemoteProcess() {

            /*
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"uimanager.exe";
            proc.Start();
            */

            IpcClientChannel channel = new IpcClientChannel();

            ChannelServices.RegisterChannel(channel, true);

            RemoteObj = Activator.GetObject(typeof(IpcRemoteObject), "ipc://ipcSample/test") as IpcRemoteObject;
            Console.WriteLine(RemoteObj.Counter);

            ChannelServices.UnregisterChannel(channel);
        }

    }
}
