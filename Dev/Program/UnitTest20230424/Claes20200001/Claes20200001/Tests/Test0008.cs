using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0008
	{
		public void Test01()
		{
			Test01_a("AAAABCCCC", 'B', 4);
			Test01_a("BCCCCCCCC", 'B', 0);
			Test01_a("AAAAAAAAB", 'B', 8);
			Test01_a("AAAAAAAAA", 'B', -1);
			Test01_a("CCCCCCCCC", 'B', -1);
			Test01_a("AAACCCCCC", 'B', -1);
			Test01_a("AAAAAACCC", 'B', -1);
			Test01_a("ABC", 'B', 1);
			Test01_a("BCC", 'B', 0);
			Test01_a("AAB", 'B', 2);
			Test01_a("AAA", 'B', -1);
			Test01_a("CCC", 'B', -1);
			Test01_a("ACC", 'B', -1);
			Test01_a("AAC", 'B', -1);
			Test01_a("AC", 'B', -1);
			Test01_a("BC", 'B', 0);
			Test01_a("AB", 'B', 1);
			Test01_a("A", 'B', -1);
			Test01_a("B", 'B', 0);
			Test01_a("C", 'B', -1);
			Test01_a("", 'B', -1);

			Console.WriteLine("OK!");
		}

		private void Test01_a(string str, char target, int expect)
		{
			int ret = SCommon.GetIndex(str.ToCharArray(), target, (a, b) => (int)a - (int)b);

			//Console.WriteLine(string.Join(", ", ret, expect)); // cout

			if (ret != expect)
				throw null;

			Console.WriteLine("OK");
		}
	}
}
