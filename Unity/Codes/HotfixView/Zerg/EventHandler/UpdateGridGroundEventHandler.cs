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
            else if(args.Node.IsMineral)
            {
                mat.color = Color.yellow;
            }
            else if (args.Node.IsBuilded)
            {
                mat.color = Color.red;
            }
            else
            {
                mat.color = Color.white;
            }
            view.VisionObj.SetActive(!args.Node.CanView);
        }
    }
}