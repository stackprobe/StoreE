using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte
{
	public static class Common
	{
		public static string LiteFormat_DIG(string str)
		{
			foreach (char dig in SCommon.DECIMAL)
				str = str.Replace(dig, '9');

			return str;
		}
	}
}
