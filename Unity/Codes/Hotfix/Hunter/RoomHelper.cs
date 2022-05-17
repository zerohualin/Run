namespace ET
{
    [FriendClass(typeof (CardPlayerComponent))]
    public static class RoomHelper
    {
        public static Room GetCardRoom(this Scene ZoneScene)
        {
            return ZoneScene.GetComponent<RoomManagerComponent>().GetCardRoom();
        }

        public static CardPlayer GetMyPlayer(this Scene ZoneScene)
        {
            var room = GetCardRoom(ZoneScene);
            return room.GetComponent<CardPlayerComponent>().CardPlayerA;
        }
    }
}