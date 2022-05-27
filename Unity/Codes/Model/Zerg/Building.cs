namespace ET
{
    public class BuildingData
    {
        public int Width;
        public int Height;
        public int VisionRange;
        public string ArtUrl;
    }
    
    public class Building : Entity, IAwake
    {
        public BuildingData Data;
    }
}