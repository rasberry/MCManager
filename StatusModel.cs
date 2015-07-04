using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Web.Script.Serialization;

namespace MCManager
{
	public class StatusModel : IModel
	{
		private const string Root = "/minecraft";
		public void Init()
		{
			var processList = Process.GetProcesses();
			var running = new Dictionary<string,RunninProc>(StringComparer.OrdinalIgnoreCase);
			foreach(Process p in processList) {
				if (p.HasExited) { continue; }
				if (p.ProcessName.ContainsIC("java")) {
					var proc = PopPropsFromProcess(p);
					running.Add(proc.WorkingPath,proc);
				}
			}

			var folderList = Directory.GetDirectories(Root);
			foreach(string f in folderList) {
				ServerProps p = PopProps(Path.Combine(Root,f));
				running.TryGetValue(p.Path,out p.Running);
				if (p.IsValid) { _serverList.Add(p); }
			}
		}

		private static char[] _seperators = new char[] { '/','\\' };
		private ServerProps PopProps(string path)
		{
			ServerProps p = new ServerProps();
			var fileList = Directory.GetFiles(path);
			var dirList = Directory.GetDirectories(path);

			p.HasMods = dirList.Any(s => s.EndsWith("mods"));
			p.Path = path;
			p.Name = path.Substring(Root.Length).Trim(_seperators);

			p.Version = "";
			foreach(string file in fileList) {
				string name = Path.GetFileName(file);
				if (name.StartsWithIC("minecraft_server") && name.EndsWithIC(".jar")) {
					p.Version = Path.GetFileNameWithoutExtension(name).Substring(17);
				}
			}

			return p;
		}

		private RunninProc PopPropsFromProcess(Process p)
		{
			return new RunninProc {
				ProcessId = p.Id
				,WorkingPath = Helpers.GetProcessWorkingDir(p.Id)
			};
		}

		private List<ServerProps> _serverList = new List<ServerProps>();
		public IList<ServerProps> ServerList { get {
			return _serverList;
		}}
	}
}
