namespace ET
{
    public enum SlgAttackResultType
    {
        None,
        Hurt,
        Dead
    }

    public class SlgAttackResult
    {
        public SlgAttackResultType ResultType;
        public SlgUnit Attacker;
        public SlgUnit Defender;
        public int Hurt;
    }
}