using Microsoft.Data.SqlClient;
using System.Data;

namespace NorthwindDataAccessLayer
{
    public class CategoryDAL
    {
       public static SqlConnection Connect() {
            SqlConnection cn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            return cn;
        }
        public void AddNewCategory(CategoryBAL category)
        {
            SqlDataAdapter da;
            DataSet ds;
            FillDataSet(out da, out ds);

            DataRow drow = ds.Tables["Categories"].NewRow();
            //   drow["CategoryID"] = category.CategoryID;
            drow["CategoryName"] = category.CategoryName;
            drow["Description"] = category.Description;

            ds.Tables["Categories"].Rows.Add(drow);

            DataTable dt = ds.Tables["Categories"];
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            da.Update(dt);
            da.Dispose();

        }

        private static void FillDataSet(out SqlDataAdapter da, out DataSet ds)
        {
            SqlConnection cn = Connect();
            da = new SqlDataAdapter("select * from categories", cn);
            ds = new DataSet();
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Categories");
        }


        public void UpdateCategory(CategoryBAL dataToUpdate)
        {
            SqlDataAdapter da;
            DataSet ds;
            FillDataSet(out da, out ds);
            DataRow foundRow=ds.Tables["Categories"].Rows.Find(dataToUpdate.CategoryID);

            if (foundRow != null)
            {
                foundRow["CategoryName"] = dataToUpdate.CategoryName;
                foundRow["Description"]=dataToUpdate.Description;

                DataTable dt = ds.Tables["Categories"];
                SqlCommandBuilder bldr = new SqlCommandBuilder(da);
                da.Update(dt);
                da.Dispose();

            }


        }
        public DataRow FindCategory(int id) 
        {

            SqlDataAdapter da;
            DataSet ds;
            FillDataSet(out da, out ds);
            DataRow foundRow = ds.Tables["Categories"].Rows.Find(id);

            return foundRow;
            

        }
        public List<CategoryBAL> ShowAllCategories() 
        {
            SqlDataAdapter da;
            DataSet ds;
            FillDataSet(out da, out ds);
            List<CategoryBAL> categories = new List<CategoryBAL>();

            for (int i = 0; i < ds.Tables["Categories"].Rows.Count-1; i++)
            {
                CategoryBAL bal=new CategoryBAL();
                DataRow row=ds.Tables["Categories"].Rows[i];
                bal.CategoryID = Convert.ToInt32(row["CategoryID"]);
                bal.CategoryName = row["CategoryName"].ToString();
                bal.Description = row["Description"].ToString();
                categories.Add(bal);
            }
            return categories;  

        }
    }
}
