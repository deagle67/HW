using HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Services
{
    public class ContactsService
    {
        private List<UserContact> _contacts = new List<UserContact>();

        public ContactsService()
        {
            _contacts.Add(new UserContact {
                Id = 1,
                FirstName = "Jean",
                LastName = "Bite",
                Phone ="0606060606",
                Email = "truc@truc.com",
                Blocked = false
            });
        }

        public IList<UserContact> GetContacts()
        {
            return _contacts;
        }

        public UserContact GetContact(int contactId)
        {
            if (contactId == 0)
                throw new ArgumentNullException();

            return _contacts.Single(c => c.Id == contactId);
        }

        public bool UpdateContact(UserContact contact)
        {
            var contactInData = _contacts.First(c => c.Id == contact.Id);
            if (contactInData == null)
                return false;

            contactInData.FirstName = contact.FirstName;
            contactInData.LastName = contact.LastName;
            contactInData.Phone = contact.Phone;
            contactInData.Email = contact.Email;
            contactInData.Blocked = contact.Blocked;

            return true;
        }

        public bool DeleteContact(int contactId)
        {
            if (contactId == 0)
                throw new ArgumentNullException();

            var contactFromData = _contacts.Single(c => c.Id == contactId);

            if (contactFromData == null)
                return false;

            return _contacts.Remove(contactFromData);
        }

        public int AddContact(UserContact contact)
        {
            if (contact == null)
                throw new ArgumentException();

            var lastId = _contacts.Last().Id + 1;
            contact.Id = lastId;
            _contacts.Add(contact);

            return _contacts.Last().Id;
        }
    }
}
