using System;
using System.Collections.Generic;
using System.Text;
using Antra.CustomerApp.Data.Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Antra.CustomerApp.Data.Repository
{
    public class CustRepository : IRepository<Cust>
    {
        DbContext db;
        public CustRepository()
        {
            db = new DbContext();
        }

        public int Delete(int id)
        {
            string cmd = "Delete from Customer where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id",id);
            return db.Execute(cmd, parameters);
        }

        public IEnumerable<Cust> GetAll()
        {
            List<Cust> lstCollection = new List<Cust>();
            DataTable dt = db.Query("Select Id, FirstName, LastName, Mobile, EmailId, City, State from Customer", null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    Cust c = new Cust();
                    c.Id = Convert.ToInt32(dataRow["Id"]);
                    c.FirstName = Convert.ToString(dataRow["FirstName"]);
                    c.LastName = Convert.ToString(dataRow["LastName"]);
                    c.Mobile = Convert.ToString(dataRow["Mobile"]);
                    c.EmailId = Convert.ToString(dataRow["EmailId"]);
                    c.City = Convert.ToString(dataRow["City"]);
                    c.State = Convert.ToString(dataRow["State"]);
                    lstCollection.Add(c);
                }
            }

            return lstCollection;
        }

        public Cust GetById(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@id", id);
            DataTable dt = db.Query("Select Id, FirstName, LastName, Mobile, EmailId, City, State from Customer where id=@id", param);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];
                Cust c = new Cust();
                c.Id = Convert.ToInt32(dataRow["Id"]);
                c.FirstName = Convert.ToString(dataRow["FirstName"]);
                c.LastName = Convert.ToString(dataRow["LastName"]);
                c.Mobile = Convert.ToString(dataRow["Mobile"]);
                c.EmailId = Convert.ToString(dataRow["EmailId"]);
                c.City = Convert.ToString(dataRow["City"]);
                c.State = Convert.ToString(dataRow["State"]);
                return c;
            }
            return null;
        }

        public int Insert(Cust item)
        {
            string cmd = "Insert into Customer values (@fname, @lname, @mob,@email,@c,@s)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fname", item.FirstName);
            parameters.Add("@lname", item.LastName);
            parameters.Add("@mob", item.Mobile);
            parameters.Add("@email", item.EmailId);
            parameters.Add("@c", item.City);
            parameters.Add("@s", item.State);
            return db.Execute(cmd, parameters);



        }

        public int Update(Cust item)
        {
            string cmd = "Update Customer set FirstName = @fname, LastName = @lname, Mobile = @mob,EmailId = @email,City = @c,State = @s, where id = @id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fname", item.FirstName);
            parameters.Add("@lname", item.LastName);
            parameters.Add("@mob", item.Mobile);
            parameters.Add("@email", item.EmailId);
            parameters.Add("@c", item.City);
            parameters.Add("@s", item.State);
            parameters.Add("@id", item.Id);
            return db.Execute(cmd, parameters);
        }
    }
}
