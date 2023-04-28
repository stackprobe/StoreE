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

			Console.WriteLine(string.Join(", ", str, target, expectRange_L, expectRange_R, range[0], range[1])); // cout

			if (
				range[0] != expectRange_L ||
				range[1] != expectRange_R
				)
				throw null;

			Console.WriteLine("OK");
		}

		public void Test02()
		{
			Test02_a(1000000, 2000000, 300000, 300000);
			Test02_a(1000000, 2000000, 100000, 100000);
			Test02_a(1000000, 2000000, 30000, 30000);
			Test02_a(1000000, 2000000, 10000, 10000);
			Test02_a(1000000, 2000000, 3000, 3000);
			Test02_a(1000000, 2000000, 1000, 1000);
			Test02_a(1000000, 2000000, 300, 300);
			Test02_a(1000000, 2000000, 100, 100);
			Test02_a(1000000, 2000000, 30, 30);
			Test02_a(1000000, 2000000, 10, 10);

			Console.WriteLine("OK!");
		}

		private void Test02_a(int minValue, int maxValue, int valueStepScale, int testCount)
		{
			for (int testcnt = 0; testcnt < testCount; testcnt++)
			{
				List<int> list = new List<int>();

				for (
					int value = SCommon.CRandom.GetRange(minValue, minValue + valueStepScale);
					value <= maxValue;
					value += SCommon.CRandom.GetRange(1, valueStepScale)
					)
					list.Add(value);

				int i1 = SCommon.CRandom.GetInt(list.Count);
				int i2 = SCommon.CRandom.GetInt(list.Count);

				int l = Math.Min(i1, i2);
				int r = Math.Max(i1, i2);

				int targetRange_L = list[l];
				int targetRange_R = list[r];

				int expectRange_L = l - 1;
				int expectRange_R = r + 1;

				// ----

				int[] range = SCommon.GetRange(list, value =>
				{
					if (value < targetRange_L) return -1;
					if (value > targetRange_R) return 1;

					return 0;
				});

				if (
					range[0] != expectRange_L ||
					range[1] != expectRange_R
					)
					throw null;
			}
			Console.WriteLine("OK");
		}

		public void Test03()
		{
			Test03_a(1000000, 2000000, 300000, 300000);
			Test03_a(1000000, 2000000, 100000, 100000);
			Test03_a(1000000, 2000000, 30000, 30000);
			Test03_a(1000000, 2000000, 10000, 10000);
			Test03_a(1000000, 2000000, 3000, 3000);
			Test03_a(1000000, 2000000, 1000, 1000);
			Test03_a(1000000, 2000000, 300, 300);
			Test03_a(1000000, 2000000, 100, 100);
			Test03_a(1000000, 2000000, 30, 30);
			Test03_a(1000000, 2000000, 10, 10);

			Console.WriteLine("OK!");
		}

		private void Test03_a(int minValue, int maxValue, int valueStepScale, int testCount)
		{
			for (int testcnt = 0; testcnt < testCount; testcnt++)
			{
				List<int> list = new List<int>();

				for (
					int value = SCommon.CRandom.GetRange(minValue, minValue + valueStepScale);
					value <= maxValue;
					value += SCommon.CRandom.GetRange(1, valueStepScale)
					)
					list.Add(value);

				int i = SCommon.CRandom.GetInt(list.Count);

				int target = SCommon.DesertElement(list, i);

				int expectRange_L = i - 1;
				int expectRange_R = i;

				// ----

				int[] range = SCommon.GetRange(list, target, (a, b) => a - b);

				if (
					range[0] != expectRange_L ||
					range[1] != expectRange_R
					)
					throw null;
			}
			Console.WriteLine("OK");
		}
	}
}
