using System;
using System.Collections.Generic;
using System.Text;

namespace StorageManageLibrary
{
    public class UserRight
    {
        #region Model
        private string _userid;
        private string _ckdmxb;
        private string _ckdhzb;
        private string _dbdgl;
        private string _dbdxz;
        private string _dbzsh;
        private string _cccx;
        private string _cksfmxb;
        private string _bmsfmxb;
        private string _sfchzb;
        private string _sflxhzb;
        private string _lkdgl;
        private string _chmxz;
        private string _kcpd;
        private string _kcpdxz;
        private string _kcpdsh;
        private string _hp;
        private string _ck;
        private string _kh;
        private string _gys;
        private string _yg;
        private string _bm;
        private string _lkdxz;
        private string _yhgl;
        private string _qxgl;
        private string _lkdsh;
        private string _lkdmxb;
        private string _lkdhzb;
        private string _ckdgl;
        private string _ckdxz;
        private string _ckdsh;
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ckdmxb
        {
            set { _ckdmxb = value; }
            get { return _ckdmxb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ckdhzb
        {
            set { _ckdhzb = value; }
            get { return _ckdhzb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbdgl
        {
            set { _dbdgl = value; }
            get { return _dbdgl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbdxz
        {
            set { _dbdxz = value; }
            get { return _dbdxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbzsh
        {
            set { _dbzsh = value; }
            get { return _dbzsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cccx
        {
            set { _cccx = value; }
            get { return _cccx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cksfmxb
        {
            set { _cksfmxb = value; }
            get { return _cksfmxb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bmsfmxb
        {
            set { _bmsfmxb = value; }
            get { return _bmsfmxb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfchzb
        {
            set { _sfchzb = value; }
            get { return _sfchzb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sflxhzb
        {
            set { _sflxhzb = value; }
            get { return _sflxhzb; }
        }
        /// <summary>
        /// 入库单管理
        /// </summary>
        public string lkdgl
        {
            set { _lkdgl = value; }
            get { return _lkdgl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string chmxz
        {
            set { _chmxz = value; }
            get { return _chmxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kcpd
        {
            set { _kcpd = value; }
            get { return _kcpd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kcpdxz
        {
            set { _kcpdxz = value; }
            get { return _kcpdxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kcpdsh
        {
            set { _kcpdsh = value; }
            get { return _kcpdsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hp
        {
            set { _hp = value; }
            get { return _hp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ck
        {
            set { _ck = value; }
            get { return _ck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kh
        {
            set { _kh = value; }
            get { return _kh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gys
        {
            set { _gys = value; }
            get { return _gys; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yg
        {
            set { _yg = value; }
            get { return _yg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bm
        {
            set { _bm = value; }
            get { return _bm; }
        }
        /// <summary>
        /// 入库单新增
        /// </summary>
        public string lkdxz
        {
            set { _lkdxz = value; }
            get { return _lkdxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yhgl
        {
            set { _yhgl = value; }
            get { return _yhgl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qxgl
        {
            set { _qxgl = value; }
            get { return _qxgl; }
        }
        /// <summary>
        /// 入库单审核
        /// </summary>
        public string lkdsh
        {
            set { _lkdsh = value; }
            get { return _lkdsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lkdmxb
        {
            set { _lkdmxb = value; }
            get { return _lkdmxb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lkdhzb
        {
            set { _lkdhzb = value; }
            get { return _lkdhzb; }
        }
        /// <summary>
        /// 出库单管理
        /// </summary>
        public string ckdgl
        {
            set { _ckdgl = value; }
            get { return _ckdgl; }
        }
        /// <summary>
        /// 出库单新增
        /// </summary>
        public string ckdxz
        {
            set { _ckdxz = value; }
            get { return _ckdxz; }
        }
        /// <summary>
        /// 出库单审核
        /// </summary>
        public string ckdsh
        {
            set { _ckdsh = value; }
            get { return _ckdsh; }
        }
        #endregion Model
    }
}
