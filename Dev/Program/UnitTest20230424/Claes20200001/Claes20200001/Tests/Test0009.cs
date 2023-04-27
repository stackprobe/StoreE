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
			Test01_a("BBBBBBCCC", 'B', -1, 6);
			Test01_a("AAABBBBBB", 'B', 2, 9);
			Test01_a("BBBBBBBBB", 'B', -1, 9);
			Test01_a("AAAAAAAAA", 'B', 8, 9);
			Test01_a("CCCCCCCCC", 'B', -1, 0);
			Test01_a("AAACCCCCC", 'B', 2, 3);
			Test01_a("AAAAAACCC", 'B', 5, 6);
			Test01_a("ABC", 'B', 0, 2);
			Test01_a("BBC", 'B', -1, 2);
			Test01_a("ABB", 'B', 0, 3);
			Test01_a("BBB", 'B', -1, 3);
			Test01_a("AAA", 'B', 2, 3);
			Test01_a("CCC", 'B', -1, 0);
			Test01_a("ACC", 'B', 0, 1);
			Test01_a("AAC", 'B', 1, 2);
			Test01_a("AC", 'B', 0, 1);
			Test01_a("BC", 'B', -1, 1);
			Test01_a("AB", 'B', 0, 2);
			Test01_a("A", 'B', 0, 1);
			Test01_a("B", 'B', -1, 1);
			Test01_a("C", 'B', -1, 0);
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
