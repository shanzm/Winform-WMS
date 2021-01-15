using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// 盘点单
    /// </summary>
    public class CheckBillDetail
    {

        #region Model
        private string _checkbilldetailguid;
        private decimal _deficientqty;
        private decimal _total;
        private string _remark;
        private string _checkbillguid;
        private string _materialguid;
        private string _materialid;
        private string _materialname;
        private string _barno;
        private string _spec;
        private string _unit;
        private decimal _price;
        private decimal _surplusqty;
        /// <summary>
        /// 
        /// </summary>
        public string CheckBillDetailGuid
        {
            set { _checkbilldetailguid = value; }
            get { return _checkbilldetailguid; }
        }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal DeficientQty
        {
            set { _deficientqty = value; }
            get { return _deficientqty; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Total
        {
            set { _total = value; }
            get { return _total; }
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
        /// 单据表头Guid
        /// </summary>
        public string CheckBillGuid
        {
            set { _checkbillguid = value; }
            get { return _checkbillguid; }
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
        /// 盘盈数量
        /// </summary>
        public decimal SurplusQty
        {
            set { _surplusqty = value; }
            get { return _surplusqty; }
        }
        #endregion Model
    }
}
