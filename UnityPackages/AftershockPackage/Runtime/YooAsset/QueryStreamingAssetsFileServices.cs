// // 内置文件查询服务类
//
// using YooAsset;
//
// public class QueryStreamingAssetsFileServices : IQueryServices
// {
//     public bool QueryStreamingAssets(string fileName)
//     {
//         // 注意：使用了BetterStreamingAssets插件，使用前需要初始化该插件！
//         string buildinFolderName = YooAssets.GetStreamingAssetBuildinFolderName();
//         return BetterStreamingAssets.FileExists($"{buildinFolderName}/{fileName}");
//     }
// }