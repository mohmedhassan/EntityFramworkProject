using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // notice: the name of the classes and the data are not recommended,
    // but I focused on the concept rather than the performance.
    public partial class Form1 : Form
    {
        // to define the table and the database entity
        TB1 add;
        Database1Entities db;
        int id;
        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            try
            {
                // i made this code to Initialize it
                db = new Database1Entities();
                // gets or sets the source from the table the display it in the GridView
                dataGridView1.DataSource = db.TB1.ToList();
            }
            catch
            {
                
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

       }

      
        private void btn_add_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// I made this function to add the Value
            /// that you are including it to the gridview
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            try
            {
                // to Initialize the database and the table
                db = new Database1Entities();
                add = new TB1();
                // the button add is = to the inputs frist name and last name 
                add.Frist_Name = edit_frist.Text;
                add.Last_Name = edit_last.Text;
                // The entry provides acces to change tracking information which i made it add
                db.Entry(add).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                // to define the data in the GridView
                loadData();
                //this is for make the input empty after pressing add button
                edit_frist.Text = edit_last.Text = "";
                //message after the app runs sucessfuly
                MessageBox.Show("Added sucessfuly");
            }
            catch
            {
                MessageBox.Show("Can't Add your Value");
            }
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /// <summary>
            /// i made this function to edit the value in the Grid ,
            /// once you double click in the row it returns the Values automatically
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            try
            {   // 	Converts the string representation of a number in a specified base.
                id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                // to returns the Value from the GridView  
                edit_frist.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                edit_last.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            }
            catch
            {
                MessageBox.Show("Can't edit your Value");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                db = new Database1Entities();
                add = new TB1();
                add.Id = id;
                add.Frist_Name = edit_frist.Text;
                add.Last_Name = edit_last.Text;
                // The entry provides acces to change tracking information which i made it modified
                db.Entry(add).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                loadData();
                //this is for make the input empty after pressing add button
                edit_frist.Text = edit_last.Text = "";
                //message after the app runs sucessful
                MessageBox.Show("edited sucessfuly");
            }
            catch
            {
                MessageBox.Show("Can't edit your Value");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                db = new Database1Entities();
                add = new TB1();
                add.Id = id;
                db.Entry(add).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                loadData();
                //this is for make the input empty after pressing add button
                edit_frist.Text = edit_last.Text = "";
                //message after the app runs sucessful
                MessageBox.Show("removed sucessfuly");
            }
            catch
            {
                MessageBox.Show("Can't remove your Value");
            }
        }
    }
}
