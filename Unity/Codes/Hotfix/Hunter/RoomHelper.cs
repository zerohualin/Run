namespace ET
{
    public static class RoomHelper
    {
        public static Room GetCardRoom(this Scene ZoneScene)
        {
            return ZoneScene.GetComponent<RoomManagerComponent>().GetCardRoom();
        }
    }
}