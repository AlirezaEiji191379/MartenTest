using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Data
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "jsonb")]
        public Book Book { get; set; }
    }
}
