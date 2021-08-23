using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace DAL.Models
{
    public class Medication :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [DisplayName("Refund percentage")]
        public double RefundPercentage { get; set; }
    }
}
