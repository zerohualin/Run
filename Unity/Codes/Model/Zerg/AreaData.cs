namespace ET
{
    public class AreaData
    {
        public int StartPosX;
        public int StartPosY;

        public int EndPosX
        {
            get
            {
                return StartPosX + Width - 1;
            }
        }

        public int EndPosY
        {
            get
            {
                return StartPosY + Height - 1;
            }
        }
        
        public int Width;
        public int Height;
    }
}