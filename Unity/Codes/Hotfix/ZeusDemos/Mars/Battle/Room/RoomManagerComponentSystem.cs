namespace ET
{
    [ObjectSystem]
    public class RoomManagerComponentAwakeSystem: AwakeSystem<RoomManagerComponent>
    {
        public override void Awake(RoomManagerComponent self)
        {
        }
    }

    [ObjectSystem]
    public class RoomManagerComponentDestroySystem: DestroySystem<RoomManagerComponent>
    {
        public override void Destroy(RoomManagerComponent self)
        {
            self.LobbyRooms.Clear();
            self.BattleRoom?.Dispose();
        }
    }

    [FriendClass(typeof(RoomManagerComponent))]
    [FriendClass(typeof(Room))]
    public static class RoomManagerComponentSystem
    {
        public static Room CreateLobbyRoom(this RoomManagerComponent self, long id)
        {
            Room room = self.AddChildWithId<Room>(id);
            self.LobbyRooms.Add(room.Id, room);
            return room;
        }

        public static Room GetBattleRoom(this RoomManagerComponent self)
        {
            return self.BattleRoom;
        }

        public static Room GetOrCreateBattleRoom(this RoomManagerComponent self)
        {
            if (self.BattleRoom == null)
            {
                self.BattleRoom = self.AddChild<Room>();

                self.BattleRoom.AddComponent<UnitComponent>();
                // BattleRoom.AddComponent<LSF_Component>();
                // BattleRoom.AddComponent<LSF_TimerComponent>();
                // BattleRoom.AddComponent<MouseTargetSelectorComponent>();
                // BattleRoom.AddComponent<MapClickCompoent>();
                // BattleRoom.AddComponent<LSF_TickComponent>();
                // BattleRoom.AddComponent<BattleEventSystemComponent>();
                // BattleRoom.AddComponent<CDComponent>();
                self.BattleRoom.AddComponent<B2S_WorldComponent>();
                self.BattleRoom.AddComponent<B2S_WorldColliderManagerComponent>();
                self.BattleRoom.AddComponent<B2S_CollisionListenerComponent>();
                self.BattleRoom.AddComponent<MouseTargetSelectorComponent>();
                self.BattleRoom.AddComponent<MapClickCompoent>();
            }

            return self.BattleRoom;
        }

        public static Room GetLobbyRoom(this RoomManagerComponent self, long id)
        {
            if (self.LobbyRooms.TryGetValue(id, out var room))
            {
                return room;
            }
            else
            {
                Log.Warning($"请求的Room Id不存在 ： {id}");
                return null;
            }
        }

        /// <summary>
        /// 根据PlayerId获取其作为房主的房间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Room GetLobbyRoomByPlayerId(this RoomManagerComponent self, long playerId)
        {
            foreach (var room in self.LobbyRooms)
            {
                if (room.Value.RoomHolderPlayerId == playerId)
                {
                    return room.Value;
                }
            }

            Log.Error($"playerId作为房主的房间不存在 ： {playerId}");
            return null;
        }

        public static void RemoveLobbyRoom(this RoomManagerComponent self, long id)
        {
            if (self.LobbyRooms.TryGetValue(id, out var room))
            {
                room.Dispose();
                self.LobbyRooms.Remove(id);
            }
        }

        public static void RemoveAllLobbyRooms(this RoomManagerComponent self)
        {
            foreach (var room in self.LobbyRooms)
            {
                room.Value.Dispose();
            }
            self.LobbyRooms.Clear();
        }
    }
}