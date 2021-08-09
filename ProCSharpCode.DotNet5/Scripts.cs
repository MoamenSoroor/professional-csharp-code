using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProCSharpCode.ExtensionMethods;
using System.Diagnostics;

namespace ProCSharpCode
{
    public static class Scripts
    {
        public static List<string> FilterFileLines(string filePath, params string[] filter)
        {
            var data = File.ReadAllLines(filePath).Where(l => filter.Any(f => l.Contains(f))).ToList();
            return data;
        }


        public static void FilterFileLines(string sourceFilePath, string destinationFilePath, params string[] filter)
        {
            var data = File.ReadAllLines(sourceFilePath).Where(l => filter.Any(f => l.Contains(f))).ToList();
            File.WriteAllLines(destinationFilePath, data);

        }

        public static string GenerateRandomString(int length)
        {
            Random rand = new Random();
            return string.Concat(Enumerable.Repeat((char)rand.Next('A', 'Z'), length));
        }


        public static string GenerateRandomStringWithRandomChar(int length)
        {

            Random rand = new Random();
            return string.Concat(Enumerable.Range(0, length).Select(n2 => (char)rand.Next('A', 'Z')));

        }


        // not finished yet, you should implement removeNewLine 
        // the default behaviour is removing newLines
        public static string ConvertTextToMaxCharsPerLine(string text, int maxCharsPerLine=80, bool removeNewlines = true )
        {
            string oneLineText = text.Replace(Environment.NewLine, " ");

            var indices = Enumerable.Range(0, oneLineText.Length / maxCharsPerLine)
                .Select(c => (c + 1) * maxCharsPerLine).ToList();
                
                
                
           var rightIndices = indices.Select(c => 
                oneLineText.LastIndexOf(" ", c-1 , maxCharsPerLine)).ToArray();

            // note that SplitAt is and extension Method at 
            // ProCSharpCode.ExtensionMethods;
            var splitted = oneLineText.SplitAt(rightIndices);
            return string.Join(Environment.NewLine,splitted);
        }


        public static void ConvertTextToMaxAndSaveIt(string path, string text, int maxCharsPerLine = 80)
        {

            if (File.Exists(path))
                path = Path.GetDirectoryName(path)+ $"temp{Guid.NewGuid()}.txt";

            File.WriteAllText(path,ConvertTextToMaxCharsPerLine(text, maxCharsPerLine));

        }


        /// <summary>
        /// this code is to run the cmd with specific commands
        /// </summary>
        public static void RunCMD()
        {

            //string strCmdText;
            //strCmdText = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);


            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            //process.StartInfo = startInfo;
            //process.Start();


            //string[] strCmdText = { @"c:", @"cd C:\Users\moame\Desktop\spotlight\to rename", @"ren *.* *.jpg" };
            string[] strCmdText = { @"", @"", @"" };

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(strCmdText[0]);
            cmd.StandardInput.WriteLine(strCmdText[1]);
            cmd.StandardInput.WriteLine(strCmdText[2]);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

        }


    }
}
