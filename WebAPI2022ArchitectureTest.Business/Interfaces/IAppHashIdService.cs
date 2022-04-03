using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI2022ArchitectureTest.Business.Interfaces
{
    public interface IAppHashIdService
    {
        string Encode(int id);
        int Decode(string encodedId);
    }
}
