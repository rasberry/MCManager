using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MCManager
{
	public class ActionModel : IModel
	{
		public HttpContext Context { get; set; }

		enum Which { None, Start, Stop }

		public void Init()
		{
			string which = Context.Request["which"];
			
		}
	}
}
