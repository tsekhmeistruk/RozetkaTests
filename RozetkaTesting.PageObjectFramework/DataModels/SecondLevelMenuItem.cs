namespace RozetkaTesting.Framework.DataModels
{
    public class SecondLevelMenuItem
    {
        public string subTopic { get; set; }
        public string subUrl { get; set; }
        public ThirdLevelMenuItem subSubItem { get; set; }
    }
}
