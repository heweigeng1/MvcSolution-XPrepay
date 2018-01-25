using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Xprepay.Services.SearchCriterias
{
    public class SCKey
    {
        /// <summary>
        /// key
        /// </summary>
        [JsonProperty("key")]
        public Guid Id { get; set; }
    }
}
