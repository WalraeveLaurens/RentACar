using RentACar.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Interfaces
{
    public interface IAutoRepository
    {
        List<Auto> GetAll();
        Auto GetById(int id);
        void Add(Auto auto);
    }
}
