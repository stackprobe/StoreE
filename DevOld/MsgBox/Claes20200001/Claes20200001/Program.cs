using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string command = args[0];
				string message = args[1];
				int exitCode = 0;

				if (command == "E")
				{
					MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (command == "W")
				{
					MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else if (command == "I")
				{
					MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (command == "YN")
				{
					DialogResult ret = MessageBox.Show(message, "Yes / No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (ret != DialogResult.Yes) // ? Maybe 'No'
					{
						exitCode = 1;
					}
				}
				else if (command == "YNC")
				{
					DialogResult ret = MessageBox.Show(message, "Yes / No / Cancel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

					if (ret == DialogResult.No)
					{
						exitCode = 1;
					}
					else if (ret != DialogResult.Yes) // ? Maybe 'Cancel'
					{
						exitCode = 2;
					}
				}
				else
				{
					throw new Exception("不明なコマンド");
				}

				Environment.Exit(exitCode);
			}
			catch (Exception ex)
			{
				MessageBox.Show("" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
