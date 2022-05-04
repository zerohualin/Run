namespace ET
{
    [FriendClass(typeof(B2S_CollisionDispatcherComponent))]
    [FriendClass(typeof(B2S_ColliderComponent))]
    public static class B2S_CollisionDispatcherComponentSystem
    {
        /// <summary>
        /// 处理碰撞开始，a碰到了b
        /// </summary>
        public static void HandleCollisionStart(this B2S_CollisionDispatcherComponent self, Unit a, Unit b)
        {
            if (self.B2SCollisionHandlers.TryGetValue(a.GetComponent<B2S_ColliderComponent>().CollisionHandlerName, out var collisionHandler))
            {
                collisionHandler.HandleCollisionStart(a, b);
            }
        }

        /// <summary>
        /// 处理碰撞持续
        /// </summary>
        public static void HandleCollisionSustain(this B2S_CollisionDispatcherComponent self, Unit a, Unit b)
        {
            if (self.B2SCollisionHandlers.TryGetValue(a.GetComponent<B2S_ColliderComponent>().CollisionHandlerName, out var collisionHandler))
            {
                collisionHandler.HandleCollisionSustain(a, b);
            }
        }

        /// <summary>
        /// 处理碰撞结束
        /// </summary>
        public static void HandleCollsionEnd(this B2S_CollisionDispatcherComponent self, Unit a, Unit b)
        {
            if (self.B2SCollisionHandlers.TryGetValue(a.GetComponent<B2S_ColliderComponent>().CollisionHandlerName, out var collisionHandler))
            {
                collisionHandler.HandleCollisionEnd(a, b);
            }
        }
    }
}