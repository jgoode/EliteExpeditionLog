using EELData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELServices {
    public class LogFileHandler {
        private Dictionary<string, NetLogFileInfo> _netlogfiles;
        public List<SystemPosition> VisitedSystems { get; private set; }
        public List<StarSystem> _foundSystems;
        private NetLogFileInfo _lastnfi = null;
        private Expedition _expedition;

        public LogFileHandler(Expedition expedition) {
            _netlogfiles = new Dictionary<string, NetLogFileInfo>();
            VisitedSystems = new List<SystemPosition>();
            _expedition = expedition;
        }

        public StarSystem RetrieveNextStarSystem(FileInfo fileInfo) {
            if (fileInfo == null) throw new ArgumentNullException("fileInfo");
            var starSystem = new StarSystem();
            int count = 0, nrsystems = VisitedSystems.Count;
            _foundSystems = new List<StarSystem>();

            using (Stream fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                using (StreamReader sr = new StreamReader(fs)) {
                    DateTime gammastart = new DateTime(2014, 11, 22, 13, 00, 00);
                    string FirstLine = sr.ReadLine();
                    string line, str;
                    NetLogFileInfo nfi = null;
                    str = "20" + FirstLine.Substring(0, 8) + " " + FirstLine.Substring(9, 5);

                    DateTime filetime = DateTime.Parse(str);
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
                                    AddNewSystem(ps);
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
                }
            }
            if (_foundSystems.Count > 0) {
                starSystem = _foundSystems[_foundSystems.Count - 1];
                return starSystem;
            } else {
                return null;
            }
            
        }

        private void AddNewSystem(SystemPosition ps) {
            if (null == ps) throw new ArgumentNullException("ps");
            var now = DateTime.Now;
            if (null == VisitedSystems.Find(p => p.Name == ps.Name)) {
                _foundSystems.Add(new StarSystem() {
                    CreatedAt = now,
                    Expedition = _expedition,
                    Name = ps.Name,
                    UpdatedAt = now
                });
                VisitedSystems.Add(ps);
            }
        }
    }
}
