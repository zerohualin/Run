using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(Card))]
    public class HandComponent: Entity, IAwake
    {
        public List<Card> Cards = new List<Card>();
    }
}