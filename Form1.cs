using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//20114137 Yadav jivan
namespace SimpleToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string decs = textBox2.Text;
            char prio = ' ';
            int indexPrio = comboBox1.SelectedIndex;
            switch (indexPrio)
            {
                case 0:
                    prio = 'H';
                    break;
                case 1:
                    prio = 'M';
                    break;
                case 2:
                    prio = 'L';
                    break;

            }
            DateTime date = dateTimePicker1.Value.Date;

            ToDo toDo = new ToDo(title, decs, prio, date.ToString("dddd, dd MMMM yyyy"));
            ToDoListWorker.myToDo.Add(toDo);
            ToDoTextFileWriter.WriteToTextFile(ToDoListWorker.myToDo);
           LoadTasks();
            ToDoListWorker.myToDo.Clear();
        }

        private void LoadTasks()
        {
            listBox1.Items.Clear();
            foreach (ToDo t in ToDoTextFileReader.ReadFromTextFile())
            {
                listBox1.Items.Add(t.Title);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           LoadTasks();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listBox1.SelectedIndex;
            List<ToDo> myToDo = new List<ToDo>();
            myToDo = ToDoTextFileReader.ReadFromTextFile();
            string prio = " ";
            if (myToDo.ElementAt<ToDo>(count).Priority.Equals('H'))
            {
                prio = "High";

            }
            if (myToDo.ElementAt<ToDo>(count).Priority.Equals('M'))
            {
                prio = "Medium";

            }
            if (myToDo.ElementAt<ToDo>(count).Priority.Equals('L'))
            {
                prio = "Low";

            }
            MessageBox.Show("Title : " + myToDo.ElementAt<ToDo>(count).Title + "\n" +
                            "Description : " + myToDo.ElementAt<ToDo>(count).Discription + "\n" +
                            "Priority : " + prio + "\n" +
                            "Date : " + myToDo.ElementAt<ToDo>(count).Date, "Task", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you are done with this task", "TO-DO LIST", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                string title = listBox1.GetItemText(listBox1.SelectedItem);
               // listBox1.Items.Remove(listBox1.SelectedItem);
                UpDateToDoList.TaskDone(title);
                LoadTasks();

            }
        }
    }
}
