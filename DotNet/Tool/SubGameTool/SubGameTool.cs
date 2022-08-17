using System.Collections.Generic;
using System.IO;

namespace ET;

public static class SubGameTool
{
    public static void CopyToSub()
    {
        InnerSubGame.CopyCodeToSub("MiniGame");
        InnerSubGame.CopyBundleToSub("MiniGame");
    }

    public static class InnerSubGame
    {
        private const string CodesPath = "../Unity/Assets/Scripts/Codes";
        private const string SubGamePath = "../SubGame";

        private const string BundlePath = "../Unity/Assets/BundleYoo";
        private const string SubBundlePath = "../SubGame";

        public static void CopyCodeToSub(string ProjectName)
        {
            List<string> ProjCodePaths = new List<string>();
            ProjCodePaths.Add($"{CodesPath}/Hotfix/Client/{ProjectName}/");
            ProjCodePaths.Add($"{CodesPath}/Hotfix/Server/{ProjectName}/");
            ProjCodePaths.Add($"{CodesPath}/Model/Client/{ProjectName}/");
            ProjCodePaths.Add($"{CodesPath}/Model/Server/{ProjectName}/");
            ProjCodePaths.Add($"{CodesPath}/HotfixView/Client/{ProjectName}/");
            ProjCodePaths.Add($"{CodesPath}/ModelView/Client/{ProjectName}/");
            CreateDirectoryIfNotExit(ProjCodePaths);

            List<string> SubGamePaths = new List<string>();
            SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Codes/Hotfix/Client/");
            SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Codes/Hotfix/Server/");
            SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Codes/Model/Client/");
            SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Codes/Model/Server/");
            SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Codes/HotfixView/Client/");
            SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Codes/ModelView/Client/");
            CreateDirectoryIfNotExit(SubGamePaths);

            for (int i = 0; i < ProjCodePaths.Count; i++)
            {
                string SrcPath = ProjCodePaths[i];
                string TatPath = SubGamePaths[i];
                FileHelper.CopyDirectory(SrcPath, TatPath);
            }
        }

        public static void CreateDirectoryIfNotExit(List<string> Paths)
        {
            for (int i = 0; i < Paths.Count; i++)
            {
                string Dir = Paths[i];
                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                    Log.Console($"创建路径！ {Dir}");
                }
            }
        }

        public static void CopyBundleToSub(string ProjectName)
        {
            string ProjBundlePath = $"{BundlePath}/{ProjectName}/";
            string SubBundleFinalPath = $"{SubBundlePath}/{ProjectName}/Bundles/";

            FileHelper.CopyDirectory(ProjBundlePath, SubBundleFinalPath);
        }
    }
}