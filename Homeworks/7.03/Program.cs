using DotaParser52;

Reader reader = new Reader(); 
reader.Read();
var start = new Client();
var filter = new Filter(reader.Data);
filter.Filtering(start.UserOrder());