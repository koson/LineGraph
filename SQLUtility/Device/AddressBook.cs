using System;

namespace LineGraph.SQLUtility
{
    /// <summary>
    /// AddressBook:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AddressBook
    {
        public AddressBook()
        { }
        #region Model
        private string _Style;
        private string _Sensorid;
        private string _Adrid;//点号
        private string _Company;
        private string _DTUid;

        public string Style
        {
            set { _Style = value; }
            get { return _Style; }
        }

        public string SENSORID
        {
            set { _Sensorid = value; }
            get { return _Sensorid; }
        }

        public string NOID
        {
            set { _Adrid = value; }
            get { return _Adrid; }
        }

        public string Company
        {
            set { _Company = value; }
            get { return _Company; }
        }

        public string DTUId
        {
            set { _DTUid = value; }
            get { return _DTUid; }
        }
 
     
        #endregion Model

    }
}
