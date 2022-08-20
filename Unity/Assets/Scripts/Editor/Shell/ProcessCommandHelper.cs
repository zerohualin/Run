using System.Diagnostics;
using ET;
using UnityEngine;

public static class ProcessCommandHelper
{
    public static void Invoke(string argument)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "C://Program Files//Git//bin//bash.exe";
        argument = $"{Application.dataPath}/../../Sub/Tools/Shell/{argument}";
        start.Arguments = argument;
        start.CreateNoWindow = false;
        start.ErrorDialog = true;
        start.UseShellExecute = true;

        if (start.UseShellExecute)
        {
            start.RedirectStandardOutput = false;
            start.RedirectStandardError = false;
            start.RedirectStandardInput = false;
        }
        else
        {
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.RedirectStandardInput = true;
            start.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
            start.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
        }

        Process p = Process.Start(start);

        if (!start.UseShellExecute)
        {
            Log.Debug(p.StandardOutput.ToString());
            Log.Debug(p.StandardError.ToString());
        }

        p.WaitForExit();
        p.Close();
    }
}