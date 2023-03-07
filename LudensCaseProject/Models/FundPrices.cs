namespace LudensCaseProject.Models
{
    public class FundPrices
    {
        public Guid Id { get; set; }
        public Guid FundId { get; set; }

        public DateTime Date { get; set; }

        public double ClosePrice { get; set; }
    }
}
