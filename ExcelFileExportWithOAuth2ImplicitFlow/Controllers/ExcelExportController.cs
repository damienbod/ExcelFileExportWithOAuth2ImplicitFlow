using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;
using ExcelFileExportWithOAuth2ImplicitFlow.Models;
using Thinktecture.IdentityModel.WebApi;

namespace ExcelFileExportWithOAuth2ImplicitFlow.Controllers
{
    public class ExcelExportController : ApiController
    {
        /// <summary>
        /// ResourceActionAuthorize: the AuthorizationManager CheckAccess method is called 
        /// ScopeAuthorize: Checks that the user has the scope 
        /// </summary>
        [ResourceActionAuthorize("export")]
        [ScopeAuthorize("export")]
        [Authorize]
        [HttpGet]
        [Route("api/ExcelExport/complete/{id}")]
        public IHttpActionResult GetAnimalsExportExcel(string id)
        {
            // force that this method always returns an excel document.
            Request.Headers.Accept.Clear();
            Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.ms-excel"));
            return Ok(books);
        }

        /// <summary>
        /// Use some demo data
        /// </summary>
        List<Book> books = new List<Book>    
        {    
            new Book { Id = 1, Name = "A way to Galway", Author = "Tom Moore", Rating = 5 },   
            new Book { Id = 2, Name = "As fast as a Berner", Author = "Bob Nobody", Rating = 4 },   
            new Book { Id = 3, Name = "Singing Loud", Author = "Tim Mooney", Rating = 3 },  
            new Book { Id = 4, Name = "Lookup", Author = "Philip Jones", Rating = 2 },   
            new Book { Id = 5, Name = "Fighting Molly", Author = "Patrick Host", Rating = 1 },   
            new Book { Id = 6, Name = "Calling home", Author = "Oliver McNearney", Rating = 6 },   
        };
    }
}
