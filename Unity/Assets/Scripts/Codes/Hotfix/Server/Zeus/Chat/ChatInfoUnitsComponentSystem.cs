namespace ET.Server
{
    [FriendOf(typeof (ET.Server.ChatInfoUnitsComponent))]
    public static class ChatInfoUnitsComponentSystem
    {
        public static ChatInfoUnit Get(this ChatInfoUnitsComponent self, long id)
        {
            self.ChatInfoUnitDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit);
            return chatInfoUnit;
        }

        public static void Add(this ChatInfoUnitsComponent self, ChatInfoUnit chatInfoUnit)
        {
            if (self.ChatInfoUnitDict.ContainsKey(chatInfoUnit.Id))
            {
                Log.Error($"chatinfounit is exits! {chatInfoUnit.Id}");
                return;
            }

            self.ChatInfoUnitDict.Add(chatInfoUnit.Id, chatInfoUnit);
        }

        public static void Remove(this ChatInfoUnitsComponent self, long id)
        {
            if (self.ChatInfoUnitDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit))
            {
                self.ChatInfoUnitDict.Remove(id);
                chatInfoUnit?.Dispose();
            }
        }
    }
}