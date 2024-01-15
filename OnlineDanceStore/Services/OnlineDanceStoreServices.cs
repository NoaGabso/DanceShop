using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OnlineDanceStore.Models;




namespace OnlineDanceStore.Services
{
    public class OnlineDanceStoreServices
    {
        #region TestData
        private static List<Item> items = new List<Item>()

      { new Item() { Categories= new Categories(){Id= 2, Name= "Shoes" },
          SubCategory= new SubCategory(){Category=new Categories(){Id=2} ,Id=4, Name="Jazz shoes" },
          Name = " jazz dance shoes",
          Description="...shoes...",
          SizeItem= new SizeItem(){Id=4,Size=37},
          ColorItem=new ColorItem(){Id=1,Name="black"},
          Quantity= 5,
          Price= 200,
          Image="imagestringshoes" }};
      
        
       
        #endregion

        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _serializerOptions;
        const string URL = @"https://j6gcbt8d-7123.euw.devtunnels.ms/api/DanceStore/";
        public OnlineDanceStoreServices()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

           
        }
            #region
            public async Task<UserDto> LoginAsync(string email, string password)
            {
                try
                {
                    //האובייקט לשליחה
                    User user = new User() { Email = email, UserPswd = password };
                    //מבצעת סיריליזציה
                    var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync($"{URL}Login", content);

                    switch (response.StatusCode)
                    {
                        case (HttpStatusCode.OK):
                            {
                                jsonContent = await response.Content.ReadAsStringAsync();
                                User u = JsonSerializer.Deserialize<User>(jsonContent, _serializerOptions);
                                await Task.Delay(2000);
                                return new UserDto() { Success = true, Message = string.Empty, User = u };

                            }
                        case (HttpStatusCode.Unauthorized):
                            {
                                return new UserDto() { Success = false, User = null, Message = ErrorMessages.INVALID_LOGIN };

                            }

                    }

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                return new UserDto() { Success = false, User = null, Message = ErrorMessages.INVALID_LOGIN };

            }

        public async Task<UserDto> RegisterUser(User user)
        {
            //create the json
            var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
            //add the json to the content of the request
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            try
            {
                //send it to the server
                var response = await _httpClient.PostAsync($"{URL}Register", content);

                switch (response.StatusCode)
                {
                    case (HttpStatusCode.OK):
                    case (HttpStatusCode.Created):
                        {
                            User u;
                            jsonContent = await response.Content.ReadAsStringAsync();
                           u = JsonSerializer.Deserialize<User>(jsonContent, _serializerOptions);
                            return new UserDto {Success=true, Message=null, User=u };

                        }
                    case (HttpStatusCode.Conflict):
                        {
                            return null;
                        }

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return null;

        }
        #endregion

    }
    }

