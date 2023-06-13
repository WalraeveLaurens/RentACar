﻿using RentACar.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Interfaces
{
    public interface IArrangementRepository
    {
        List<Arrangement> GetAll();
        void Add(Arrangement arrangement);
    }
}
