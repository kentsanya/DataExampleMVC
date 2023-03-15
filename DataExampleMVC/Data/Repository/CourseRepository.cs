using DataExampleMVC.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static Dapper.SqlMapper;

namespace DataExampleMVC.Data.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        private string _stringconnection = String.Empty;
        public CourseRepository(string stringconnection)
        {
            _stringconnection= stringconnection;
        }

        public void Create(Course entity)
        {
            using (IDbConnection db = new SqlConnection(_stringconnection))
            {
                var sqlQuery = "INSERT INTO Course (Name, Description VALUES(@Name, @Description)";
                db.Execute(sqlQuery, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_stringconnection))
            {
                var sqlQuery = "DELETE From Course WHERE Id=@Id";
                db.Execute(sqlQuery,  new { id });
            }
        }

        public IEnumerable<Course> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_stringconnection))
            {
                return db.Query<Course>("SELECT * From Course").ToList();
            }
        }

        public Course GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(_stringconnection))
            {
               return db.Query<Course>("SELECT * From Course WHERE Id=@Id", new { id }).FirstOrDefault();
            }
        }

        public void Update(Course entity)
        {
            using (IDbConnection db = new SqlConnection(_stringconnection))
            {
                var sqlQuery = "UPDATE Course SET Name=@Name, Description=@Description WHERE Id=@Id";
                db.Execute(sqlQuery, entity);
            }
        }
    }
}
