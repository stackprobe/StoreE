using System;
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

		public void Test02()
		{
			for (int c = 0; c < 50; c++)
			{
				Console.WriteLine(SCommon.CRandom.GetBoolean());
			}
		}

		public void Test03()
		{
			Test03_a("ABCDEF", 1, 4, "BCDE");
			Test03_a("ABCDEF", 0, 3, "ABC");
			Test03_a("ABCDEF", 3, 3, "DEF");
			Test03_a("ABCDEF", 0, 6, "ABCDEF");
			Test03_a("ABCDEF", 0, 0, "");

			Test03_b("ABCDEF", 6, "");
			Test03_b("ABCDEF", 3, "DEF");
			Test03_b("ABCDEF", 0, "ABCDEF");

			Console.WriteLine("OK!");
		}

		private void Test03_a(string sSrc, int offset, int size, string sAssumeDest)
		{
			char[] src = sSrc.ToArray();
			char[] assumeDest = sAssumeDest.ToArray();

			char[] dest = SCommon.GetPart(src, offset, size);

			if (SCommon.Comp(dest, assumeDest, (a, b) => (int)a - (int)b) != 0)
				throw null;

			Console.WriteLine("OK");
		}

		private void Test03_b(string sSrc, int offset, string sAssumeDest)
		{
			char[] src = sSrc.ToArray();
			char[] assumeDest = sAssumeDest.ToArray();

			char[] dest = SCommon.GetPart(src, offset);

			if (SCommon.Comp(dest, assumeDest, (a, b) => (int)a - (int)b) != 0)
				throw null;

			Console.WriteLine("OK");
		}
	}
}
