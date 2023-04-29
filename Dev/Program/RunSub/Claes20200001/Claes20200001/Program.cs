using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Charlotte.Commons;
using Charlotte.Tests;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2);
		}

		private void Main2(ArgsReader ar)
		{
			if (ProcMain.DEBUG)
			{
				Main3();
			}
			else
			{
				Main4(ar);
			}
			SCommon.OpenOutputDirIfCreated();
		}

		private void Main3()
		{
			// テスト系 -- リリース版では使用しない。
#if DEBUG
			// -- choose one --

			Main4(new ArgsReader(new string[] { @"C:\temp", "Test" }));
			//new Test0001().Test01();
			//new Test0002().Test01();
			//new Test0003().Test01();

			// --
#endif
			SCommon.Pause();
		}

		private void Main4(ArgsReader ar)
		{
			try
			{
				Main5(ar);
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);

				MessageBox.Show("" + ex, Path.GetFileNameWithoutExtension(ProcMain.SelfFile) + " / エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

				//Console.WriteLine("Press ENTER key. (エラーによりプログラムを終了します)");
				//Console.ReadLine();
			}
		}

		private void Main5(ArgsReader ar)
		{
			string rootDir = SCommon.MakeFullPath(ar.NextArg());
			string targetName = ar.NextArg();

			if (!Directory.Exists(rootDir))
				throw new Exception("no rootDir");

			if (!SCommon.IsFairLocalPath(targetName, -1) || targetName.Contains('\u0020') || targetName.Contains('\u3000'))
				throw new Exception("Bad targetName");

			ProcMain.WriteLog("R " + rootDir);
			ProcMain.WriteLog("T " + targetName);

			string targetBatName = targetName + ".bat";
			string targetExeName = targetName + ".exe";

			foreach (string file in Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories))
			{
				if (SCommon.EqualsIgnoreCase(Path.GetFileName(file), targetBatName))
				{
					ExecuteCommand("CALL " + targetBatName, Path.GetDirectoryName(file));
				}
				else if (SCommon.EqualsIgnoreCase(Path.GetFileName(file), targetExeName))
				{
					ExecuteCommand(targetExeName, Path.GetDirectoryName(file));
				}
			}
			ProcMain.WriteLog("done!");
		}

		private void ExecuteCommand(string command, string workingDir)
		{
			ProcMain.WriteLog("$ " + workingDir);
			ProcMain.WriteLog("* " + command);

			SCommon.Batch(
				new string[] { command, "TIMEOUT 1" },
				Path.GetDirectoryName(workingDir),
				SCommon.StartProcessWindowStyle_e.MINIMIZED
				);

			ProcMain.WriteLog("done");
		}
	}
}
