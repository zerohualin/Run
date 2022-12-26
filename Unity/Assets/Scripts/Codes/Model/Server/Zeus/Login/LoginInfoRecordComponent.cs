using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class LoginInfoRecordComponent : Entity, IAwake, IDestroy, IAwake<long>
    {
        public Dictionary<long, int> AccountLoginINfoDict = new Dictionary<long, int>();
    }
}