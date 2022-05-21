namespace BusinessManagement.API.Settings
{
    //để cái mail của mình dô
    public class EmailConfig
    {
        //nhập đồ mình dô
        public string UserName { get; set; } = "huyquang22241@gmail.com";
        public string Password { get; set; } = "0932711257";
        public string DisplayName { get; set; } = "KHV";
        //để y chang vậy
        public string Host { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public bool EnableSsl { get; set; } = true;
        public bool UseDefaultCredentials { get; set; } = false;
    }
}
