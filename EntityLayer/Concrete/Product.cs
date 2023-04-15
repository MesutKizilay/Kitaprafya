using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string ProductImage { get; set; }

        [StringLength(2000)]
        public string ProductDescription { get; set; }

        [StringLength(20)]
        public string Language { get; set; }

        public short NoOfPage { get; set; }
        public DateTime PublishingDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
