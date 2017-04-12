using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace esales.Models
{
    public class CodeService
    {
        /// <summary>
        /// 連線到DB
        /// </summary>
        /// <returns></returns>
        private string GetConnectioin()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString.ToString();
        }

        /// <summary>
        /// 員工資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetEmp()
        {
            DataTable dt = new DataTable();
            string sql = @"Select EmployeeID As CodeID,Lastname+'-'+Firstname As CodeName FROM HR.Employees";
            using (SqlConnection conn = new SqlConnection(this.GetConnectioin()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 出貨公司
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCompany()
        {
            DataTable dt = new DataTable();
            string sql = @"Select  CompanyName As CodeName , ShipperID as CodeID FROM Sales.Shippers";
            using (SqlConnection conn = new SqlConnection(this.GetConnectioin()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得產品資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetProduct() {
            DataTable dt = new DataTable();
            string sql = @"Select ProductID as CodeID,Productname as CodeName From Production.Products";
            using (SqlConnection conn = new SqlConnection(this.GetConnectioin()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCustomer()
        {
            DataTable dt = new DataTable();
            string sql = @"Select CustomerID As CodeID,CompanyName As CodeName FROM Sales.Customers";
            using (SqlConnection conn = new SqlConnection(this.GetConnectioin()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }



        /// <summary>
        /// Maping ID資料
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem());
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeName"].ToString(),
                    Value = row["CodeID"].ToString()
                });
            }
            return result;
        }

    }
}