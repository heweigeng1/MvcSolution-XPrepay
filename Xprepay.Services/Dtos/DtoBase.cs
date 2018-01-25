using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Xprepay.Services.Dtos
{
    public class DtoBase
    {
        [JsonProperty("key")]
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public int Delflag { get; set; }
    }
}
