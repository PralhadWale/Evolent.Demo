using Evolent.Demo.Data.Core;
using Evolent.Demo.Data.Entity;
using Evolent.Demo.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolent.Demo.Domain.Services.Master
{
    public class ContactMasterService : IContactMasterService
    {
        IGenericRepository<ContactMaster> contactRepository = null;
        public ContactMasterService(IGenericRepository<ContactMaster> _contactRepository)
        {
            contactRepository = _contactRepository;
        }

        public ContactMaster Add(ContactMaster contactMaster)
        {
            contactMaster.ContactId =  contactRepository.Add(contactMaster);
            return contactMaster;
        }

        public ContactMaster Update(ContactMaster contactMaster)
        {
            contactRepository.Update(contactMaster);
            return contactMaster;
        }

        public List<ContactMaster> GetAll()
        {
            return contactRepository.GetAll().ToList();
        }


        public ContactMaster Get(int contactId)
        {
            return contactRepository.Find(contactId);
        }

        public bool Delete(int contactId)
        {
            return Delete(Get(contactId));
        }


        private bool Delete(ContactMaster contact)
        {
            return contactRepository.Delete(contact);
        }
    }
}
