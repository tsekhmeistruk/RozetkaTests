namespace RozetkaTesting.Framework.DataModels
{
    public class FirstLevelMenuItem
    {
        public string topic { get; set; }
        public string url { get; set; }
        public SecondLevelMenuItem[] subItems { get; set; }
    }
}
