using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    public class UnitHeadBarComponentAwakeSystem: AwakeSystem<UnitHeadBarComponent>
    {
        protected override void Awake(UnitHeadBarComponent self)
        {
            // fui = mFui as HeadBar;
            self.Target =  self.Unit.GetComponent<GameObjectComponent>().GameObject.transform;
            // fui.icon.url = "";
            // fui.network.alpha = 0;
            self.Create().Coroutine();
        }
    }

    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.HeadBar))]
    public class UnitHeadBarComponentDestorySystem : DestroySystem<UnitHeadBarComponent>
    {
        protected override void Destroy(UnitHeadBarComponent self)
        {
            GRoot.inst.RemoveChild(self.fui.self);
        }
    }

    [ObjectSystem]
    public class UnitHeadBarComponentUpdateSystem: UpdateSystem<UnitHeadBarComponent>
    {
        protected override void Update(UnitHeadBarComponent self)
        {
            self.UpdatePos();
        }
    }

    [FriendOfAttribute(typeof(ET.Client.UnitHeadBarComponent))]
    [FriendOfAttribute(typeof(ET.Client.HeadBar))]
    [FriendOfAttribute(typeof(ET.Client.ProgressBarHp))]
    [FriendOfAttribute(typeof(ET.Client.ProgressBarMp))]
    public static class UnitHeadBarComponentSystem
    {
        public static async ETTask Create(this UnitHeadBarComponent self)
        {
            GObject obj = await FGUIHelper.CreateObjectAsync("MMO", "HeadBar");
            GRoot.inst.AddChild(obj);
            self.fui = self.AddChild<HeadBar>();
            FGUIHelper.BindRoot(typeof(HeadBar), self.fui, obj.asCom);
            self.fui.ProgressBarHp.self.visible = false;
            self.fui.ProgressBarMp.self.visible = false;
            self.fui.network.visible = false;

            self.fui.title.text = self.Unit.Config.Name;
            if (self.Unit.Type == UnitType.Player)
                self.fui.title.color = Color.cyan;
            if (self.Unit.Type == UnitType.NPC)
                self.fui.title.color = Color.yellow;
        }

        public static void UpdatePos(this UnitHeadBarComponent self)
        {
            if(self.fui == null)
                return;
            
            // 游戏物体的世界坐标转屏幕坐标
            var position = self.Target.position + Vector3.up * 2f;
            self.Unit2ScreenPos = Camera.main.WorldToScreenPoint(position);

            // 屏幕坐标转FGUI全局坐标
            self.HearBarScreenPos.x = self.Unit2ScreenPos.x;
            self.HearBarScreenPos.y = Screen.height - self.Unit2ScreenPos.y;

            // FGUI全局坐标转头顶血条本地坐标
            self.fui.self.position = GRoot.inst.GlobalToLocal(self.HearBarScreenPos.ToV2()).ToV3();
        }

        // public async void ShowEmoji(int emojiId)
        // {
        //     EmojiConfig emojiConfig = EmojiConfigCategory.Instance.Get(emojiId);
        //
        //     fui.icon.url = $"ui://Hotfix/{emojiConfig.EmojiResName}";
        //
        //     if (gmojiFadeEmojiTweener != null)
        //     {
        //         gmojiFadeEmojiTweener.Kill();
        //     }
        //
        //     fui.icon.alpha = 1;
        //     gmojiFadeEmojiTweener = fui.icon.TweenFade(1, 2).OnComplete(() => { fui.icon.TweenFade(0, 0.1f); });
        // }
        //
        // public void SetNetworkState(int state)
        // {
        //     fui.network.alpha = state;
        // }
        //
        // public void SetTitle(string title)
        // {
        //     fui.title.text = title;
        // }
        //
        // public override void Dispose()
        // {
        //     if (IsDisposed)
        //         return;
        //     this.DomainScene().GetComponent<FUIComponent>().Get(Play.UIResName).Remove(Unit.Id.ToString());
        //     base.Dispose();
        // }
    }
}