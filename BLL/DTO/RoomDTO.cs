using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTO
{
    public class RoomDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
