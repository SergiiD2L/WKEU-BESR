using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKEU_BESR.Events;
using WKEU_BESR.Models;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Services.RestService
{
    public interface IRestService
    {
        void InitUri(string uri);

        Task<TModel> GetItemAsync<TModel>(string url) where TModel : class, IModel;

        Task<List<TModel>> GetItemsAsync<TModel>(string url, Dictionary<string, string> parameters = null) where TModel : class, IModel;
        Task<List<TModel>> GetExternalCoursesItemsAsync<TModel>() where TModel : class, IModel;

        Task<TModel> GetItemByIdAsync<TModel>(string id) where TModel : class, IModel;

        Task<TModel> AuthenticateAsync<TModel>(string username, string password) where TModel : class, IModel;

        //Task<int> BidActions(string url, MessageBidAction.BidActionType action, string id);

        Task<TModel> SaveItemAsync<TModel>(string data, bool isNewItem) where TModel : class, IModel;

        Task DeleteItemAsync<TModel>(string id) where TModel : class, IModel;

        Task<string> VerifyUserToken(string token);

        Task<string> GetAPIToken(string username, string password);

        Task<string> GetLocationAddress(string lan, string lat);
    }
}
