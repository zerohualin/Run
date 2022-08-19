using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class GObjectComponentAwakeSystem: AwakeSystem<GObjectComponent, GObject>
    {
        protected override void Awake(GObjectComponent self, GObject gObject)
        {
            self.GObject = gObject;
        }
    }

    [ComponentOf]
    public class GObjectComponent: Entity, IAwake<GObject>
    {
        public GObject GObject;
    }
}