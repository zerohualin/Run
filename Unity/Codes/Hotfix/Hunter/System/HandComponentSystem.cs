using Cfg.zerg;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof (LubanComponent))]
    public class HandComponentAwakeSystem: AwakeSystem<HandComponent>
    {
        public override void Awake(HandComponent self)
        {
            var dataList = Game.Scene.GetComponent<LubanComponent>().Tables.TbBuilding.DataList;
            for (int i = 0; i < dataList.Count; i++)
            {
                self.AddCard(dataList[i].Id);
            }
        }
    }

    [FriendClass(typeof (HandComponent))]
    public static class HandComponentSystem
    {
        public static void AddCard(this HandComponent self, string cardConfigId)
        {
            var card = self.AddChild<BuildingData, string>(cardConfigId);
            self.AddCard(card);
        }

        public static void AddCard(this HandComponent self, BuildingData card)
        {
            self.Cards.Add(card);
        }

        public static void RemoveCard(this HandComponent self, BuildingData card)
        {
            self.Cards.Remove(card);
        }

        public static void TryUseCard(this HandComponent self, BuildingData card)
        {
            self.RemoveCard(card);
            Game.EventSystem.Publish(new EventType.ChangeCard() { ZoneScene = self.DomainScene() });
        }

        public static void TryAddRandomCard(this HandComponent self)
        {
            var dataList = Game.Scene.GetComponent<LubanComponent>().Tables.TbBuilding.DataList;
            int randomCardIndex = Random.Range(0, dataList.Count);
            self.AddCard(dataList[randomCardIndex].Id);
            Game.EventSystem.Publish(new EventType.ChangeCard() { ZoneScene = self.DomainScene() });
        }
    }
}