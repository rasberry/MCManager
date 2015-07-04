using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MCManager
{
	public class Status : IHttpHandler
	{
		public bool IsReusable { get { return false; }}

		public void ProcessRequest(HttpContext context)
		{
			var action = new ActionModel();
			action.Context = context;
			action.Init();
			var model = new StatusModel();
			model.Init();
			var view = new StatusView(model);
			view.Render(context.Response.Output);
		}
	}

	public class Static : IHttpHandler
	{
		public bool IsReusable { get { return false; }}

		public void ProcessRequest(HttpContext context)
		{
			string path = context.Request.Url.AbsolutePath;
			string file = Path.GetFileName(path);
			string phys = context.Server.MapPath("~/Static/"+file);
			if (File.Exists(phys)) {
				string mime = Mime.GetMimeMapping(file);
				context.Response.ContentType = mime;
				context.Response.WriteFile(phys);
			} else {
				context.Response.StatusCode = 404;
			}
		}
	}
}
