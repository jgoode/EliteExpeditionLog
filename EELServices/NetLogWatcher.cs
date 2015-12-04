using EELData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELServices
{
    public interface INetLogWatcher
    {
        NetLogWatcherStatus Status { get; }
        FileSystemWatcher Watcher { get; }
        void Start();
        void Stop();
    }

    public enum NetLogWatcherStatus {
        Initialized = 0,
        Started,
        Stopped,
        NoFile,
        NoPath
    }

    public class NetLogWatcherEventArgs : EventArgs {
        public StarSystem CurrentSystem { get; set; }
    }

    public delegate void NetLogWatcherHandler(object source, NetLogWatcherEventArgs args);

    public class NetLogWatcher : INetLogWatcher {
        public NetLogWatcherStatus Status { get; private set; }
        public FileSystemWatcher Watcher { get; private set; }
        public List<StarSystem> VisitedSystems { get; private set; }


        public void Start() {
            throw new NotImplementedException();
        }

        public void Stop() {
            throw new NotImplementedException();
        }
    }
}
