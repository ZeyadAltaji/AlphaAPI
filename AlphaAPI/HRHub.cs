using AlphaAPI.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaAPI
{
    public class HRHub : Hub
    {

        public IMemoryCache cache;

        public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        public static IHubContext<HRHub> Current { get; set; }

        public Task Send(string name, string message)
        {
            return Clients.All.SendCoreAsync("OnMessage", new object[] { name, message });
        }

        public HRHub(IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }

        public void AddUser(string UserId)
        {
            //cache.Remove(Context.ConnectionId);
            //cache.Set(Context.ConnectionId, "user-" + UserId);
            //if (offline.Where(x => x.UserID == UserId).Count() > 0)
            //{
            //    foreach (var cx in offline.Where(x => x.UserID == UserId))
            //    {
            //        wfCL c = JsonConvert.DeserializeObject<wfCL>(cx.connection);
            //        Clients.Client(Context.ConnectionId)
            //        .SendCoreAsync(
            //        c.RAction.ToUpper() == "CR" ? "WFNEWACTION" : "WFNEWNOTIFI",
            //        new object[] {c.CompNo,c.TID,c.RAction,c.FID,c.K1,c.K2,c.K3,c.K4,c.FunctionDesc,c.FunctionDescEn,c.wFDesc,c.ConfirmCol,c.RejectCol,c.NotifiyCol,c.DateAdded,c.comp_name,c.comp_ename,c.BUUser});
            //        cache.Remove(cx.connection);
            //    }

            //}
        }

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    //  cache.Remove(Context.ConnectionId);
        //    //   await base.OnDisconnectedAsync(exception);
        //}
        //public override async Task OnConnectedAsync()
        //{
        //    var t = 9;
        //}
        private List<SignalRUser> offline
        {
            get
            {
                var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(cache) as dynamic;
                List<SignalRUser> x = new List<SignalRUser>();
                foreach (var cacheItem in cacheEntriesCollection)
                {
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                    x.Add(
                        new SignalRUser()
                        {
                            Type = cacheItemValue.Value.ToString().Split('-')[0],
                            UserID = cacheItemValue.Value.ToString().Split('-')[1],
                            connection = cacheItemValue.Key.ToString(),
                        });
                }
                return x.Where(c => c.Type == "offline").ToList();
            }
        }
    }
}
