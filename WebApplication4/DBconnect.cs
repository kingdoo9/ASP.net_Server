using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebApplication4.Model;
using System.Linq;
using Dapper;
using System.Net;
using System.Net.Http;

namespace WebApplication4
{
    public class DBconnect
    {
        public string ConnectionString { get; set; }

        public DBconnect(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        //Dapper를 사용한 Select, Insert, Update, Delete 문 구현

        public  List<Customer_Data> GetData()
        {
            try {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    String sql = "SELECT * FROM STUDENT ";
                    var customer = conn.Query<Customer_Data>(sql).ToList();

                    conn.Close();
                    return customer;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Customer_Data Insert(Customer_Data customer)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    String sql = "INSERT INTO STUDENT VALUE (@grade,@cclass,@no,@name,@score);";
                    conn.Open();
                    conn.Execute(sql, new { grade = Convert.ToInt32(customer.grade), cclass = Convert.ToInt32(customer.cclass), no = Convert.ToInt32(customer.no), customer.name, customer.score });
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return customer;
        }

        public Customer_Data Update(int id, Customer_Data customer)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    String sql = "UPDATE STUDENT SET grade = @grade, cclass = @cclass, name = @name, score = @score WHERE no = @no;";
                    conn.Open();
                    conn.Execute(sql, new { grade = Convert.ToInt32(customer.grade), cclass = Convert.ToInt32(customer.cclass), customer.name, customer.score, no = Convert.ToInt32(id) });
                    conn.Close();
                }
            }catch(Exception ex) {
                return null;
            }
            return customer;
        }

        public int Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    String sql = "DELETE FROM STUDENT WHERE no = @no;";
                    conn.Open();
                    conn.Execute(sql, new { no = Convert.ToInt32(id) });
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return id;
        }
    }
}
