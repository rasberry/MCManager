using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MCManager
{
	public interface IModel
	{
		void Init();
	}

	public interface IView
	{
		void Render(TextWriter writer);
	}
}
