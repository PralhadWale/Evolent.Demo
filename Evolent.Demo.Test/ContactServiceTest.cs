using Evolent.Demo.Data.Core;
using Evolent.Demo.Data.Entity.Master;
using Evolent.Demo.Domain.Services.Master;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Evolent.Demo.Test
{
    
    public class ContactServiceTest
    {

        IGenericRepository<ContactMaster> _contactRepository;
        IContactMasterService _contactService;

        public  ContactServiceTest()
        {
            var repo = new Mock<IGenericRepository<ContactMaster>>();
            repo.Setup(r => r.Find(It.IsAny<int>())).Returns(new ContactMaster
            {
                ContactId = 1,
                FirstName = "Test1",
                LastName = "TestLast",
                Email = "test@test.com",
                PhoneNumber = "123123123",
                IsActive = true
            });

            repo.Setup(r => r.GetAll()).Returns(new System.Collections.Generic.List<ContactMaster> {
               new ContactMaster {
                ContactId=1,
                FirstName="Test1",
                LastName="TestLast",
                Email="test@test.com",
                PhoneNumber="12312",
                IsActive=true
            },
               new ContactMaster {
                ContactId=2,
                FirstName="Test2",
                LastName="TestLast2",
                Email="test2@test2.com",
                PhoneNumber="12123231",
                IsActive=true
            }
            });

            repo.Setup(r => r.Update(It.IsAny<ContactMaster>())).Returns(true);

            repo.Setup(r => r.Add(It.IsAny<ContactMaster>())).Returns(1);

            repo.Setup(r => r.Delete(It.IsAny<ContactMaster>())).Returns(true);

            _contactRepository = repo.Object;
            _contactService = new ContactMasterService(_contactRepository);
        }

        [Fact]
        public void ShouldReturnCorrectContact()
        {
            var contact = _contactService.Get(1);
            Assert.Equal(1, contact.ContactId);
        }

        [Fact]
        public void ShouldReturnAllContacts()
        {
            var users = _contactService.GetAll();
            Assert.Equal(2,users.Count);
        }

        [Fact]
        public void ShouldReturnNewContact()
        {
            var result = _contactService.Add(new ContactMaster());
            Assert.NotNull(result);
        }


        [Fact]
        public void ShouldReturnSuccessForDeleteUser()
        {
            var result = _contactService.Delete(1);
            Assert.True(result);
        }


    }
}
