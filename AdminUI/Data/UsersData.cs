using AdminUI.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;

namespace AdminUI.Data
{
    public class UsersData
    {
        public string BaseUrl { get => "https://localhost:7024/"; }
        public string MediaType { get => "application/json"; }

        public async Task<List<UsersModel>> ListUsers()
        {
            var users = new List<UsersModel>();
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);
                var result = await client.SendAsync(request);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UsersModel>>(response);
                }
            } catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);

            }
            return users;
        }

        public async Task<UsersModel> GetAUser(int id)
        {
            var user = new UsersModel();
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + $"?id={id}");
                var result = await client.SendAsync(request);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UsersModel>(response);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return user;
        }

        public async Task<bool> RegisterNewUser(UsersModel newUser)
        {
            var ans = false;

            try
            {
                HttpClient client = new HttpClient();
                var data = JsonConvert.SerializeObject(newUser);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "/RegisterNewUser");
                request.Content = new StringContent(data, Encoding.UTF8, MediaType);
                var result = await client.SendAsync(request);

                if(result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();

                    if (response == "true")
                    {
                        ans = true;
                    }
                }

            }catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                ans = false;
            }

            return ans;
        }
    }
}
