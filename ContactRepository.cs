using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ContactManagerT3.Models;
using System.Data.SqlClient;

namespace ContactManagerT3.DataAccess
{
    public class ContactRepository
    {
        private string connectionString = "Server=localhost;Database=personal_contacts;Uid=root;Pwd=123456;";

        public List<Contact> GetAllContacts()
        {
            var contacts = new List<Contact>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT name, address, phone FROM contacts", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contact = new Contact(reader["name"].ToString(), reader["address"].ToString(), reader["phone"].ToString());
                        contacts.Add(contact);
                    }
                }
            }
            return contacts;
        }

        public void AddContact(Contact contact)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO contacts (name, address, phone) VALUES (@name, @address, @phone)", connection);
                command.Parameters.AddWithValue("@name", contact.Name);
                command.Parameters.AddWithValue("@address", contact.Address);
                command.Parameters.AddWithValue("@phone", contact.Phone);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE contacts SET address = @address, phone = @phone WHERE name = @name", connection);
                command.Parameters.AddWithValue("@name", contact.Name);
                command.Parameters.AddWithValue("@address", contact.Address);
                command.Parameters.AddWithValue("@phone", contact.Phone);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteContact(string name)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM contacts WHERE name = @name", connection);
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
        }

        public List<Contact> GetContactsByName(string name)
        {
            var contacts = new List<Contact>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT name, address, phone FROM contacts WHERE name LIKE @name", connection);
                command.Parameters.AddWithValue("@name", "%" + name + "%"); // 使用模糊查询

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contact = new Contact(reader["name"].ToString(), reader["address"].ToString(), reader["phone"].ToString());
                        contacts.Add(contact);
                    }
                }
            }
            return contacts; // 返回匹配的联系人列表
        }


    }
}
