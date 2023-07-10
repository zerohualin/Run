using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class AvatarComponentAwakeSystem: AwakeSystem<AvatarComponent>
    {
        protected override void Awake(AvatarComponent self)
        {
        }
    }

    [ObjectSystem]
    public class AvatarComponentDestorySystem: DestroySystem<AvatarComponent>
    {
        protected override void Destroy(AvatarComponent self)
        {
            self.RoleId = 0;
            GameObject.Destroy(self.RoleObj);
        }
    }

    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.MoveComponent))]
    public class AvatarComponentUpdateSystem : UpdateSystem<AvatarComponent>
    {
        protected override void Update(AvatarComponent self)
        {
            AnimationComponent AnimationComponent = self.GetComponent<AnimationComponent>();
            if(AnimationComponent == null)
                return;
            
            self.RoleObj.transform.localEulerAngles = Vector3.zero;
            self.RoleObj.transform.localPosition = Vector3.zero;
            
            Unit unit = self.GetParent<Unit>();
            int N = unit.GetComponent<MoveComponent>().N;
            if (N == 0)
            {
                AnimationComponent.PlayIdle();;
            }
            else
            {
                AnimationComponent.PlayRun();;
            }
        }
    }

    [FriendOfAttribute(typeof (ET.Client.AvatarComponent))]
    public static class AvatarComponentSystem
    {
        public static async ETTask Init(this AvatarComponent self)
        {
            await self.CreateRoleModel();
            self.SetObjParent(self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.transform);
            self.AddComponent<AnimationComponent>();
        }

        public static async ETTask CreateRoleModel(this AvatarComponent self, int playerInfo = 0)
        {
            //string path = "Assets/BundleYoo/Zeus/Model/Cube - Sci Fi Underworld City/Prefabs/Customize Character here/04 Customized Samples/Hacker.prefab";
            string path = $"{ConstValueView.ZeusBundlePath}/Common/Hacker.prefab";
            var unitObj = await YooAssetProxy.Zeus.LoadAssetETAsync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(unitObj.GetAssetObject<GameObject>(), GlobalComponent.Instance.Unit, true);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            go.transform.localEulerAngles = Vector3.zero;

            AnimaResourceComponent animaResourceComponent = Root.Instance.Scene.GetComponent<AnimaResourceComponent>();
            animaResourceComponent.SetAnimaReferenceCollector(go);

            self.RoleObj = go;
        }

        public static void SetObjParent(this AvatarComponent self, Transform fTra)
        {
            self.RoleObj.transform.parent = fTra;
            self.RoleObj.transform.localPosition = Vector3.zero;
            self.RoleObj.transform.localEulerAngles = Vector3.zero;
        }

        public static void UpdateRoleModel(this AvatarComponent self)
        {
            // if (RoleId != playerInfo.RoleId)
            // {
            //     CreateRoleModel(playerInfo);
            //     GetComponent<AnimationComponent>().Reload();
            // }
        }
    }
}