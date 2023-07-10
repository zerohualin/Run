using FairyGUI;
using UnityEngine;

namespace ET
{
    public static class FUIPackageHelper
    {
        public static async ETTask AddFGUIPackageAsync(string packageName)
        {
            string path = $"{ConstValueView.ZeusBundlePath}/{packageName}/FUI/{packageName}_fui.bytes";
            var package = UIPackage.GetByName(packageName);
            if (package != null)
                return;
            var handle = await YooAssetProxy.Zeus.LoadAssetETAsync<TextAsset>(path);
            byte[] bytes = handle.GetAsset<TextAsset>().bytes;
            UIPackage.AddPackage(bytes, packageName, OnTextureLoadComplete);
        }

        #pragma warning disable
        public static async void OnTextureLoadComplete(string name, string extension, System.Type type, PackageItem item)
        {
            string[] splits = name.Split('_');
            string SubName = splits[0];
            if (item.type == PackageItemType.Atlas)
            {
                string texName = name.Replace("_fui", "");
                string path = $"{ConstValueView.ZeusBundlePath}/{SubName}/FUI/{texName}.png";
                var handle = await YooAssetProxy.Zeus.LoadAssetETAsync<Texture>(path);
                Texture t = handle.GetAsset<Texture>();
                item.owner.SetItemAsset(item, t, DestroyMethod.Custom);
            }
        }
    }
}