namespace ET
{
    public class AI_OthersTurn: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            if (!aiComponent.GetParent<CardPlayer>().IsMyTurn())
            {
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Log.Info("AI 进入等待。");
        }
    }
}