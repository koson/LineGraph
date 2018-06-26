using System;
using System.Collections.Generic;
using System.Text;

namespace LineGraph.DataReceiver
{
    //记录登录的用户Id
    class UserHelper
    {
        public static byte[] sDeviceRuiFenProtocol = { 0x68, 0x04, 0x00,0x04,0x08 };
        public static int sDeviceRuiFenProtocolAdr = 2;
        public static int sDeviceRuiFenProtocolCrc0 = 4;

        public static byte[] sDeviceXiJuProtocol = { 0x02, 0x03, 0x00, 0x04, 0x00, 0x02, 0x85,0xF9};
        public static int sDeviceXiJuProtocolAdr = 0;
        public static int sDeviceXiJuProtocolCrc0 = 6;
        public static int sDeviceXiJuProtocolCrc1 = 7;

        public static List<byte[]> DeviceDataProtocolList = new List<byte[]>();

        public static List<KeyValuePair<byte, byte>> DeviceDataAdrList = new List<KeyValuePair<byte, byte>>();
    }
}


