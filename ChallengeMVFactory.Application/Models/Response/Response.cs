 

namespace ChallengeMVFactory.Application.Models.Response
{
    public class Response
    {

        public object _data { get; set; } = null;

        public string _messageerror { get; set; }

        public bool _error { get; set; }

        public Response(Exception ex)
        {
            _messageerror = ex.Message;
            _error = true;

        }

        public Response(object data) { 
            _data = data;
            _error = false;
        }
    }
}
