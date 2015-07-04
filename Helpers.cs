using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MCManager
{
	public static class Helpers
	{
		public static bool EqualsIC(this string self,string subject)
		{
			return self != null && self.Equals(subject,StringComparison.OrdinalIgnoreCase);
		}

		public static bool StartsWithIC(this string self, string subject)
		{
			return self != null && self.StartsWith(subject,StringComparison.OrdinalIgnoreCase);
		}

		public static bool ContainsIC(this string self, string subject)
		{
			return self != null && -1 != self.IndexOf(subject,StringComparison.OrdinalIgnoreCase);
		}

		public static bool EndsWithIC(this string self, string subject)
		{
			return self != null && self.EndsWith(subject,StringComparison.OrdinalIgnoreCase);
		}

		private static JavaScriptSerializer _jss = new JavaScriptSerializer();
		public static string ToJson(object sub)
		{
			return _jss.Serialize(sub);
		}

		public static string ReadLink(string path)
		{
			return Mono.Unix.UnixPath.TryReadLink(path);
		}

		public static string GetProcessWorkingDir(int processid)
		{
			//must be in the sudoers list to do this /etc/sudoers.d/mono
			string res = RunCommand("/usr/bin/sudo","-n pwdx "+processid.ToString());
			if (!String.IsNullOrEmpty(res)) {
				return res.Substring(processid.ToString().Length + 2).Trim();
			}
			return "";
		}

		public static string RunCommand(string cmd, string args)
		{
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.StartInfo.FileName = cmd;
			proc.StartInfo.Arguments = args;
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.Start();
			proc.WaitForExit(5000);
			string ret = proc.StandardOutput.ReadToEnd();
			return ret;
		}
	}
}
