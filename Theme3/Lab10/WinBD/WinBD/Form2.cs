using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void oleDbDataAdapter1_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
        {

        }

        DataView ЗаказчикиDataView;
        private void button1_Click(object sender, EventArgs e)
        {
            // Загрузка таблицы данными: 
            заказчикиTableAdapter1.Fill(конфетная_фабрикаDataSet1.Заказчики);
            // Настройка объекта DataView 
            ЗаказчикиDataView = new
            DataView(конфетная_фабрикаDataSet1.Заказчики);
            // Настройка dataGridView для отображения данных 
            dataGridView1.DataSource = ЗаказчикиDataView;
            // Присвоения исходного порядка сортировки 
            ЗаказчикиDataView.Sort = "C";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oleDbDataAdapter1.Update(dataSet111);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ЗаказчикиDataView.Sort = SortTextBox.Text;
            ЗаказчикиDataView.RowFilter = FilterTextBox.Text;
        }
    }
}
