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
    public class CheckBill
    {

        #region Model
        private string _checkbillguid;
        private DateTime? _checkdate;
        private string _remark;
        private DateTime? _billdate;
        private string _depot;
        private string _handleperson;
        private string _billid;
        private string _billautoid;
        private string _createperson;
        private DateTime? _createdate;
        private string _checkperson;
        /// <summary>
        /// 
        /// </summary>
        public string CheckBillGuid
        {
            set { _checkbillguid = value; }
            get { return _checkbillguid; }
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
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
        /// 单据日期
        /// </summary>
        public DateTime? BillDate
        {
            set { _billdate = value; }
            get { return _billdate; }
        }
        /// <summary>
        /// 调出仓库
        /// </summary>
        public string Depot
        {
            set { _depot = value; }
            get { return _depot; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public string HandlePerson
        {
            set { _handleperson = value; }
            get { return _handleperson; }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillAutoID
        {
            set { _billautoid = value; }
            get { return _billautoid; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public string CreatePerson
        {
            set { _createperson = value; }
            get { return _createperson; }
        }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckPerson
        {
            set { _checkperson = value; }
            get { return _checkperson; }
        }
        #endregion Model
    }
}
