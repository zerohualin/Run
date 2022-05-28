using UnityEngine;

namespace ET
{
    public class UpdateGridGroundEventHandler: AEvent<EventType.UpdateGridNode>
    {
        protected override void Run(EventType.UpdateGridNode args)
        {
            var view = args.Node.GetComponent<GridNodeViewComponent>();
            if (view == null)
                return;

            var mat = view.GroundStateObj.GetComponentInChildren<Renderer>().material;
            if (args.Node.IsBarrier)
            {
                mat.color = Color.gray;
            }
            else if (args.Node.CanBuild)
            {
                mat.color = Color.white;
            }
            else
            {
                mat.color = Color.red;
            }
            view.VisionObj.SetActive(!args.Node.CanView);
        }
    }
}