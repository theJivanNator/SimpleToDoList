using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoList
{
    class UpDateToDoList
    {
        public static void TaskDone(string title )
        {
            List<ToDo> myList = ToDoTextFileReader.ReadFromTextFile();
         
            int count = 0;
            foreach (ToDo T in myList.ToList())
            {
                if (T.Title.Equals(title))
                {
                    myList.RemoveAt(count);
                   

                }
                else
                {
                    count++;
                }

            }
            ToDoTextFileWriter.ReWriteToTextFile(myList);
           
        }
    }
}
