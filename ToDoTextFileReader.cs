using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoList
{
    class ToDoTextFileReader
    {
        public static List<ToDo> ReadFromTextFile()
        {
            List<ToDo> toDoReturn = new List<ToDo>();
            StreamReader sr = new StreamReader("TODO.txt");
            string line = "";
 
            while ((line = sr.ReadLine()) != null)
            { 
                string[] texts = line.Split("#");
                if(texts[0].Equals(null)){ texts[0] = "Add something to do"; texts[1] = "Add something to do"; texts[2] = "H"; texts[3] = "1/1/2000"; }
                ToDo to = new ToDo(texts[0], texts[1], char.Parse(texts[2]), texts[3]);
                toDoReturn.Add(to);
            }
            sr.Close();
            return toDoReturn;
        }
    }
}
