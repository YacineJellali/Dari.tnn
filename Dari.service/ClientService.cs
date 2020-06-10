using Dari.Data.Infrastructure;
using Dari.db;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.service
{
    public class ClientService: Service<Client>, IClientService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public ClientService():base(UTK)
        { }

        public IEnumerable<Client> FindClientByName(string Clientname)
        {
            IEnumerable<Client> EventDomain = GetMany();
            if (!String.IsNullOrEmpty(Clientname))
            {
                EventDomain = GetMany(x => x.Nom.Contains(Clientname));
            }
            return EventDomain;
        }


    }



}


        

   




