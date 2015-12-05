using EELData;
using EELServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EliteExpeditionLog.Tests
{
    public class NetLogWatcherTests
    {
        [Fact]
        public void EventShouldFireWhenFileIsChanged() {
            var systems = new List<StarSystem>();
            var watcher = new NetLogWatcher();
            var fileName = "test.log";
            var path = CreateFile(fileName);
            var pathToFile = string.Format(path + "\\{0}", fileName);
            watcher.Watcher.Path = path;
            watcher.Start();

            // C:\dev\EliteExpeditionLog\EliteExpeditionLog\testdata
            // 15-10-30-18:47 Eastern Summer Time  (22:47 GMT) - part 1
            // {19:59:51} System:322(Floawns JM-W f1-322) Body:2 Pos:(9.94721e+009,6.32041e+009,-9.21425e+009) cruising
            watcher.OnNewPosition += delegate (object sender, NetLogWatcherEventArgs e) {
                systems.Add(e.CurrentSystem);
            };

            WriteFile(pathToFile, "Some text");
            WriteFile(pathToFile, "{19:59:51} System:322(Floawns JM-W f1-322) Body:2 Pos:(9.94721e+009,6.32041e+009,-9.21425e+009) cruising");

            Assert.True(systems.Count > 0);

        }

        public void WriteFile(string path, string text) {
            // Open the stream and read it back.
            using (StreamWriter sr = File.AppendText(path)) {
                sr.WriteLine(text);
            }
        }

        public string CreateFile(string fileName) {
            var path = @"C:\dev\EliteExpeditionLog\EliteExpeditionLog\EliteExpeditionLog.Tests\bin\Debug";
            string pathToFile = string.Format(path + "\\{0}", fileName);
            var now = DateTime.Now;
            var initString = string.Format("{0}-{1}-{2}-{3}:{4} Eastern Summer Time  (22:47 GMT) - part 1", now.Year, now.Month, now.Day, now.Hour, now.Minute);
            try {

                // Delete the file if it exists.
                if (File.Exists(pathToFile)) {
                    File.Delete(pathToFile);
                }

                // Create the file.
                using (FileStream fs = File.Create(pathToFile)) {
                    Byte[] info = new UTF8Encoding(true).GetBytes(initString);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
  
            } catch (Exception Ex) {
                Console.WriteLine(Ex.ToString());
            }
            return path;
        }
    }
}
