namespace CerealAPI_uge_3.Models
{
    public class User
    {
        //what the migration uses to generate the SQL for making the tables in the database 
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
