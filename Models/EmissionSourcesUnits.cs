namespace EmissionFactorTask_3pmetrics.Models
{
    public class EmissionSourcesUnits
    {
        public int id { get; set; }
        public string unitIDHash { get; set; }
        public string unitTitle { get; set;}
        public string unitSymbol { get; set;}
        public int pointID { get; set;}
        public DateTime creationDate { get; set; }
    }
}
