namespace Chat.ChatWebBrowser.Configurations
{
    public class MyAPIConfig
    {
        public string url { get; set; }
        public string createUserMethod { get; set; }
        public string getEmailByPassMethod { get; set; }
        public string StockMethodName { get; set; }
        public string StockMethodParams { get; set; }
        public string stockMethod
        {
            get
            {
                return url + StockMethodName + "?" + StockMethodParams;
            }
        }
        public string saveUserMethod
        {
            get; set;
        }
        public string getRoomsMethod { get; set; }
        public string getMessageByRoomMethodName
        {
            get; set;
        }
        public string getMessageByRoomMethodParams{
            get;set;
        }
        public string getMessageByRoomMethod
        {
            get
            {
                return url + getMessageByRoomMethodName + "?" + getMessageByRoomMethodParams;
            }
        }
    }
}
