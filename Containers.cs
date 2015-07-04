using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCManager
{
	public class ServerProps
	{
		public string Version;
		public string Name;
		public bool IsValid { get { return !String.IsNullOrEmpty(Version); }}
		public string Path;
		public RunninProc Running;
		public bool HasMods;
	}

	public class RunninProc
	{
		public string WorkingPath;
		public int ProcessId;
	}
}
