using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer:IEntity
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(20)]
        public string WriterName { get; set; }
        
        [StringLength(20)]
        public string WriterSurname { get; set; }
        
        [StringLength(200)]
        public string WriterImage { get; set; }
        
        [StringLength(200)]
        public string WriterAbout { get; set; }
        
        [StringLength(100)]
        public string WriterMail { get; set; }
    }
}
