using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTO
{
    public class MedicationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double RefundPercentage { get; set; }
    }
}
