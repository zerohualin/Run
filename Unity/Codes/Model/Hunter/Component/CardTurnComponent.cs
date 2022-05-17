using System.Collections.Generic;

namespace ET
{
    public class CardTurnComponent: Entity, IAwake
    {
        public int Num;
        public LinkedList<CardPlayer> CardPlayers = new LinkedList<CardPlayer>();
        public LinkedListNode<CardPlayer> Current = null;
    }
}