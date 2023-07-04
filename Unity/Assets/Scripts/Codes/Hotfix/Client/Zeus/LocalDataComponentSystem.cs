using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using MongoDB.Bson;

namespace ET.Client
{
    public static class LocalDataComponentSystem
    {
        public static void Init(this LocalDataComponent self, string FilePath, string FileName)
        {
            self.FilePath = FilePath;
            self.FileName = FileName;

            string Path = $"{self.FilePath}/{self.FileName}.json";
            
            if (File.Exists(Path))
            {
                string Json = File.ReadAllText(Path);
                if (Json != "")
                {
                    LocalDataComponent localDataComponent = JsonHelper.FromJson<LocalDataComponent>(Json);
                    self.IntDic = localDataComponent.IntDic;
                    self.StringDic = localDataComponent.StringDic;
                }
            }
            else
            {
                File.Create(Path);
            }
        }
        
        public static void Set(this LocalDataComponent self, string key, int value)
        {
            self.IntDic[key] = value;
            self.SaveAll();
        }
        
        public static void Set(this LocalDataComponent self, string key, string value)
        {
            self.StringDic[key] = value;
            self.SaveAll();
        }

        public static string GetString(this LocalDataComponent self, string key)
        {
            self.StringDic.TryGetValue(key,out string result);
            return result;
        }
        
        public static int GetInt(this LocalDataComponent self, string key)
        {
            self.IntDic.TryGetValue(key,out int result);
            return result;
        }

        public static void SaveAll(this LocalDataComponent self)
        {
            string json = self.ToJson();
            byte[] bytes = json.ToUtf8();
            FileHelper.SaveFile(self.FilePath, self.FileName, ".json", bytes);
        }
    }
}