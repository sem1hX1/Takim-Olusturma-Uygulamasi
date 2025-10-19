namespace TakımOluşturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            textBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Atakımı.Items.Add(comboBox1.Text);
            comboBox1.Text = "";
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Btakımı.Items.Add(comboBox1.Text);
            comboBox1.Text = "";
            comboBox1.Items.Remove(comboBox1.SelectedItem);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (Atakımı.SelectedItem != null)
            {
                Btakımı.Items.Add(Atakımı.SelectedItem);
                Atakımı.Items.Remove(Atakımı.SelectedItem);
                
            }
            else
            {
                MessageBox.Show("Lütfen A Takımından Bir Oyuncu Seçiniz.");
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Btakımı.SelectedItem != null) {
                Atakımı.Items.Add(Btakımı.SelectedItem);
                Btakımı.Items.Remove(Btakımı.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen B Takımından Bir Oyuncu Seçiniz.");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Atakımı.SelectedItem != null)
            {
                comboBox1.Items.Add(Atakımı.SelectedItem);
                Atakımı.Items.Remove(Atakımı.SelectedItem);
            }
            else { 
            MessageBox.Show("Lütven Kaldırılacak Oyuncuyu Seçiniz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Btakımı.SelectedItem != null)
            {
                comboBox1.Items.Add(Btakımı.SelectedItem);
                Btakımı.Items.Remove(Btakımı.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütven Kaldırılacak Oyuncuyu Seçiniz.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 1. Temizlik
            Atakımı.Items.Clear();
            Btakımı.Items.Clear();

            // 2. Oyuncu Listesini Hazırla (ComboBox'taki tüm öğeleri geçici listeye al)
            List<string> tumOyuncular = new List<string>();
            foreach (var item in comboBox1.Items)
            {
                tumOyuncular.Add(item.ToString());
            }

            // Yeterli oyuncu yoksa uyarı verip çık
            if (tumOyuncular.Count < 2)
            {
                MessageBox.Show("Rastgele takım yapmak için en az 2 oyuncu olmalı.");
                return;
            }

            // 3. Rastgele Atama
            Random rnd = new Random();
            int takimSirasi = 0; // 0 = A Takımı (listBox1), 1 = B Takımı (listBox2)

            while (tumOyuncular.Count > 0)
            {
                // Rastgele bir oyuncu seç
                int randomIndex = rnd.Next(tumOyuncular.Count);
                string secilenOyuncu = tumOyuncular[randomIndex];

                // Takıma Ekle
                if (takimSirasi == 0)
                {
                    Atakımı.Items.Add(secilenOyuncu); // A Takımı
                    takimSirasi = 1; // Sıra B Takımına geçti
                }
                else
                {
                    Btakımı.Items.Add(secilenOyuncu); // B Takımı
                    takimSirasi = 0; // Sıra A Takımına geçti
                }

                // Listeden Kaldır
                tumOyuncular.RemoveAt(randomIndex);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
        }
    }
}
