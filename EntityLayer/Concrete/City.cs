﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class City:IEntity
    {
        [Key]
        public int CityId { get; set; }

        [StringLength(30)]
        public string CityName { get; set; }
    }
}
