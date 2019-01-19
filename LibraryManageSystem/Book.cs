using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    class Book
    {
        string isbn;//ISBN
        string name;//书名
        string style;//类型
        float price;//价格
        string press;//出版社
        string author;//作者
        string enterTime;//购入时间
        string isBorrow;//是否借出
        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Style 
        {
            get { return style; }
            set { style = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Press
        {
            get { return press; }
            set { press = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string EnterTime
        {
            get { return enterTime; }
            set { enterTime = value; }
        }
        public string IsBorrow
        {
            get { return isBorrow; }
            set { isBorrow = value; }
        }
    }
}
