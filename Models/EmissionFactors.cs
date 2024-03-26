namespace EmissionFactorTask_3pmetrics.Models
{
    public class EmissionFactors
    {
        public int id { get; set; }
        public string emissionFactor { get; set; }
        public string emissionIDHash { get; set; }
        public string emissionFactorTittle { get; set; }
        public int catalogID { get; set; }
        public DateTime effectiveStartDate { get; set; }
        public DateTime effectiveEndDate { get; set; }
        public DateTime creationDate { get; set; }
    }
}
