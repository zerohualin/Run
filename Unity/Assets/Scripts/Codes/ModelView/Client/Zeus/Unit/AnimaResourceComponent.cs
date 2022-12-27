namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class AnimaResourceComponent : Entity, IAwake
    {
        public ReferenceCollector AnimaReferenceCollector;
    }
}