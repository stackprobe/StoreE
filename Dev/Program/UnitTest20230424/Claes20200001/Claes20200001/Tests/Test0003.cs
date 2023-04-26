using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0003
	{
		public void Test01()
		{
			for (int testcnt = 0; testcnt < 1000; testcnt++)
			{
				if (testcnt % 100 == 0) Console.WriteLine("" + testcnt); // cout

				bool[] table = Enumerable.Range(0, SCommon.CRandom.GetRange(1, 300)).Select(dummy => SCommon.CRandom.GetBoolean()).ToArray();

				RandomUnit ru = new RandomUnit(new RandomNumberGenerator_01() { Table = table });

				for (int c = 0; c < 100; c++)
				{
					foreach (bool flag in table)
						if (ru.GetBoolean() != flag)
							throw null;

					foreach (bool flag in table)
						if (ru.GetSign() != (flag ? 1 : -1))
							throw null;
				}
			}
			Console.WriteLine("OK!");
		}

		private class RandomNumberGenerator_01 : RandomUnit.IRandomNumberGenerator
		{
			public bool[] Table;
			private int RdIndex = 0;

			public byte[] GetBlock()
			{
				return this.NextBytes();
			}

			private byte[] NextBytes()
			{
				int size = SCommon.CRandom.GetRange(1, 100);
				byte[] data = new byte[size];

				for (int c = 0; c < size; c++)
					data[c] = this.NextByte();

				return data;
			}

			private byte NextByte()
			{
				int value = 0;

				for (int c = 0; c < 8; c++)
					if (this.NextBit())
						value |= 1 << c;

				return (byte)value;
			}

			private bool NextBit()
			{
				return this.Table[this.RdIndex++ % this.Table.Length];
			}

			public void Dispose()
			{
				// noop
			}
		}
	}
}
