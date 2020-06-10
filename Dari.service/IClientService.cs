
using Dari.db;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.service
{
    public interface IClientService : IService<Client>
    {
        IEnumerable<Client> FindClientByName(string Clientname);
        


    }
}
