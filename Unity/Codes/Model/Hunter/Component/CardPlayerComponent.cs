using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof (CardPlayer))]
    public class CardPlayerComponent : Entity, IAwake
    {
        public CardPlayer CardPlayerA;
        public CardPlayer CardPlayerB;
    }
}