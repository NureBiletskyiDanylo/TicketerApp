using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketerApp.APIConnector.Converters
{
    public abstract class BasicConverter<T> : JsonConverter<List<T>>
    {
    }
}
