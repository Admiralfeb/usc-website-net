namespace UnitedSystemsCooperative.Web.EmailService;

public interface IEmailSender
{
    void SendEmail(Message message);
}