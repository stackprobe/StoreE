﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			File.WriteAllBytes(SCommon.NextOutputPath() + ".txt", SCommon.GetJCharBytes().ToArray());
		}
	}
}
