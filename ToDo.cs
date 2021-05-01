using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoList
{
    class ToDo
    {
        private string title;
        private string discription;
        private string  date;
        private char priority;
        public ToDo(string title, string discription, char priority, string date)
        {
            this.title = title;
            this.discription = discription;
            this.priority = priority;
            this.date = date;
        }

        public string Title { get => title; set => title = value; }
        public string Discription { get => discription; set => discription = value; }
        public char Priority { get => priority; set => priority = value; }
        public string Date { get => date; set => date = value; }


        public string toString()
        {

            return title + "\nDiscription :" + discription + "\nDate :" + date + "\nPriority : " + Priority;

        }
    }
}
