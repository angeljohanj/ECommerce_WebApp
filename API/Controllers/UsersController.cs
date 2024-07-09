using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using API.Data;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using API.Model;
using System;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

       public DataConnection connection = new DataConnection();

        public string[] parameters = new string[]
        {
            "Id", "Name", "LastName", "Email", "Password"
        };

        public string[] procedures = new string[]
        {
            "sp_ListUsers", "sp_GetAUser", "sp_RegisNewUser"
        };        
/*

 create procedure sp_RegisNewUser
 (@Name varchar(100),
 @LastName varchar(100), 
 @Email varchar(100), 
 @Password varchar(150))
 as
 begin
     insert into tb_Users
     (Name,
     LastName,
     Email,
     Password)


     values
     (@Name,
      @LastName,
      @Email,
      @Password)
 end*/
        [HttpGet]
        [Route("/")]
        public JsonResult ListUsers()
        {
            var users = new List<UsersModel>();
            try
            {
                using(var conn = new SqlConnection(connection.GetConnectionString()))
                {
                    using(var cmd = new SqlCommand("sp_ListUsers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using(var dReader = cmd.ExecuteReader())
                        {
                            while (dReader.Read())
                            {
                                users.Add(new UsersModel
                                {
                                    UsersId = Convert.ToInt32(dReader["UsersId"]),
                                    Name = dReader["Name"].ToString(),
                                    LastName = dReader["Lastname"].ToString(),
                                    Email = dReader["Email"].ToString(),
                                    Password = dReader["Password"].ToString(),
                                    RestoreUser = Convert.ToBoolean(dReader["RestoreUser"]),
                                    Active = Convert.ToBoolean(dReader["Active"])
                                });
                            };
                            dReader.Close();
                        }
                        conn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new JsonResult(users);
        }

        [HttpGet][Route("/GetAUser")]
        public JsonResult GetAUser(int id)
        {
            var user = new UsersModel();
            try
            {
                using(var conn = new SqlConnection(connection.GetConnectionString()))
                {
                    using(var cmd = new SqlCommand(procedures[1], conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue(parameters[0], id);
                        using(var dReader = cmd.ExecuteReader())
                        {
                            while (dReader.Read())
                            {
                                user.UsersId = Convert.ToInt32(dReader["UsersId"]);
                                user.Name = dReader["Name"].ToString();
                                user.LastName = dReader["Lastname"].ToString();
                                user.Email = dReader["Email"].ToString();
                                user.Password = dReader["Password"].ToString();
                                user.RestoreUser = Convert.ToBoolean(dReader["RestoreUser"]);
                                user.Active = Convert.ToBoolean(dReader["Active"]);
                            }
                            dReader.Close();
                        }
                       conn.Close();
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new JsonResult(user);
        }


        [HttpPost][Route("/RegisterNewUser")]

        public JsonResult RegisterNewUser(UsersModel newUser)
        {
            var ans = false;

            try
            {
                using(var conn = new SqlConnection(connection.GetConnectionString()))
                {
                    using(var cmd = new SqlCommand(procedures[2], conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue(parameters[1], newUser.Name);
                        cmd.Parameters.AddWithValue(parameters[2], newUser.LastName);
                        cmd.Parameters.AddWithValue(parameters[3], newUser.Email);
                        cmd.Parameters.AddWithValue(parameters[4], newUser.Password);
                        var affectedRows=cmd.ExecuteNonQuery();

                        if(affectedRows != 0)
                        {
                            ans = true;
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ans = false;
            }
            return new JsonResult(ans);
        }
    }
}
