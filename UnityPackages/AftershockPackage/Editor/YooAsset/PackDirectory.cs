// // -----------------------------------------------
// // Copyright © Sirius. All rights reserved.
// // CreateTime: 2022/7/11   17:46:32
// // -----------------------------------------------
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;
// using YooAsset.Editor;
//
// //自定义扩展范例
// public class PackDirectory : IPackRule
// {
//   string IPackRule.GetBundleName(PackRuleData data)
//   {
//     return Path.GetDirectoryName(data.AssetPath); //"Assets/Config/test.txt" --> "Assets/Config"
//   }
//
//   public PackRuleResult GetPackRuleResult(PackRuleData data)
//   {
//     throw new System.NotImplementedException();
//   }
//
//   public bool IsRawFilePackRule()
//   {
//     throw new System.NotImplementedException();
//   }
// }