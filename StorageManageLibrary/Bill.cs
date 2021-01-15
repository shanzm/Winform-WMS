using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// 出入库单实体类
    /// </summary>
    public class Bill
    {
        #region Model
        private string _billguid;
        private string _batchno;
        private string _handleperson;
        private string _createperson;
        private DateTime? _createdate;
        private string _checkperson;
        private DateTime? _checkdate;
        private string _flag;
        private string _remark;
        private string _billautoid;
        private DateTime? _billdate;
        private string _depotguid;
        private string _storagetypeguid;
        private string _supplierguid;
        private string _deptguid;
        private string _bearing;
        private string _billid;
        /// <summary>
        /// 
        /// </summary>
        public string BillGuid
        {
            set { _billguid = value; }
            get { return _billguid; }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNo
        {
            set { _batchno = value; }
            get { return _batchno; }
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
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 入库单或出库单(I:入库单 E：出库单)
        /// </summary>
        public string Flag
        {
            set { _flag = value; }
            get { return _flag; }
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
        /// 单据编号
        /// </summary>
        public string BillAutoID
        {
            set { _billautoid = value; }
            get { return _billautoid; }
        }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? BillDate
        {
            set { _billdate = value; }
            get { return _billdate; }
        }
        /// <summary>
        /// 仓库Guid
        /// </summary>
        public string DepotGuid
        {
            set { _depotguid = value; }
            get { return _depotguid; }
        }
        /// <summary>
        /// 类型guid
        /// </summary>
        public string StorageTypeGuid
        {
            set { _storagetypeguid = value; }
            get { return _storagetypeguid; }
        }
        /// <summary>
        /// 供应商guid
        /// </summary>
        public string SupplierGuid
        {
            set { _supplierguid = value; }
            get { return _supplierguid; }
        }
        /// <summary>
        /// 部门Guid
        /// </summary>
        public string DeptGuid
        {
            set { _deptguid = value; }
            get { return _deptguid; }
        }
        /// <summary>
        /// 方向
        /// </summary>
        public string Bearing
        {
            set { _bearing = value; }
            get { return _bearing; }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        #endregion Model
    }
}