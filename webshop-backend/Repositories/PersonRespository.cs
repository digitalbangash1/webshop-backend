using webshop_backend.Model;
using System.Data;

namespace webshop_backend.Repositories
{
    public class PersonRespository : IPersonRespository
    {

        private readonly IDbConnectionService dbConnectionService;

        public PersonRespository(IDbConnectionService dbConnectionService)
        {
            this.dbConnectionService = dbConnectionService;
        }

        public IList<Person> GetPersons()
        {
           var persons = new List<Person>();
            using (var conn = dbConnectionService.Create()) 
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from person";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persons.Add(GetPersons(reader));
                    }
                }         



            }
           return persons;

        }
        private Person GetPersons(IDataReader reader)
        {
            return new Person()
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = reader["name"].ToString(),
                Phone = reader["phone"].ToString(),
                Email = reader["email"].ToString(),
                ZipCode = reader["ZipCode"].ToString(),


            };
        }
    }
}
