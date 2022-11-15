using ApiTest.Command;
using ApiTest.Data;
using Marten;
using Marten.PLv8;
using Marten.PLv8.Patching;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _dbContext; 
        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut]
        [Route("update")]        
        public async  Task<IActionResult> Update([FromBody] UpdateBook updateBook)
        {
            using var store = DocumentStore.For(_ =>
            {
                _.Connection("User ID=postgres;Password=92?VH2WMrx;Host=localhost;Port=5432;Database=postgres;Pooling=true;");
               // _.UseJavascriptTransformsAndPatching();
            });
            using var session = store.LightweightSession();
            var user = new User()
            {
                Id = 1,
                Name = "ali"
            };
            //var book = new Book()
            //{
            //    Id = 1,
            //    Price = 100
            //};
            session.Store(user);
            //const string where = "where 1 = 1";
            //session.Patch<Book>(where).Set("Title", "ahmad");
            session.SaveChanges();
            //var book = new Book()
            //{
            //    Id = 5,
            //    mamad = 102
            //};
            //session.Store(book);
            //session.SaveChanges();
            //_dbContext.Users.Attach(new User { Id = updateBook.UserId, Book = new Book() { Title = updateBook.Title } }).Property(x => x.Book.Title).IsModified = true;
            //_dbContext.SaveChanges();
            return Ok();
        }      


    }
}
