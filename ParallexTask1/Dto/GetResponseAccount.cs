namespace ParallexTask1.Dto
{
    public class GetResponseAccount
    {
      public bool success { get; set; }

      public string message { get; set; }

      public Data  data { get; set; }

      public int  stausCode { get; set; }

      public string responseCode { get; set; }
    }

    public class Data
    {
        public bool validateCustomer { get; set; }

        public string accountNumber { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

        public string username { get; set; }
    }
}
