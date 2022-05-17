namespace ET
{
    [FriendClass(typeof (RoomManagerComponent))]
    [FriendClass(typeof (Room))]
    public static partial class RoomManagerComponentSystem
    {
        public static Room CreatCardRoom(this RoomManagerComponent self, long id)
        {
            self.CardRoom = self.AddChildWithId<Room>(id);
            
            self.CardRoom.AddComponent<CardPlayerComponent>();
            self.CardRoom.AddComponent<CardUnitManagerComponent>();
            self.CardRoom.AddComponent<CardTurnComponent>();
            
            return self.CardRoom;
        }

        public static Room GetCardRoom(this RoomManagerComponent self)
        {
            return self.CardRoom;
        }
    }
}