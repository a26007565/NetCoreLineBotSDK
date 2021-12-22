using NetCoreLineBotSDK.Models.Message;

namespace NetCoreLineBotSDK.Interfaces
{
    public interface IFlex : IRequestMessage
    {
        public dynamic Contents { get; set; }

        public QuickReply QuickReply { get; set; }

    }
}