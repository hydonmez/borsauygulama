﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borsa
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }
       private KullaniciGirisIslemleriManager girisIslemleri = new KullaniciGirisIslemleriManager();
        private AdminGirisIslemleriManager adminIslemleri = new AdminGirisIslemleriManager();
       private KullaniciTbl kullanici = new KullaniciTbl();
        private void btnKayitOl_Click(object sender, EventArgs e) 
        {
            //kayit olma formu gösterilir
            KayitOlmaForm kayitOl = new KayitOlmaForm();
            kayitOl.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            kullanici.KullaniciAdi = txtKullaniciAdi.Text;
            kullanici.KullaniciSifre = txtSifre.Text;
            if(girisIslemleri.GirisYap(kullanici))//kullanici tablosunda kullanici adi ve sifresi eslesen bir kisi varsa kullanici islemleri menusunu acar
            {
                KullaniciIslemleriMenuForm kullaniciIslemlerimenu = new KullaniciIslemleriMenuForm();
                kullaniciIslemlerimenu.Show();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnAdminGiris_Click(object sender, EventArgs e)
        {
            
            AdminTbl admin = new AdminTbl();
            admin.AdmiKullaniciAdi = txtAdminKullaniciAdi.Text;
            admin.AdminSifre = txtAdminSifre.Text;
            adminIslemleri.GirisYap(admin);//admin islemleri sınıfına admin nesnesi gonderilir


        }
        private void formuKapat_Click_1(object sender, EventArgs e)
        {
            this.Close();//Formu kapatır
        }

        private void formuKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//formu asagi alir
        }
    }
}
