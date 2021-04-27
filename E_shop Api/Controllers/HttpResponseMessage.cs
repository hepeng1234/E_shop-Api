namespace E_shop_Api.Controllers
{
    internal class HttpResponseMessage : System.Net.Http.HttpResponseMessage
    {
        public object Content { get; set; }
    }
}