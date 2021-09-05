namespace BLL.DTO
{
    public class MedicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double RefundPercentage { get; set; }
    }
}
