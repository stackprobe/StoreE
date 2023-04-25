using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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

		public void Test04()
		{
			Exception ex = SCommon.ToThrow(() => SCommon.Hex.I.ToBytes("xxx"));

			Console.WriteLine("" + ex);

			MessageBox.Show(ex.Message, "AAAA / Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void Test05()
		{
			for (int c = 0; c < 10000; c++)
			{
				byte[] data = SCommon.CRandom.GetBytes(SCommon.CRandom.GetInt(1000));
				string str = SCommon.Hex.I.ToString(data);
				byte[] retData = SCommon.Hex.I.ToBytes(str);

				if (SCommon.Comp(data, retData) != 0)
					throw null;
			}
			Console.WriteLine("OK!");
		}

		public void Test06()
		{
			Test06_a();
			Test06_b();
			Test06_b2();

			Console.WriteLine("OK!");
		}

		private void Test06_a()
		{
			for (int c = 0; c < 10000; c++)
			{
				byte[] data = SCommon.CRandom.GetBytes(SCommon.CRandom.GetInt(1000));
				string str = SCommon.Base64.I.Encode(data);
				byte[] retData = SCommon.Base64.I.Decode(str);

				if (SCommon.Comp(data, retData) != 0)
					throw null;
			}
			Console.WriteLine("OK");
		}

		private void Test06_b()
		{
			char[] TEST_CHARS = (SCommon.HALF + SCommon.MBC_ASCII + "いろはにほへと日本語漢字").ToArray();

			for (int c = 0; c < 10000; c++)
			{
				string str = new string(Enumerable.Range(0, SCommon.CRandom.GetInt(1000)).Select(dummy => SCommon.CRandom.ChooseOne(TEST_CHARS)).ToArray());

				// でたらめな文字列でも例外を投げずに何らかのバイト列を返すはず。
				//
				byte[] retData = SCommon.Base64.I.Decode(str);

				if (retData == null)
					throw null;
			}
			Console.WriteLine("OK");
		}

		private void Test06_b2()
		{
			for (int c = 0; c < 10000; c++)
			{
				string str = new string(Enumerable.Range(0, SCommon.CRandom.GetInt(1000)).Select(dummy => (char)SCommon.CRandom.GetInt(0x10000)).ToArray());

				// でたらめな文字列でも例外を投げずに何らかのバイト列を返すはず。
				//
				byte[] retData = SCommon.Base64.I.Decode(str);

				if (retData == null)
					throw null;
			}
			Console.WriteLine("OK");
		}
	}
}
