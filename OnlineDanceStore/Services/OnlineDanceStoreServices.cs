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
        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _serializerOptions;
        const string URL = @"";
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
            public async Task<UserDto> LoginAsync(string userName, string password)
            {
                try
                {
                    //האובייקט לשליחה
                    User user = new User() { UserName = userName, Password = password };
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
#endregion

        }
    }

