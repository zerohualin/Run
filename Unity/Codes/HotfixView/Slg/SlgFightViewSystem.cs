using DG.Tweening;
using UnityEngine;

namespace ET
{
    public class EventView_Update_Unit_AttackResult : AEvent<EventTypeView.Update_Unit_AttackResult>
    {
        protected override async ETTask Run(EventTypeView.Update_Unit_AttackResult args)
        {
            var results = args.ZoneScene.GetComponent<SlgComponent>().SlgAttackResults;
            var SlgFightView = Game.Scene.GetComponent<SlgFightView>();
            for (int i = 0; i < results.Count; i++)
            {
                await SlgFightView.ShowResult(results[i]);
            }
        }
    }

    public static class SlgFightViewSystem
    {
        public static async ETTask ShowResult(this SlgFightView self, SlgAttackResult slgAttackResult)
        {
            switch (slgAttackResult.ResultType)
            {
                case SlgAttackResultType.None:

                    break;
                case SlgAttackResultType.Hurt:
                    var defenderObj = slgAttackResult.Defender.GetComponent<SlgUnitRoleView>().Obj;
                    var acttackerObj = slgAttackResult.Attacker.GetComponent<SlgUnitRoleView>().Obj;
                    var startPos = acttackerObj.transform.position;
                    await acttackerObj.transform.DOMoveAsync(defenderObj.transform.position, 0.2f);
                    await acttackerObj.transform.DOMoveAsync(startPos, 0.2f);
                    break;
                case SlgAttackResultType.Dead:

                    break;
            }
        }
    }
}