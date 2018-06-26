///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、范例简介：示范三维符号（三维模型符号、线符号和水面填充符号）在场景中的显示与操作。
//2、示例数据：
//安装目录\SampleData\Symbol3DDisplay\Symbol3DDisplay.smwu
//安装目录\SampleData\Symbol3DDisplay\Model\Subway.kml
//安装目录\SampleData\Symbol3DDisplay\flyground.fpf
//安装目录\SampleData\SymbolLibrary\FillLibrary3D.bru
//安装目录\SampleData\SymbolLibrary\LineLibrary3D.lsl
//安装目录\SampleData\SymbolLibrary\MarkerLibrary3D.sym
//3、关键类型/成员: 
//      Workspace.Resources 属性
//      Resources.MarkerLibrary 属性
//      Resources.LineLibrary 属性
//      Resources.FillLibrary 属性
//      SymbolMarkerLibrary.FromFile 方法
//      SymbolLineLibrary.FromFile 方法
//      SymbolFillLibrary.FromFile 方法
//      SceneControl.Scene 属性
//      SceneControl.Tracked 事件
//      SceneControl.MouseClick 事件
//      Scene.Underground 属性  
//      Scene.PixelToGlobe 方法   
//      DatasetVector.GetRecordset 方法
//      Recordset.AddNew 方法
//      Recordset.Update 方法
//      GeoStyle3D.AltitudeMode 属性
//      GeoStyle3D.BottomAltitude 属性
//      GeoStyle3D.MarkerSymbolID 属性
//      GeoStyle3D.IsMarkerSizeFixed 属性 
//      GeoStyle3D.MarkerSize 属性
//      GeoStyle3D.Marker3DScaleX 属性 
//      GeoStyle3D.Marker3DScaleY 属性
//      GeoStyle3D.Marker3DScaleZ 属性 
//      GeoStyle3D.LineSymbolID 属性
//      GeoStyle3D.LineWidth 属性 
//      GeoStyle3D.FillSymbolID 属性
//      GeoPoint3D.Style3D 属性
//      GeoLine3D.Style3D 属性
//      GeoRegion3D.Style3D 属性   
//4、使用步骤：
//   (1)在符号交互去，选择点符号类型，在场景中绘制点；
//   (2)选择线符号类型，在场景中绘制线；
//   (3)选择水面符号类型，在场景中绘制面；
//   (4)结束绘制操作后，将鼠标状态切换到漫游状态；
//   (5)在符号展示区选择北京地铁线，观看该线数据的动态飞行的效果；
//   (6)在场景中选择一条线数据，可执行沿所绘制线飞行的操作。
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using System.Windows.Forms;
using SuperMap.Mapping;
using SuperMap.Analyst.NetworkAnalyst;

namespace LineGraph.SuperMapUtility
{
    class NetworkGeometry
    {
        public Geometry geometry;
        public int nID;
        public int nFNode;
        public int nTNode;
        public bool bIsIn;

        public NetworkGeometry()
        {
            nID = -1;
            nFNode = -1;
            nTNode = -1;
            geometry = null;
            bIsIn = true;
        }

        ~NetworkGeometry()
        {
        }
    }

    // 模拟三维网络数据的结构，标识当前点的前一结点，后一结点等逻辑结构信息，为计算管点方向提供依据
    public class Vector3d
    {
        public double x, y, z;
        public Vector3d()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3d(double fX, double fY, double fZ)
        {
            x = fX;
            y = fY;
            z = fZ;
        }

        public Vector3d Sub()
        {
            Vector3d TempVec = new Vector3d();
            TempVec.x = -x;
            TempVec.y = -y;
            TempVec.z = -z;
            return TempVec;
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3d Normalize()
        {
            double fLength = 0.0;
            fLength = Length();

            x /= fLength;
            y /= fLength;
            z /= fLength;
            Vector3d TempVec = new Vector3d(x, y, z);
            return TempVec;
        }

        public double DotProduct(Vector3d vec)
        {
            return x * vec.x + y * vec.y + z * vec.z;
        }
        public Vector3d CrossProduct(Vector3d vec)
        {
            Vector3d TempVector = new Vector3d();
            TempVector.x = y * vec.z - z * vec.y;
            TempVector.y = z * vec.x - x * vec.z;
            TempVector.z = x * vec.y - y * vec.x;

            return TempVector;
        }
    }

    class SampleDesignerRun
    {
        public Workspace m_workspace;
        private SceneControl m_sceneControl;
        private DatasetVector m_datasetLine3D;
        public Boolean flag = true;
        public FlyManager flyManager;
        private List<NetworkGeometry> m_SelectedGeoNetwork;
        public Boolean isDraw = false;
        private Boolean PointLineCamera = true;
        private Int32 m_region3DIndex;
        private Int32 m_line3DIndex;
        private Int32 m_marker3DIndex = 253311;
        public Int32 routestopCount;
        private RouteStop stop;
        public Route route;
        public String routestopName;
        private double RTOD = 57.295779513082320876798154814;
        private double DTOR = 0.017453292519943295769236907684894;

        private Layer3DDataset m_layer3DPoint;
        private Layer3DDataset m_layer3DRegionPoint;
        private Layer3DDataset m_layer3DLine;
        private Layer3DDataset m_layer3DRegion;

