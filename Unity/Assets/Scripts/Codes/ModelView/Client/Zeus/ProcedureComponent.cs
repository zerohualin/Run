
namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ProcedureComponent : Entity, IAwake
    {
        public string TargetMap;
        public bool IsFinishLoadMapScene;
        public bool IsFinishCreateMyUnit;
    }
}