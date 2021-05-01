using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoList
{
    class ToDoTextFileWriter
    {
        public static void WriteToTextFile(List<ToDo> myToDo)
        {
            string line = "";
            StreamWriter writer = File.AppendText("TODO.txt");
            foreach (ToDo t in myToDo)
            {
                line = t.Title + "#" + t.Discription + "#" + t.Priority + "#" + t.Date;
                writer.WriteLine(line);
            }

            writer.Close();
            myToDo.Clear();
        }

        public static void ReWriteToTextFile(List<ToDo> myToDo)
        {
            File.WriteAllText("TODO.txt", String.Empty);
            string line = "";
            StreamWriter writer = File.AppendText("TODO.txt");
            foreach (ToDo t in myToDo)
            {
                line = t.Title + "#" + t.Discription + "#" + t.Priority + "#" + (" " + t.Date).Trim();
                writer.WriteLine(line);
            }

            writer.Close();
            myToDo.Clear();
        }

    }
}
