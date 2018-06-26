using System;
using System.Collections.Generic;
using System.Text;

namespace LineGraph.SuperMapUtility
{
    class UserHelper
    {
        public static string[] sModelName = { @"..\..\Bin64\Ref\3DData\Models\Airplane\Airplane.SGM",
        @"..\..\Bin64\Ref\3DData\Models\Airplane\Airplane.SGM",
        @"..\..\Bin64\Ref\3DData\Models\Airplane\Airplane.SGM"};
        public static string[] sDeviceName = {"水准仪", "倾角仪" , "加速计" };
        public static string sTextName = "Text";
        //public static int[] MarkerSymbolID = { 330113, 330112, 330111 };
        public static int[] MarkerSymbolID = { 3, 1, 2 };
        public static int[] Marker3DSymbolID = { 330107, 330110, 330109 };
        public static bool bMeasure = false;
        public static bool bAddSymbolMark = false;
        public static bool bAddSymbolFill = false;

        public static string MapLayerName = "gugong_5_adjust@gugong1";
        
        public static string MapLayerName正射影像 = "正射影像图拼@gongyuan";
        public static string MapLayerName线划图 = "地形图@gongyuan2";
        public static string MapLayerName卫星影像 = "莒县卫星影像@gongyuan";

        public static string SceneLayerName = "gugong5@gugong1";
        //public static string SceneLayerName = "lijiaoqiao@lijiaoqiao";
        //public static string SceneLayerName = "JUXIAN3@gongyuan";
        public static string SceneLayerOSGBName = "倾斜摄影";

        public static string WorkSpaceName = @"..\..\Bin64\Ref\3DData\GuGong\GuGong.smwu";
        //public static string WorkSpaceName = @"..\..\Bin64\Ref\3DData\Bridge\Bridge.smwu";
        //public static string WorkSpaceName = @"..\..\Bin64\Ref\3DData\JuXian\gongyuan.smwu";

        public static string DefaultWorkSpaceName = @"..\..\Bin64\Ref\3DData\DefaultSpace\DefaultSpace.smwu";

        public static string KMLFile = @"..\..\Bin64\Ref\3DData\sensor.kml";
        public static int nDeviceNum = 3;

        //传感设备命名规则SZ1/QJ1/JS1(传感地址)
 
    }
}
