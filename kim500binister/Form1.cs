using kim500binister.App_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kim500binister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int soruindis = 0;
        bool devam = true; 

        List<soru> sorular = new List<soru>();

        private void Form1_Load(object sender, EventArgs e)
        {
            sorularFill();
            getSoru();
        }

        void getSoru()
        {
            soru item = sorular[soruindis];
            
            lblsoru.Text = item.Soru;

            BtnA.Text = item.secenekA;
            BtnA.BackColor = Color.Transparent;

            btnB.Text = item.secenekB;
            btnB.BackColor = Color.Transparent;

            btnC.Text = item.secenekC;
            btnC.BackColor = Color.Transparent;

            btnD.Text = item.secenekD;
            btnD.BackColor = Color.Transparent;
        }

        string getkazanilanpara()
        {
            int toplampara = 0;
            foreach (soru item in sorular)
            {
                if(item.secenekcevap==item.secenekKullanicicevap)
                {
                    toplampara += item.odul;
                }
            }
            return string.Format("{0:C}", toplampara);
        }

        void sorularFill()
        {
            sorular.Add(new soru()
            {
                Soru="6 kere 8?",
                secenekA="42",
                secenekB="44",
                secenekC="46",
                secenekD="48",
                secenekcevap="D",
                odul=100000

            });
            sorular.Add(new soru()
            {
                Soru = "12 kere 11?",
                secenekA = "130",
                secenekB = "131",
                secenekC = "132",
                secenekD = "133",
                secenekcevap = "C",
                odul = 100000

            }); sorular.Add(new soru()
            {
                Soru = "Nasıl gidiyor?",
                secenekA = "kötü",
                secenekB = "leş",
                secenekC = "iyi",
                secenekD = "fişşek gibi",
                secenekcevap = "C",
                odul = 100000

            }); sorular.Add(new soru()
            {
                Soru = "Zeki Müren de bizi görecek mi?",
                secenekA = "Bilmem",
                secenekB = "Evet",
                secenekC = "Hayır",
                secenekD = "Niye napacan",
                secenekcevap = "A",
                odul = 100000

            }); sorular.Add(new soru()
            {
                Soru = "En güzel renk",
                secenekA = "Yeşil",
                secenekB = "Mavi",
                secenekC = "Mor",
                secenekD = "Kırmızı",
                secenekcevap = "B",
                odul = 100000

            });
        }


        void setkullanicicevap(string secenek,Button button)
        {
            if(devam)
            {
                if(string.IsNullOrEmpty(sorular[soruindis].secenekKullanicicevap))
                {
                    DialogResult dialogResult = MessageBox.Show(button.Text+" son kararınız mı?", "Son kararınız mı?", MessageBoxButtons.YesNo);

                    if(dialogResult==DialogResult.Yes)
                    {
                        sorular[soruindis].secenekKullanicicevap = secenek;

                        lblOdul.Text = getkazanilanpara();

                        if(sorular[soruindis].secenekcevap==sorular[soruindis].secenekKullanicicevap)
                        {
                            button.BackColor = Color.Green;

                        }
                        else
                        {
                            devam = false;

                            button.BackColor = Color.Red;

                            MessageBox.Show("Yarışma Bitti. Kazanılan Para :" + getkazanilanpara());

                            switch (sorular[soruindis].secenekcevap)
                            {
                                case "A":
                                    BtnA.BackColor = Color.Green;
                                    break;

                                case "B":
                                    btnB.BackColor = Color.Green;
                                    break;

                                case "C":
                                    btnC.BackColor = Color.Green;
                                    break;

                                case "D":
                                    btnD.BackColor = Color.Green;
                                    break;

                                default:
                                    break;
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sonraki soruya geçin");
                }

            }
            else
            {
                MessageBox.Show("Yanlış Cevap");
            }
        }

        void getSonrakiSoru()
        {
            if (devam)
            {
                if (!string.IsNullOrEmpty(sorular[soruindis].secenekKullanicicevap))
                {
                    if ((sorular.Count - 1) > soruindis)
                    {
                        soruindis++;
                        getSoru();
                    }
                    else
                    {
                        MessageBox.Show("Yarışma Bitti. Kazanılan Para :" + getkazanilanpara());
                    }
                }
                else
                {
                    MessageBox.Show("Soruya cevap veriniz.");
                }
            }
            else
            {
                MessageBox.Show("Yarışma maalesef bitti.");
            }
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            setkullanicicevap("A", (Button)sender);

        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            setkullanicicevap("B", (Button)sender);
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            setkullanicicevap("C", (Button)sender);
        }

        private void BtnD_Click(object sender, EventArgs e)
        {
            setkullanicicevap("D", (Button)sender);
        }

        private void BtnSoru_Click(object sender, EventArgs e)
        {
            getSonrakiSoru();
        }
    }
}