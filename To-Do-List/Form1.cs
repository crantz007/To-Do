using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<string> ct = new List<string>();
            ct.Add("Personal");
            ct.Add("Work");
            ct.Add("School");

            cBox.Items.AddRange(ct.ToArray());
            
        }

        private void btnAddToDo_Click(object sender, EventArgs e)
        {
            // Remove any spaces start and end of string
            string newItem = txtNewToDo.Text.Trim();
            List<string> ct = new List<string>();
            ct.Add("Personal");
            ct.Add("Work");
            ct.Add("School");

            cBox.Items.AddRange(ct.ToArray());

            if (!String.IsNullOrWhiteSpace(newItem))
            {
                if (itemIsInList(clsToDo.Items, newItem))
                {
                    MessageBox.Show("Duplicate item", "Warning");
                }
                else
                {
                    // Use Add to add new item to end of Item collection
                    DateTime todoCreated = DateTime.Now;
                    bool urgent = chkUrgent.Checked;
                    var  category = this.cBox.GetItemText(this.cBox.SelectedItem);

                    // Format the text, date/time created and urgent into one string
                    string todoText = $"{newItem} - {category} - Created at {todoCreated:g}";
                    if (urgent)
                    {
                        todoText += " URGENT!";
                    }
                    // add to the ListBox items
                    clsToDo.Items.Add(todoText);
                    cBox.Items.Add(category);


                    // Clear inputs
                    txtNewToDo.Text = "";
                    chkUrgent.Checked = false;
                }
                // No else, just ignore empty input
            }
        }

        private bool itemIsInList(CheckedListBox.ObjectCollection items, string newItem)
        {
           foreach(string item in items)
            {
                if (item.ToUpper() == newItem.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Make new list 
            List<string> doneItems = new List<string>();

            // Copy all checked item to new list
            foreach (string item in clsToDo.CheckedItems)
            {
                doneItems.Add(item);

            }

            // For each string in doneItems list, remove from clsToDo.Items
            // Add to lstDone.Items
            foreach (string item in doneItems)
            {
                clsToDo.Items.Remove(item);  // Remove by value
                cBox.Items.Remove(cBox.SelectedItem);
                lstDone.Items.Add(item);
            }
            
        }

        private void chkUrgent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNewToDo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
