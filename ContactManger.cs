using System.Collections.Generic;
using ContactManagerT3.Models;
using ContactManagerT3.DataAccess;

namespace ContactManagerT3.BusinessLogic
{
    public class ContactManager
    {
        private ContactRepository contactRepository;

        public ContactManager()
        {
            contactRepository = new ContactRepository();
        }

        public List<Contact> GetAllContacts()
        {
            return contactRepository.GetAllContacts();
        }

        public void AddContact(Contact contact)
        {
            contactRepository.AddContact(contact);
        }

        public void UpdateContact(Contact contact)
        {
            contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(string name)
        {
            contactRepository.DeleteContact(name);
        }

        public List<Contact> GetContactsByName(string name)
        {
            return contactRepository.GetContactsByName(name);
        }


    }
}
