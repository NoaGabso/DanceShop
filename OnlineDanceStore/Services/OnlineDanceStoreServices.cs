using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OnlineDanceStore.Models;
using static System.Net.WebRequestMethods;




namespace OnlineDanceStore.Services
{
    public class OnlineDanceStoreServices
    {
       // #region TestData
       // public static List<Item> items = new List<Item>() {

       //new Item() { Categories= new Categories(){CategoryId= 2, CategoriesName= "Shoes" },
       //   SubCategory= new SubCategory(){CategoryId=new Categories(){CategoryId=2} ,SubCategoryId=4, SubcategoryName="Jazz shoes" },
       //   ItemName = " jazz dance shoes",
       //   ItemDescription="...shoes...",
       //   Gender=new Gender(){GenderId=1, GenderName ="Female"},
       //   SizeItem= new SizeItem(){SizeItemId=4,SizeName=37},
       //   ColorItem=new ColorItem(){ColorItemId=1,ColorName="black"},
       //   Quantity= 5,
       //   Price= 200,
       //   ItemImage="iconshome.png" },

       //   new Item() { Categories= new Categories(){CategoryId= 1, CategoriesName= "Leotards" },
       //   ItemName = "women leotards",
       //   ItemDescription="...leotards...",
       //   Gender=new Gender(){GenderId=1, GenderName ="Female"},
       //   SizeItem= new SizeItem(){SizeItemId=1,SizeName=0},
       //   ColorItem=new ColorItem(){ColorItemId=5,ColorName="maroon"},
       //   Quantity= 2,
       //   Price= 150,
       //   ItemImage="iconsshopping_bag.png" }

       // };



       // #endregion

        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _serializerOptions;
        static string URL = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5187/api/DanceStore/" : "http://localhost:5187/api/DanceStore/";
            //@"https://j6gcbt8d-7123.euw.devtunnels.ms/api/DanceStore/";
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

        #region Log&Reg
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
                            return new UserDto { Success = true, Message = null, User = u };

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
        public async Task<List<Item>> GetItemsByCategory(int CategoryId)
        {
            List<Item> items = new List<Item>(); 
            try
            {
                //send it to the server
                var response = await _httpClient.GetAsync($"{URL}GetItemsByCategory?CtegoryId={CategoryId}");

                if (response.StatusCode== HttpStatusCode.OK)
                {

                   var jsonContent = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<List<Item>>(jsonContent, _serializerOptions);
                    return items;



                }
                return items;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return null;

            //return items.Where(x=> x.Categories.CategoryId == CategoryId).ToList();
        }

        public async Task<List<Item>> GetItemsBySubCategory(int CategoryId, int SubCategoryId)
        {
            List<Item> items = new List<Item>();
            try
            {
                //send it to the server
                var response = await _httpClient.GetAsync($"{URL}GetItemsBySubCategory?SubCtegoryId={SubCategoryId}?CtegoryId={CategoryId}");

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var jsonContent = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<List<Item>>(jsonContent, _serializerOptions);
                    return items;



                }
                return items;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return null;
            //return items.Where(x=> x.Categories.CategoryId==CategoryId && x.SubCategory.SubCategoryId==SubCategoryId).ToList();
        }

        public async Task<List<Item>> GetItemsByGender(int gender)
        {
            List<Item> items = new List<Item>();
            try
            {
                //send it to the server
                var response = await _httpClient.GetAsync($"{URL}GetItemsByGender?GenderId={gender}");

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var jsonContent = await response.Content.ReadAsStringAsync();
                    items = JsonSerializer.Deserialize<List<Item>>(jsonContent, _serializerOptions);
                    return items;
                }
                return items;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return null;         
        }



        #region TestData
        //public async Task<List<Item>> GetAllLeotards()
        //{
        //    List<Item> items = new List<Item>();
        //    try
        //    {
        //        //send it to the server
        //        var response = await _httpClient.GetAsync($"{URL}GetAllItems/1");

        //if (response.StatusCode == HttpStatusCode.OK)
        //        {

        //            var jsonContent = await response.Content.ReadAsStringAsync();
        //            items = JsonSerializer.Deserialize<List<Item>>(jsonContent, _serializerOptions);
        //            return items;
        //        }
        //        return items;
        //    }
        //    catch (Exception ex) { Console.WriteLine(ex.Message); }
        //    return null;
        //}
        //public async Task<List<Item>> GetAllDancingShoes()
        //{

        //}
        //    public async Task<List<Item>> GetAllAccessories()
        //    {
        //        //return items.Where(x => x.Categories.CategoryId == 1).ToList();
        //    }

        //public async Task<List<Item>> GetItemsForWomen()
        //{
        //    //return items.Where(x=> x.Gender.GenderId==1).ToList();
        //}
        //public async Task<List<Item>> GetItemsForMen()
        //{
        //    return items.Where(x => x.Gender.GenderId == 2).ToList();
        //}

        //public async Task<List<Item>> GetAllDancingShoes()
        //{
        //    return items.Where(x => x.Categories.CategoryId == 2).ToList();
        //}
        //public async Task<List<Item>> GetAllAccessories()
        //{
        //    return items.Where(x => x.Categories.CategoryId == 3).ToList();
        //}
        #endregion
        #endregion


    }
}

