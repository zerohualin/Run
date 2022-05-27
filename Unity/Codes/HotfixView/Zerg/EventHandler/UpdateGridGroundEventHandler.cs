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

            view.GroundStateObj.GetComponentInChildren<Renderer>().material.color = args.Node.Builded? Color.red : Color.white;
            view.VisionObj.SetActive(!args.Node.CanView);
        }
    }
}