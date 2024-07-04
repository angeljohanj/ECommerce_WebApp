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


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

       public DataConnection connection = new DataConnection();

        /*public string[] procedures = new string[]
        {
            "sp_ListUsers"
        };*/
        /* create procedure sp_ListUsers
 as
 begin

     select* from tb_Users where active = 1;
     end

 create procedure sp_GetAUser(@Id int)
 as
 begin
 select* from tb_Users where Active = 1 and UsersId = @Id
 end

 create table tb_Users(
 UsersId int primary key identity,
 Name varchar(100),
 LastName varchar(100), 
 Email varchar(100), 
 Password varchar(150),
 RestoreUser bit default 0,
 Edited_at datetime,
 Deleted_at datetime,
 Active bit default 1, 
 Registered_at datetime default getdate())


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
                                });
                            };
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new JsonResult(users);
        }
        
        
    }
}
