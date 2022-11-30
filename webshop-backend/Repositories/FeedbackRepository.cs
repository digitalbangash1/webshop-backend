using webshop_backend.Model;
using System.Data;
using webshop_backend.Model.Products;

namespace webshop_backend.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {


        private readonly IDbConnectionService dbConnectionService;
        

        public FeedbackRepository(IDbConnectionService dbConnectionService)
        {
            this.dbConnectionService = dbConnectionService;
            

        }



        public void createFeedback(int id, string review, int rating, int product_id)
        {
            using (var conaction = dbConnectionService.Create())
            {
                conaction.Open();
                var db = conaction.CreateCommand();
                db.CommandType = CommandType.Text;

                db.CommandText = "INSERT INTO Feedback (id , review , rating, product_id ) VALUES (@id, @review, @rating, @product_id)";


                var idParam = db.CreateParameter();
                idParam.ParameterName = "@id";
                idParam.Value = id;
                db.Parameters.Add(idParam);

                var reviewParam = db.CreateParameter();
                reviewParam.ParameterName = "@review";
                reviewParam.Value = review;
                db.Parameters.Add(reviewParam);

                var ratingParam = db.CreateParameter();
                ratingParam.ParameterName = "@rating";
                ratingParam.Value = rating;
                db.Parameters.Add(ratingParam);

                var product_idParam = db.CreateParameter();
                product_idParam.ParameterName = "@product_id";
                product_idParam.Value = product_id;
                db.Parameters.Add(product_idParam);

                db.ExecuteNonQuery();
            }
        }



        public IList<Feedback> GetFeedback()
        {
            var Feedback = new List<Feedback>();
            using (var conaction = dbConnectionService.Create())
            {
                conaction.Open();
                var db = conaction.CreateCommand();
                db.CommandType = CommandType.Text;
                db.CommandText = "select * from Feedback";

                using (var reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Feedback.Add(GetFeedback(reader));
                    }
                }

            }
            return Feedback;

        }


        private Feedback GetFeedback(IDataReader reader)
        {
            return new Feedback
            {
                id = Convert.ToInt32(reader["id"]),
                review = Convert.ToString(reader["review"]),
                rating = Convert.ToInt32(reader["rating"]),
                product_id = Convert.ToInt32(reader["product_id"]),
                

            };
        }
    }
}
