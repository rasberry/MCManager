using EasySgml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;

namespace MCManager
{
	public class StatusView : BasePage
	{
		public StatusView(StatusModel model)
		{
			_model = model;
			IncludeCssFile("main.css");
			IncludeJsFile("jquery-2.1.4.min.js");
			IncludeJsFile("main.js");
		}
		private StatusModel _model;

		protected override void RenderHead(System.IO.TextWriter buffer)
		{
			//nothing to do
		}

		protected override void RenderBody(System.IO.TextWriter buffer)
		{
			var con = Sgml.Pile();
			var table = Sgml.Tag("tbody");
			con.Add(Sgml.Tag("table").Add(table));
			bool hasRunning = _model.ServerList.Any(p => p.Running != null);

			foreach(ServerProps p in _model.ServerList)
			{
				IFragment runn = null;
				if (hasRunning) {
					if (p.Running != null) {
						hasRunning = true;
						string pid = p.Running.ProcessId.ToString();
						runn = Sgml.Pile().Add(
							Sgml.Tag("td").AddText(pid)
							,Sgml.Tag("td").Add(
								Sgml.Tag("button","which","stop","pid",pid).AddText("stop")
							)
						);
					}
				} else {
					runn = Sgml.Pile().Add(
						Sgml.Tag("td").AddText("\00A0")
						,Sgml.Tag("td").Add(
							Sgml.Tag("button","which","start","name",p.Name).AddText("start")
						)
					);
				}

				table.Add(
					Sgml.Tag("tr").Add(
						Sgml.Tag("td").AddText(p.Name)
						,Sgml.Tag("td").AddText(p.Version)
						,Sgml.Tag("td").AddText(p.HasMods ? "mods" : "")
						,runn
					)
				);
			}

			con.Write(buffer);
		}

		//private IWrite DrawControls()
		//{
		//	var con = Sgml.Tag("div","class","controls");
		//	con.

		//}
	}
}
