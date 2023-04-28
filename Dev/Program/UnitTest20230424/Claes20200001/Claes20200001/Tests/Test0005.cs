using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0005
	{
		public void Test01()
		{
			for (int testcnt = 0; testcnt < 10000; testcnt++)
			{
				if (testcnt % 1000 == 0) Console.WriteLine("TEST-0005-01, " + testcnt); // cout

				byte[] data = SCommon.CRandom.GetBytes(SCommon.CRandom.GetInt(1000));
				string str = SCommon.Hex.I.ToString(data);

				if (str == null)
					throw null;

				if (str.Length != data.Length * 2)
					throw null;

				if (!Regex.IsMatch(str, "^[0-9a-f]*$"))
					throw null;

				byte[] retData = SCommon.Hex.I.ToBytes(str);

				if (retData == null)
					throw null;

				if (SCommon.Comp(data, retData) != 0) // ? 不一致
					throw null;
			}
			Console.WriteLine("OK!");
		}
	}
}
