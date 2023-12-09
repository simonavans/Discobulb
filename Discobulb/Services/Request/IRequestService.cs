using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Discobulb.Services.Request
{
    public interface IRequestService
    {
        Task<JsonObject?> GetJsonObjectAsync(string path);
        Task<JsonArray?> GetJsonArrayAsync(string path);
        Task<bool> PutJsonAsync(string path, JsonObject json);
    }
}
