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

			//Main4(new ArgsReader(new string[] { "DP", @"C:\temp", ".txt" }));
			//Main4(new ArgsReader(new string[] { "OS", @"C:\temp" }));
			//Main4(new ArgsReader(new string[] { "L3", @"C:\temp", @"C:\temp\MP3List.txt" }));
			Main4(new ArgsReader(new string[] { "RN", @"C:\temp" }));
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
			string command = ar.NextArg();

			ProcMain.WriteLog("# " + command);

			if (command == "DP")
			{
				string dir = SCommon.MakeFullPath(ar.NextArg());
				string[] midPtns = ar.TrailArgs().ToArray();

				ProcMain.WriteLog("< " + dir);
				ProcMain.WriteLog("P " + string.Join(" OR ", midPtns));

				if (!Directory.Exists(dir))
					throw new Exception("no dir");

				if (midPtns.Length == 0)
					throw new Exception("no midPtns");

				if (midPtns.Any(midPtn => string.IsNullOrWhiteSpace(midPtn)))
					throw new Exception("Bad midPtns");

				if (!Directory.Exists(Consts.GOMISUTEBA_DIR))
					throw new Exception("no GOMISUTEBA_DIR");

				foreach (string file in Directory.GetFiles(dir))
				{
					if (midPtns.Any(midPtn => SCommon.ContainsIgnoreCase(Path.GetFileName(file), midPtn)))
					{
						string destFile = Path.Combine(Consts.GOMISUTEBA_DIR, Path.GetFileName(file));
						destFile = SCommon.ToCreatablePath(destFile);

						ProcMain.WriteLog("< " + file);
						ProcMain.WriteLog("> " + destFile);

						File.Move(file, destFile);

						ProcMain.WriteLog("done");
					}
				}
				ProcMain.WriteLog("done!");
			}
			else if (command == "OS")
			{
				string dir = SCommon.MakeFullPath(ar.NextArg());

				ProcMain.WriteLog("* " + dir);

				if (!Directory.Exists(dir))
					throw new Exception("no dir");

				DateTime dt = DateTime.Now;

				foreach (string file in Directory.GetFiles(dir).OrderBy(SCommon.CompIgnoreCase).Reverse())
				{
					ProcMain.WriteLog("< " + file);
					ProcMain.WriteLog("W " + dt);

					new FileInfo(file).LastWriteTime = dt;

					dt -= TimeSpan.FromSeconds(1.0);
				}
				ProcMain.WriteLog("done!");
			}
			else if (command == "L3")
			{
				string dir = SCommon.MakeFullPath(ar.NextArg());
				string destFile = SCommon.MakeFullPath(ar.NextArg());

				ProcMain.WriteLog("< " + dir);
				ProcMain.WriteLog("> " + destFile);

				if (!Directory.Exists(dir))
					throw new Exception("no dir");

				if (Directory.Exists(destFile))
					throw new Exception("Bad destFile");

				File.WriteAllLines(
					destFile,
					Directory.GetFiles(dir, "*.mp3").OrderBy(SCommon.CompIgnoreCase),
					SCommon.ENCODING_SJIS
					);

				ProcMain.WriteLog("done!");
			}
			else if (command == "RN")
			{
				string dir = SCommon.MakeFullPath(ar.NextArg());

				ProcMain.WriteLog("* " + dir);

				if (!Directory.Exists(dir))
					throw new Exception("no dir");

				string[] fileNames = Directory.GetFiles(dir)
					.Select(file => Path.GetFileName(file))
					.OrderBy(SCommon.CompIgnoreCase)
					.ToArray();

				string[] midFileNames = fileNames
					.Select(fileName => "$_" + fileName)
					.ToArray();

				string[] destFileNames = new string[fileNames.Length];

				for (int index = 0; index < fileNames.Length; index++)
				{
					string fileName = fileNames[index];

					if (Common.LiteFormat_DIG(fileName).StartsWith("9999_"))
						fileName = fileName.Substring(5);

					destFileNames[index] = ((index + 1) * 10).ToString("D4") + "_" + fileName;
				}

				RenameAllFile(dir, fileNames, midFileNames);
				RenameAllFile(dir, midFileNames, destFileNames);

				ProcMain.WriteLog("done!");
			}
			else
			{
				throw new Exception("Bad command");
			}
		}

		private void RenameAllFile(string dir, string[] fileNames, string[] destFileNames)
		{
			for (int index = 0; index < fileNames.Length; index++)
			{
				RenameFile(dir, fileNames[index], destFileNames[index]);
			}
		}

		private void RenameFile(string dir, string fileName, string destFileName)
		{
			ProcMain.WriteLog("D " + dir);
			ProcMain.WriteLog("< " + fileName);
			ProcMain.WriteLog("> " + destFileName);

			File.Move(
				Path.Combine(dir, fileName),
				Path.Combine(dir, destFileName)
				);

			ProcMain.WriteLog("done");
		}
	}
}
