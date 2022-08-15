using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShellCmdHelper
{
    public static string GetArg(string argName)
    {
        {
#if UNITY_EDITOR
            //在这里分析shell传入的参数， 还记得上面我们说的哪个 project-$1 这个参数吗？
            //这里遍历所有参数，找到 project开头的参数， 然后把-符号 后面的字符串返回，
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith(argName))
                {
                    return arg.Split("="[0])[1];
                }
            }
#endif
        }
        Debug.LogError($"这个参数未输入！ {argName}");
        return "";
    }
}
