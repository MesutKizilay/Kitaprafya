﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        Writer GetById(int id);
        void UpdateWriter(Writer writer);
        void DeleteWriter(Writer writer);
        void AddWriter(Writer writer);
    }
}
