using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animek
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Anime neve";
            dataGridView1.Columns[1].Name = "Év";
            dataGridView1.Columns[2].Name = "Műfaj";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            string[] adatok = input.Split(';');

            if (adatok.Length == 3)
            {
                string cim = adatok[0].Trim();
                string ev = adatok[1].Trim();
                string mufaj = adatok[2].Trim();

                dataGridView1.Rows.Add(cim, ev, mufaj);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Hibás formátum! Használat: Cím;Év;Műfaj", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog mentes = new SaveFileDialog())
            {
                mentes.Filter = "Szövegfájl (*.txt)|*.txt";
                mentes.Title = "Mentés anime listához";

                if (mentes.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(mentes.FileName))
                        {
                            foreach (DataGridViewRow sor in dataGridView1.Rows)
                            {
                                if (!sor.IsNewRow)
                                {
                                    string cim = sor.Cells[0].Value?.ToString() ?? "";
                                    string ev = sor.Cells[1].Value?.ToString() ?? "";
                                    string mufaj = sor.Cells[2].Value?.ToString() ?? "";

                                    sw.WriteLine($"{cim};{ev};{mufaj}");
                                }
                            }
                        }

                        MessageBox.Show("Sikeresen elmentve!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba a mentés során:\n" + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
