using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace process_stdout_reader
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("No file name specified");
				return;
			}
			Process p = new Process();
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.FileName = args[0];
			p.StartInfo.StandardOutputEncoding = Encoding.UTF8;

			StringBuilder sb = new StringBuilder();
			for (int i = 1; i < args.Length; i++)
			{
				sb.Append(args[i]);
				sb.Append(' ');
			}
			p.StartInfo.Arguments = sb.ToString();
			p.Start();

			string output = p.StandardOutput.ReadToEnd();
			p.WaitForExit();

			Console.OutputEncoding = Encoding.UTF8;
			Console.Write(output);

			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}
	}
}
