using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// 调拨单明细实体
    /// </summary>
    public class RemoveBillDetail
    {

        #region Model
        private string _removebilldetailguid;
        private string _remark;
        private int _sortid;
        private string _removebillguid;
        private string _materialguid;
        private string _materialid;
        private string _materialname;
        private string _barno;
        private string _spec;
        private string _unit;
        private decimal _price;
        private decimal _qty;
        private decimal _total;
        /// <summary>
        /// 
        /// </summary>
        public string RemoveBillDetailGuid
        {
            set { _removebilldetailguid = value; }
            get { return _removebilldetailguid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 单据表头Guid
        /// </summary>
        public string RemoveBillGuid
        {
            set { _removebillguid = value; }
            get { return _removebillguid; }
        }
        /// <summary>
        /// 货品guid
        /// </summary>
        public string MaterialGuid
        {
            set { _materialguid = value; }
            get { return _materialguid; }
        }

        /// <summary>
        /// 货号
        /// </summary>
        public string MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
        }
        /// <summary>
        /// 品名
        /// </summary>
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 助查码
        /// </summary>
        public string BarNo
        {
            set { _barno = value; }
            get { return _barno; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Total
        {
            set { _total = value; }
            get { return _total; }
        }
        #endregion Model
    }
}
