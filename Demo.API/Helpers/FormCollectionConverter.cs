using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Helpers
{
    public static class FormCollectionConverter
    {
        public static string ToJSON(IFormCollection collection)
        {
            var list = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                list.Add(key, collection[key]);
            }
            return JsonConvert.SerializeObject(list);
        }
    }
}
