using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(PlayerComponent))]
    public static class PlayerComponentSystem
    {
        public static Player GetPlayer(this PlayerComponent self, long playerId)
        {
            foreach (var VARIABLE in self.Children)
            {
                if (VARIABLE.Value.Id == playerId)
                {
                    return VARIABLE.Value as Player;
                }
            }
            return null;
        }
    }
}