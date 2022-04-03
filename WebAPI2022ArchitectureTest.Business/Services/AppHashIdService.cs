using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Business.Interfaces;

namespace WebAPI2022ArchitectureTest.Business.Services
{
    public class AppHashIdService : IAppHashIdService
    {
        public const string SALT = "THIS IS MY SALT";
        public readonly Hashids Hasher;

        public AppHashIdService() 
        {
            Hasher = new Hashids(SALT, 10);
        }

        public int Decode(string encodedId) => Hasher.Decode(encodedId).FirstOrDefault();

        public string Encode(int id) => Hasher.Encode(id);   
    }
}