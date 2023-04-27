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
			Test01_a("AAAAAAAB", 'B', 7);
			Test01_a("BCCCCCC", 'B', 0);
			Test01_a("AAACCC", 'B', -1);
			Test01_a("AABCC", 'B', 2);
			Test01_a("CCCC", 'B', -1);
			Test01_a("AAA", 'B', -1);
			Test01_a("AB", 'B', 1);
			Test01_a("B", 'B', 0);
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
