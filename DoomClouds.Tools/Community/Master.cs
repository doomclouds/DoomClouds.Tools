using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DoomClouds.Tools.Community.Device;
using DoomClouds.Tools.Community.Interface;
using DoomClouds.Tools.Community.Message;
using DoomClouds.Tools.Helpers.Log;

namespace DoomClouds.Tools.Community
{
    public abstract class Master : BaseMaster
    {
        public static readonly object locker = new object();

        public List<string> IgnoreStringList { get; set; } = new List<string>();

        public Master(IStreamResource streamResource) : base(streamResource)
        {

        }

        public override void InitTimeout()
        {
            StreamResource.ReadTimeout = 50;
            StreamResource.WriteTimeout = 50;
        }

        public override IMessage Unicast(IMessage message)
        {
            lock (locker)
            {
                int times = ReadWriteTimes;
                byte[] buffer = new byte[message.ReadBytes];
                byte[] sendDatas = message.Datas;
                while (times > 0)
                {
                    StreamResource.DiscardInBuffer();
                    SendData(message);

                    try
                    {
                        string result = "";
                        do
                        {
                            int numBytesRead = 0;
                            while (numBytesRead != message.ReadBytes)
                            {
                                numBytesRead += StreamResource.Read(buffer, numBytesRead, message.ReadBytes - numBytesRead);
                            }                          
                            result = BitConverter.ToString(buffer).Replace("-", " ");
                        }
                        while (IgnoreStringList.Contains(result));

                        message.Buffer = buffer;
                        result = BitConverter.ToString(buffer).Replace("-", " ");
                        LogHelper.Default.Debug("RX:" + DateTime.Now.ToString("HH:mm:ss:fff ") + BitConverter.ToString(buffer).Replace("-", " "));
                    }
                    catch (Exception)
                    {
                        times--;
                        continue;
                    }

                    if (!CheckData(message))
                    {
                        LogHelper.Default.Error("数据校验错误," + BitConverter.ToString(buffer).Replace("-", " "));
                        times--;
                        continue;
                    }
                    break;
                }
                
                if (times <= 0) throw new Exception("通讯超时");               
                return message;
            }
        }
    }
}
