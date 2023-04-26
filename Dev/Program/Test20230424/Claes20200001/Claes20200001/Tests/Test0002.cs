using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public void Test01()
		{
			ProcMain.WriteLog("*1");
			SCommon.Batch(new string[] { "TIMEOUT 3" }, "", SCommon.StartProcessWindowStyle_e.MINIMIZED);
			ProcMain.WriteLog("*2");
		}
	}
}
