using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketerApp.APIConnector.Converters
{
    public abstract class BasicConverter<T> : JsonConverter<List<T>>
    {
    }
}
