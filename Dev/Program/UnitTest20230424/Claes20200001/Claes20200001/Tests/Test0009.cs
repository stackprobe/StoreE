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
			for (int a = 0; a < 10; a++)
			{
				for (int b = 0; b < 10; b++)
				{
					for (int c = 0; c < 10; c++)
					{
						string str = new string('A', a) + new string('B', b) + new string('C', c);
						char target = 'B';
						int expectRange_L = a - 1;
						int expectRange_R = a + b;

						Test01_a(str, target, expectRange_L, expectRange_R);
					}
				}
			}
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

			//Console.WriteLine("OK");
		}
	}
}
