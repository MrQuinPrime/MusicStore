using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    /// <summary>
    /// 学生类，主要用于了解注解验证
    /// </summary>
    public class Student:IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Gender { get; set; }//性别
        public string UserName { get; set; }//用户名
        public string NiName { get; set; }//昵称
        public DateTime Birthday { get; set; }//出生日期
        public int Age { get; set; }//年龄
        public string Password { get; set; }//密码
        public string ConfirmPassword { get; set; }//密码确认
        public string Email { get; set; }
        public decimal Contribution { get; set; }//贡献度
        public DateTime CreatTime { get; set; }//建立时间
        public DataStatus DataStatue { get; set; }//用户状态，枚举类型
    }
    public enum DataStatus
    {
        合法用户,
        非法用户,
        冻结用户
    }
}