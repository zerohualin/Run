// -----------------------------------------------
// Copyright © Sirius. All rights reserved.
// CreateTime: 2022/7/11   17:46:9
// -----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using YooAsset.Editor;

//自定义扩展范例
public class AddressByPath : IAddressRule
{
  string IAddressRule.GetAssetAddress(AddressRuleData data)
  {
    return data.AssetPath;
  }
}