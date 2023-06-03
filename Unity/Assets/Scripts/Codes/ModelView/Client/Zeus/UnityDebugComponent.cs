using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class UnityDebugComponent : Entity, IUpdate, IAwake
    {
    }
}
