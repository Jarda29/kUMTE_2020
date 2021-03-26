using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace kUMTE_2020.Models.Covid
{
    public class Covid19JsonResult
    {
        public static string Url => "https://onemocneni-aktualne.mzcr.cz/api/v1/covid-19/testy.json";

        public DateTime Modified { get; set; }
        public string Source { get; set; }

        public IList<Record> Data { get; set; }


        public class Record
        {
            [JsonProperty("datum")]
            public string Date { get; set; }
            [JsonProperty("prirustkovy_pocet_testu")]
            public string PrirustkovyPocetTestu { get; set; }

            [JsonProperty("kumulativni_pocet_testu")]
            public string KumulativniPocetTestu { get; set; }

            [JsonProperty("prirustkovy_pocet_prvnich_testu")]
            public string PrirustkovyPocetPrvnichTestu { get; set; }

            [JsonProperty("kumulativni_pocet_prvnich_testu")]
            public string KumulativniPocetPrvnichTestu { get; set; }
        }
    }
}
