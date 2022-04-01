namespace Chat.ChatWebBrowser
{
    public class MyAPIConfig
    {
        public string url { get; set; }
        public string StockMethodName { get; set; }
        public string StockMethodParams { get; set; }
        public string stockMethod
        {
            get
            {
                return url + StockMethodName + "?"+StockMethodParams;
            } 
        }
    }
}
