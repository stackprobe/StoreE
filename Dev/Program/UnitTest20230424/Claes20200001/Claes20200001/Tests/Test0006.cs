using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0006
	{
		public void Test01()
		{
			Test01_a(10115235959L, 1);
			Test01_a(10201235959L, 3);
			Test01_a(10301235959L, 10);
			Test01_a(10401235959L, 30);
			Test01_a(11231235959L, 100);
			Test01_a(31231235959L, 300);
			Test01_a(101231235959L, 1000);
			Test01_a(301231235959L, 3000);
			Test01_a(1001231235959L, 10000);
			Test01_a(3001231235959L, 30000);
			Test01_a(10001231235959L, 100000);
			Test01_a(30001231235959L, 300000);
			Test01_a(90001231235959L, 1000000);

			Console.WriteLine("OK!");
		}

		private void Test01_a(long maxTimeStamp, int maxSecAdd)
		{
			long timeStamp = 10101000000L;
			long sec = 0;

			while (timeStamp <= maxTimeStamp)
			{
				long retTimeStamp = SCommon.TimeStampToSec.ToTimeStamp(sec);
				long retSec = SCommon.TimeStampToSec.ToSec(timeStamp);

				if (retTimeStamp != timeStamp)
					throw null;

				if (retSec != sec)
					throw null;

				// ----

				int secAdd = SCommon.CRandom.GetRange(1, maxSecAdd);

				timeStamp = AddSecToTimeStamp(timeStamp, secAdd);
				sec += secAdd;
			}
			Console.WriteLine("OK");
		}

		public void Test02()
		{
			Test02_a(19500101000000L, 20501231235959L, 10000);
			Test02_a(19000101000000L, 21001231235959L, 30000);
			Test02_a(10000101000000L, 30001231235959L, 86400);

			Console.WriteLine("OK!");
		}

		private void Test02_a(long minTimeStamp, long maxTimeStamp, int maxSecAdd)
		{
			long timeStamp = minTimeStamp;
			long sec = SCommon.TimeStampToSec.ToSec(timeStamp);

			while (timeStamp <= maxTimeStamp)
			{
				long retTimeStamp = SCommon.TimeStampToSec.ToTimeStamp(sec);
				long retSec = SCommon.TimeStampToSec.ToSec(timeStamp);

				if (retTimeStamp != timeStamp)
					throw null;

				if (retSec != sec)
					throw null;

				// ----

				int secAdd = SCommon.CRandom.GetRange(1, maxSecAdd);

				timeStamp = AddSecToTimeStamp(timeStamp, secAdd);
				sec += secAdd;
			}
			Console.WriteLine("OK");
		}

		private long AddSecToTimeStamp(long timeStamp, int secAdd)
		{
			int s = (int)(timeStamp % 100);
			timeStamp /= 100;
			int i = (int)(timeStamp % 100);
			timeStamp /= 100;
			int h = (int)(timeStamp % 100);
			timeStamp /= 100;
			int d = (int)(timeStamp % 100);
			timeStamp /= 100;
			int m = (int)(timeStamp % 100);
			timeStamp /= 100;
			int y = (int)timeStamp;

			s += secAdd;
			i += s / 60; s %= 60;
			h += i / 60; i %= 60;
			d += h / 24; h %= 24;

			for (; ; )
			{
				int days = DateTime.DaysInMonth(y, m);

				if (d <= days)
					break;

				d -= days;
				m++;

				if (12 < m)
				{
					m -= 12;
					y++;
				}
			}

			timeStamp =
				y * 10000000000L +
				m * 100000000L +
				d * 1000000L +
				h * 10000L +
				i * 100L +
				s;

			return timeStamp;
		}
	}
}
