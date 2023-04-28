using System;
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
				if (testcnt % 1000 == 0) Console.WriteLine("TEST-0001-01, " + testcnt); // cout

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

		public void Test02()
		{
			Test02_a(SCommon.ALPHA_UPPER + SCommon.DECIMAL.Substring(2, 6));
			Test02_a(SCommon.ASCII);
			Test02_a(SCommon.HALF);
			Test02_a(SCommon.HALF + SCommon.MBC_ASCII);
			Test02_a(SCommon.HALF + SCommon.MBC_ASCII + "いろはにほへと★日本語");

			Console.WriteLine("OK!");
		}

		private void Test02_a(string testChars)
		{
			Console.WriteLine(string.Join(", ", "TEST-0001-02", testChars)); // cout

			char[] TEST_CHARS = testChars.ToArray();

			for (int testcnt = 0; testcnt < 10000; testcnt++)
			{
				string str = new string(Enumerable.Range(0, SCommon.CRandom.GetInt(1000)).Select(dummy => SCommon.CRandom.ChooseOne(TEST_CHARS)).ToArray());

				byte[] data = SCommon.Base32.I.Decode(str); // でたらめな入力文字列

				if (data == null)
					throw null;
			}
			Console.WriteLine("OK");
		}
	}
}