        private Boolean isRegion = false;
        private Boolean ispointRegion = false;

        /// <summary>
        ///  根据sceneControl构造 SampleRun对象
        /// </summary>
        /// <param routestopName="sceneControl"></param>
        public SampleDesignerRun(Workspace workspace, SceneControl sceneControl)
        {
            try
            {
                m_workspace = workspace;
                m_sceneControl = sceneControl;
                flyManager = m_sceneControl.Scene.FlyManager;

                //注册事件            
                m_sceneControl.Tracked += new Tracked3DEventHandler(m_sceneControl_Tracked);
                m_sceneControl.MouseClick += new MouseEventHandler(m_sceneControl_MouseClick);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void CreateLineDataset()
        {
            try
            {
                //新建线数据集，用于临时绘制线形符号
                if (m_workspace.Datasources[0].Datasets.Contains("Line3D"))
                {
                    m_workspace.Datasources[0].Datasets.Delete("Line3D");
                }

                //定义新数据集
                DatasetVectorInfo Datasetinfo = new DatasetVectorInfo();
                Datasetinfo.Type = DatasetType.CAD;
                Datasetinfo.Name = "Line3D";
                m_workspace.Datasources[0].Datasets.Create(Datasetinfo);


                m_datasetLine3D = m_workspace.Datasources[0].Datasets["Line3D"] as DatasetVector;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 静态展示地铁和管道
        /// </summary>
        /// <param routestopName="selectID"></param>
        public void comBoxDisplayLine3D(int selectID)
        {
            try
            {
                int selectinonID = selectID;
                //先进行地表挖方
                m_sceneControl.Scene.Refresh();
                m_sceneControl.Scene.Underground.IsVisible = true;
                m_sceneControl.Scene.GlobalImage.Transparency = 0;
                DatasetVector dataSet_Region = m_workspace.Datasources["Pipeline3D"].Datasets["Region"] as DatasetVector;

                int[] id = { 1 };
                Recordset recordset = dataSet_Region.Query(id, CursorType.Static);
                GeoRegion georegion = recordset.GetGeometry() as GeoRegion;
                int i = m_sceneControl.Scene.GlobalImage.AddExcavationRegion(georegion, "地表局部透明");

                switch (selectinonID)
                {
                    case 0:
                        {
                            LoadSubway();
                            break;
                        }
                    case 1:
                        {
                            LoadPipeLine3D();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载地下管道线
        /// </summary>
        public void LoadPipeLine3D()
        {
            try
            {
                m_SelectedGeoNetwork = new List<NetworkGeometry>();
                DatasetVector dataset_PipeLine = m_workspace.Datasources["Pipeline3D"].Datasets["PipeLine3D"] as DatasetVector;
                DatasetVector dataset_PipePoint = m_workspace.Datasources["Pipeline3D"].Datasets["PipePoint3D"] as DatasetVector;

                Layer3DSettingVector setvetor = new Layer3DSettingVector();
                setvetor.Style.AltitudeMode = AltitudeMode.RelativeToGround;
                setvetor.Style.LineSymbolID = 962048;
                setvetor.Style.LineWidth = 0.35;


                Layer3DDataset layer_ditie = m_sceneControl.Scene.Layers.Add(dataset_PipeLine, setvetor, true, "PipeLine3D");
                Layer3DDataset layer_pipepoint = m_sceneControl.Scene.Layers.Add(dataset_PipePoint, setvetor, true, "PipePoint3D");

                if (dataset_PipePoint != null)
                {
                    Theme3DUnique theme = new Theme3DUnique();
                    theme.UniqueExpression = "SmID";
                    GeoStyle3D style3D = new GeoStyle3D();
                    style3D.AltitudeMode = AltitudeMode.RelativeToGround;
                    style3D.Marker3DScaleX = 2.2;
                    style3D.Marker3DScaleY = 2.2;
                    style3D.Marker3DScaleZ = 2.2;

                    style3D.IsMarker3D = true;
                    theme.DefaultStyle = style3D;
                    Recordset rs = dataset_PipePoint.Query("", CursorType.Static);
                    rs.MoveFirst();
                    while (!rs.IsEOF)
                    {
                        Theme3DUniqueItem item = new Theme3DUniqueItem();
                        item.Unique = rs.GetID().ToString();
                        item.IsModellingStyleEnabled = true;
                        GeoStyle3D tempStyle = new GeoStyle3D(style3D);
                        PickNodeToLine(rs.GetID());
                        GeoPoint3D geoPoint3D = rs.GetGeometry() as GeoPoint3D;

                        List<Vector3d> arrVector3d = new List<Vector3d>();
                        for (Int32 curIndex = 0; curIndex < m_SelectedGeoNetwork.Count; curIndex++)
                        {
                            NetworkGeometry geoNetWork = m_SelectedGeoNetwork[curIndex];

                            if (geoNetWork != null)
                            {
                                Vector3d vec = new Vector3d();
                                GeoLine3D geoLine = geoNetWork.geometry as GeoLine3D;
                                if (geoNetWork.bIsIn)
                                {
                                    if (geoLine != null)
                                    {
                                        Point3Ds point3D = geoLine[0];
                                        Point3D pntTNode = point3D[1];
                                        Point3D pntFNode = point3D[0];
                                        Vector3d vecTNode = SphericalToCartesian(pntTNode.X * DTOR, pntTNode.Y * DTOR, pntTNode.Z);
                                        Vector3d vecFNode = SphericalToCartesian(pntFNode.X * DTOR, pntFNode.Y * DTOR, pntFNode.Z);

                                        vec = new Vector3d(vecFNode.x - vecTNode.x, vecFNode.y - vecTNode.y, vecFNode.z - vecTNode.z);
                                        vec.Normalize();
                                    }
                                }
                                else
                                {
                                    if (geoLine != null)
                                    {
                                        Point3Ds point3D = geoLine[0];
                                        Point3D pntFNode = point3D[0];
                                        Point3D pntTNode = point3D[1];
                                        Vector3d vecTNode = SphericalToCartesian(pntTNode.X * DTOR, pntTNode.Y * DTOR, pntTNode.Z);
                                        Vector3d vecFNode = SphericalToCartesian(pntFNode.X * DTOR, pntFNode.Y * DTOR, pntFNode.Z);

                                        vec = new Vector3d(vecTNode.x - vecFNode.x, vecTNode.y - vecFNode.y, vecTNode.z - vecFNode.z);
                                        vec.Normalize();
                                    }
                                }

                                vec = FromAngleAxis(vec, -geoPoint3D.X * DTOR, new Vector3d(0, 1, 0));
                                vec = FromAngleAxis(vec, geoPoint3D.Y * DTOR, new Vector3d(1, 0, 0));
                                vec.Normalize();
                                arrVector3d.Add(vec);
                            }
                        }

                        Vector3d vecX = new Vector3d();
                        Vector3d vecY = new Vector3d();
                        Vector3d vecZ = new Vector3d();
                        switch (m_SelectedGeoNetwork.Count)
                        {
                            case 2://弯头或阀门
                                {
                                    if (arrVector3d.Count == 2)
                                    {
                                        vecX = arrVector3d[0].Normalize().Sub();
                                        vecY = arrVector3d[1].Normalize();
                                    }

                                    double dAngle1_2 = vecX.DotProduct(vecY);
                                    if (Math.Abs(dAngle1_2) < 0.3)
                                    {
                                        tempStyle.MarkerSymbolID = 54441;
                                    }
                                    else if (-1 < dAngle1_2 && dAngle1_2 < 0.7)
                                    {
                                        tempStyle.MarkerSymbolID = 54442;
                                    }
                                    else
                                    {
                                        vecY.z = 0;
                                        Vector3d vec = new Vector3d(0, 0, 1);
                                        vecX = vecY.CrossProduct(vec);
                                        tempStyle.MarkerSymbolID = 54435;
                                    }
                                }
                                break;
                            case 3://三通
                                {
                                    tempStyle.MarkerSymbolID = 54437;

                                    if (arrVector3d.Count == 3)
                                    {
                                        Vector3d vec1 = arrVector3d[0];
                                        Vector3d vec2 = arrVector3d[1];
                                        Vector3d vec3 = arrVector3d[2];

                                        double dAngle1_2 = vec1.DotProduct(vec2);
                                        double dAngle1_3 = vec1.DotProduct(vec3);
                                        double dAngle2_3 = vec2.DotProduct(vec3);
                                        if (Math.Abs(dAngle1_2) < 0.3)
                                        {
                                            if (Math.Abs(dAngle1_3) < 0.3)
                                            {
                                                vecX = vec1.Normalize().Sub();
                                                vecY = vec2.Normalize();
                                            }
                                            else
                                            {
                                                vecX = vec2.Normalize().Sub();
                                                vecY = vec1.Normalize();
                                            }
                                        }
                                        else
                                        {
                                            vecX = vec3.Normalize().Sub();
                                            vecY = vec1.Normalize();
                                        }
                                    }
                                }
                                break;
                            case 4://四通
                                {
                                    tempStyle.MarkerSymbolID = 54438;
                                    if (arrVector3d.Count == 4)
                                    {
                                        Vector3d vec1 = arrVector3d[0];
                                        Vector3d vec2 = arrVector3d[1];
                                        Vector3d vec3 = arrVector3d[2];

                                        double dAngle1_2 = vec1.DotProduct(vec2);
                                        double dAngle1_3 = vec1.DotProduct(vec3);

                                        vecX = vec1;
                                        if (Math.Abs(dAngle1_2) < 0.3)
                                        {
                                            vecY = vec2.Normalize();
                                        }
                                        else
                                        {
                                            vecY = vec3.Normalize();
                                        }
                                    }
                                }
                                break;
                            default://结点
                                {
                                    tempStyle.MarkerSymbolID = 330101;
                                }
                                break;
                        }

                        if (m_SelectedGeoNetwork.Count > 1)
                        {
                            vecZ = vecX.CrossProduct(vecY);
                            vecZ.Normalize();

                            Vector3d vecRotate = ToEulerAnglesXYZ(vecX, vecY, vecZ);

                            tempStyle.Marker3DRotateX = -vecRotate.x * RTOD;
                            tempStyle.Marker3DRotateY = -vecRotate.y * RTOD;
                            tempStyle.Marker3DRotateZ = -vecRotate.z * RTOD;

                        }
                        item.Style = tempStyle;
                        theme.Add(item);
                        rs.MoveNext();
                    }
                    rs.Dispose();
                    Layer3D layer_theme = m_sceneControl.Scene.Layers.Add(dataset_PipePoint, theme, true, "underPipeLine3D");
                    layer_theme.IsSelectable = false;
                    if (m_sceneControl.Scene.Layers.Contains("PipePoint3D"))
                    {
                        m_sceneControl.Scene.Layers.Remove("PipePoint3D");
                    }

                    Camera camera = m_sceneControl.Scene.Camera;
                    camera.AltitudeMode = AltitudeMode.RelativeToGround;
                    camera.Altitude = 26.978640816174448;
                    camera.Latitude = 39.992608337161023;
                    camera.Longitude = 116.3898561529368;
                    camera.Tilt = 59.567389444384283;
                    camera.Heading = 300.19323029928478;
                    m_sceneControl.Scene.Fly(camera, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Vector3d ToEulerAnglesXYZ(Vector3d vecX, Vector3d vecY, Vector3d vecZ)
        {
            double dYAngle = 0, dPAngle = 0, dRAngle = 0;
            dPAngle = Math.Asin(vecX.z);
            if (dPAngle < Math.PI / 2)
            {
                if (dPAngle > -Math.PI / 2)
                {
                    dYAngle = Math.Atan2(-vecY.z, vecZ.z);
                    dRAngle = Math.Atan2(-vecX.y, vecX.x);
                    return new Vector3d(dYAngle, dPAngle, dRAngle);
                }
                else
                {
                    double fRmY = Math.Atan2(vecY.x, vecY.y);
                    dRAngle = 0.0;
                    dYAngle = dRAngle - fRmY;
                    return new Vector3d(dYAngle, dPAngle, dRAngle); ;
                }
            }
            else
            {
                double fRpY = Math.Atan2(vecY.x, vecY.y);
                dRAngle = 0.0;
                dYAngle = fRpY - dRAngle;
                return new Vector3d(dYAngle, dPAngle, dRAngle);
            }
        }

        public int PickNodeToLine(int nID)
        {
            m_SelectedGeoNetwork.Clear();
            DatasetVector DvLine = m_workspace.Datasources["Pipeline3D"].Datasets["PipeLine3D"] as DatasetVector;
            DatasetVector DvNode = m_workspace.Datasources["Pipeline3D"].Datasets["PipePoint3D"] as DatasetVector;

            int[] id = { nID };
            Recordset recordset = DvNode.Query(id, CursorType.Static);
            Geometry pGeoNode = recordset.GetGeometry();

            string strNodeID = "PtID";
            int nNodeID = Convert.ToInt32(recordset.GetFieldValue(strNodeID));

            string strFNode = "FNode";
            string strTNode = "ENode";
            QueryParameter queryparameter = new QueryParameter();
            queryparameter.CursorType = CursorType.Static;

            queryparameter.AttributeFilter = String.Format("{0}={1} or {2}={3}", strFNode, nNodeID, strTNode, nNodeID);
            Recordset Rs = DvLine.Query(queryparameter);

            int nCount = Rs.RecordCount; ;
            Rs.MoveFirst();
            while (!Rs.IsEOF)
            {
                GeoLine3D geoline3D = Rs.GetGeometry() as GeoLine3D;

                NetworkGeometry NetWorkGeometry = new NetworkGeometry();
                NetWorkGeometry.nID = geoline3D.ID;
                NetWorkGeometry.nFNode = Convert.ToInt32(Rs.GetFieldValue(strFNode));
                NetWorkGeometry.nTNode = Convert.ToInt32(Rs.GetFieldValue(strTNode));

                if (!m_SelectedGeoNetwork.Contains(NetWorkGeometry))
                {
                    if (NetWorkGeometry.nTNode == nNodeID)
                    {
                        NetWorkGeometry.geometry = geoline3D;
                        m_SelectedGeoNetwork.Add(NetWorkGeometry);//流入对象在第一位
                    }
                    else
                    {
                        NetWorkGeometry.bIsIn = false;
                        NetWorkGeometry.geometry = geoline3D;
                        m_SelectedGeoNetwork.Add(NetWorkGeometry);//线对象
                    }
                }

                Rs.MoveNext();
            }
            Rs.Dispose();
            return nCount;
        }

        /// <summary>
        /// 加载北京地铁数据
        /// </summary>
        public void LoadSubway()
        {
            try
            {
                if (!m_sceneControl.Scene.Layers.Contains("ditie3"))
                {
                    //加载北京地铁数据集                   
                    DatasetVector dataset_subway = m_workspace.Datasources["Pipeline3D"].Datasets["BeijingSubway"] as DatasetVector;
                    DatasetVector dataset_label = m_workspace.Datasources["Pipeline3D"].Datasets["StopsName"] as DatasetVector;
                    Layer3DSettingVector setvetor = new Layer3DSettingVector();
                    setvetor.Style.AltitudeMode = AltitudeMode.RelativeToGround;
                    setvetor.Style.BottomAltitude = 5;
                    setvetor.Style.LineWidth = 100;
                    setvetor.Style.LineSymbolID = 962046;
                    //setvetor.Style.MarkerColor = Color.Blue; ;                    

                    Layer3DSettingVector pointSetting = new Layer3DSettingVector();
                    pointSetting.Style.AltitudeMode = AltitudeMode.ClampToGround;
                    pointSetting.Style.MarkerSize = 1;
                    pointSetting.Style.MarkerFile = @"..\..\SampleData\Symbol3DDisplay\SubwayMarkerLibrary.png";
                    pointSetting.Style.IsMarkerSizeFixed = true;
                    pointSetting.Style.MarkerScale = 1;
                    m_sceneControl.Scene.Underground.IsVisible = false;
                    Layer3D layer_ditie = m_sceneControl.Scene.Layers.Add(dataset_subway, setvetor, true, "ditie3");

                    //标签专题图
                    Theme3DLabel themeLabel = new Theme3DLabel();
                    themeLabel.LabelExpression = "Name";
                    themeLabel.UniformStyle.IsSizeFixed = true;
                    themeLabel.UniformStyle.ForeColor = Color.Yellow;
                    themeLabel.UniformStyle.BackColor = Color.Black;
                    themeLabel.UniformStyle.Outline = true;
                    themeLabel.UniformStyle.FontScale = 1;
                    themeLabel.UniformStyle.Weight = 7;
                    themeLabel.UniformStyle.FontScale = 1.0;
                    themeLabel.UniformStyle.Alignment = TextAlignment.MiddleRight;
                    themeLabel.UniformStyle.IsSizeFixed = true;


                    Layer3D layer1 = m_sceneControl.Scene.Layers.Add(dataset_label, pointSetting, true);
                    Layer3D layer_label = m_sceneControl.Scene.Layers.Add(dataset_label, themeLabel, true);

                    Camera camera = m_sceneControl.Scene.Camera;
                    camera.AltitudeMode = AltitudeMode.RelativeToGround;
                    camera.Altitude = 5508.4005263671279;
                    camera.Latitude = 39.908042501262457;
                    camera.Longitude = 116.39138653936693;
                    camera.Tilt = 45.45877650025642;
                    camera.Heading = 0.016679026847733185;
                    m_sceneControl.Scene.Fly(camera, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 继续飞行
        /// </summary>
        public void FlymanagerFly()
        {
            flyManager.Play();
        }

        /// <summary>
        /// 加载鸟巢数据集
        /// </summary>
        public void LoadOlympicGreen()
        {
            try
            {
                m_sceneControl.Scene.Open("OlympicGreen");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 由地下飞到地上
        /// </summary>
        public void FlyUndergroud()
        {
            try
            {
                // 地下飞行时，开启地下
                m_sceneControl.Scene.Underground.IsVisible = true;
                m_sceneControl.Scene.CameraFOV = 60;
                // 加载飞行路线所需的数据和风格              
                //为“北京地铁”设置风格
                DatasetVector dataSet_ditie = m_workspace.Datasources[0].Datasets["BeijingSubway"] as DatasetVector;
                Layer3DSettingVector settingvetor = new Layer3DSettingVector();
                settingvetor.Style.AltitudeMode = AltitudeMode.RelativeToGround;
                settingvetor.Style.LineWidth = 3;
                settingvetor.Style.LineSymbolID = 962046;
                settingvetor.Style.BottomAltitude = -24;
                Layer3DDataset layer_ditie1 = m_sceneControl.Scene.Layers.Add(dataSet_ditie, settingvetor, true, "ditie");
                layer_ditie1.IsSelectable = false;

                // 加载 "Subway_Line8"数据集作为地铁八号线的站点
                DatasetVector DataSet_ditieLine8 = m_workspace.Datasources[0].Datasets["Subway_Line8"] as DatasetVector;
                Layer3DSettingVector setvetor_ditieLine8 = new Layer3DSettingVector();
                setvetor_ditieLine8.Style = new GeoStyle3D();
                setvetor_ditieLine8.Style.AltitudeMode = AltitudeMode.RelativeToGround;
                setvetor_ditieLine8.Style.BottomAltitude = 10;
                Layer3DDataset layer_ditieLine8 = m_sceneControl.Scene.Layers.Add(DataSet_ditieLine8, setvetor_ditieLine8, true, "地铁八号线");
                layer_ditieLine8.UpdateData();

                // 加载"BeijingSubway_Tunnel"数据集作为地铁巷道
                DatasetVector DataSet_ditieL_2 = m_workspace.Datasources[0].Datasets["BeijingSubway_Tunnel"] as DatasetVector;
                Layer3DSettingVector setvetor_ditieL_2 = new Layer3DSettingVector();
                setvetor_ditieL_2.Style = new GeoStyle3D();
                setvetor_ditieL_2.Style.AltitudeMode = AltitudeMode.RelativeToGround;
                setvetor_ditieL_2.Style.BottomAltitude = -26.5;
                setvetor_ditieL_2.Style.LineSymbolID = 962047;
                setvetor_ditieL_2.Style.LineWidth = 10;
                Layer3DDataset layer_ditieL_2 = m_sceneControl.Scene.Layers.Add(DataSet_ditieL_2, setvetor_ditieL_2, true, "地铁巷道");
                layer_ditieL_2.UpdateData();

                // 加载北京地铁动画模型KML文件到场景
                String KMLPath = @"..\..\SampleData\Symbol3DDisplay\Model\Subway.kml";
                Layer3DKML layer_kml = m_sceneControl.Scene.Layers.Add(KMLPath, Layer3DType.KML, true, "模型动画") as Layer3DKML;
                Feature3D geofeature = layer_kml.Features.FindFeature(1, Feature3DSearchOption.AllFeatures);
                GeoPlacemark geoplacemark = geofeature.Geometry as GeoPlacemark;
                GeoModel geomodel = geoplacemark.Geometry as GeoModel;
                geomodel.Animation.PlayMode = PlayMode.Once;
                layer_kml.UpdateData();

                //导入飞行路线文件  
                Boolean i = flyManager.Routes.FromFile(@"..\..\SampleData\Symbol3DDisplay\flyground.fpf");
                flyManager.Routes.CurrentRouteIndex = 0;
                flyManager.Play();

                //当飞行结束后触发事件               
                m_sceneControl.Focus();
                m_sceneControl.Scene.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置三维点符号
        /// </summary>
        public void SettingPoint3D(int Marker3DIndex)
        {

            isDraw = true;
            m_marker3DIndex = Marker3DIndex;

            try
            {
                flag = false;

                // 新建数据集
                if (m_workspace.Datasources[0].Datasets.Contains("Point3D"))
                {
                    DatasetVector datasetPoint3D = m_workspace.Datasources[0].Datasets["Point3D"] as DatasetVector;

                    if (m_sceneControl.Scene.Layers.Contains("stylePoint3D"))
                    {
                        m_layer3DPoint = m_sceneControl.Scene.Layers["stylePoint3D"] as Layer3DDataset;
                    }
                    else
                    {
                        m_layer3DPoint = m_sceneControl.Scene.Layers.Add(datasetPoint3D, new Layer3DSettingVector(), true, "stylePoint3D");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置三维水面符号
        /// </summary>
        public void SettingRegion3D(int region3DIndex, bool point)
        {
            isRegion = true;
            flag = true;
            ispointRegion = point;
            m_region3DIndex = region3DIndex;
            try
            {
                m_sceneControl.Action = Action3D.MeasureArea;

                // 新建数据集
                if (m_workspace.Datasources[0].Datasets.Contains("Region3D"))
                {
                    DatasetVector datasetRegion3D = m_workspace.Datasources[0].Datasets["Region3D"] as DatasetVector;

                    if (m_sceneControl.Scene.Layers.Contains("styleRegion3D"))
                    {
                        m_layer3DRegion = m_sceneControl.Scene.Layers["styleRegion3D"] as Layer3DDataset;
                    }
                    else
                    {
                        m_layer3DRegion = m_sceneControl.Scene.Layers.Add(datasetRegion3D, new Layer3DSettingVector(), true, "styleRegion3D");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //绘制线触发的事件
        private void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            Recordset recordset;

            Double lineWidth = 0.0;
            Double bottomheight = 0;
            try
            {
                if (flag)
                {
                    if (!isRegion)
                    {
                        GeoLine3D geoLine3D = e.Geometry as GeoLine3D;

                        GeoStyle3D geoStyle = new GeoStyle3D();

                        geoStyle.LineSymbolID = m_line3DIndex;
                        geoStyle.LineWidth = lineWidth;
                        geoStyle.AltitudeMode = AltitudeMode.RelativeToGround;
                        geoStyle.BottomAltitude = bottomheight;

                        geoLine3D.Style3D = geoStyle;

                        recordset = m_datasetLine3D.GetRecordset(false, CursorType.Dynamic);
                        recordset.AddNew(geoLine3D);
                        recordset.Update();
                        recordset.Dispose();

                        m_layer3DLine.UpdateData();
                        m_sceneControl.Scene.Refresh();
                    }
                    else
                    {

                        if (ispointRegion)
                        {
                            GeoRegion3D geoRegion3D = e.Geometry as GeoRegion3D;

                            if (geoRegion3D.PartCount > 0)
                            {
                                Rectangle2D rect = geoRegion3D.Bounds;
                                Datasource datasource = m_workspace.Datasources[0];
                                DatasetVector pointDataset = datasource.Datasets["Point3D"] as DatasetVector;


                                for (double y = geoRegion3D.Bounds.Bottom; y < geoRegion3D.Bounds.Top;)
                                {
                                    for (double x = geoRegion3D.Bounds.Left; x < geoRegion3D.Bounds.Right;)
                                    {
                                        recordset = pointDataset.GetRecordset(false, CursorType.Dynamic);

                                        Point3D pt3d = new Point3D();
                                        pt3d.X = x;
                                        pt3d.Y = y;
                                        pt3d.Z = 0;
                                        GeoPoint3D geopoint3D = new GeoPoint3D(pt3d);

                                        GeoStyle3D geoStyle = new GeoStyle3D();
                                        geoStyle.MarkerSymbolID = m_marker3DIndex;
                                        geoStyle.IsMarkerSizeFixed = false;
                                        geoStyle.MarkerSize = 1;
                                        geoStyle.Marker3DScaleX = 1;
                                        geoStyle.Marker3DScaleY = 1;
                                        geoStyle.Marker3DScaleZ = 1;
                                        geoStyle.IsMarker3D = true;
                                        geoStyle.AltitudeMode = AltitudeMode.RelativeToGround;
                                        geopoint3D.Style3D = geoStyle;

                                        recordset.MoveLast();
                                        recordset.AddNew(geopoint3D);
                                        recordset.Update();
                                        recordset.Dispose();

                                        m_layer3DPoint.IsSelectable = false;
                                        m_layer3DPoint.UpdateData();
                                        m_sceneControl.Scene.Refresh();

                                        x += 0.0002;
                                    }
                                    y += 0.0002;

                                }
                            }
                        }
                        else
                        {
                            Datasource datasource = m_workspace.Datasources[0];
                            DatasetVector Region3DDataset = datasource.Datasets["Region3D"] as DatasetVector;
                            recordset = Region3DDataset.GetRecordset(false, CursorType.Dynamic);

                            GeoRegion3D geoRegion = e.Geometry as GeoRegion3D;
                            GeoStyle3D geoStyle = new GeoStyle3D();


                            geoStyle.FillSymbolID = m_region3DIndex;

                            geoStyle.AltitudeMode = AltitudeMode.RelativeToGround;
                            geoStyle.BottomAltitude = 0.5;

                            geoRegion.Style3D = geoStyle;
                            recordset.AddNew(geoRegion);
                            recordset.Update();
                            recordset.Dispose();

                            (m_layer3DRegion.AdditionalSetting as Layer3DSettingVector).Style = geoStyle;

                            m_layer3DRegion.UpdateData();
                            m_sceneControl.Scene.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 鼠标单击事件来实现画点的功能
        /// </summary>
        /// <param routestopName="sender"></param>
        /// <param routestopName="e"></param>
        private void m_sceneControl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && isDraw)
                {
                    //画点
                    if (!flag)
                    {

                        Datasource datasource = m_workspace.Datasources[0];
                        DatasetVector pointDataset = datasource.Datasets["Point3D"] as DatasetVector;
                        Recordset recordset = pointDataset.GetRecordset(false, CursorType.Dynamic);

                        Point3D pt3d = new Point3D();
                        pt3d = m_sceneControl.Scene.PixelToGlobe(e.Location, PixelToGlobeMode.TerrainAndModel);
                        GeoPoint3D geopoint3D = new GeoPoint3D(pt3d);

                        GeoStyle3D geoStyle = new GeoStyle3D();
                        geoStyle.MarkerSymbolID = m_marker3DIndex;
                        geoStyle.IsMarkerSizeFixed = false;
                        geoStyle.MarkerSize = 1;
                        geoStyle.Marker3DScaleX = 1;
                        geoStyle.Marker3DScaleY = 1;
                        geoStyle.Marker3DScaleZ = 1;
                        geoStyle.IsMarker3D = true;
                        geoStyle.AltitudeMode = AltitudeMode.RelativeToGround;
                        geopoint3D.Style3D = geoStyle;

                        recordset.MoveLast();
                        recordset.AddNew(geopoint3D);
                        recordset.Update();
                        recordset.Dispose();

                        m_layer3DPoint.IsSelectable = false;
                        m_layer3DPoint.UpdateData();
                        m_sceneControl.Scene.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 停止沿线飞行操作
        /// </summary>
        public void FlyLineStop()
        {
            flyManager.Stop();
            flyManager.Routes.Remove(0);
            //m_sceneControl.Scene.IsFirstPersonView = false;

        }

        /// <summary>
        /// 沿线飞行
        /// </summary>
        public void FlyLine(Geometry3D geometry)
        {

            try
            {
                GeoLine3D geoline = geometry as GeoLine3D;

                route = new Route();
                route.FromGeoLine3D(geoline);
                route.IsFlyAlongTheRoute = true;

                routestopCount = route.Stops.Count;
                int i;
                for (i = 0; i < routestopCount; i++)
                {
                    stop = route.Stops[i];
                    Camera camera = stop.Camera;

                    camera.Tilt = 90;
                    camera.Altitude = 50;
                    stop.Camera = camera;
                }

                route.IsTiltFixed = true;
                route.IsHeadingFixed = true;
                route.IsAltitudeFixed = true;
                route.Speed = 110;
                route.IsLinesVisible = false;
                route.IsStopsVisible = false;
                //m_sceneControl.Scene.IsFirstPersonView = true;

                flyManager.Routes.Add(route);
                routestopName = route.Stops[routestopCount - 1].Name;
                flyManager.Scene = m_sceneControl.Scene;

                //设置当前路线
                if (flyManager.Routes.Count == 1)
                {
                    flyManager.Routes.CurrentRouteIndex = 0;
                }
                else
                {
                    flyManager.Routes.CurrentRouteIndex = 1;
                }

                flyManager.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置三维线符号
        /// </summary>
        public void SettingLine3D(int Line3DIndex)
        {
            flag = true;
            isRegion = false;
            m_line3DIndex = Line3DIndex;
            //新建数据集

            switch (m_line3DIndex)
            {
                case 0:
                    {

                        if (!m_sceneControl.Scene.Layers.Contains("ditie3"))
                        {
                            comBoxDisplayLine3D(0);
                        }

                        break;
                    }
                case 1:
                    {
                        if (!m_sceneControl.Scene.Layers.Contains("underPipeLine3D"))
                        {
                            comBoxDisplayLine3D(1);
                        }

                        break;
                    }
                case 2:
                    {
                        m_sceneControl.Scene.Underground.IsVisible = false;
                        if (!m_sceneControl.Scene.Layers.Contains("Ground@OlympicGreen"))
                        {

                            m_sceneControl.Scene.Layers.Clear();
                            LoadOlympicGreen();
                            Camera camera = m_sceneControl.Scene.Camera;
                            camera.Altitude = 341.96175131294876;
                            camera.Tilt = 63.988040332277215;
                            camera.Heading = 4.18128919038237;
                            camera.Longitude = 116.3842976377199;
                            camera.Latitude = 39.986785637662514;
                            m_sceneControl.Scene.Fly(camera, 1);
                            PointLineCamera = true;
                        }
                        if (!PointLineCamera)
                        {
                            Camera camera = m_sceneControl.Scene.Camera;
                            camera.Altitude = 341.96175131294876;
                            camera.Tilt = 63.988040332277215;
                            camera.Heading = 4.18128919038237;
                            camera.Longitude = 116.3842976377199;
                            camera.Latitude = 39.986785637662514;
                            m_sceneControl.Scene.Fly(camera, 1);
                            PointLineCamera = true;
                        }
                        break;
                    }
            }

            try
            {

                m_sceneControl.Action = Action3D.MeasureDistance;
                // 新建数据集
                if (m_workspace.Datasources[0].Datasets.Contains("Line3D"))
                {
                    m_workspace.Datasources[0].Datasets.Delete("Line3D");
                }
                //定义新数据集
                DatasetVectorInfo Datasetinfo = new DatasetVectorInfo();
                Datasetinfo.Type = DatasetType.CAD;
                Datasetinfo.Name = "Line3D";
                m_workspace.Datasources[0].Datasets.Create(Datasetinfo);
                m_datasetLine3D = m_workspace.Datasources[0].Datasets["Line3D"] as DatasetVector;

                if (m_sceneControl.Scene.Layers.Contains("styleLine3D"))
                {
                    m_layer3DLine = m_sceneControl.Scene.Layers["styleLine3D"] as Layer3DDataset;
                }
                else
                {
                    m_layer3DLine = m_sceneControl.Scene.Layers.Add(m_datasetLine3D, new Layer3DSettingVector(), true, "styleLine3D");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public static Vector3d SphericalToCartesian(double dLongitude, double dLatitude, double dDepth)
        {
            double dRadCosLat = (6378137 + dDepth) * (double)Math.Cos(dLatitude);
            return new Vector3d((double)(dRadCosLat * Math.Sin(dLongitude)),
                              (double)((6378137 + dDepth) * Math.Sin(dLatitude)),
                              (double)(dRadCosLat * Math.Cos(dLongitude)));

        }
        public static Vector3d FromAngleAxis(Vector3d v, double rfAngle, Vector3d rkAxis)
        {
            double fHalfAngle = 0.5 * rfAngle;
            double fSin = Math.Sin(fHalfAngle);
            double w = Math.Cos(fHalfAngle);
            double x = fSin * rkAxis.x;
            double y = fSin * rkAxis.y;
            double z = fSin * rkAxis.z;

            Vector3d qvec = new Vector3d(x, y, z);
            Vector3d uv = qvec.CrossProduct(v);
            Vector3d uuv = qvec.CrossProduct(uv);
            Vector3d uv1 = new Vector3d(uv.x * 2.0f * w, uv.y * 2.0f * w, uv.z * 2.0f * w);
            Vector3d uuv1 = new Vector3d(uuv.x * 2.0f, uuv.y * 2.0f, uuv.z * 2.0f);
            Vector3d vecReturn = new Vector3d(v.x + uv1.x + uuv1.x, v.y + uv1.y + uuv1.y, v.z + uv1.z + uuv1.z);

            return vecReturn;

        }

  
        public void SetRegionPoint()
        {
            try
            {
                if (m_workspace.Datasources[0].Datasets.Contains("New_Point3D"))
                {
                    DatasetVector datasetPoint3D = m_workspace.Datasources[0].Datasets["New_Point3D"] as DatasetVector;

                    if (m_sceneControl.Scene.Layers.Contains("New_Point3D@gongyuan"))
                    {
                        m_sceneControl.Scene.Layers.Remove("New_Point3D@gongyuan");
                    }
                   
                    {
                        Layer3DSettingVector pointSetting = new Layer3DSettingVector();
                        pointSetting.Style.AltitudeMode = AltitudeMode.RelativeToGround;
                        pointSetting.Style.MarkerSize = 1;
                        pointSetting.Style.IsMarkerSizeFixed = true;
                        pointSetting.Style.MarkerScale = 1;
                        pointSetting.Style.MarkerSymbolID = m_marker3DIndex;
                        pointSetting.Style.IsMarker3D = true;
                       m_layer3DRegionPoint = m_sceneControl.Scene.Layers.Add(datasetPoint3D, pointSetting, true, "New_Point3D@gongyuan");
                    }

                    m_layer3DRegionPoint.UpdateData();
                    m_sceneControl.Scene.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    
    }
}


