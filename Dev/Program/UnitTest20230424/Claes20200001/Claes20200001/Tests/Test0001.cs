﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			for (int testcnt = 0; testcnt < 10000; testcnt++)
			{
				if (testcnt % 1000 == 0) Console.WriteLine("" + testcnt); // cout

				byte[] data = SCommon.CRandom.GetBytes(SCommon.CRandom.GetInt(1000));
				string str = SCommon.Base32.I.Encode(data);

				if (str == null)
					throw null;

				if (!Regex.IsMatch(str, "^[A-Z2-7]*=*$"))
					throw null;

				byte[] retData = SCommon.Base32.I.Decode(str);

				if (retData == null)
					throw null;

				if (SCommon.Comp(data, retData) != 0) // ? 不一致
					throw null;
			}
			Console.WriteLine("OK!");
		}
	}
}
