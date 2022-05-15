using UnityEngine;

namespace ET
{
    public class UserInputComponent : Entity, IAwake, IUpdate
    {
        public bool RightMouseDown { get; set; }
        public bool RightMouseUp { get; set; }
        
        public bool LeftMouseDown { get; set; }
        public bool LeftMouseUp { get; set; }

        public bool ADown_long { get; set; }
        public bool ADown { get; set; }
        public bool AUp { get; set; }

        public bool ADouble { get; set; }
        public double ALastClickTime { get; set; }

        public double DLastClickTime { get; set; }
        public bool DDown { get; set; }
        public bool DUp { get; set; }

        public bool DDouble { get; set; }
        public bool DDown_long { get; set; }

        public double QLastClickTime { get; set; }
        public bool QDown { get; set; }
        public bool QUp { get; set; }

        public bool QDouble { get; set; }
        public bool QDown_long { get; set; }

        public bool WDown_long { get; set; }
        public bool WDown { get; set; }
        public bool WUp { get; set; }
        public bool WDouble { get; set; }
        public double WLastClickTime { get; set; }

        public bool EDown_long { get; set; }
        public bool EDown { get; set; }
        public bool EUp { get; set; }
        public bool EDouble { get; set; }
        public double ELastClickTime { get; set; }

        public bool RDown_long { get; set; }
        public bool RDown { get; set; }
        public bool RUp { get; set; }
        public bool RDouble { get; set; }
        public double RLastClickTime { get; set; }

        public bool JDown_long { get; set; }
        public bool JDown { get; set; }
        public bool JUp { get; set; }
        public bool JDouble { get; set; }
        public double JLastClickTime { get; set; }

        public bool SDown_long { get; set; }
        public bool SDown { get; set; }
        public bool SUp { get; set; }
        public bool SDouble { get; set; }
        public double SLastClickTime { get; set; }

        public bool SpaceDown_long { get; set; }
        public bool SpaceDown { get; set; }
        public bool SpaceUp { get; set; }
        public double SpaceLastClickTime { get; set; }

        public long currentTime;
        public long startTime;
    }
}