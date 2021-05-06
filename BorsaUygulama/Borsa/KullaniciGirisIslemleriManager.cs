﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borsa
{
   public class KullaniciGirisIslemleriManager
    {

        public static int girisId;//giris yapan kullaniciyla ilgili islemleri yapabilmek icin sisteme giren kullanicin id'si girisId'de statik ve her yerden ulasilabilir olacak sekilde tanmlandi
        VeriTabaniEntities veriTabani = new VeriTabaniEntities();//veritabaniyla ilgili islemleri yapabilmek icin nesne olusturuldu

        public void GirisYap(KullaniciTbl kullanici)//giris yapan kullanici bilgileri parametre olarak alınır
        {
            var sonuc = from gecici in veriTabani.KullaniciTbl
                        where gecici.KullaniciAdi == kullanici.KullaniciAdi
                        && gecici.KullaniciSifre == kullanici.KullaniciSifre select gecici;
            //texten gelen kullaniciyla veritabanindaki kullanci bilgileri eslesen kullanici alır ve listede tutar
            foreach (var kullaniciBilgileri in sonuc)
            {
                girisId = kullaniciBilgileri.KullaniciId;
            }
            if (sonuc.Any())//sonuc listesinde bir kayit varsa true döner ve kullanici islemleri menusunu acar 
            {

                KullaniciIslemleriMenuForm kullaniciIslemlerimenu = new KullaniciIslemleriMenuForm();
                kullaniciIslemlerimenu.Show();
            }
            else //eslesen bir kullanici yoksa ekranda hata mesaji gosterir.
            {
                MessageBox.Show("Hatali Giris Yaptiniz!");
            }
        }
    }
}
