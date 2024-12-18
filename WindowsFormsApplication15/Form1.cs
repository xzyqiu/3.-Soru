using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class Form1 : Form
    {
        // Çalışanlar listesini tutacak
        List<Personel> personelListesi = new List<Personel>();

        public Form1()
        {
            InitializeComponent();

            // Departmanları ComboBox'a ekliyoruz
            comboBoxDepartman.Items.Add("Otomobil Satışı");
            comboBoxDepartman.Items.Add("Yedek Parça Satışı");
            comboBoxDepartman.SelectedIndex = 0; // İlk seçeneği varsayılan olarak seç
        }

        // Ekle butonuna tıklanınca çalışacak metod
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int numara = int.Parse(txtNumara.Text);
                string adSoyad = txtAdSoyad.Text;
                decimal maas = decimal.Parse(txtMaas.Text);
                decimal satisTutari = decimal.Parse(txtSatisTutari.Text);
                string departman = comboBoxDepartman.SelectedItem.ToString();
                Personel yeniPersonel;

                if (departman == "Otomobil Satışı")
                {
                    yeniPersonel = new OtomobilSatisi(numara, adSoyad, maas, departman, satisTutari);
                }
                else
                {
                    yeniPersonel = new YedekParcaSatisi(numara, adSoyad, maas, departman, satisTutari);
                }

                personelListesi.Add(yeniPersonel);

                listBox1.Items.Clear();
                foreach (var personel in personelListesi)
                {
                    listBox1.Items.Add("Numara: " + personel.Numarası + "- Ad Soyad: " + personel.AdSoyad + "- Maaş: " + personel.Maas + "- Satış Tutarı: " + personel.SatisTutari + "- Departman: " + personel.Departman);
                }

                txtNumara.Clear();
                txtAdSoyad.Clear();
                txtMaas.Clear();
                txtSatisTutari.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri girişi hatası: " + ex.Message);
            }
        }
    }

    public class Personel
    {
        public int Numarası { get; set; }
        public string AdSoyad { get; set; }
        public decimal Maas { get; set; }
        public string Departman { get; set; }
        public decimal SatisTutari { get; set; }

        public Personel(int numara, string adSoyad, decimal maas, string departman, decimal satisTutari)
        {
            Numarası = numara;
            AdSoyad = adSoyad;
            Maas = maas;
            Departman = departman;
            SatisTutari = satisTutari;
        }
    }

    public class OtomobilSatisi : Personel
    {
        public OtomobilSatisi(int numara, string adSoyad, decimal maas, string departman, decimal satisTutari)
            : base(numara, adSoyad, maas, departman, satisTutari)
        {
        }
    }

    public class YedekParcaSatisi : Personel
    {
        public YedekParcaSatisi(int numara, string adSoyad, decimal maas, string departman, decimal satisTutari)
            : base(numara, adSoyad, maas, departman, satisTutari)
        {
        }
    }
}
