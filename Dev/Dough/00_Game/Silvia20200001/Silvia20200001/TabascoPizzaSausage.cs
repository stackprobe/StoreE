using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Games;

namespace Charlotte
{
	public static class TabascoPizzaSausage
	{
		public static void Run()
		{
			if (ProcMain.DEBUG)
			{
				RunOnDebug();
			}
			else
			{
				RunOnRelease();
			}
		}

		private static void RunOnDebug()
		{
#if DEBUG
			// -- choose one --

			Logo.Run();
			//TitleMenu.Run();
			//Game.Run();
			//new Test0001().Test01();
			//new Test0002().Test01();
			//new Test0003().Test01();

			// --
#else
			throw new Exception("DEBUG is True");
#endif
		}

		private static void RunOnRelease()
		{
			Logo.Run();
		}
	}
}
