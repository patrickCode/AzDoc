using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzDoc.Common.Models
{
    public class StepDto
    {
        [JsonProperty(PropertyName = "id")]
        public string StepId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
