using HashidsNet;
using WebAPI2022ArchitectureTest.Application.Common.Interfaces;

namespace WebAPI2022ArchitectureTest.Infrastructure.Services
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