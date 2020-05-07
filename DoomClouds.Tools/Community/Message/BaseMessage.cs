using DoomClouds.Tools.Community.Interface;

namespace DoomClouds.Tools.Community.Message
{
    public class BaseMessage : IMessage
    {
        public byte[] Datas { get; set; }
        public byte[] Buffer { get; set; }
        public int ReadBytes { get; set; } = 13;
        public int SendBytes { get; set; } = 13;
    }
}
