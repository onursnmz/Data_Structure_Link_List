using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev_DLinkList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class dugum
        {
            public string ad;
            public int numara;
            public dugum sonraki;
            public dugum onceki;
        }
        dugum ilk = null;
        public void print()
        {
            listBox1.Items.Clear();
            dugum yeni = new dugum();
            yeni = ilk;
            while (yeni != null)
            {
                listBox1.Items.Add(yeni.numara);
                yeni = yeni.sonraki;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dugum yeni = new dugum();
            
            yeni.numara = Convert.ToInt32(textBox2.Text);
            if (ilk == null)
            {
                ilk = yeni;
                ilk.sonraki = null;
                ilk.onceki = null;
            }
            else
            {
                dugum iter,temp;
                iter = ilk;
                //Eğer başlangıç düğümünden küçükse yeni başlangıç düğümümüz, gelecek olan "yeni" düğüm olacaktır
                if (yeni.numara < ilk.numara)
                {
                    temp = ilk;
                    ilk = yeni;
                    ilk.sonraki = temp;
                    temp.onceki = ilk;
                    ilk.onceki = null;
                }//Linkli liste içerisinde girilen değeri yerine yerleştirme. ( büyük küçük kontrolleri yaparak )
                else
                {
                    while (iter.sonraki != null && iter.sonraki.numara < yeni.numara)
                    {
                        iter = iter.sonraki;
                    }
                    if(iter.sonraki == null)
                    {
                        yeni.sonraki = iter.sonraki;
                        iter.sonraki = yeni;
                        yeni.onceki = iter;
                    }
                    else
                    {
                        yeni.sonraki = iter.sonraki;
                        iter.sonraki.onceki = yeni;
                        iter.sonraki = yeni;
                        yeni.onceki = iter;
                    }
                }
            }
            print();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dugum iter;
            iter = ilk;
            dugum temp;
            if (ilk == null)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Linkli listede herhangi bir eleman yok!";
            }
            else
            {
                //Eğer sileceğimiz düğüm baştaysa, başlangıç düğümünü kaybetmemek adına temp adlı değişken
                //oluşturup sileceğimiz düğümü o temp haline getirip öyle sildik. Daha sonrasında başlangıç düğümünü
                //eski başlangıç'ın bir sonrasına attık(çünkü eski başlangıç silinmesi istendi)
                if (ilk.numara == Convert.ToInt32(textBox2.Text))
                {
                    temp = ilk;
                    ilk = ilk.sonraki;
                    temp = null;
                }
                else
                {
                    while (iter.sonraki != null && iter.sonraki.numara != Convert.ToInt32(textBox2.Text))
                    {
                        iter = iter.sonraki;
                    }
                    if (iter.sonraki == null)
                    {
                        label3.ForeColor = Color.Red;
                        label3.Text = "Girdiğiniz numara bulunamadı.";
                    }
                    else
                    {
                        temp = iter.sonraki;
                        iter.sonraki = iter.sonraki.sonraki;
                        temp = null;
                    }
                }
            }
            print();
        }
    }
}
