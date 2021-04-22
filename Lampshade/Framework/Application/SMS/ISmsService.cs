namespace Framework.Application.SMS
{
    public interface ISmsService
    {
        void SendSms(string mobile, string message);
    }
}
