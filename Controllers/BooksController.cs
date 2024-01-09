using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using Web_API_ReactJS.Models;

namespace Web_API_ReactJS.Controllers
{
    public class BooksController : ApiController
    {
        private BooksManagementEntities DB = new BooksManagementEntities();

        [HttpPost]
        public object AddNewBook(BookDeatail b)
        {
            try
            {
                BookDeatail bookDeatail = new BookDeatail();
                bookDeatail.Name = b.Name;
                bookDeatail.Author = b.Author;
                DB.BookDetails.Add(bookDeatail);
                DB.SaveChanges();
                return new Responce
                {
                    Status = "Success",
                    Message = "Book added"
                };
            }
            catch(Exception ex)
            {
                return new Responce
                {
                    Status = "Failed",
                    Message = ex.Message
                };

            };
            

        }
    }
}
