using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Matrix : Form
    {
        private int[,] matrix;
        private int rowCount;
        private int colCount;
        public Matrix()
        {
            InitializeComponent();
        }

        private void Matrix_Load(object sender, EventArgs e)
        {
            
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
           
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // отримання кількості рядків та стовпців з текстових полів
            rowCount = int.Parse(textBox1.Text);
            colCount = int.Parse(textBox2.Text);

            // створення матриці та заповнення її випадковими значеннями
            matrix = new int[rowCount, colCount];
            Random random = new Random();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = random.Next(-10, 10); // генерація випадкового числа в діапазоні від 0 до 9
                }
            }
            // заповнення DataGridView зі створеної матриці
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int j = 0; j < colCount; j++)
            {
                dataGridView1.Columns.Add(j.ToString(), (j + 1).ToString());
            }
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < colCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
            // обчислення кількості стовпців з нульовим елементом
            int zeroColCount = 0;
            for (int j = 0; j < colCount; j++)
            {
                bool hasZero = false;
                for (int i = 0; i < rowCount; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    zeroColCount++;
                }
            }
            textBox3.Text = zeroColCount.ToString();

            // обчислення номера рядка з найбільшою кількістю однакових елементів

            2// зберігання номерів рядків з однаковою кількістю однакових елементів
            List<int> equalRows = new List<int>();
            for (int i = 0; i < rowCount; i++)
            {
                Dictionary<int, int> equalCounts = new Dictionary<int, int>();
                for (int j = 0; j < colCount; j++)
                {
                    int element = matrix[i, j];
                    if (equalCounts.ContainsKey(element))
                    {
                        equalCounts[element]++;
                    }
                    else
                    {
                        equalCounts[element] = 1;
                    }
                }
                int count = equalCounts.Values.Max();
                if (count > 1 && equalCounts.Values.Count(c => c == count) == 1)
                {
                    equalRows.Add(i);
                }
            }
            if (equalRows.Count == 0)
            {
                textBox4.Text = "таких рядків немає";
            }
            else
            {
                textBox4.Text = string.Join(", ", equalRows.Select(r => r + 1));
            }



        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
