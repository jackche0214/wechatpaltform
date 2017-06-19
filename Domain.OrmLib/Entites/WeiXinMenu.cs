using System;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace Domain.OrmLib.Entity{
	 	//WeiXinMenu
		public class WeiXinMenu
	{
	
      	/// <summary>
		/// Id
        /// </summary>
        public virtual int Id
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MenuId
        /// </summary>
        public virtual string MenuId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MenuName
        /// </summary>
        public virtual string MenuName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MenuType
        /// </summary>
        public virtual string MenuType
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MenuKey
        /// </summary>
        public virtual string MenuKey
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MenuUrl
        /// </summary>
        public virtual string MenuUrl
        {
            get; 
            set; 
        }        
		/// <summary>
		/// MediaId
        /// </summary>
        public virtual string MediaId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ParentId
        /// </summary>
        public virtual string ParentId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// OrderBy
        /// </summary>
        public virtual int? OrderBy
        {
            get; 
            set; 
        }        
		/// <summary>
		/// IsEnable
        /// </summary>
        public virtual string IsEnable
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
		/// CreateTime
        /// </summary>
        public virtual DateTime? CreateTime
        {
            get; 
            set; 
        }        
		   
	}
}