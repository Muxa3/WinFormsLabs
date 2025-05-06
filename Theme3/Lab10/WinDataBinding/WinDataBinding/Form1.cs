using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDataBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BindingSource sotrBindingSourse;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Загрузка таблицы данными: 
            заказчикиTableAdapter1.Fill(конфетная_фабрикаDataSet1.Заказчики);
            // Создание BindingSource для таблицы Сотрудники: 
            sotrBindingSourse = new
            BindingSource(конфетная_фабрикаDataSet1, "Заказчики");
            // Настройка связывания для элементов TextBox: 
            FamtextBox.DataBindings.Add("Text", sotrBindingSourse, "B");
            NametextBox.DataBindings.Add("Text", sotrBindingSourse, "C");
            SectiontextBox.DataBindings.Add("Text", sotrBindingSourse, "E");
        }

        private void Previousbutton_Click(object sender, EventArgs e)
        {
            sotrBindingSourse.MovePrevious();
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            sotrBindingSourse.MoveNext();
        }
    }
}
