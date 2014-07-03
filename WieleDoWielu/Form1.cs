using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WieleDoWielu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ksiazkiDataSet.Autorzy' table. You can move, or remove it, as needed.
            this.autorzyTableAdapter.Fill(this.ksiazkiDataSet.Autorzy);
            ksiazkiTableAdapter1.Fill(ksiazkiDataSet.Ksiazki);
            ksiazkaAutorTableAdapter1.Fill(ksiazkiDataSet.KsiazkaAutor);

        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            DataRowView rowView = e.ListItem as DataRowView;
            KsiazkiDataSet.AutorzyRow row = rowView.Row as KsiazkiDataSet.AutorzyRow;
            e.Value = row.Nazwisko + " " + row.Imie;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==-1)
            {
                return;
            }
            listBox1.Items.Clear();
            DataRowView rowViewAutorzy = comboBox1.SelectedItem as DataRowView;
            KsiazkiDataSet.AutorzyRow rowAutorzy = rowViewAutorzy.Row as KsiazkiDataSet.AutorzyRow;
            foreach (var row in rowAutorzy.GetKsiazkaAutorRows())
            {
                listBox1.Items.Add(row.KsiazkiRow.Tytul);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
