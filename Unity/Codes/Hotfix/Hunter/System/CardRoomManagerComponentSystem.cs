namespace ET
{
    [FriendClass(typeof (RoomManagerComponent))]
    [FriendClass(typeof (Room))]
    public static partial class RoomManagerComponentSystem
    {
        public static Room CreatCardRoom(this RoomManagerComponent self, long id)
        {
            self.CardRoom = self.AddChildWithId<Room>(id);
            self.CardRoom.AddComponent<CardTurnComponent>();
            self.CardRoom.AddComponent<CardUnitManagerComponent>();
            return self.CardRoom;
        }

        public static Room GetCardRoom(this RoomManagerComponent self)
        {
            return self.CardRoom;
        }
    }
}