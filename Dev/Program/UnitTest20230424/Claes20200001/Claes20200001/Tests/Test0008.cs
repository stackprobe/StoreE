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
			for (int a = 0; a < 10; a++)
			{
				for (int b = 0; b <= 1; b++)
				{
					for (int c = 0; c < 10; c++)
					{
						string str = new string('A', a) + new string('B', b) + new string('C', c);
						char target = 'B';
						int expect = b == 1 ? a : -1;

						Test01_a(str, target, expect);
					}
				}
			}
			Console.WriteLine("OK!");
		}

		private void Test01_a(string str, char target, int expect)
		{
			int ret = SCommon.GetIndex(str.ToCharArray(), target, (a, b) => (int)a - (int)b);

			//Console.WriteLine(string.Join(", ", ret, expect)); // cout

			if (ret != expect)
				throw null;

			//Console.WriteLine("OK");
		}
	}
}
