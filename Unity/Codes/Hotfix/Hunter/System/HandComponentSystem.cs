using UnityEngine;

namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class HandComponentAwakeSystem: AwakeSystem<HandComponent>
    {
        public override void Awake(HandComponent self)
        {
            var dataList = Game.Scene.GetComponent<LubanComponent>().Tables.TbCardConfig.DataList;
            for (int i = 0; i < dataList.Count; i++)
            {
                self.AddCard(dataList[i].Id);
            }
        }
    }

    [FriendClass(typeof (HandComponent))]
    public static class HandComponentSystem
    {
        public static void AddCard(this HandComponent self, int cardConfigId)
        {
            var card = self.AddChild<Card, int>(cardConfigId);
            self.AddCard(card);
        }

        public static void AddCard(this HandComponent self, Card card)
        {
            self.Cards.Add(card);
        }

        public static void RemoveCard(this HandComponent self, Card card)
        {
            self.Cards.Remove(card);
        }

        public static void TryUseCard(this HandComponent self, Card card)
        {
            self.RemoveCard(card);
            Game.EventSystem.Publish(new EventType.ChangeCard() { ZoneScene = self.DomainScene() });
        }

        public static void TryAddRandomCard(this HandComponent self)
        {
            var dataList = Game.Scene.GetComponent<LubanComponent>().Tables.TbCardConfig.DataList;
            int randomCardIndex = Random.Range(0, dataList.Count);
            self.AddCard(dataList[randomCardIndex].Id);
            Game.EventSystem.Publish(new EventType.ChangeCard() { ZoneScene = self.DomainScene() });
        }
    }
}