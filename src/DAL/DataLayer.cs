using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataLayer
    {
        SqlConnection sqlConnection;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        public DataLayer()
        {
            sqlConnection = new SqlConnection(Properties.Settings.Default.medicine_storeConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        #region sales
        public DataTable GetMedicin()
        {
            cmd.CommandText = "Select * from medicine";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Search(string Name)
        {
            cmd.CommandText = $"select * from medicine where name like '%{Name}%'";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int UpdateMedicin(int id ,int quantity)
        {
            cmd.CommandText =
               $"UPDATE [dbo].[medicine]" +
               $"SET [quantity] =[quantity] - {quantity}"
               + $"Where [id] = {id} ";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }

        public int UpdateRetreveMedicin(int id, int quantity)
        {
            cmd.CommandText =
               $"UPDATE [dbo].[medicine]" +
               $"SET [quantity] = [quantity] + {quantity}"
               + $"Where [id] = {id} ";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }

        public int UpdateOrderMedicin(int medicine_id,int order_id, int quantity)
        {
            cmd.CommandText =
               $"UPDATE [dbo].[order_medicine]" +
               $"SET [quantity] = [quantity] - {quantity}"
               + $"Where [medicine_id] = {medicine_id} and [order_id] = {order_id}";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }

        public int InsertNewOrder(decimal total_price)
        {
            cmd.CommandText = $"execute customerInsert {total_price},'2023-05-30'";
               //$"INSERT INTO [dbo].[order_]([total_price],[order_date])" +
               //$"VALUES({total_price}, (getdate()) )";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }

        public DataTable GetOrderId()
        {
            cmd.CommandText = "select top 1 * from order_ order by id desc";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int InsertOrderMedicin(int medicine_id, int order_id ,int quantity)
        {
            cmd.CommandText =
               $"INSERT INTO [dbo].[order_medicine]([medicine_id],[order_id],[quantity])" +
               $"VALUES({medicine_id},{order_id},{quantity})";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }

        public DataTable GetOrderById(int orderId ,int medicinId)
        {
            cmd.CommandText = $"select * from order_medicine  where order_id = {orderId} " +
                $"and [medicine_id] = {medicinId}" ;
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        #endregion

        #region admin
        public DataTable getAdmin()
        {
            cmd.CommandText = "select * from admin";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public int UpdatAdmin(string password, int id)
        {
            cmd.CommandText = $"update Admin  SET password = '{password}' Where id={id}";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }
        #endregion

        #region medicin
        public DataTable getMsdicin()
        {
            cmd.CommandText = "select * from medicine";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public int Insertmesicin(string name, string description, decimal price, int quantity, int company_Id)
        {
            cmd.CommandText =
               $"INSERT INTO [dbo].[medicine]( [name],[description],[price],[quantity],[medicine_company_id])" +
               $"VALUES('{name}','{description}', {price},{quantity},{company_Id})";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }
        public int Updatemedicine(int id, string name, string description, decimal price, int quantity, int company_Id)
        {


            cmd.CommandText =
                          $"UPDATE [dbo].[medicine]" +
               $"SET [name]= '{name}' ,[description] = '{description}',[price] = {price},[quantity] = {quantity},[medicine_company_id] = {company_Id}"
               + $"Where [id] = {id} ";


            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }
        public SqlCommand GetCmd()
        {
            return cmd;
        }
        public int DeleteMsdicin(int _id)
        {
            cmd.CommandText =
                $"Delete from [dbo].[medicine]"
                + $"Where [id] = {_id}";

            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }

        #endregion

        #region company
        public DataTable GetCompanyMedicin()
        {
            cmd.CommandText = "select * from medicine_company";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public int InsertCompanyMedicin(string name, string address, string phone_number)
        {
            cmd.CommandText =
               $"INSERT INTO [dbo].[medicine_company]([name],[address],[phone_number])" +
               $"VALUES('{name}','{address}', '{phone_number}')";
            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }
        public int UpdateCompanyMedicin(int id, string name, string address, string phone_number)
        {
            cmd.CommandText =
               $"UPDATE medicine_company set  [name]= '{name}',[address]='{address}',[phone_number]= '{phone_number}' where [id]='{id}'";

            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }
        public int DeleteCompanyMedicin(int id)
        {
            cmd.CommandText = $"DELETE FROM [dbo].[medicine] WHERE [medicine_company_id] = {id};" +
                $"Delete from [dbo].[medicine_company] Where [id] = {id} ";


            sqlConnection.Open();
            int count = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return count;
        }
        #endregion


        #region Reports

        public DataTable GetCompany(string id)
        {


         
            cmd.Connection = sqlConnection;
            cmd.CommandText = $"exec getcompany '{id}' ";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);




            return dt;
        }

        public DataTable GetItemDetails(string itemName)
        {

            cmd.Connection = sqlConnection;
            cmd.CommandText = $"exec itemdetails '{itemName}' ";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public DataTable getInvoice(int OrderId)
        {

            cmd.Connection = sqlConnection;
            cmd.CommandText = $"exec [dbo].[invoice] '{OrderId}' ";
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        #endregion


    }
}
