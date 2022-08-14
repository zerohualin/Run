// -----------------------------------------------
// Copyright © Sirius. All rights reserved.
// CreateTime: 2022/7/11   17:47:1
// -----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YooAsset.Editor;

//自定义扩展范例
public class CollectScene : IFilterRule
{
    public bool IsCollectAsset(FilterRuleData data)
    {
        return Path.GetExtension(data.AssetPath) == ".unity";
    }
}