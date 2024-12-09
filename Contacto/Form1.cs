using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contactos
{
    public partial class Form1 : Form
    {
        private List<Contacto> contacts;

        public Form1()
        {
            InitializeComponent();
            contacts = new List<Contacto>();
           
        }

        private bool checkPhone(string phone)
        {
            if (phone.Length != 11 || !long.TryParse(phone, out _))
            {
                MessageBox.Show("El teléfono debe tener 11 dígitos numéricos");
                return false;
            }
            return true;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text;
            string phone = txtTelefono.Text;

            if (string.IsNullOrEmpty(name) || !checkPhone(phone))
            {
                return;
            }

            Contacto contact = new Contacto(name, phone);
            contacts.Add(contact);

            ListViewItem item = new ListViewItem(contact.Name);
            item.SubItems.Add(contact.Phone);
            listViewContactos.Items.Add(item);

            MessageBox.Show("Contacto añadido correctamente");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string phone = txtTelefono.Text;

            if (!checkPhone(phone))
            {
                MessageBox.Show("Introduce un número de teléfono válido antes de buscar");
                return;
            }

            var contact = contacts.Find(c => c.Phone == phone);

            if (contact != null)
            {
                txtNombre.Text = contact.Name;
                txtTelefono.Text = contact.Phone;

                foreach (ListViewItem item in listViewContactos.Items)
                {
                    if (item.SubItems[1].Text == phone)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
                MessageBox.Show($"Se encontró el siguiente contacto:\nNombre: {contact.Name}\nTeléfono: {contact.Phone}");
            }
            else
            {
                MessageBox.Show("No se encontró ningún contacto con esos datos");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string phone = txtTelefono.Text;
            if (!checkPhone(phone))
            {
                return;
            }

            var contact = contacts.Find(c => c.Phone == phone);
            if (contact != null)
            {
                contacts.Remove(contact);
                foreach (ListViewItem item in listViewContactos.Items)
                {
                    if (item.SubItems[1].Text == phone)
                    {
                        listViewContactos.Items.Remove(item);
                        break;
                    }
                }
                MessageBox.Show("Contacto eliminado correctamente");
            }
            else
            {
                MessageBox.Show("No se encontró ningún contacto con esos datos");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string oldPhone = txtTelefono.Text;
            string newName = txtNombre.Text;
            string newPhone = txtTelefono.Text;

            if (!checkPhone(oldPhone) || !checkPhone(newPhone))
            {
                MessageBox.Show("Por favor, introduce un número de teléfono válido");
                return;
            }

            int index = contacts.FindIndex(c => c.Phone == oldPhone);

            if (index == -1)
            {
                MessageBox.Show("No se encontró ningún contacto con esos datos");
            }
            else
            {
                Contacto updatedContact = new Contacto(newName, newPhone);
                contacts[index] = updatedContact;

                foreach (ListViewItem item in listViewContactos.Items)
                {
                    if (item.SubItems[1].Text == oldPhone)
                    {
                        item.Text = updatedContact.Name;
                        item.SubItems[1].Text = updatedContact.Phone;
                        break;
                    }
                }
                MessageBox.Show($"Contacto actualizado correctamente:\nNombre: {updatedContact.Name}\nTeléfono: {updatedContact.Phone}");
            }
        }

        private void lblInstrucciones_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewContactos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}