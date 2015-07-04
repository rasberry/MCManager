using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MCManager
{
	public abstract class BasePage : IView
	{
		public void Render(TextWriter buffer)
		{
			buffer.Write("<!DOCTYPE html><html>");
			buffer.Write("<head>");
			RenderStyles(buffer);
			RenderHead(buffer);
			buffer.Write("</head>");
			buffer.Write("<body>");
			RenderBody(buffer);
			RenderScripts(buffer);
			buffer.Write("</body></html>");
		}

		private List<string> _styles = new List<string>();
		private List<string> _scripts = new List<string>();

		private void RenderStyles(TextWriter buffer)
		{
			foreach(string style in _styles)
			{
				buffer.Write(@"<link rel=""stylesheet"" type=""text/css"" href="""+style+@""" />");
			}
		}
		private void RenderScripts(TextWriter buffer)
		{
			foreach(string script in _scripts)
			{
				buffer.Write(@"<script src="""+script+@"""/>");
			}
		}

		protected void IncludeCssFile(string name)
		{
			_styles.Add(name);
		}
		protected void IncludeJsFile(string name)
		{
			_scripts.Add(name);
		}

		protected abstract void RenderHead(TextWriter buffer);
		protected abstract void RenderBody(TextWriter buffer);
	}
}
