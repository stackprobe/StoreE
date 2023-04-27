using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0009
	{
		public void Test01()
		{
			Test01_a("AAABBBCCC", 'B', 2, 6);
			Test01_a("BBBBBBBB", 'B', -1, 8);
			Test01_a("ABBBBBC", 'B', 0, 6);
			Test01_a("AAACCC", 'B', 2, 3);
			Test01_a("AABCC", 'B', 1, 3);
			Test01_a("AAAA", 'B', 3, 4);
			Test01_a("CCC", 'B', -1, 0);
			Test01_a("AB", 'B', 0, 2);
			Test01_a("B", 'B', -1, 1);
			Test01_a("", 'B', -1, 0);

			Console.WriteLine("OK!");
		}

		private void Test01_a(string str, char target, int expectRange_L, int expectRange_R)
		{
			int[] range = SCommon.GetRange(str.ToCharArray(), target, (a, b) => (int)a - (int)b);

			//Console.WriteLine(string.Join(", ", range[0], range[1], expectRange_L, expectRange_R)); // cout

			if (
				range[0] != expectRange_L ||
				range[1] != expectRange_R
				)
				throw null;

			Console.WriteLine("OK");
		}
	}
}
