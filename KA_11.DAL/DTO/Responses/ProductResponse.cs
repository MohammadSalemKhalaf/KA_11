using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KA_11.DAL.DTO.Responses
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string mainImage { get; set; }
        public string mainImageUrl => $"https://localhost:7174/images/{mainImage}";




    }
}
