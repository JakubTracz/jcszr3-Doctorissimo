using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Models
{
    public class Room :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
