using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
namespace Chat.UseCases.GetStock
{
    public class CSVStock
    {

        [Name("Symbol")]
        public string Symbol { get; set; }
        [Name("Open")]
        public decimal Open { get; set; }
        [Name("High")]
        public decimal High { get; set; }
        [Name("Close")]
        public decimal Close { get; set; }
        [Name("Volume")]
        public decimal Volume { get; set; }
    }
}
