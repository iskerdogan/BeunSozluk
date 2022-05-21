﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddContactBusinessLayer(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void ContactDelete(Contact contact)
        {
           _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
           _contactDal.Update(contact);
        }

        public Contact GetContactById(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
