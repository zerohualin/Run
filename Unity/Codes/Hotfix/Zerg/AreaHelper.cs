using System;

namespace ET
{
    public static class AreaHelper
    {
        public static AreaData GetArea(float inputX, float inputY, int width, int height)
        {
            int startX = 0;
            int startY = 0;

            int remainderX = width % 2;
            int roundX = 0;
            if (remainderX == 1)
            {
                roundX = (int)Math.Round(inputX);
                startX = roundX - width / 2;
            }
            else
            {
                roundX = (int)Math.Ceiling(inputX);
                startX = roundX - width / 2;
            }
            
            int remainderY = height % 2;
            int roundY = 0;
            if (remainderY == 1)
            {
                roundY = (int)Math.Round(inputY);
                startY = roundY - height / 2;
            }
            else
            {
                roundY = (int)Math.Ceiling(inputY);
                startY = roundY - height / 2;
            }

            return new AreaData() { StartPosX = startX, StartPosY = startY, Width = width, Height = height };
        }
    }
}