using System;

namespace PdaHub.Models.Item
{
    public record ItemSectionEnitiyModel
    {

        public short? itemclass { get; set; }
        public short section { get; set; }
        public string a_name { get; set; }
        public string l_name { get; set; }
        public short? usage { get; set; }
        public DateTime? transdate { get; set; }
    }

}



