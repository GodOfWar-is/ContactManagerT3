using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactManagerT3.BusinessLogic;
using ContactManagerT3.Models;

namespace ContactManagerT3
{
    public partial class Form1 : Form
    {
        private ContactManager contactManager;

        public Form1()
        {
            InitializeComponent();
            contactManager = new ContactManager();
            LoadContacts();
        }

        private void LoadContacts()
        {
            contactListBox.Items.Clear();
            var contacts = contactManager.GetAllContacts();
            foreach (var contact in contacts)
            {
                contactListBox.Items.Add(contact); // 显示联系人
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var contact = new Contact(nameTextBox.Text, addressTextBox.Text, phoneTextBox.Text);
            contactManager.AddContact(contact);
            LoadContacts();
            ClearInputFields();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (contactListBox.SelectedItem != null)
            {
                var selectedContact = (Contact)contactListBox.SelectedItem;
                contactManager.DeleteContact(selectedContact.Name);
                LoadContacts();
                ClearInputFields();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (contactListBox.SelectedItem != null)
            {
                var selectedContact = (Contact)contactListBox.SelectedItem;
                selectedContact.Name = nameTextBox.Text;
                selectedContact.Address = addressTextBox.Text;
                selectedContact.Phone = phoneTextBox.Text;
                contactManager.UpdateContact(selectedContact);
                LoadContacts();
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            phoneTextBox.Clear();
        }

        private void contactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contactListBox.SelectedItem != null)
            {
                var contact = (Contact)contactListBox.SelectedItem;
                nameTextBox.Text = contact.Name;
                addressTextBox.Text = contact.Address;
                phoneTextBox.Text = contact.Phone;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var contacts = contactManager.GetContactsByName(nameTextBox.Text);
            contactListBox.Items.Clear(); // 清空列表框

            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    contactListBox.Items.Add(contact); // 将匹配的联系人添加到列表框
                }
            }
            else
            {
                MessageBox.Show("未找到匹配的联系人。");
                ClearInputFields();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadContacts();
        }
    }
}
