using Evolent.Demo.Data.Entity.Master;
using System.Collections.Generic;

namespace Evolent.Demo.Domain.Services.Master
{
    public interface IContactMasterService
    {
   
        List<ContactMaster> GetAll();
        ContactMaster Get(int contactId);
        bool Delete(int contactId);
        ContactMaster Add(ContactMaster contactMaster);
        ContactMaster Update(ContactMaster contactMaster);
    }
}