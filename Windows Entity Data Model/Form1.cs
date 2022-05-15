using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Entity_Data_Model
{
    public partial class Form1 : Form
    {
        ApplicationEntities dbcontext=new ApplicationEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Emp emp=new Emp();
                emp.Name = textname.Text;
                emp.Designation= textdesignation.Text;
                emp.Salary= Convert.ToInt32(textsalary.Text);
                dbcontext.Emps.Add(emp);
                dbcontext.SaveChanges();
                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Emp emp=dbcontext.Emps.Find(Convert.ToInt32(textid.Text));
                if(emp!=null)
                {
                    textname.Text = emp.Name;
                    textdesignation.Text = emp.Designation;
                    textsalary.Text = emp.Salary.ToString();
                }
                else
                {
                    MessageBox.Show("records not found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Emp emp = dbcontext.Emps.Find(Convert.ToInt32(textid.Text));
                if (emp != null)
                {
                    emp.Name = textname.Text;
                    emp.Designation = textdesignation.Text;
                     emp.Salary=Convert.ToInt32(textsalary.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Updated");

                }
                else
                {
                    MessageBox.Show("records not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                Emp emp = dbcontext.Emps.Find(Convert.ToInt32(textid.Text));
                if (emp != null)
                {
                    dbcontext.Emps.Remove(emp);
                    dbcontext.SaveChanges();
                    MessageBox.Show("deleted");

                }
                else
                {
                    MessageBox.Show("records not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnshowall_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=dbcontext.Emps.ToList();
        }
    }
}
