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
        public List<SystemPosition> VisitedSystems { get; private set; }
        public event NetLogWatcherHandler OnNewPosition;
        private Dictionary<string, NetLogFileInfo> _netlogfiles;
        private NetLogFileInfo _lastnfi = null;

        public NetLogWatcher() {
            Watcher = new FileSystemWatcher();
            VisitedSystems = new List<SystemPosition>();
            _netlogfiles = new Dictionary<string, NetLogFileInfo>();
            Watcher.Changed += Watcher_Changed;
            Status = NetLogWatcherStatus.Initialized;
        }

        private async void Watcher_Changed(object sender, FileSystemEventArgs e) {
            if (e.ChangeType == System.IO.WatcherChangeTypes.Changed) {
                await ParseFile(new FileInfo(e.FullPath));
            }
        }

        private async Task<int> ParseFile(FileInfo fileInfo) {
            if (fileInfo == null) throw new ArgumentNullException("fileInfo");

            int count = 0, nrsystems = VisitedSystems.Count;
            try {
                using (Stream fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    using (StreamReader sr = new StreamReader(fs)) {
                        count = await ReadData(fileInfo, sr);
                    }
                }
            } catch (Exception ex) {
                return 0;
            }
            return count;
        }

        private async Task<int> ReadData(FileInfo fileInfo, StreamReader sr) {
            if (fileInfo == null) throw new ArgumentNullException("fileInfo");
            if (sr == null) throw new ArgumentNullException("sr");

            DateTime gammastart = new DateTime(2014, 11, 22, 13, 00, 00);
            var count = 0;
            DateTime filetime = DateTime.Now.AddDays(-500);
            string FirstLine = sr.ReadLine();
            string line, str;
            NetLogFileInfo nfi = null;

            str = "20" + FirstLine.Substring(0, 8) + " " + FirstLine.Substring(9, 5);

            filetime = DateTime.Parse(str);

            if (_netlogfiles.ContainsKey(fileInfo.FullName)) {
                nfi = _netlogfiles[fileInfo.FullName];
                sr.BaseStream.Position = nfi.filePos;
                sr.DiscardBufferedData();
            }

            while ((line = sr.ReadLine()) != null) {
                if (line.Contains(" System:")) {
                    SystemPosition ps = SystemPosition.Parse(filetime, line);
                    if (ps != null) {
                        if (ps.Name.Equals("Training"))
                            continue;
                        if (ps.Name.Equals("Destination"))
                            continue;

                        filetime = ps.Time;

                        if (VisitedSystems.Count > 0)
                            if (VisitedSystems[VisitedSystems.Count - 1].Name.Equals(ps.Name))
                                continue;

                        if (ps.Time.Subtract(gammastart).TotalMinutes > 0) { // Ta bara med efter gamma. 
                            await AddNewSystem(ps);
                            count++;
                        }
                    }
                }
            }


            if (nfi == null)
                nfi = new NetLogFileInfo();

            nfi.FileName = fileInfo.FullName;
            nfi.lastchanged = File.GetLastWriteTimeUtc(nfi.FileName);
            nfi.filePos = sr.BaseStream.Position;
            nfi.fileSize = fileInfo.Length;

            _netlogfiles[nfi.FileName] = nfi;
            _lastnfi = nfi;

            return count;
        }

        private async Task AddNewSystem(SystemPosition ps) {
            throw new NotImplementedException();
        }

        public void Start() {
            if (string.IsNullOrWhiteSpace(Watcher.Path)) {
                Status = NetLogWatcherStatus.NoPath;
                return;
            }

            Watcher.EnableRaisingEvents = true;
            Status = NetLogWatcherStatus.Started;
        }

        public void Stop() {
            Watcher.EnableRaisingEvents = false;
            Status = NetLogWatcherStatus.Stopped;
        }
    }
}
