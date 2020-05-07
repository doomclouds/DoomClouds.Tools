using System;
using System.Collections;
using DoomClouds.Tools.Community.Interface;
using DoomClouds.Tools.Helpers.Log;

namespace DoomClouds.Tools.Community.Device
{
    public abstract class BaseMaster
    {
        public int ReadWriteTimes { get; set; } = 3;

        public BaseMaster(IStreamResource streamResource)
        {
            StreamResource = streamResource;
            InitTimeout();
        }

        public IStreamResource StreamResource { get; set; }

        public void SendData(IMessage message)
        {
            StreamResource.Write(message.Datas, 0, message.Datas.Length);
            string recStr = "";
            for (int i = 0; i < message.ReadBytes; i++)
            {
                recStr = recStr + string.Format("{0:x2}", message.Datas[i]) + " ";
            }
            LogHelper.Default.Debug("TX:" + DateTime.Now.ToString("HH:mm:ss:fff ") + recStr);
        }

        public abstract void InitTimeout();

        public abstract IMessage Unicast(IMessage message);

        public abstract bool CheckData(IMessage message);

        public abstract IMessage CreateFrame((byte id, byte cmd, byte[] frame) noCheckFrame);
    }
}
