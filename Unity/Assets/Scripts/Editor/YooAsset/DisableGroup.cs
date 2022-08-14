// -----------------------------------------------
// Copyright © Sirius. All rights reserved.
// CreateTime: 2022/7/11   17:45:29
// -----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using YooAsset.Editor;

//自定义扩展范例
public class DisableGroup : IActiveRule
{
  public bool IsActiveGroup()
  {
    return false;
  }
}
