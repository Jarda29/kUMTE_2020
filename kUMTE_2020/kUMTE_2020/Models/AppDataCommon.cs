using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace kUMTE_2020.Models
{
    public class AppDataCommon
    {
        [PrimaryKey]
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
