using Kavenegar;
using Microsoft.Extensions.Configuration;

namespace Framework.Application.SMS
{
    public class SmsService : ISmsService
    {
        private IConfiguration _configuration;

        public SmsService(IConfiguration configuration) => _configuration = configuration;

        public void SendSms(string mobile, string message)
        {
            var smsConfig = _configuration.GetSection("SmsService");
            var sender = smsConfig.GetSection("Number").Value;
            var api = new KavenegarApi(smsConfig.GetSection("ApiKey").Value);
            api.Send(sender, mobile, message);
        }
    }
}
