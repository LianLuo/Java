using System;
using System.Collections.Generic;
using System.Text;

using agsXMPP.Xml.Dom;
namespace client
{
    /************************************************************
     * 2007-05-18   ţ��
     * ����������������Ա����ϸ������Ϣ  ������Ϣ�������ݿ�������
     * �Ժ����Ҫ���浽����
     ***********************************************************/
    public class Info : Element
    {
         public Info()
         {
             this.TagName = "Info";
             this.Namespace = "agsoftware:Info";
         }
        public Info(string name,string  pwd,string sex,int age,string group,string tel,string email):this()
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
            this.Group = group;
            this.Tel = tel;
            this.Email = email;
            this.Pwd = pwd;
        }
        public string Name
        {
            get { return GetTag("name"); }
            set { SetTag("name",value); }
        }
        public string Pwd
        {
            get { return GetTag("pwd"); }
            set { SetTag("pwd", value); }
        }
        public int FaceId
        {
            get { return GetTagInt("faceid"); }
            set { SetTag("faceid", value.ToString()); }
        }
        public string  Sex
        {
            get { return GetTag("sex"); }
            set { SetTag("sex", value); }
        }
        public int Age
        {
            get { return GetTagInt("age"); }
            set { SetTag("age", value.ToString()); }
        }
        public string Group
        {
            get { return GetTag("group"); }
            set { SetTag("group", value); }
        }
        public string Tel
        {
            get { return GetTag("tel"); }
            set { SetTag("tel", value); }
        }
        public string Email
        {
            get { return GetTag("email"); }
            set { SetTag("email", value); }
        }
    }
}
