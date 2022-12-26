// using ET.EventType;
//
// namespace ET
// {
//     public class NumericChangeEvent_NoticeClient : AEventClass<NumbericChange>
//     {
//         protected override void Run(object args)
//         {
//             NumbericChange NumbericChange = args as NumbericChange;
//             if(!(NumbericChange.Parent is Unit unit))
//                 return;
//             unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(NumbericChange);
//         }
//     }
// }