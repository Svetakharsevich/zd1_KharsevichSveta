using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Задание_2_3
{
    public partial class Form1 : Form
    {
        Shop pyaterochka = new Shop();
        private Playlist playlist;
        public Form1()
        {
            InitializeComponent();
            playlist = new Playlist();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void магазинToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || numericUpDown1.Value == 0 || numericUpDown2.Value == 0)
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
                return;
            }
            string Name;
            int Price, Count;
            Name = textBox1.Text;
            Price = (int)numericUpDown1.Value;
            Count = (int)numericUpDown2.Value;
            foreach (var ch in Name)
            {
                if (char.IsDigit(ch))
                {
                    MessageBox.Show("Имя не может состоять из цифр", "Ошибка");
                    return;
                }
            }
            Product ToSell = pyaterochka.FindByName(Name);
            if (ToSell == null)
            {
                pyaterochka.CreateProduct(Name, Price, Count);
                MessageBox.Show("Товар добавлен", "");
                textBox1.Text = "";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;

            }
            else
            {
                MessageBox.Show("Такой товар уже есть", "Ошибка");
            }
        }

        private void списокТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox2.Visible = true;
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            List<string> list = new List<string>();
            List<string> namelist = new List<string>();
            pyaterochka.WriteOnlyProductsName(namelist);
            pyaterochka.WriteAllProducts(list);
            foreach (string listitem in list)
            {
                listBox1.Items.Add(listitem);
            }
            foreach (string listitem in namelist)
            {
                comboBox1.Items.Add(listitem);
            }
            label6.Text = $"{pyaterochka.Profit.ToString()} руб.";
        }

        private void продажаТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Пустое поле ввода", "Ошибка");
                return;
            }
            string cellpr = comboBox1.Text;
            MessageBox.Show($"{pyaterochka.Sell(cellpr)}", "");
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
                return;
            }
            string author = textBox3.Text;
            string title = textBox2.Text;
            string filename = "";
            foreach (var ch in author)
            {
                if (char.IsDigit(ch))
                {
                    MessageBox.Show("Имя не может состоять из цифр", "Ошибка");
                    return;
                }
            }
            Song song = new Song(author, title, filename);
            playlist.AddSong(song);
            listBox2.Items.Add(song);
            MessageBox.Show("Песня добавлена в плейлист");
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void UpdateCurrentSongDisplay()
        {
            Song currentSong = playlist.CurrentSong();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                string itemText = listBox2.Items[i].ToString();
                if (itemText == $"{currentSong.Title} от {currentSong.Author}")
                {
                    listBox2.SetSelected(i, true);
                    return;
                }
            }
            button6.Enabled = playlist.list.Count > 1;
            button4.Enabled = playlist.list.Count > 1;


        }



        private void плейлистToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            playlist.BackSong();
            UpdateCurrentSongDisplay();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < playlist.list.Count)
            {
                playlist.currentIndex = selectedIndex;
               //UpdateCurrentSongDisplay();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            playlist.NextSong();
            UpdateCurrentSongDisplay();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            playlist.currentIndex = 0;
            UpdateCurrentSongDisplay();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            playlist.ClearPlaylist();
            listBox2.Items.Clear();
            MessageBox.Show("Плейлист успешно очищен!", "Сообщение");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBox2.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < playlist.list.Count)
                {
                    playlist.list.RemoveAt(selectedIndex);
                    listBox2.Items.RemoveAt(selectedIndex);
                    UpdateCurrentSongDisplay();
                }
            }
            catch
            {
                MessageBox.Show("Песня удалена из плейлиста");
            }
        }
    }
}
