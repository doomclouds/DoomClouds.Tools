namespace DoomClouds.Tools.Community.Interface
{
    public interface IMessage
    {
        byte[] Datas { get; set; }
        byte[] Buffer { get; set; }
        int ReadBytes { get; set; }
    }
}
