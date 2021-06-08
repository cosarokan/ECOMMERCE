namespace ECOMMERCE.WEBUI.Notification
{
    public interface INotification
    {
        /// <summary>
        /// Mesaj gönderimi yapar
        /// </summary>
        /// <param name="receiver">Alıcı bilgisi</param>
        /// <param name="message">Mesaj</param>
        void SendMessage(string receiver, string message);
    }
}