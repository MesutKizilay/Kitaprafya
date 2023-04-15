using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string UserSurName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
    }
}
