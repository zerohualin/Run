using System.Collections.Generic;
using System.IO;

namespace ET
{
    public static class SubGameTool
    {
        public static int DoSub()
        {
            string SubGameName = Options.Instance.MiniGameName;
            switch (Options.Instance.SubGameActType)
            {
                case SubGameActType.Unity2Sub:
                {
                    CopyToSub(SubGameName);
                    return 0;
                }
                case SubGameActType.Sub2Unity:
                {
                    CopyToUnity(SubGameName);
                    return 0;
                }
                case SubGameActType.DeleteUnity:
                {
                    InnerSubGame.ClearUnityCodes(SubGameName);
                    return 0;
                }
            }

            Log.Console("好像啥也没做。");
            return 1;
        }

        public static void CopyToSub(string SubGameName)
        {
            InnerSubGame.CopyCodeToSub(SubGameName);
            InnerSubGame.CopyBundleToSub(SubGameName);
        }

        public static void CopyToUnity(string SubGameName)
        {
            InnerSubGame.CopySubToUnity(SubGameName);
        }

        public static class InnerSubGame
        {
            private const string CodesPath = "../Unity/Assets/Scripts/Codes";
            private const string SubGamePath = "../SubGame";

            private const string BundlePath = "../Unity/Assets/BundleYoo";
            private const string SubBundlePath = "../SubGame";
            private static List<string> ProjCodePaths = new List<string>();
            private static List<string> SubGamePaths = new List<string>();

            private static void SetupPath(string ProjectName)
            {
                ProjCodePaths = new List<string>();
                ProjCodePaths.Add($"{CodesPath}/Hotfix/Client/{ProjectName}/");
                ProjCodePaths.Add($"{CodesPath}/Hotfix/Server/{ProjectName}/");
                ProjCodePaths.Add($"{CodesPath}/Model/Client/{ProjectName}/");
                ProjCodePaths.Add($"{CodesPath}/Model/Server/{ProjectName}/");
                ProjCodePaths.Add($"{CodesPath}/HotfixView/Client/{ProjectName}/");
                ProjCodePaths.Add($"{CodesPath}/ModelView/Client/{ProjectName}/");

                SubGamePaths = new List<string>();
                SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Client/Hotfix/Client/");
                SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Client/Hotfix/Server/");
                SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Client/Model/Client/");
                SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Client/Model/Server/");
                SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Client/HotfixView/Client/");
                SubGamePaths.Add($"{SubGamePath}/{ProjectName}/Client/ModelView/Client/");

                CreateDirectoryIfNotExit(ProjCodePaths);
                CreateDirectoryIfNotExit(SubGamePaths);
            }

            public static void CopyCodeToSub(string ProjectName)
            {
                SetupPath(ProjectName);
                for (int i = 0; i < ProjCodePaths.Count; i++)
                {
                    string SrcPath = ProjCodePaths[i];
                    string TatPath = SubGamePaths[i];
                    FileHelper.CopyDirectory(SrcPath, TatPath);
                }
            }

            public static void CopySubToUnity(string ProjectName)
            {
                SetupPath(ProjectName);
                for (int i = 0; i < ProjCodePaths.Count; i++)
                {
                    string SrcPath = SubGamePaths[i];
                    string TatPath = ProjCodePaths[i];
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

            public static void ClearUnityCodes(string ProjectName)
            {
                SetupPath(ProjectName);
                for (int i = 0; i < ProjCodePaths.Count; i++)
                {
                    Directory.Delete(ProjCodePaths[i], true);
                    File.Delete(ProjCodePaths[i].Replace($"{ProjectName}/", $"{ProjectName}.meta"));
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
}