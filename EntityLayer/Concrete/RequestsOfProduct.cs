using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RequestsOfProduct:IEntity
    {
        [Key]
        public int RequestOfProductId { get; set; }
        
        public int OwnerUserId { get; set; }
      
        
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        [StringLength(200)]
        public string RequestNote { get; set; }

        public bool RequestStatus { get; set; }
        public bool HistoryStatus { get; set; }
    }
}
