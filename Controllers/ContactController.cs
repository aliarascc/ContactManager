using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManager.Controllers
{
    public class ContactController : ApiController
    {
        #region ilk yazılan kod
        //public Contact[] Get()
        //{
        //    return new Contact[]{
        //       new Contact
        //       {
        //           Id=1,
        //           Name="Gleen Block"
        //       },
        //       new Contact
        //       {
        //           Id=2,
        //           Name="Dan Roth"
        //       }
        //    };

        //}
        #endregion

        private ContactRepository contactRepository;
        public ContactController()
        {
            this.contactRepository = new ContactRepository();

        }

        public Contact[] Get() 
        {
            return contactRepository.GetAllContacts();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}
