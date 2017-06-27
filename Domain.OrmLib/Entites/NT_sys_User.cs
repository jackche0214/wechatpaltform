using System;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace Domain.OrmLib.Entity{
	 	//NT_sys_User
		public class NT_sys_User
	{
	
      	/// <summary>
		/// Id
        /// </summary>
        public virtual long Id
        {
            get; 
            set; 
        }        
		/// <summary>
		/// UserNum
        /// </summary>
        public virtual string UserNum
        {
            get; 
            set; 
        }        
		/// <summary>
		/// UserName
        /// </summary>
        public virtual string UserName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// UserPassword
        /// </summary>
        public virtual string UserPassword
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PayPassword
        /// </summary>
        public virtual string PayPassword
        {
            get; 
            set; 
        }        
		/// <summary>
		/// NickName
        /// </summary>
        public virtual string NickName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// RealName
        /// </summary>
        public virtual string RealName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// isAdmin
        /// </summary>
        public virtual int isAdmin
        {
            get; 
            set; 
        }        
		/// <summary>
		/// UserGroupNumber
        /// </summary>
        public virtual string UserGroupNumber
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PassQuestion
        /// </summary>
        public virtual string PassQuestion
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PassKey
        /// </summary>
        public virtual string PassKey
        {
            get; 
            set; 
        }        
		/// <summary>
		/// CertType
        /// </summary>
        public virtual string CertType
        {
            get; 
            set; 
        }        
		/// <summary>
		/// CertNumber
        /// </summary>
        public virtual string CertNumber
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Email
        /// </summary>
        public virtual string Email
        {
            get; 
            set; 
        }        
		/// <summary>
		/// mobile
        /// </summary>
        public virtual string mobile
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Sex
        /// </summary>
        public virtual int? Sex
        {
            get; 
            set; 
        }        
		/// <summary>
		/// birthday
        /// </summary>
        public virtual DateTime? birthday
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Userinfo
        /// </summary>
        public virtual string Userinfo
        {
            get; 
            set; 
        }        
		/// <summary>
		/// UserFace
        /// </summary>
        public virtual string UserFace
        {
            get; 
            set; 
        }        
		/// <summary>
		/// userFacesize
        /// </summary>
        public virtual string userFacesize
        {
            get; 
            set; 
        }        
		/// <summary>
		/// marriage
        /// </summary>
        public virtual int? marriage
        {
            get; 
            set; 
        }        
		/// <summary>
		/// iPoint
        /// </summary>
        public virtual int iPoint
        {
            get; 
            set; 
        }        
		/// <summary>
		/// gPoint
        /// </summary>
        public virtual int gPoint
        {
            get; 
            set; 
        }        
		/// <summary>
		/// cPoint
        /// </summary>
        public virtual int cPoint
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ePoint
        /// </summary>
        public virtual int ePoint
        {
            get; 
            set; 
        }        
		/// <summary>
		/// aPoint
        /// </summary>
        public virtual int aPoint
        {
            get; 
            set; 
        }        
		/// <summary>
		/// isLock
        /// </summary>
        public virtual int isLock
        {
            get; 
            set; 
        }        
		/// <summary>
		/// RegTime
        /// </summary>
        public virtual DateTime RegTime
        {
            get; 
            set; 
        }        
		/// <summary>
		/// LastLoginTime
        /// </summary>
        public virtual DateTime? LastLoginTime
        {
            get; 
            set; 
        }        
		/// <summary>
		/// OnlineTime
        /// </summary>
        public virtual int OnlineTime
        {
            get; 
            set; 
        }        
		/// <summary>
		/// OnlineTF
        /// </summary>
        public virtual int OnlineTF
        {
            get; 
            set; 
        }        
		/// <summary>
		/// LoginNumber
        /// </summary>
        public virtual int LoginNumber
        {
            get; 
            set; 
        }        
		/// <summary>
		/// FriendClass
        /// </summary>
        public virtual string FriendClass
        {
            get; 
            set; 
        }        
		/// <summary>
		/// LoginLimtNumber
        /// </summary>
        public virtual int? LoginLimtNumber
        {
            get; 
            set; 
        }        
		/// <summary>
		/// LastIP
        /// </summary>
        public virtual string LastIP
        {
            get; 
            set; 
        }        
		/// <summary>
		/// SiteID
        /// </summary>
        public virtual string SiteID
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Addfriend
        /// </summary>
        public virtual int? Addfriend
        {
            get; 
            set; 
        }        
		/// <summary>
		/// isOpen
        /// </summary>
        public virtual int? isOpen
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ParmConstrNum
        /// </summary>
        public virtual int? ParmConstrNum
        {
            get; 
            set; 
        }        
		/// <summary>
		/// isIDcard
        /// </summary>
        public virtual int? isIDcard
        {
            get; 
            set; 
        }        
		/// <summary>
		/// IDcardFiles
        /// </summary>
        public virtual string IDcardFiles
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Addfriendbs
        /// </summary>
        public virtual int? Addfriendbs
        {
            get; 
            set; 
        }        
		/// <summary>
		/// EmailATF
        /// </summary>
        public virtual int? EmailATF
        {
            get; 
            set; 
        }        
		/// <summary>
		/// EmailCode
        /// </summary>
        public virtual string EmailCode
        {
            get; 
            set; 
        }        
		/// <summary>
		/// isMobile
        /// </summary>
        public virtual int? isMobile
        {
            get; 
            set; 
        }        
		/// <summary>
		/// BindTF
        /// </summary>
        public virtual int? BindTF
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MobileCode
        /// </summary>
        public virtual string MobileCode
        {
            get; 
            set; 
        }        
		/// <summary>
		/// IsUpdate
        /// </summary>
        public virtual string IsUpdate
        {
            get; 
            set; 
        }        
		/// <summary>
		/// isseller
        /// </summary>
        public virtual int? isseller
        {
            get; 
            set; 
        }        
		/// <summary>
		/// OwnerAny
        /// </summary>
        public virtual string OwnerAny
        {
            get; 
            set; 
        }        
		/// <summary>
		/// userType
        /// </summary>
        public virtual int? userType
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PromotionCode
        /// </summary>
        public virtual string PromotionCode
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountStatus
        /// </summary>
        public virtual string AccountStatus
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountType
        /// </summary>
        public virtual string AccountType
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountBankCard
        /// </summary>
        public virtual string AccountBankCard
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountICard
        /// </summary>
        public virtual string AccountICard
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountUrl
        /// </summary>
        public virtual string AccountUrl
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountExtension
        /// </summary>
        public virtual string AccountExtension
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AccountBankCardName
        /// </summary>
        public virtual string AccountBankCardName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// backPoint
        /// </summary>
        public virtual decimal? backPoint
        {
            get; 
            set; 
        }        
		/// <summary>
		/// backPointPrice
        /// </summary>
        public virtual decimal? backPointPrice
        {
            get; 
            set; 
        }        
		/// <summary>
		/// QrCode
        /// </summary>
        public virtual string QrCode
        {
            get; 
            set; 
        }        
		/// <summary>
		/// QrCodeUrl
        /// </summary>
        public virtual string QrCodeUrl
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Token
        /// </summary>
        public virtual string Token
        {
            get; 
            set; 
        }        
		/// <summary>
		/// WxPlat_Openid
        /// </summary>
        public virtual string WxPlat_Openid
        {
            get; 
            set; 
        }        
		   
	}
}