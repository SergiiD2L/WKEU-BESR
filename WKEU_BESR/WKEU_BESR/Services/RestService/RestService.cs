using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using WKEU_BESR.Common;
using WKEU_BESR.Events;
using WKEU_BESR.Models;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Services.RestService
{
    public class RestService //: IRestService
    {
        //private HttpClient client;
        //public IUserSettings UserSetting { get; set; }
        //public IPubSub PubSub { get; set; }

        //public INavigationService NavigationService { get; set; }
        //public string Url { get; set; }

        //public RestService(IUserSettings userSetting, IPubSub pubsub, INavigationService navigation)
        //{
        //    client = new HttpClient();

        //    UserSetting = userSetting;
        //    PubSub = pubsub;
        //    NavigationService = navigation;
        //}

        //public void RestServiceInit()
        //{
        //    client = new HttpClient();
        //}

        //public async Task<TModel> AuthenticateAsync<TModel>(string phone, string password) where TModel : class, IModel
        //{
        //    string authUrl = Constants.ResolverUri(string.Format(Constants.AuthenticateUrl, phone, password));
        //    var uri = new Uri(authUrl);
        //    try
        //    {
        //        var response = await client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<TModel>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"ERROR {0}", ex.Message);
        //    }
        //    return null;
        //}

        //public async Task<TModel> GetItemByIdAsync<TModel>(string id) where TModel : class, IModel
        //{
        //    var uri = new Uri(Url + "/" + id);

        //    try
        //    {
        //        var response = await client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<TModel>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"ERROR {0}", ex.Message);
        //    }
        //    return null;

        //}

        //public async Task<string> GetAPIToken(string userName, string password)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            //setup client
        //            client.BaseAddress = new Uri(Constants.BaseRestUrl);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

        //            //setup login data
        //            var formContent = new FormUrlEncodedContent(new[]
        //            {
        //            new KeyValuePair<string, string>("grant_type", "password"),
        //            new KeyValuePair<string, string>("username", userName),
        //            new KeyValuePair<string, string>("password", password),
        //            });

        //            //send request
        //            HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);

        //            //get access token from response body
        //            if (responseMessage.IsSuccessStatusCode)
        //            {
        //                var responseJson = await responseMessage.Content.ReadAsStringAsync();
        //                var jObject = JObject.Parse(responseJson);
        //                return jObject.GetValue("access_token").ToString();
        //            }
        //            return null;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
            
        //}

        //public async Task<TModel> GetItemAsync<TModel>(string url) where TModel : class, IModel
        //{
        //    try
        //    {
        //        client.BaseAddress = new Uri(Constants.BaseRestUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Clear();

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserSetting.Token);

        //        var responseMessage = await client.GetAsync(url);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string resultContent = await responseMessage.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<TModel>(resultContent);
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            if (UserSetting.IsLoggedIn)
        //            {
        //                PubSub.Publish(new Events.Message(Message.MessageType.TokenExpired));
        //            }
                     
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //        throw;
        //    }
            
        //}

        //public async Task<int> BidActions(string url, MessageBidAction.BidActionType action, string id)
        //{
        //    try
        //    {
        //        client.BaseAddress = new Uri(Constants.BaseRestUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Clear();

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserSetting.Token);

        //        if(action == MessageBidAction.BidActionType.Deactivate || action == MessageBidAction.BidActionType.Delete)
        //        {
        //            url = url + "?id=" + id;
        //        }else
        //        {
        //            url = url + "?phone=" + id;
        //        }

        //        var responseMessage = await client.GetAsync(url);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string resultContent = await responseMessage.Content.ReadAsStringAsync();
        //            return 1;
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            if (UserSetting.IsLoggedIn)
        //            {
        //                PubSub.Publish(new Events.Message(Message.MessageType.TokenExpired));
        //            }
                        
        //        }

        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //        throw;
        //    }

        //}


        //public async Task<List<TModel>> GetItemsAsync<TModel>(string url, Dictionary<string,string> parameters = null) where TModel : class, IModel
        //{
        //    try
        //    {
        //        client.BaseAddress = new Uri(Constants.BaseRestUrl);

        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Clear();

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        string requestUrl = url;
        //        if (parameters != null)
        //        {
        //            StringBuilder builder = new StringBuilder(url + "?");
        //            foreach (var parameter in parameters)
        //            {
        //                builder.Append($"{parameter.Key}={parameter.Value}&");                        
        //            }
        //            requestUrl = builder.ToString();
        //        }

        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserSetting.Token);

        //        var responseMessage = await client.GetAsync(requestUrl);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string resultContent = await responseMessage.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<List<TModel>>(resultContent);
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            if (UserSetting.IsLoggedIn)
        //            {
        //                PubSub.Publish(new Events.Message(Message.MessageType.TokenExpired));
        //            }

        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //        return null;
        //    }
        //}

        //public async Task<List<TModel>> GetExternalCoursesItemsAsync<TModel>() where TModel : class, IModel
        //{
        //    try
        //    {
        //        client.BaseAddress = new Uri(Constants.GetCurrencyCourseBase);

        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Clear();

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.Timeout = TimeSpan.FromMilliseconds(2500);

        //        var responseMessage = await client.GetAsync(Constants.GetCurrencyCourse);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string resultContent = await responseMessage.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<List<TModel>>(resultContent);
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //        return null;
        //    }
        //}


        //Task IRestService.DeleteItemAsync<TModel>(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<TModel> SaveItemAsync<TModel>(string data, bool isNewItem) where TModel : class, IModel
        //{
        //    if (isNewItem)
        //    {
        //        //var uri = new Uri(Constants.ResolverUri(Constants.RegisterUrl));
        //        try
        //        {
        //            var content = new StringContent(data, Encoding.UTF8, "application/json");

        //            var response = await client.PostAsync(Url, content);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string resultContent = await response.Content.ReadAsStringAsync();
        //                return JsonConvert.DeserializeObject<TModel>(resultContent);
        //            }
        //            if (response.StatusCode == HttpStatusCode.Unauthorized)
        //            {
        //                PubSub.Publish(new Events.Message(Message.MessageType.TokenExpired));
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(@"ERROR {0}", ex.Message);
        //        }
        //    }

        //    return null;
        //}

        //public void InitUri(string uri)
        //{
        //    Url = uri;
        //}

        //public async Task<string> VerifyUserToken(string token)
        //{

        //    client.BaseAddress = new Uri(Constants.BaseRestUrl);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Clear();

        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //    //setup login data
        //    var formContent = new FormUrlEncodedContent(new[]
        //    {
        //            new KeyValuePair<string, string>("Authorization", "Bearer "+token)
        //            //new KeyValuePair<string, string>("ContentType", "application/x-www-form-urlencoded")
        //            });

        //    //send request
        //    try
        //    {
        //        var responseMessage = await client.GetAsync(Constants.PingUser);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string resultContent = await responseMessage.Content.ReadAsStringAsync();
        //            return resultContent;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"ERROR {0}", ex.Message);
        //    }


        //    //if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //    //{
        //    //    PubSub.Publish(new Events.Message(Message.MessageType.TokenExpired));
        //    //}

        //    return null;

        //}

        //public async Task<string> GetLocationAddress(string lan, string lat)
        //{
        //    string locationString = string.Empty;
        //    string locationApiurl = string.Format(Constants.GeoLocationApiBaseUrl, lat, lan, Constants.GeoKey);
        //    var uri = new Uri(locationApiurl);

        //    try
        //    {
        //        var response = await client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode) { 
                
        //            locationString = await response.Content.ReadAsStringAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"ERROR {0}", ex.Message);
        //    }
        //    return locationString;

        //}
    }
}
