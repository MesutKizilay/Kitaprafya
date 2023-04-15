using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class District: IEntity
    {
        [Key]
        public int DistrictId { get; set; }
        [StringLength(30)]
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
