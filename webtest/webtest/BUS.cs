using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webtest
{
    public class BUS
    {
        private static BUS instance;

        public static BUS Instance
        {
            get { if (instance == null) instance = new BUS(); return BUS.instance; }
            private set { BUS.instance = value; }
        }
        KetnoiCSDLDataContext data = new KetnoiCSDLDataContext();
        #region Đăng nhập
        public bool KTdangnhap(string tendn, string matkhau)
        {
            int taikhoan = (from tk in data.nhansus
                            where tk.acc == tendn && tk.pw == matkhau
                            select tk).Count();
            if (taikhoan == 1)
                return true;
            else
                return false;
        }
        public short KTquyen(string tendn)
        {
            short taikhoan = (from tk in data.nhansus
                              where tk.acc == tendn
                              select tk.quyen).Single();
            return taikhoan;
        }

         public IEnumerable<nhansu> Laydstk()
         {
            IEnumerable<nhansu> taikhoan = from tk in data.nhansus
                                           select tk;
            return taikhoan;
         }

         public nhansu Laytaikhoan(string tendn)
         {
             nhansu taikhoan = (from tk in data.nhansus
                                where tk.acc == tendn
                                select tk).Single();
             return taikhoan;
         }
         public nhansu Laytaikhoan2(int iduser)
         {
             nhansu taikhoan = (from tk in data.nhansus
                                where tk.iduser == iduser
                                select tk).Single();
             return taikhoan;
         }
         public List<bantin_ykien_duyet> Layykien(int idbantin)
         {
             List<bantin_ykien_duyet> ketqua = (from tk in data.bantin_ykien_duyets
                                                where tk.idbantin == idbantin
                                                select tk).ToList();
             return ketqua;
         }
//        public string layten(string tendn)
//        {
//            string ten = (from tk in data.nguoidungs
//                          where tk.Taikhoan == tendn
//                          select tk.Ten).Single();
//            return ten;
//        }
//        #endregion
//        #region Thêm tài khoản
//        public bool KTtontai(string tendn)
//        {
//            int taikhoan = (from tk in data.nguoidungs
//                            where tk.Taikhoan == tendn
//                            select tk).Count();
//            if (taikhoan == 1)
//                return true;
//            else
//                return false;
//        }

//        public IEnumerable<nguoidung> Laytaikhoan()
//        {
//            IEnumerable<nguoidung> taikhoan = from tk in data.nguoidungs
//                                              select tk;
//            return taikhoan;
//        }
//        public void Themtaikhoan(string tendn, string mk, string ten, bool quyen)
//        {
//            nguoidung themtk = new nguoidung();
//            themtk.Taikhoan = tendn;
//            themtk.Matkhau = mk;
//            themtk.Ten = ten;
//            themtk.Quyen = quyen;
//            data.nguoidungs.InsertOnSubmit(themtk);
//            data.SubmitChanges();

//        }

//        public void xoatk(string tendn)
//        {
//            nguoidung xoanguoidung = (from tk in data.nguoidungs
//                                      select tk).Single(t => t.Taikhoan == tendn);
            
//            data.nguoidungs.DeleteOnSubmit(xoanguoidung);
//            data.SubmitChanges();
//        }
//        #endregion
//        #region Cập nhật sản phẩm
         //public bool KTBTtontai(int idbantin)
         //{
         //    int bantin = (from tk in data.bantins
         //                   where tk.idbantin == idbantin
         //                   select tk).Count();
         //    if (bantin == 1)
         //        return true;
         //    else
         //        return false;
         //}

//        public IEnumerable<Sanpham> Laysanpham()
//        {
//            IEnumerable<Sanpham> sanpham = from tk in data.Sanphams
//                                              select tk;
//            return sanpham;
//        }
         
//        public int Layspmoinhat()
//        {
//            Sanpham spmoi = new Sanpham();
//            List<int> idsp = (from tk in data.Sanphams
//                              select tk.IDsp).ToList();
//            return idsp.Max();
//        }

//        public void Capnhatspmoi(int idsp, string idngay)
//        {
//            luungay spmoi = new luungay();

//            spmoi.IDsp = idsp;
//            spmoi.IDngay = idngay;
//            spmoi.Nhap = 0;
//            spmoi.Xuat = 0;
//            spmoi.Ghichu = "";
//            spmoi.Ton = 0;
//            List<int> id = (from tk in data.luungays
//                            select tk.ID).ToList();

//            if (id.Count() == 0)
//                spmoi.IDsp = 1;
//            else
//                spmoi.ID = id.Max() + 1;

//            data.luungays.InsertOnSubmit(spmoi);
//            data.SubmitChanges();
//        }

//        public void Capnhatsp(string tenspcu, string tenspmoi, string quycachcu, string quycachmoi)
//        {
//            Sanpham suasanpham = (from sp in data.Sanphams
//                                  select sp).Single(t => t.Tensp == tenspcu && t.Quycachsp == quycachcu);
//            suasanpham.Tensp = tenspmoi;
//            suasanpham.Quycachsp = quycachmoi;
//            data.SubmitChanges();
//        }

//        public void Xoasp (int idsp)
//        {
//            Sanpham xoasanpham = (from sp in data.Sanphams
//                                  select sp).Single(t => t.IDsp == idsp);
//            data.Sanphams.DeleteOnSubmit(xoasanpham);

//            List<string> ngaysanpham = (from spx in data.luungays
//                                          where spx.IDsp == xoasanpham.IDsp
//                                          select spx.IDngay).ToList();

//            foreach (string idngay in ngaysanpham)
//            {
//                luungay sanphamngay = (from sp2 in data.luungays
//                                       where sp2.IDngay == idngay && sp2.IDsp == idsp
//                                       select sp2).Single();
//                data.luungays.DeleteOnSubmit(sanphamngay);
//            }
            
//            data.SubmitChanges();
//        }
//        #endregion
//        #region Cập nhật ngày
//        public bool KTngaymoi(string idngay)
//        {
//            int ngay = (from day in data.Ngays
//                        where day.IDngay == idngay
//                        select day).Count();
//            if (ngay == 1)
//                return true;
//            else
//                return false;
//        }
        
//        public void taongaymoi(string idngay, DateTime ngay)
//        {
//            Ngay ngaymoi = new Ngay();

//            ngaymoi.IDngay = idngay;
//            ngaymoi.Ngay1 = ngay;
//            data.Ngays.InsertOnSubmit(ngaymoi);
//            data.SubmitChanges();
//        }

//        public void xoangay(string idngay)
//        {
//            List<luungay> sanphamngay = (from sp2 in data.luungays
//                                       where sp2.IDngay == idngay
//                                       select sp2).ToList();
//            foreach (luungay item in sanphamngay)
//            {
//                data.luungays.DeleteOnSubmit(item);
//            }
            
//            data.SubmitChanges();
//        }

//        public void Themngay(string idngaycu, string idngaymoi)
//        {
//            IEnumerable<Sanpham> sanpham = (from sp in data.Sanphams
//                                            select sp).ToList();
//            List<int> ton = (from luu in data.luungays
//                                        where luu.IDngay == idngaycu
//                                        select luu.Ton).ToList();
//            int i = 0;
//            foreach (Sanpham item in sanpham)
//            {
//                luungay themngay = new luungay();
//                themngay.IDsp = item.IDsp;
//                themngay.IDngay = idngaymoi;
//                themngay.Nhap = 0;
//                themngay.Xuat = 0;
//                themngay.Ghichu = "";
//                themngay.Ton = ton[i];
//                List<int> id = (from tk in data.luungays
//                                select tk.ID).ToList();
//                themngay.ID = id.Max() + 1;
//                data.luungays.InsertOnSubmit(themngay);
//                data.SubmitChanges();
//                i += 1;

//            }
//        }

//        //public List<string> Layidngay()
//        //{
//        //    int songay = (from ngay in data.Ngays
//        //                     select ngay).Count();

//        //    List<string> listngay = (from ngay in data.Ngays
//        //                         select ngay.IDngay.ToString()).ToList();

//        //    string ngaycu = listngay[songay - 1];
//        //    string ngaymoi = listngay[songay - 2];


//        //    List<string> xuat = new List<string>();
//        //    xuat.Add(ngaycu);
//        //    xuat.Add(ngaymoi);
//        //    return xuat;
//        //}
//        public IEnumerable<sanphamxuat> Layngay(string idngay)
//        {
//            IEnumerable<sanphamxuat> luu = from luu1 in data.luungays
//                                       join tensp in data.Sanphams on luu1.IDsp equals tensp.IDsp
//                                       where luu1.IDngay == idngay
//                                       select new sanphamxuat(luu1.IDsp, luu1.IDngay, tensp.Tensp, luu1.Nhap, luu1.Xuat, luu1.Ton, luu1.Ghichu);
//            return luu;
//        }

//        public bool KTcapnhat(string idngay)
//        {
//            int ngay = (from day in data.luungays
//                        where day.IDngay == idngay
//                        select day).Count();
//            if (ngay >= 1)
//                return true;
//            else
//                return false;
//        }

//        public void Capnhatngay(int idsp, string idngay, int nhap, int xuat, string ghichu)
//        {
//            luungay sanpham = (from sp in data.luungays
//                               where sp.IDsp == idsp && sp.IDngay == idngay
//                               select sp).Single();
//            sanpham.Nhap = nhap;
//            sanpham.Xuat = xuat;
//            sanpham.Ton = sanpham.Ton + nhap - xuat;
//            sanpham.Ghichu = ghichu;
//            data.SubmitChanges();
//        }

//        public void Huybongay(int idsp, string idngaymoi, string idngaycu)
//        {
//            luungay sanpham = (from sp in data.luungays
//                               where sp.IDsp == idsp && sp.IDngay == idngaymoi
//                               select sp).Single();
//            sanpham.Nhap = 0;
//            sanpham.Xuat = 0;
//            sanpham.Ghichu = "";
//            sanpham.Ton = (from luu in data.luungays
//                           where luu.IDsp == idsp && luu.IDngay == idngaycu
//                           select luu.Ton).Single();
//            data.SubmitChanges();
//        }
//        #endregion
//        #region Tra cứu
//        public IEnumerable<Sanpham> Laytensanpham()
//        {
//            IEnumerable<Sanpham> sanpham = from tk in data.Sanphams
//                                           select tk;
//            return sanpham;
//        }
        
//        public List<sanphamxuat> tracuu(string tensanpham, string idngay)
//        {
//            List<sanphamxuat> sanpham = (from sp in data.luungays
//                                         join tensp in data.Sanphams on sp.IDsp equals tensp.IDsp
//                                         join ng in data.Ngays on sp.IDngay equals ng.IDngay
//                                         where tensp.Tensp == tensanpham && sp.IDngay == idngay
//                                         select new sanphamxuat(tensp.Tensp, ng.Ngay1, sp.Nhap, sp.Xuat, sp.Ton, sp.Ghichu)).ToList();
//            return sanpham;
//        }
//        #endregion
//    }
//    #region Class sản phẩm xuất
//    public class sanphamxuat
//    {
//        public string ten { get; set; }
//        public DateTime ngay { get; set; }
//        public int nhap { get; set; }
//        public int xuat { get; set; }
//        public int ton { get; set; }
//        public string ghichu { get; set; }
//        public int idsp { get; set; }
//        public string idngay { get; set; }
//        public sanphamxuat() { }
//        public sanphamxuat(string Ten, DateTime Ngay, int Nhap, int Xuat, int Ton, string Ghichu)
//        {
//            ten = Ten;
//            ngay = Ngay;
//            nhap = Nhap;
//            xuat = Xuat;
//            ton = Ton;
//            ghichu = Ghichu;
//        }

//        public sanphamxuat(int Idsp, string Idngay, string Ten, int Nhap, int Xuat, int Ton, string Ghichu)
//        {
//            idsp = Idsp;
//            idngay = Idngay;
//            ten = Ten;
//            nhap = Nhap;
//            xuat = Xuat;
//            ton = Ton;
//            ghichu = Ghichu;
//        }
//    }
#endregion

        #region Danh mục
         #region KhoaLS
         public List<khoa> Loadkhoa()
         {
             List<khoa> ketqua = (from tk in data.khoas
                                  select tk).ToList();
             return ketqua;
         }

         public void Themkhoa(string tenkhoa)
         {
             
             khoa themkhoa = new khoa();
             try
             {
                 int dem = (from tk in data.khoas
                            select tk).ToList().Last().idkhoa;
                 themkhoa.idkhoa = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themkhoa.idkhoa = 1;
             }
                 
             themkhoa.ten = tenkhoa;

             data.khoas.InsertOnSubmit(themkhoa);
             data.SubmitChanges();
         }
         public void Xoakhoa(string tenkhoa)
         {
             try
             {
                 khoa xoakhoa = (from tk in data.khoas
                                 where tk.ten == tenkhoa
                                 select tk).Single();

                 data.khoas.DeleteOnSubmit(xoakhoa);
                 data.SubmitChanges();
             }
             catch { }
         }

         public void Capnhatkhoa(string tenkhoacu, string tenkhoamoi)
         {
             try
             {
                 khoa xoakhoa = (from tk in data.khoas
                                 where tk.ten == tenkhoacu
                                 select tk).Single();
                 xoakhoa.ten = tenkhoamoi;
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #region Phòng ban
         public List<phongban> Loadphongban()
         {
             List<phongban> ketqua = (from tk in data.phongbans
                                  select tk).ToList();
             return ketqua;
         }

         public void Themphongban(string tenphongban)
         {
             phongban themphongban = new phongban();
             try
             {
                 int dem = (from tk in data.phongbans
                        select tk).ToList().Last().idphongban;
                 themphongban.idphongban = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themphongban.idphongban = 1;
             }
             themphongban.ten = tenphongban;

             data.phongbans.InsertOnSubmit(themphongban);
             data.SubmitChanges();
         }
         public void Xoaphongban(string tenphongban)
         {
             try
             {
                 phongban xoaphongban = (from tk in data.phongbans
                                         where tk.ten == tenphongban
                                         select tk).Single();

                 data.phongbans.DeleteOnSubmit(xoaphongban);
                 data.SubmitChanges();
             }
             catch
             {

             }
             
         }

         public void Capnhatphongban(string tenphongbancu, string tenphongbanmoi)
         {
             try
             {
                 phongban capnhat = (from tk in data.phongbans
                                     where tk.ten == tenphongbancu
                                     select tk).Single();
                 capnhat.ten = tenphongbanmoi;
                 data.SubmitChanges();
             }
             catch
             {

             }
         }
         #endregion
         #region Nhân sự
         public List<nhansu> Loadnhansu()
         {
             List<nhansu> ketqua = (from tk in data.nhansus
                                    select tk).ToList();
             return ketqua;
         }
         public List<string> Loadnghe()
         {
             List<string> ketqua = (from tk in data.nhansus
                                    select tk.nghenghiep).ToList();
             return ketqua;
         }

         public List<string> Loadchucvu()
         {
             List<string> ketqua = (from tk in data.nhansus
                                    select tk.chucvu).ToList();
             return ketqua;
         }

         public string Layphongban(short? idpb)
         {
             string ketqua = (from tk in data.phongbans
                              where tk.idphongban == idpb
                              select tk.ten).Single();
             return ketqua;
         }

         public string Laykhoa(short? id)
         {
             string ketqua = (from tk in data.khoas
                              where tk.idkhoa == id
                              select tk.ten).Single();
             return ketqua;
         }
         public void Themnhansu(string hoten, string manv, short idkhoa, short idphongban, string nghenghiep,
             string chucvu, string email, string sdt, string account)
         {
             nhansu themnhansu = new nhansu();
             try
             {
                 int dem = (from tk in data.nhansus
                            select tk).ToList().Last().iduser;
                 themnhansu.iduser = dem + 1;
             }
             catch
             {
                 themnhansu.iduser = 1;
             }                 

             themnhansu.hoten = hoten;
             themnhansu.manv = manv;
             if (idkhoa != 0)
                 themnhansu.idkhoa = idkhoa;
             if (idphongban != 0)
                 themnhansu.idphongban = idphongban;

             themnhansu.nghenghiep = nghenghiep;
             themnhansu.chucvu = chucvu;
             themnhansu.email = email;
             themnhansu.sdt = sdt;
             themnhansu.acc = account;
             themnhansu.pw = "1";

             data.nhansus.InsertOnSubmit(themnhansu);
             data.SubmitChanges();
         }

         public void Capnhatnhansu(int iduser, string hoten, string manv, short idkhoa, short idphongban, string nghenghiep,
             string chucvu, string email, string sdt, string account)
         {
             nhansu themnhansu = (from tk in data.nhansus
                                  where tk.iduser == iduser
                                  select tk).Single();

             themnhansu.hoten = hoten;
             themnhansu.manv = manv;
             if (idkhoa != 0)
                 themnhansu.idkhoa = idkhoa;
             if (idphongban != 0)
                 themnhansu.idphongban = idphongban;
             themnhansu.nghenghiep = nghenghiep;
             themnhansu.chucvu = chucvu;
             themnhansu.email = email;
             themnhansu.sdt = sdt;
             themnhansu.acc = account;
             themnhansu.pw = "1";

             data.SubmitChanges();
         }

         public void Xoanhansu(int iduser)
         {
             try
             {
                 nhansu xoanhansu = (from tk in data.nhansus
                                     where tk.iduser == iduser
                                     select tk).Single();

                 data.nhansus.DeleteOnSubmit(xoanhansu);
                 data.SubmitChanges();
             }
             catch
             {

             }
         }

         public nhansu Laynhansu(int iduser)
         {
             nhansu ketqua = (from tk in data.nhansus
                                 where tk.iduser == iduser
                                 select tk).Single();
             return ketqua;
         }
         #endregion
         #region Chủ đề
         public List<bantin_chude> Loadchude()
         {
             List<bantin_chude> ketqua = (from tk in data.bantin_chudes
                                          select tk).ToList();
             return ketqua;
         }

         public void Themchude(string tenchude)
         {
             bantin_chude themchude = new bantin_chude();
             try
             {
                 int dem = (from tk in data.bantin_chudes
                        select tk).ToList().Last().idchude;
                 themchude.idchude = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themchude.idchude = 1;
             }
             themchude.tenchude = tenchude;

             data.bantin_chudes.InsertOnSubmit(themchude);
             data.SubmitChanges();
         }
         public void Xoachude(string tenchude)
         {
             try
             {
                 bantin_chude xoachude = (from tk in data.bantin_chudes
                                       where tk.tenchude == tenchude
                                       select tk).Single();

             data.bantin_chudes.DeleteOnSubmit(xoachude);
             data.SubmitChanges();
             }
             catch{}
         }

         public void Capnhatchude(string tenchudecu, string tenchudemoi)
         {
             try
             {
                 bantin_chude xoachude = (from tk in data.bantin_chudes
                                      where tk.tenchude == tenchudecu
                                      select tk).Single();
                 xoachude.tenchude = tenchudemoi;
                 data.SubmitChanges();
             }
             catch{}
         }
         #endregion
         #region Nhóm bản tin
         public void Themnhombantin(string tennhombantin, string mota, List<int> iduser)
         {
             bantin_nhom themnhombantin = new bantin_nhom();
             try
             {
                 int dem = (from tk in data.bantin_nhoms
                        select tk).ToList().Last().idnhombantin;
                 themnhombantin.idnhombantin = dem + 1;
             }
             catch
             {
                 themnhombantin.idnhombantin = 1;
             }
                 
             themnhombantin.tennhom = tennhombantin;
             themnhombantin.mota = mota;
             data.bantin_nhoms.InsertOnSubmit(themnhombantin);
             data.SubmitChanges();

             foreach (int item in iduser)
             {
                 bantin_kqnhom themkq = new bantin_kqnhom();
                 try
                 {
                     int dem2 = (from tk in data.bantin_kqnhoms
                                 select tk).ToList().Last().idkqnhom;
                     themkq.idkqnhom = dem2 + 1;
                 }
                 catch
                 {
                     themkq.idkqnhom = 1;
                 }
                 
                 themkq.idnhombantin = themnhombantin.idnhombantin;
                 themkq.iduser = item;
                 data.bantin_kqnhoms.InsertOnSubmit(themkq);
                 data.SubmitChanges();
             }
         }
         public void Xoanhombantin(int idnhom)
         {
             List<bantin_kqnhom> dskqxoa = (from tk in data.bantin_kqnhoms
                                            where tk.idnhombantin == idnhom
                                            select tk).ToList();
             data.bantin_kqnhoms.DeleteAllOnSubmit(dskqxoa);             

             bantin_nhom xoanhombantin = (from tk in data.bantin_nhoms
                                          where tk.idnhombantin == idnhom
                                          select tk).Single();
             data.bantin_nhoms.DeleteOnSubmit(xoanhombantin);

             data.SubmitChanges();
         }

         public void Capnhatnhombantin(int idnhom, string tenmoi, string motamoi, List<int> usermoi)
         {
             bantin_nhom capnhat = (from tk in data.bantin_nhoms
                                     where tk.idnhombantin == idnhom
                                     select tk).Single();
             capnhat.tennhom = tenmoi;
             capnhat.mota = motamoi;
             data.SubmitChanges();

             List<bantin_kqnhom> dskqxoa = (from tk in data.bantin_kqnhoms
                                            where tk.idnhombantin == idnhom
                                            select tk).ToList();
             data.bantin_kqnhoms.DeleteAllOnSubmit(dskqxoa);

             foreach (int item in usermoi)
             {
                 bantin_kqnhom themkq = new bantin_kqnhom();
                 try
                 {
                     int dem2 = (from tk in data.bantin_kqnhoms
                             select tk).ToList().Last().idkqnhom;
                     themkq.idkqnhom = dem2 + 1;
                 }
                 catch
                 {
                     themkq.idkqnhom = 1;
                 }
                 themkq.idnhombantin = idnhom;
                 themkq.iduser = item;
                 data.bantin_kqnhoms.InsertOnSubmit(themkq);
                 data.SubmitChanges();
             }
         }

         public List<nhansu> Laykqnhombantin(int idnhom)
         {
             List<nhansu> dsnhansu = (from tk in data.nhansus
                                      join cd in data.bantin_kqnhoms on tk.iduser equals cd.iduser
                                      where cd.idnhombantin == idnhom
                                      select tk).ToList();
             return dsnhansu;
         }

         public List<nhansu> Laykqbtconlai(List<nhansu> dsguitin)
         {
             List<nhansu> dsnhansu = (from tk in data.nhansus
                                      select tk).ToList();
             List<nhansu> conlai = dsnhansu.Except(dsguitin).ToList();
             return conlai;
         }
         #endregion
         #region Tên bệnh phẩm
         public List<tenbenhpham> Loadtenbenhpham()
         {
             List<tenbenhpham> ketqua = (from tk in data.tenbenhphams
                                  select tk).ToList();
             return ketqua;
         }

         public void Themtenbenhpham(string tentenbenhpham)
         {            
             tenbenhpham themtenbenhpham = new tenbenhpham();
             try
             {
                 int dem = (from tk in data.tenbenhphams
                        select tk).ToList().Last().idtenbenhpham;
                 themtenbenhpham.idtenbenhpham = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themtenbenhpham.idtenbenhpham = 1;
             }
                 
             themtenbenhpham.tenbp = tentenbenhpham;

             data.tenbenhphams.InsertOnSubmit(themtenbenhpham);
             data.SubmitChanges();
         }
         public void Xoatenbenhpham(string tentenbenhpham)
         {
             try
             {
                 tenbenhpham xoatenbenhpham = (from tk in data.tenbenhphams
                                           where tk.tenbp == tentenbenhpham
                                           select tk).Single();

             data.tenbenhphams.DeleteOnSubmit(xoatenbenhpham);
             data.SubmitChanges();
             }
             catch{}
         }

         public void Capnhattenbenhpham(string tentenbenhphamcu, string tentenbenhphammoi)
         {
             try
             {
                 tenbenhpham xoatenbenhpham = (from tk in data.tenbenhphams
                                           where tk.tenbp == tentenbenhphamcu
                                           select tk).Single();
             xoatenbenhpham.tenbp = tentenbenhphammoi;
             data.SubmitChanges();
             }
             catch{}
         }
         #endregion
         #region Nhóm dược lý
         public List<nhomduocly> Loadnhomdl()
         {
             List<nhomduocly> ketqua = (from tk in data.nhomduoclies
                                         select tk).ToList();
             return ketqua;
         }

         public void Themnhomduocly(string tennhomduocly)
         {
             nhomduocly themnhomduocly = new nhomduocly();
             try
             {
                 int dem = (from tk in data.nhomduoclies
                            select tk).ToList().Last().idnhomdl;
                 themnhomduocly.idnhomdl = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themnhomduocly.idnhomdl = 1;
             }
              
             themnhomduocly.ten = tennhomduocly;

             data.nhomduoclies.InsertOnSubmit(themnhomduocly);
             data.SubmitChanges();
         }
         public void Xoanhomduocly(string tennhomduocly)
         {
             nhomduocly xoanhomduocly = (from tk in data.nhomduoclies
                                         where tk.ten == tennhomduocly
                                           select tk).Single();

             data.nhomduoclies.DeleteOnSubmit(xoanhomduocly);
             data.SubmitChanges();
         }

         public void Capnhatnhomduocly(string tennhomduoclycu, string tennhomduoclymoi)
         {
             nhomduocly xoanhomduocly = (from tk in data.nhomduoclies
                                           where tk.ten == tennhomduoclycu
                                           select tk).Single();
             xoanhomduocly.ten = tennhomduoclymoi;
             data.SubmitChanges();
         }
         #endregion
         #region Hoạt chất gốc
         public List<hoatchatgoc> Loadhoatchatgoc()
         {
             List<hoatchatgoc> ketqua = (from tk in data.hoatchatgocs
                                  select tk).ToList();
             return ketqua;
         }

         public void Themhoatchatgoc(string tenhoatchatgoc)
         {
             hoatchatgoc themhoatchatgoc = new hoatchatgoc();
             try
             {
                 int dem = (from tk in data.hoatchatgocs
                            select tk).ToList().Last().idhcgoc;
                 themhoatchatgoc.idhcgoc = short.Parse((dem + 1).ToString());
             }
             catch 
             {
                 themhoatchatgoc.idhcgoc = 1;
             }                 
             themhoatchatgoc.ten = tenhoatchatgoc;

             data.hoatchatgocs.InsertOnSubmit(themhoatchatgoc);
             data.SubmitChanges();
         }
         public void Xoahoatchatgoc(string tenhoatchatgoc)
         {
             hoatchatgoc xoahoatchatgoc = (from tk in data.hoatchatgocs
                             where tk.ten == tenhoatchatgoc
                             select tk).Single();

             data.hoatchatgocs.DeleteOnSubmit(xoahoatchatgoc);
             data.SubmitChanges();
         }

         public void Capnhathoatchatgoc(string tenhoatchatgoccu, string tenhoatchatgocmoi)
         {
             hoatchatgoc xoahoatchatgoc = (from tk in data.hoatchatgocs
                             where tk.ten == tenhoatchatgoccu
                             select tk).Single();
             xoahoatchatgoc.ten = tenhoatchatgocmoi;
             data.SubmitChanges();
         }
         #endregion
         #region Hoạt chất
         public List<hoatchat> Loadhoatchat()
         {
             List<hoatchat> ketqua = (from tk in data.hoatchats
                                      select tk).ToList();
             return ketqua;
         }
         public bool Checkhoatchat(string mahoatchat, string tenhoatchat)
         {
             bool trave;
             try
             {
                 int dem = (from tk in data.hoatchats
                            where tk.mahc== mahoatchat
                            && tk.tenhc ==tenhoatchat
                            select tk).ToList().Last().idhc;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public List<kqhc> Layhoatchat(int idhc)
         {
             List<kqhc> ketqua = (from tk in data.kqhcs
                                  where tk.idhc == idhc
                                  select tk).ToList();
             return ketqua;
         }



         
         #endregion
         #region KSDB
         public List<khangsinhdacbiet> LoadKSDB()
         {
             List<khangsinhdacbiet> ketqua = (from tk in data.khangsinhdacbiets
                                              select tk).ToList();
             return ketqua;
         }

         public bool CheckKSDB(int idthuoc, string ghichu)
         {
             bool trave;
             try
             {
                 khangsinhdacbiet ketqua = (from tk in data.khangsinhdacbiets
                                            where tk.idthuoc == idthuoc
                                            && tk.ghichu == ghichu
                                            select tk).Single();
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public void Themksdb (int idthuoc, string ghichu)
         {
             khangsinhdacbiet themkhangsinhdacbiet = new khangsinhdacbiet();
             try
             {
                 int dem = (from tk in data.khangsinhdacbiets
                            select tk).ToList().Last().idksdb;
                 themkhangsinhdacbiet.idksdb = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themkhangsinhdacbiet.idksdb = 1;
             }

             themkhangsinhdacbiet.idthuoc = idthuoc;
             themkhangsinhdacbiet.ghichu = ghichu;
             data.khangsinhdacbiets.InsertOnSubmit(themkhangsinhdacbiet);
             data.SubmitChanges();
         }
         public void XoaKSDB(int idksdb)
         {
             khangsinhdacbiet xoaksdb = (from tk in data.khangsinhdacbiets
                                         where tk.idksdb == idksdb
                                         select tk).Single();

             data.khangsinhdacbiets.DeleteOnSubmit(xoaksdb);
             data.SubmitChanges();
         }

         public void Capnhatksdb(int idksdb, int idthuoc, string ghichu)
         {
             khangsinhdacbiet capnhatksdb = (from tk in data.khangsinhdacbiets
                                                     where tk.idksdb == idksdb
                                                     select tk).Single();
             capnhatksdb.idthuoc = idthuoc;
             capnhatksdb.ghichu = ghichu;
             data.SubmitChanges();
         }
         #endregion
         #region Nhóm KSDB
         
         public void CapnhatnhomKSDB(List<int> usermoi)
         {
             List<nhomKSDB2> dskqxoa = (from tk in data.nhomKSDB2s
                                        select tk).ToList();
             data.nhomKSDB2s.DeleteAllOnSubmit(dskqxoa);

             foreach (int item in usermoi)
             {
                 nhomKSDB2 themkq = new nhomKSDB2();
                 try
                 {
                     int dem2 = (from tk in data.nhomKSDB2s
                                 select tk).ToList().Last().id;
                     themkq.id = dem2 + 1;
                 }
                 catch
                 {
                     themkq.id = 1;
                 }
                 themkq.iduser = item;
                 themkq.trongnhom = true;
                 data.nhomKSDB2s.InsertOnSubmit(themkq);
                 data.SubmitChanges();
             }
         }

         public List<nhansu> LaykqnhomKSDB()
         {
             List<nhansu> dsnhansu = (from tk in data.nhansus
                                      join cd in data.nhomKSDB2s on tk.iduser equals cd.iduser
                                      where cd.trongnhom == true
                                      select tk).ToList();
             return dsnhansu;
         }

         public List<nhansu> LayKSDBconlai()
         {
             List<nhansu> dsnhansu = (from tk in data.nhansus
                                      select tk).ToList();
             List<nhansu> conlai = dsnhansu.Except(LaykqnhomKSDB()).ToList();
             return conlai;
         }
         #endregion
         #region Thuốc
         public List<thuoc> Loadthuoc()
         {
             List<thuoc> ketqua = (from tk in data.thuocs
                                   select tk).ToList();
             return ketqua;
         }

         public List<string> Laythuoc(int idhoatchat)
         {
             List<string> ketqua = (from tk in data.thuocs
                                   where tk.hoatchat.idhc == idhoatchat
                                   select tk.tenthuoc).ToList();
             return ketqua;
         }

         public bool Checkthuoc(string tenthuoc, short idnhasx, string dangbc)
         {
             bool trave;
             try
             {
                 thuoc ketqua = (from tk in data.thuocs
                                 where tk.tenthuoc == tenthuoc && tk.dangbc == dangbc && tk.idnhasx == idnhasx
                                 select tk).Single();
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public void Themthuoc(int idhc, string tenthuoc, short idnhasx, string dangbc, string duongdung, string dvt, string dungtich)
         {
             thuoc themthuoc = new thuoc();
             try
             {
                 int dem = (from tk in data.thuocs
                            select tk).ToList().Last().idthuoc;
                 themthuoc.idthuoc = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themthuoc.idthuoc = 1;
             }

             themthuoc.idhc = idhc;
             themthuoc.tenthuoc = tenthuoc;
             themthuoc.idnhasx = idnhasx;
             themthuoc.dangbc = dangbc;
             themthuoc.duongdung = duongdung;
             themthuoc.dungtich = dungtich;
             themthuoc.dvt = dvt;
             data.thuocs.InsertOnSubmit(themthuoc);
             data.SubmitChanges();
         }
         public void Xoathuoc(int idthuoc)
         {
             thuoc xoathuoc = (from tk in data.thuocs
                                         where tk.idthuoc == idthuoc
                                         select tk).Single();

             data.thuocs.DeleteOnSubmit(xoathuoc);
             data.SubmitChanges();
         }

         public void Capnhatthuoc(int idthuoc, int idhc, string tenthuoc, short idnhasx,
             string dangbc, string duongdung, string dvt,string dungtich)
         {
             thuoc capnhatthuoc = (from tk in data.thuocs
                                             where tk.idthuoc == idthuoc
                                             select tk).Single();
             capnhatthuoc.idhc = idhc;
             capnhatthuoc.tenthuoc = tenthuoc;
             capnhatthuoc.idnhasx = idnhasx;
             capnhatthuoc.dangbc = dangbc;
             capnhatthuoc.duongdung = duongdung;
             capnhatthuoc.dungtich = dungtich;
             capnhatthuoc.dvt = dvt;
             data.SubmitChanges();
         }
         #endregion
         #region Vi sinh vật
         public List<vikhuan> Loadvikhuan()
         {
             List<vikhuan> ketqua = (from tk in data.vikhuans
                                      select tk).ToList();
             return ketqua;
         }
         public bool Checkvikhuan(string tenvikhuan, string ghichu)
         {
             bool trave;
             try
             {
                 vikhuan ketqua = (from tk in data.vikhuans
                                   where tk.tenvk == tenvikhuan && tk.ghichu == ghichu
                                   select tk).Single();
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public void Themvikhuan(string tenvikhuan, string ghichu)
         {

             
             vikhuan themvikhuan = new vikhuan();
             try
             {
                 int dem = (from tk in data.vikhuans
                            select tk).ToList().Last().idvikhuan;
                 themvikhuan.idvikhuan = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themvikhuan.idvikhuan = 1;
             }

             themvikhuan.tenvk = tenvikhuan;
             themvikhuan.ghichu = ghichu;

             data.vikhuans.InsertOnSubmit(themvikhuan);
             data.SubmitChanges();
         }
         public void Xoavikhuan(int idvk)
         {
             vikhuan xoavikhuan = (from tk in data.vikhuans
                                     where tk.idvikhuan == idvk
                                     select tk).Single();

             data.vikhuans.DeleteOnSubmit(xoavikhuan);
             data.SubmitChanges();
         }

         public void Capnhatvikhuan(int idvk, string tenvikhuan, string ghichu)
         {
             vikhuan capnhat = (from tk in data.vikhuans
                                 where tk.idvikhuan == idvk
                                 select tk).Single();
             capnhat.tenvk = tenvikhuan;
             capnhat.ghichu = ghichu;
             data.SubmitChanges();
         }
         #endregion
         #region Xét nghiệm
         #region Tên XN
         public List<xetnghiem> Loadtenxetnghiem()
         {
             List<xetnghiem> ketqua = (from tk in data.xetnghiems
                                  select tk).ToList();
             return ketqua;
         }

         public void Themtenxetnghiem(string tenxetnghiem)
         {

             xetnghiem themxetnghiem = new xetnghiem();
             try
             {
                 int dem = (from tk in data.xetnghiems
                            select tk).ToList().Last().idxn;
                 themxetnghiem.idxn = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.idxn = 1;
             }

             themxetnghiem.tenxn = tenxetnghiem;

             data.xetnghiems.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }
         public void Xoatenxetnghiem(string tenxetnghiem)
         {
             try
             {
                 xetnghiem xoaxetnghiem = (from tk in data.xetnghiems
                                 where tk.tenxn == tenxetnghiem
                                 select tk).Single();

                 data.xetnghiems.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
             }
             catch { }
         }

         public void Capnhattenxetnghiem(string tenxetnghiemcu, string tenxetnghiemmoi)
         {
             try
             {
                 xetnghiem xoaxetnghiem = (from tk in data.xetnghiems
                                 where tk.tenxn == tenxetnghiemcu
                                 select tk).Single();
                 xoaxetnghiem.tenxn = tenxetnghiemmoi;
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #region Tên TS
         public List<xetnghiem_thongso> Loadtents()
         {
             List<xetnghiem_thongso> ketqua = (from tk in data.xetnghiem_thongsos
                                       select tk).ToList();
             return ketqua;
         }

         public void Themtents(string tents)
         {

             xetnghiem_thongso themxetnghiem = new xetnghiem_thongso();
             try
             {
                 int dem = (from tk in data.xetnghiem_thongsos
                            select tk).ToList().Last().idthongso;
                 themxetnghiem.idthongso = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.idthongso = 1;
             }

             themxetnghiem.thongso = tents;

             data.xetnghiem_thongsos.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }
         public void Xoatents(string tents)
         {
             try
             {
                 xetnghiem_thongso xoaxetnghiem = (from tk in data.xetnghiem_thongsos
                                                   where tk.thongso == tents
                                                   select tk).Single();

                 data.xetnghiem_thongsos.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
             }
             catch { }
         }

         public void Capnhattents(string tenxetnghiemcu, string tenxetnghiemmoi)
         {
             try
             {
                 xetnghiem_thongso xoaxetnghiem = (from tk in data.xetnghiem_thongsos
                                                   where tk.thongso == tenxetnghiemcu
                                                   select tk).Single();
                 xoaxetnghiem.thongso = tenxetnghiemmoi;
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #region Load
         public List<xetnghiem_kq_thongso> Loadxetnghiem()
         {
             List<xetnghiem_kq_thongso> ketqua = (from tk in data.xetnghiem_kq_thongsos
                                                  select tk).ToList();
             return ketqua;
         }
         public int Layidkqts(string tenxn, string thongso, benhan ttbenhan)
         {
             int ketqua=0;
             short tuoi = short.Parse((DateTime.Now.Year - ttbenhan.ngaysinh.Year).ToString());
             try
             {
                 ketqua = (from tk in data.xetnghiem_kq_thongsos
                           join db in data.xetnghiem_thongsos on tk.idthongso equals db.idthongso
                           join xy in data.xetnghiems on tk.idxn equals xy.idxn
                           where xy.tenxn == tenxn
                           && db.thongso == thongso
                           && tk.gioitinh == ttbenhan.gioitinh
                           && tk.tuoitren > tuoi
                       && tk.tuoiduoi <= tuoi
                           select tk).ToList().Last().idkqts;
             }
             catch
             {
             }
             return ketqua;
         }

         public string Laykbtxetnghiem(int idxn, int idts, benhan inputbn)
         {
             short tuoi = short.Parse((DateTime.Now.Year - inputbn.ngaysinh.Year).ToString());
             List<xetnghiem_kq_thongso> ketqua = (from tk in data.xetnghiem_kq_thongsos
                                                  where tk.idxn == idxn
                                                  && tk.idthongso == idts
                                                  && tk.gioitinh == inputbn.gioitinh
                                                  select tk).ToList();
             xetnghiem_kq_thongso ketqua2 = ketqua.Single(x => x.tuoitren > tuoi && x.tuoiduoi <= tuoi);
             string trave = string.Format("{0:0.00}", ketqua2.btduoi) + " - " +
                 string.Format("{0:0.00}", ketqua2.bttren) + " " + ketqua2.donvi;
             return trave;
         }
         
         public List<xetnghiem_thongso> Layts(int idxn)
         {
             List<xetnghiem_thongso> ketqua = (from tk in data.xetnghiem_thongsos
                                               join dy in data.xetnghiem_kq_thongsos on tk.idthongso equals dy.idthongso
                                               where dy.idxn == idxn
                                               select tk).ToList();
             return ketqua;
         }
         
         public bool Checkxetnghiem(string tenxn, string thongso, bool gioitinh,short tuoitren)
         {
             bool trave;
             try
             {
                 int ketqua = (from tk in data.xetnghiem_kq_thongsos
                               where tk.xetnghiem.tenxn == tenxn
                               && tk.xetnghiem_thongso.thongso == thongso
                               && tk.gioitinh == gioitinh
                               && tk.tuoitren == tuoitren
                               select tk).Last().idkqts;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public void Themxetnghiem(string tenxn, string thongso, bool gioitinh, short tuoitren, short tuoiduoi,
             float bttren, float btduoi, string donvi)
         {
             short idxnsd = Loadtenxetnghiem().Single(x => x.tenxn == tenxn).idxn;
             short idtssd = Loadtents().Single(x => x.thongso == thongso).idthongso;

             xetnghiem_kq_thongso themkqts = new xetnghiem_kq_thongso();
             try
             {
                 int dem = (from tk in data.xetnghiem_kq_thongsos
                            select tk).ToList().Last().idkqts;
                 themkqts.idkqts = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themkqts.idkqts = 1;
             }
             themkqts.idxn = idxnsd;
             themkqts.idthongso = idtssd;
             themkqts.gioitinh = gioitinh;
             themkqts.tuoitren = tuoitren;
             themkqts.tuoiduoi = tuoiduoi;
             themkqts.bttren = bttren;
             themkqts.btduoi = btduoi;
             themkqts.donvi = donvi;

             data.xetnghiem_kq_thongsos.InsertOnSubmit(themkqts);
             data.SubmitChanges();


         }
         public void Xoakqtsxn(int idkq)
         {
             xetnghiem_kq_thongso xoaxetnghiem = (from tk in data.xetnghiem_kq_thongsos
                                                  where tk.idkqts == idkq
                                                  select tk).Single();

             data.xetnghiem_kq_thongsos.DeleteOnSubmit(xoaxetnghiem);
             data.SubmitChanges();
         }

         public void Capnhatxetnghiem(int idkq, string tenxn, string thongso, bool gioitinh, short tuoitren, short tuoiduoi,
             float bttren, float btduoi, string donvi)
         {
             short idxnsd = Loadtenxetnghiem().Single(x => x.tenxn == tenxn).idxn;
             short idtssd = Loadtents().Single(x => x.thongso == thongso).idthongso;

             xetnghiem_kq_thongso themxetnghiem = (from tk in data.xetnghiem_kq_thongsos
                                                   where tk.idkqts == idkq
                                                   select tk).Single();
             themxetnghiem.idxn = idxnsd;
             themxetnghiem.idthongso = idtssd;
             themxetnghiem.gioitinh = gioitinh;
             themxetnghiem.tuoitren = tuoitren;
             themxetnghiem.tuoiduoi = tuoiduoi;
             themxetnghiem.bttren = bttren;
             themxetnghiem.btduoi = btduoi;
             themxetnghiem.donvi = donvi;
             data.SubmitChanges();
         }
         #endregion
         #region Ketquaxncn
         public List<kqxetnghiem> Laykqxetnghiem(int idbn)
         {
             List<kqxetnghiem> ketqua = (from tk in data.kqxetnghiems
                                   where tk.idbenhan == idbn
                                   select tk).ToList();
             return ketqua;
         }
         public bool Checkkqxetnghiem(int idbn, int idkqts)
         {
             bool trave;
             try
             {
                 int ketqua = (from tk in data.kqxetnghiems
                               where tk.idbenhan == idbn && tk.idkqts == idkqts
                               select tk).Single().id;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }
         public void Themkqxetnghiem(int idbn, int idkqts, int kq, DateTime ngayxn)
         {

             kqxetnghiem themxetnghiem = new kqxetnghiem();
             try
             {
                 int dem = (from tk in data.kqxetnghiems
                            select tk).ToList().Last().id;
                 themxetnghiem.id = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.id = 1;
             }

             themxetnghiem.idbenhan = idbn;
             themxetnghiem.idkqts = idkqts;
             themxetnghiem.kq = kq;
             themxetnghiem.ngayxn = ngayxn;

             data.kqxetnghiems.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }
         public void Xoakqxetnghiem(int id)
         {
             try
             {
                 kqxetnghiem xoaxetnghiem = (from tk in data.kqxetnghiems
                                             where tk.id == id
                                             select tk).Single();

                 data.kqxetnghiems.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
             }
             catch { }
         }

         public void Capnhatkqxetnghiem(int id, int kq, DateTime ngayxn)
         {
             try
             {
                 kqxetnghiem xoaxetnghiem = (from tk in data.kqxetnghiems
                                             where tk.id == id
                                             select tk).Single();
                 xoaxetnghiem.kq = kq;
                 xoaxetnghiem.ngayxn = ngayxn;
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #region SH
         public List<sinhhieu> LoadSH(int idbn)
         {
             List<sinhhieu> ketqua = (from tk in data.sinhhieus
                                         where tk.idbenhan == idbn
                                         select tk).ToList();
             return ketqua;
         }
         public bool Checksinhhieu(int idbn, DateTime ngaydo)
         {
             bool trave;
             try
             {
                 int ketqua = (from tk in data.sinhhieus
                               where tk.idbenhan == idbn && tk.ngaydo == ngaydo
                               select tk).Single().idsinhhieu;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }
         public void Themsinhhieu(int idbn, DateTime ngaydo,string ha,byte mach,byte tho,byte spo,double thannhiet,
             string ls)
         {

             sinhhieu themxetnghiem = new sinhhieu();
             try
             {
                 int dem = (from tk in data.sinhhieus
                            select tk).ToList().Last().idsinhhieu;
                 themxetnghiem.idsinhhieu = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.idsinhhieu = 1;
             }

             themxetnghiem.idbenhan = idbn;
             themxetnghiem.ngaydo = ngaydo;
             themxetnghiem.huyetap = ha;
             if (mach > 0)
                 themxetnghiem.mach = mach;
             if (thannhiet > 0)
                 themxetnghiem.thannhiet = thannhiet;
             if (tho > 0)
                 themxetnghiem.nhiptho = tho;
             if (spo > 0)
                 themxetnghiem.spo2 = spo;
             themxetnghiem.lamsang = ls;

             data.sinhhieus.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }
         public void Xoasinhhieu(int id)
         {
             try
             {
                 sinhhieu xoaxetnghiem = (from tk in data.sinhhieus
                                             where tk.idsinhhieu == id
                                             select tk).Single();

                 data.sinhhieus.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
             }
             catch { }
         }

         public void Capnhatsinhhieu(int id, string ha, byte mach, byte tho, byte spo, double thannhiet,
             string ls)
         {
             try
             {
                 sinhhieu themxetnghiem = (from tk in data.sinhhieus
                                             where tk.idsinhhieu == id
                                             select tk).Single();

                 themxetnghiem.huyetap = ha;
                 if (mach > 0)
                     themxetnghiem.mach = mach;
                 if (thannhiet > 0)
                     themxetnghiem.thannhiet = thannhiet;
                 if (tho > 0)
                     themxetnghiem.nhiptho = tho;
                 if (spo > 0)
                     themxetnghiem.spo2 = spo;
                 themxetnghiem.lamsang = ls;
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #region XNVS
         public List<benhpham> LoadXNVS(int idbn)
         {
             List<benhpham> ketqua = (from tk in data.benhphams
                                      where tk.idbenhan == idbn
                                      select tk).ToList();
             return ketqua;
         }

         public List<xetnghiemv> LoadVSV(int idbp)
         {
             List<xetnghiemv> ketqua = (from tk in data.xetnghiemvs
                                        where tk.idbenhpham == idbp
                                        select tk).ToList();
             return ketqua;
         }
         public bool Checkxetnghiemvs(int idbn, int idtenbp, DateTime ngaydo)
         {
             bool trave;
             try
             {
                 int ketqua = (from tk in data.benhphams
                               where tk.idbenhan == idbn && tk.idtenbenhpham == idtenbp
                               && tk.ngaytra == ngaydo
                               select tk).Single().idbenhpham;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public bool Checkvsv(int idbp, short idvk)
         {
             bool trave;
             try
             {
                 int ketqua = (from tk in data.xetnghiemvs
                               where tk.idbenhpham == idbp && tk.idvikhuan == idvk
                               select tk).Single().idxnvs;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }
         public void Themxetnghiemvs(int idbn, short idtenbp, DateTime ngaydo, int kq, string dv)
         {
             benhpham themxetnghiem = new benhpham();
             try
             {
                 int dem = (from tk in data.benhphams
                            select tk).ToList().Last().idbenhpham;
                 themxetnghiem.idbenhpham = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.idbenhpham = 1;
             }

             themxetnghiem.idbenhan = idbn;
             themxetnghiem.idtenbenhpham = idtenbp;
             themxetnghiem.ngaytra = ngaydo;
             themxetnghiem.ketqua = kq;
             themxetnghiem.donvi = dv;

             data.benhphams.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }

         public void Themvsv(int idbp, short idvk, string tietmen)
         {
             xetnghiemv themxetnghiem = new xetnghiemv();
             try
             {
                 int dem = (from tk in data.xetnghiemvs
                            select tk).ToList().Last().idxnvs;
                 themxetnghiem.idxnvs = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.idxnvs = 1;
             }

             themxetnghiem.idbenhpham = idbp;
             themxetnghiem.idvikhuan = idvk;
             themxetnghiem.tietmen = tietmen;

             data.xetnghiemvs.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }
         public void Xoaxetnghiemvs(int id)
         {
                 benhpham xoaxetnghiem = (from tk in data.benhphams
                                          where tk.idbenhpham == id
                                          select tk).Single();

                 data.benhphams.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
         }

         public void Xoavsv(int id)
         {
                 xetnghiemv xoaxetnghiem = (from tk in data.xetnghiemvs
                                            where tk.idvikhuan == id
                                            select tk).Single();

                 data.xetnghiemvs.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
         }

         public void Capnhatxetnghiemvs(int id, int idbn, short idtenbp, DateTime ngaydo, int kq, string dv)
         {
             try
             {
                 benhpham themxetnghiem = (from tk in data.benhphams
                                           where tk.idbenhpham == id
                                           select tk).Single();


                 themxetnghiem.idbenhan = idbn;
                 themxetnghiem.idtenbenhpham = idtenbp;
                 themxetnghiem.ngaytra = ngaydo;
                 themxetnghiem.ketqua = kq;
                 themxetnghiem.donvi = dv;
                 data.SubmitChanges();
             }
             catch { }
         }

         public void Capnhatvsv(int id, int idbp, short idvk, string tietmen)
         {
             try
             {
                 xetnghiemv themxetnghiem = (from tk in data.xetnghiemvs
                                           where tk.idbenhpham == id
                                           select tk).Single();


                 themxetnghiem.idbenhpham = idbp;
                 themxetnghiem.idvikhuan = idvk;
                 themxetnghiem.tietmen = tietmen;
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #region KSD
         public List<khangsinhdo> LoadKSD(int idbn)
         {
             List<khangsinhdo> ketqua = (from tk in data.khangsinhdos
                                         where tk.idbn == idbn
                                         select tk).ToList();
             return ketqua;
         }
         public bool Checkkhangsinhdo(int idbn, short idvk, int idhc, string nongdo)
         {
             bool trave;
             try
             {
                 int ketqua = (from tk in data.khangsinhdos
                               where tk.idbn == idbn
                               && tk.idhc == idhc
                               && tk.idvk == idvk
                               && tk.nongdo == nongdo
                               select tk).Single().idksdo;
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }
         public void Themkhangsinhdo(int idbn, short idvk, int idhc, string nongdo, char kq)
         {
             khangsinhdo themxetnghiem = new khangsinhdo();
             try
             {
                 int dem = (from tk in data.khangsinhdos
                            select tk).ToList().Last().idksdo;
                 themxetnghiem.idksdo = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themxetnghiem.idksdo = 1;
             }

             themxetnghiem.idbn = idbn;
             themxetnghiem.idhc = idhc;
             themxetnghiem.idvk = idvk;
             themxetnghiem.nongdo = nongdo;
             themxetnghiem.ketqua = kq;
             data.khangsinhdos.InsertOnSubmit(themxetnghiem);
             data.SubmitChanges();
         }
         public void Xoakhangsinhdo(int id)
         {
             try
             {
                 khangsinhdo xoaxetnghiem = (from tk in data.khangsinhdos
                                             where tk.idksdo == id
                                             select tk).Single();

                 data.khangsinhdos.DeleteOnSubmit(xoaxetnghiem);
                 data.SubmitChanges();
             }
             catch { }
         }
         #endregion
         #endregion
         #region Nhà SX
         public List<nhasx> Loadnhasx()
         {
             List<nhasx> ketqua = (from tk in data.nhasxes
                                  select tk).ToList();
             return ketqua;
         }
         public List<string> Laynuocsx(string ten)
         {
             List<string> ketqua = (from tk in data.nhasxes
                                   where tk.tennsx == ten
                                   select tk.nuocsx).ToList();
             return ketqua;
         }

         public void Themnhasx(string tennhasx, string nuocsx)
         {
             
             nhasx themnhasx = new nhasx();
             try
             {
                 int dem = (from tk in data.nhasxes
                            select tk).ToList().Last().id;
                 themnhasx.id = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themnhasx.id = 1;
             }
             
             themnhasx.tennsx = tennhasx;
             themnhasx.nuocsx = nuocsx;

             data.nhasxes.InsertOnSubmit(themnhasx);
             data.SubmitChanges();
         }
         public void Xoanhasx(int idnhasx)
         {
             nhasx xoanhasx = (from tk in data.nhasxes
                               where tk.id == idnhasx
                               select tk).Single();

             data.nhasxes.DeleteOnSubmit(xoanhasx);
             data.SubmitChanges();
         }

         public void Capnhatnhasx(int idnhasx, string tennhasx, string nuocsx)
         {
             nhasx xoanhasx = (from tk in data.nhasxes
                               where tk.id == idnhasx
                               select tk).Single();
             xoanhasx.tennsx = tennhasx;
             xoanhasx.nuocsx = nuocsx;
             data.SubmitChanges();
         }
         #endregion
        #endregion
        #region Nhập dữ liệu
         #region Bệnh án
         public List<benhan> LoadBa()
         {
             List<benhan> ketqua = (from tk in data.benhans
                                    select tk).ToList();
             return ketqua;
         }

         public bool CheckBa(string maBa)
         {
             bool trave;
             try
             {
                 benhan ketqua = (from tk in data.benhans
                                 where tk.mabenhan == maBa
                                 select tk).Single();
                 trave = true;
             }
             catch
             {
                 trave = false;
             }
             return trave;
         }

         public void TamluuBa(string ma, short idkhoa, string ten, DateTime ngaysinh, bool gioi, int cao,
             float cannang, DateTime nhapvien, string lydo, string chandoannv, string info)
         {
             benhan themthuoc = new benhan();
             try
             {
                 int dem = (from tk in data.benhans
                            select tk).ToList().Last().idbenhan;
                 themthuoc.idbenhan = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 themthuoc.idbenhan = 1;
             }

             themthuoc.mabenhan = ma;
             themthuoc.idkhoa = idkhoa;
             themthuoc.tenbn = ten;
             themthuoc.ngaysinh = ngaysinh;
             themthuoc.gioitinh = gioi;
             themthuoc.chieucao = cao;
             themthuoc.cannang = cannang;
             themthuoc.ngaynhapvien = nhapvien;
             themthuoc.lydonhapvien = lydo;
             themthuoc.chandoannhapvien = chandoannv;
             themthuoc.thongtinthem = info;
             data.benhans.InsertOnSubmit(themthuoc);
             data.SubmitChanges();
         }

         public void RavienBa(string ma, string chandoanrv, DateTime ravien, string kqdt)
         {
             benhan capnhatbenhan = (from tk in data.benhans
                                     where tk.mabenhan == ma
                                     select tk).Single();

             capnhatbenhan.mabenhan = ma;
             capnhatbenhan.chandoanravien = chandoanrv;
             capnhatbenhan.ngayravien = ravien;
             capnhatbenhan.ketquadieutri = kqdt;
             data.SubmitChanges();
         }
         public void Xoabenhan(string ma)
         {
             benhan xoabenhan = (from tk in data.benhans
                                 where tk.mabenhan == ma
                                 select tk).Single();

             data.benhans.DeleteOnSubmit(xoabenhan);
             data.SubmitChanges();
         }

         public void Capnhatbenhan(string ma, short idkhoa, string ten, DateTime ngaysinh, bool gioi, int cao,
             float cannang, DateTime nhapvien, string lydo, string chandoannv, string info)
         {
             benhan capnhatbenhan = (from tk in data.benhans
                                     where tk.mabenhan == ma
                                   select tk).Single();
             capnhatbenhan.tenbn = ten;
             capnhatbenhan.idkhoa = idkhoa;
             capnhatbenhan.ngaysinh = ngaysinh;
             capnhatbenhan.gioitinh = gioi;
             capnhatbenhan.chieucao = cao;
             capnhatbenhan.cannang = cannang;
             capnhatbenhan.ngaynhapvien = nhapvien;
             capnhatbenhan.lydonhapvien = lydo;
             capnhatbenhan.chandoannhapvien = chandoannv;
             capnhatbenhan.thongtinthem = info;
             data.SubmitChanges();
         }
         #endregion
         #region Xét nghiệm
         public List<hoatchat> LoadKS()
         {
             List<hoatchat> ketqua = (from tk in data.hoatchats
                                      where tk.idnhomdl == 1
                                      select tk).ToList();
             return ketqua;
         }
         #endregion
        #endregion
         #region Phiếu KSDB
         #region Nhập phiếu
         public List<phieuksdb> Loadphieuchuaduyet()
         {
             List<phieuksdb> ketqua = (from tk in data.phieuksdbs
                                       where tk.tinhtrang != 'H' && tk.tinhtrang != 'D'
                                       select tk).ToList();
             return ketqua;
         }

         public List<phieuksdb> Loadphieuuserchuaduyet(int iduser)
         {
             List<phieuksdb> ketqua = (from tk in data.phieuksdbs
                                       join db in data.phieuksdb_guis on tk.idphieu equals db.idphieu
                                       where tk.tinhtrang != 'H' && tk.tinhtrang != 'D'
                                       && db.iduser == iduser && db.daduyet == false
                                       select tk).ToList();
             return ketqua;
         }
         public List<phieuksdb> Loadphieuuserdaduyet(int iduser)
         {
             List<phieuksdb> ketqua = (from tk in data.phieuksdbs
                                       join db in data.phieuksdb_guis on tk.idphieu equals db.idphieu
                                       where tk.tinhtrang != 'H' && tk.tinhtrang != 'D'
                                       && db.iduser == iduser && db.daduyet == true
                                       select tk).ToList();
             return ketqua;
         }
         public int Layidphieu()
         {
             int ketqua;
             try
             {
                 ketqua = (from tk in data.phieuksdbs
                           select tk).ToList().Last().idphieu + 1;
             }
             catch
             {
                 ketqua = 1;
             }
             return ketqua;
         }
         public void Guiphieu(int idphieu, int idbn, string trchungls, string chidinh, short idksdb, short slg, string lieusd,
             string duongsd, string donvi, string tansuat, short songaysd, string tocdotr, string ghichu, DateTime tg, int iduser)
         {
             phieuksdb themphieu = new phieuksdb();
             themphieu.idphieu = idphieu;
             themphieu.idbenhnhan = idbn;
             themphieu.trchlamsang = trchungls;
             themphieu.chidinh = chidinh;
             themphieu.idksdb = idksdb;
             themphieu.solg = slg;
             themphieu.lieusd = lieusd;
             themphieu.duongsd = duongsd;
             themphieu.donvitinh = donvi;
             themphieu.tansuat = tansuat;
             themphieu.songaydung = songaysd;
             themphieu.tocdotruyen = tocdotr;
             themphieu.ghichu = ghichu;
             themphieu.khoals = 'C';
             themphieu.khoaduoc = 'C';
             themphieu.bsdieutri = 'D';
             themphieu.tinhtrang = 'C';
             themphieu.thoigian = tg;
             data.phieuksdbs.InsertOnSubmit(themphieu);
             data.SubmitChanges();

             phieuksdb_ykien ykien = new phieuksdb_ykien();
             try
             {
                 int dem = (from tk in data.phieuksdb_ykiens
                            select tk).ToList().Last().idykienksdb;
                 ykien.idykienksdb = short.Parse((dem + 1).ToString());
             }
             catch
             {
                 ykien.idykienksdb = 1;
             }
             ykien.idphieu = idphieu;
             ykien.iduser = iduser;
             ykien.ngaygio = tg;
             ykien.ndykien = "Đã duyệt";
             data.phieuksdb_ykiens.InsertOnSubmit(ykien);
             data.SubmitChanges();

             
             foreach (nhansu item in LaykqnhomKSDB())
             {
                 phieuksdb_gui guiphieu = new phieuksdb_gui();
                 try
                 {
                     int dem = (from tk in data.phieuksdb_guis
                                select tk).ToList().Last().id;
                     guiphieu.id = int.Parse((dem + 1).ToString());
                 }
                 catch
                 {
                     guiphieu.id = 1;
                 }
                 guiphieu.idphieu = idphieu;
                 guiphieu.iduser = item.iduser;
                 guiphieu.daduyet = false;
                 data.phieuksdb_guis.InsertOnSubmit(guiphieu);
                 data.SubmitChanges();
             }
         }
         public bool checkdaduyet(int idphieu, int iduser)
         {
             phieuksdb_gui capnhatphieu = (from tk in data.phieuksdb_guis
                                       where tk.idphieu == idphieu && tk.iduser == iduser
                                       select tk).Single();
             if (capnhatphieu.daduyet == true)
                 return true;
             else
                 return false;
         }
         public void checkNhomdaduyet(int idphieu)
         {
             List<phieuksdb_gui> capnhatphieu = (from tk in data.phieuksdb_guis
                                           where tk.idphieu == idphieu
                                           select tk).ToList();
             int dem = capnhatphieu.Count;
             int duyet = 0;
             foreach (phieuksdb_gui item in capnhatphieu)
             {
                 if (item.daduyet == true)
                     duyet = duyet + 1;
             }

             phieuksdb phieu = (from tk in data.phieuksdbs
                                where tk.idphieu == idphieu
                                select tk).Single();
             if (duyet == dem)
                 phieu.khoals = 'D';
         }

         public void Duyetphieu(int idphieu, int iduser, string khoa, DateTime tgduyet)
         {
             //check khoa Dược
             phieuksdb capnhatphieu = (from tk in data.phieuksdbs
                                        where tk.idphieu == idphieu
                                        select tk).Single();
             if (khoa == "Khoa Dược")
             {
                 capnhatphieu.khoaduoc = 'D';
                 data.SubmitChanges();
             }
             //nhóm KSDB
             phieuksdb_gui duyetkq = (from tk in data.phieuksdb_guis
                                      where tk.idphieu == idphieu && tk.iduser == iduser
                                      select tk).Single();
             duyetkq.daduyet = true;
             data.SubmitChanges();
             //Check nhóm duyệt hết chưa
             checkNhomdaduyet(idphieu);
             //Thêm ý kiến
             phieuksdb_ykien ykien = new phieuksdb_ykien();
             try
             {
                 int dem = (from tk in data.phieuksdb_ykiens
                            select tk).ToList().Last().idykienksdb;
                 ykien.idykienksdb = int.Parse((dem + 1).ToString());
             }
             catch
             {
                 ykien.idykienksdb = 1;
             }
             ykien.idphieu = idphieu;
             ykien.iduser = iduser;
             ykien.ngaygio = tgduyet;
             ykien.ndykien = "Đã duyệt";
             data.phieuksdb_ykiens.InsertOnSubmit(ykien);
             data.SubmitChanges();
             Checkphieu(idphieu);
         }

         public void Themykienphieu(int idphieu, int iduser, string khoa, DateTime tgyk, string ndykien)
         {
             phieuksdb capnhatphieu = (from tk in data.phieuksdbs
                                       where tk.idphieu == idphieu
                                       select tk).Single();

             if (khoa == "Khoa Dược")
                 capnhatphieu.khoaduoc = 'Y';// CÓ  ý kiến
             else
                 capnhatphieu.khoals = 'Y';
             capnhatphieu.bsdieutri = 'C';//Chưa duyệt
             data.SubmitChanges();

             phieuksdb_ykien ykien = new phieuksdb_ykien();
             try
             {
                 int dem = (from tk in data.phieuksdb_ykiens
                            select tk).ToList().Last().idykienksdb;
                 ykien.idykienksdb = int.Parse((dem + 1).ToString());
             }
             catch
             {
                 ykien.idykienksdb = 1;
             }
             ykien.idphieu = idphieu;
             ykien.iduser = iduser;
             ykien.ngaygio = tgyk;
             ykien.ndykien = ndykien;
             data.phieuksdb_ykiens.InsertOnSubmit(ykien);
             data.SubmitChanges();
         }
         public void Suaphieu(int idphieu, int idbn, string trchungls, string chidinh, short idksdb, short slg, string lieusd,
             string duongsd, string donvi, string tansuat, short songaysd, string tocdotr, string ghichu, string _thaydoi, DateTime tgdoi, int iduser)
         {
             phieuksdb themphieu = (from tk in data.phieuksdbs
                                    where tk.idphieu == idphieu
                                    select tk).Single();

             themphieu.idbenhnhan = idbn;
             themphieu.trchlamsang = trchungls;
             themphieu.chidinh = chidinh;
             themphieu.idksdb = idksdb;
             themphieu.solg = slg;
             themphieu.lieusd = lieusd;
             themphieu.duongsd = duongsd;
             themphieu.donvitinh = donvi;
             themphieu.tansuat = tansuat;
             themphieu.songaydung = songaysd;
             themphieu.tocdotruyen = tocdotr;
             themphieu.ghichu = ghichu;
             themphieu.khoals = 'C';
             themphieu.khoaduoc = 'C';
             themphieu.bsdieutri = 'S';//đã sửa
             themphieu.tinhtrang = 'C';
             data.SubmitChanges();

             phieuksdb_thaydoi thaydoi = new phieuksdb_thaydoi();
             try
             {
                 int dem = (from tk in data.phieuksdb_thaydois
                            select tk).ToList().Last().idthaydoi;
                 thaydoi.idthaydoi = int.Parse((dem + 1).ToString());
             }
             catch
             {
                 thaydoi.idthaydoi = 1;
             }
             thaydoi.idphieu = idphieu;
             thaydoi.noidung = _thaydoi;
             thaydoi.thoigian = tgdoi;
             data.phieuksdb_thaydois.InsertOnSubmit(thaydoi);
             data.SubmitChanges();

             phieuksdb_ykien ykien = new phieuksdb_ykien();
             try
             {
                 int dem = (from tk in data.phieuksdb_ykiens
                            select tk).ToList().Last().idykienksdb;
                 ykien.idykienksdb = int.Parse((dem + 1).ToString());
             }
             catch
             {
                 ykien.idykienksdb = 1;
             }
             ykien.idphieu = idphieu;
             ykien.iduser = iduser;
             ykien.ngaygio = tgdoi;
             ykien.ndykien = "Đã sửa";
             data.phieuksdb_ykiens.InsertOnSubmit(ykien);
             data.SubmitChanges();
             Checkphieu(idphieu);
         }

         public void Checkphieu(int idphieu)
         {
             phieuksdb themphieu = (from tk in data.phieuksdbs
                                    where tk.idphieu == idphieu
                                    select tk).Single();

             if (themphieu.khoals == 'D' && themphieu.khoaduoc == 'D' && themphieu.bsdieutri == 'D')
                 themphieu.tinhtrang = 'D';
             data.SubmitChanges();
         }

         public void Huyphieu(int idphieu)
         {
             phieuksdb huyphieu = (from tk in data.phieuksdbs
                                    where tk.idphieu == idphieu
                                    select tk).Single();

             huyphieu.tinhtrang = 'H';
             huyphieu.ketqua = 'H';
             data.SubmitChanges();
         }

         public void Ketquaphieu(int idphieu, char ketqua)
         {
             phieuksdb kqphieu = (from tk in data.phieuksdbs
                                    where tk.idphieu == idphieu
                                    select tk).Single();

             kqphieu.tinhtrang = 'D';
             kqphieu.ketqua = ketqua;
             data.SubmitChanges();
         }

         public List<phieuksdb_ykien> Loadykien(int idphieu)
         {
             List<phieuksdb_ykien> phieu = (from tk in data.phieuksdb_ykiens
                                            where tk.idphieu == idphieu
                                            select tk).ToList();
             return phieu;
         }

         public List<phieuksdb_thaydoi> Laythaydoi(int idphieu)
         {
             List<phieuksdb_thaydoi> phieu = (from tk in data.phieuksdb_thaydois
                                            where tk.idphieu == idphieu
                                            select tk).ToList();
             return phieu;
         }
         #endregion
         #endregion
         #region Bản tin
         public bantin Laybantin(int idbantin)
         {
             bantin bantin = (from bt in data.bantins
                              where bt.idbantin == idbantin
                              select bt).Single();
             
             return bantin;
         }

         public bantin_gui Checkbantin(int iduser, int idbantin)
         {
             bantin_gui bantin = (from bt in data.bantins
                              join db in data.bantin_guis on bt.idbantin equals db.idbantin
                              where bt.idbantin == idbantin && db.iduser == iduser
                                  select db).Single();

             return bantin;
         }

         public bantin_filedata Layfilebantin(int idbantin, char loaibantin)
         {
             bantin_filedata bantin = (from bt in data.bantin_filedatas
                                       where bt.idbantin == idbantin
                                       && bt.loaibantin == loaibantin
                                       select bt).Single();
             return bantin;
         }

         public List<bantin> Laybantinduyet()
         {
             List<bantin> bantin = (from bt in data.bantins
                                    where bt.tinhtrangduyet != "DD"
                                    select bt).ToList();
             return bantin;
         }

         public List<bantin> Laybantindaduyet()
         {
             List<bantin> bantin = (from bt in data.bantins
                                    where bt.tinhtrangduyet == "DD"
                                    select bt).ToList();
             return bantin;
         }

         public List<bantin> Laybantinsoan(int iduser)
         {
             List<bantin> bantin = (from bt in data.bantins
                                    where bt.iduser == iduser
                                    select bt).ToList();
             return bantin;
         }

         public int Laybantincuoi()
         {
             int kq;
             try
             {
                 kq = (from bt in data.bantins
                       select bt).ToList().Count();
             }
             catch
             {
                 kq = 0;
             }
             return kq;
         }
         public List<bantin> Laybantinxem(int iduser)
         {
             List<bantin> bantin = (from bt in data.bantins
                                    join gui in data.bantin_guis on bt.idbantin equals gui.idbantin
                                    where gui.iduser == iduser && gui.dagui == true
                                    select bt).ToList();
             return bantin;
         }
         public List<bantin_chude> Laychude()
         {
             List<bantin_chude> chude = (from cd in data.bantin_chudes
                                         select cd).ToList();
             return chude;
         }

         public List<string> Laytennhom()
         {
             List<string> nhombt = (from cd in data.bantin_nhoms
                                    select cd.tennhom).ToList();
             return nhombt;
         }

         public bantin_nhom Laynhom(int idnhom)
         {
             bantin_nhom nhombt = (from cd in data.bantin_nhoms
                                   where cd.idnhombantin == idnhom
                                   select cd).Single();
             return nhombt;
         }

         public List<bantin_nhom> Laynhomall()
         {
             List<bantin_nhom> nhombt = (from cd in data.bantin_nhoms
                                         select cd).ToList();
             return nhombt;
         }
         public List<bantin> Locbantin1(int idchude, string tukhoa, int iduser)
         {
             List<bantin> ketqua = new List<bantin>();
             if (idchude == 0)
             {
                 ketqua = (from cd in data.bantins
                           join gui in data.bantin_guis on cd.idbantin equals gui.idbantin
                           where cd.tieude.Contains(tukhoa) == true && gui.iduser == iduser
                           select cd).ToList();
             }
             else
             {
                 ketqua = (from cd in data.bantins
                           join gui in data.bantin_guis on cd.idbantin equals gui.idbantin
                           where cd.idchude == idchude && cd.tieude.Contains(tukhoa) == true
                           && gui.iduser == iduser
                           select cd).ToList();
             }
             return ketqua;
         }
         public List<bantin> Locbantin2(int idchude, string tukhoa, bool doc, bool phanhoi, int iduser)
         {
             List<bantin> ketqua = new List<bantin>();
             if (idchude == 0)
             {
                 ketqua = (from cd in data.bantins
                                        join gui in data.bantin_guis on cd.idbantin equals gui.idbantin
                                        where cd.tieude.Contains(tukhoa) == true
                                        && gui.iduser == iduser && gui.daxem == doc
                                        && gui.daphanhoi == phanhoi
                                        select cd).ToList();
             }
             else
             {
                 ketqua = (from cd in data.bantins
                                        join gui in data.bantin_guis on cd.idbantin equals gui.idbantin
                                        where cd.idchude == idchude && cd.tieude.Contains(tukhoa) == true
                                        && gui.iduser == iduser && gui.daxem == doc
                                        && gui.daphanhoi == phanhoi
                                        select cd).ToList();
             }
             return ketqua;
         }

         public List<bantin> Locbantinduyet1(int idchude, string tukhoa, char mucdo)
         {
             List<bantin> ketqua = new List<bantin>();
             if (idchude == 0)
             {
                 ketqua = (from cd in data.bantins
                           where cd.tieude.Contains(tukhoa) == true && cd.mucdo == mucdo
                           && cd.tinhtrangduyet != "DD"
                           select cd).ToList();
             }
             else
             {
                 ketqua = (from cd in data.bantins
                           where cd.idchude == idchude && cd.tieude.Contains(tukhoa) == true && cd.mucdo == mucdo
                           && cd.tinhtrangduyet != "DD"
                           select cd).ToList();
             }
             return ketqua;
         }

         public List<bantin> Locbantinduyet2(int idchude, string tukhoa)
         {
             List<bantin> ketqua = new List<bantin>();
             if (idchude == 0)
             {
                 ketqua = (from cd in data.bantins
                           where cd.tieude.Contains(tukhoa) == true && cd.tinhtrangduyet != "DD"
                           select cd).ToList();
             }
             else
             {
                 ketqua = (from cd in data.bantins
                           join gui in data.bantin_guis on cd.idbantin equals gui.idbantin
                           where cd.idchude == idchude && cd.tieude.Contains(tukhoa) == true
                           && cd.tinhtrangduyet != "DD"
                           select cd).ToList();
             }
             return ketqua;
         }

         public List<bantin_phanhoi_doc> Layphanhoi(int idbantin)
         {
             List<bantin_phanhoi_doc> ketqua = (from cd in data.bantin_phanhoi_docs
                                                where cd.idbantin == idbantin
                                                select cd).ToList();
             return ketqua;

         }

         public void Xembantin(int idbantin, int iduser)
         {
             bantin_gui xembt = (from tk in data.bantin_guis
                                 where tk.idbantin == idbantin && tk.iduser == iduser
                                 select tk).Single();
             xembt.daxem = true;
             data.SubmitChanges();

             bantin luotxem = (from tk in data.bantins
                               where tk.idbantin == idbantin
                               select tk).Single();
             luotxem.xem += 1;
             data.SubmitChanges();
         }
         public void Themphanhoi(int idbantin, int iduser, string noidung, DateTime thoigian)
         {
             bantin_phanhoi_doc themphanhoi = new bantin_phanhoi_doc();
             try
             {
                 int idsp = (from tk in data.bantin_phanhoi_docs
                             select tk).ToList().Last().idphanhoi;
                 themphanhoi.idphanhoi = idsp + 1;
             }
             catch
             {
                 themphanhoi.idphanhoi = 1;
             }                 

             themphanhoi.idbantin = idbantin;
             themphanhoi.iduser = iduser;
             themphanhoi.noidung = noidung;
             themphanhoi.ngaygio = thoigian;
             themphanhoi.xoa = false;
             data.bantin_phanhoi_docs.InsertOnSubmit(themphanhoi);

             bantin_gui users = (from tk in data.bantin_guis
                                 where tk.idbantin == idbantin && tk.iduser == iduser
                                 select tk).Single();

             users.daphanhoi = true;

             data.SubmitChanges();
         }

         public void Xoaphanhoi(int idbantin, int iduser, string noidung)
         {
             bantin_phanhoi_doc xoaph = (from tk in data.bantin_phanhoi_docs
                                         where tk.idbantin == idbantin && tk.iduser == iduser && tk.noidung == noidung
                                         select tk).Single();

             data.bantin_phanhoi_docs.DeleteOnSubmit(xoaph);
             data.SubmitChanges();

             bantin_gui users = (from tk in data.bantin_guis
                                  where tk.idbantin == idbantin && tk.iduser == iduser
                                  select tk).Single();
             users.daphanhoi = false;
             data.SubmitChanges();
         }

         public void Luuykienduyet(int idbantin, int iduser, string noidung, DateTime ngaygui)
         {
             bantin_ykien_duyet ykienmoi = new bantin_ykien_duyet();
             try
             {
                 int slykien = (from tk in data.bantin_ykien_duyets
                                select tk).ToList().Last().idykienbt;
                 ykienmoi.idykienbt = slykien + 1;
             }
             catch
             {
                 ykienmoi.idykienbt = 1;
             }

             ykienmoi.idbantin = idbantin;
             ykienmoi.iduser = iduser;
             ykienmoi.noidung = noidung;
             ykienmoi.ngay = ngaygui;
             data.bantin_ykien_duyets.InsertOnSubmit(ykienmoi);
             data.SubmitChanges();

             bantin capnhatbt = (from tk in data.bantins
                                     where tk.idbantin == idbantin
                                     select tk).Single();

             capnhatbt.tinhtrangduyet = "YK";
             data.SubmitChanges();
         }

         public void Luuykienduyet2(int idbantin, int iduser, string noidung, DateTime ngaygui, string duongdanD)
         {
             bantin_ykien_duyet ykienmoi = new bantin_ykien_duyet();
             try
             {
                 int slykien = (from tk in data.bantin_ykien_duyets
                                select tk).ToList().Last().idykienbt;
                 ykienmoi.idykienbt = slykien + 1;
             }
             catch
             {
                 ykienmoi.idykienbt = 1;
             }

             ykienmoi.idbantin = idbantin;
             ykienmoi.iduser = iduser;
             ykienmoi.noidung = noidung;
             ykienmoi.ngay = ngaygui;
             data.bantin_ykien_duyets.InsertOnSubmit(ykienmoi);
             data.SubmitChanges();

             bantin capnhatbt = (from tk in data.bantins
                                 where tk.idbantin == idbantin
                                 select tk).Single();

             capnhatbt.tinhtrangduyet = "YK";
             capnhatbt.duongdanDuyet = duongdanD;
             data.SubmitChanges();
         }

         public void Duyetbantin(int idbantin)
         {
             bantin capnhatbt = (from tk in data.bantins
                                 where tk.idbantin == idbantin
                                 select tk).Single();

             capnhatbt.tinhtrangduyet = "DD";
             data.SubmitChanges();

             List<bantin_gui> capnhatgui = (from tk in data.bantin_guis
                                      where tk.idbantin == idbantin
                                      select tk).ToList();
             foreach (bantin_gui users in capnhatgui)
             {
                 users.dagui = true;
                 data.SubmitChanges();
             }
             
         }

         public void Thembantin(int idbantin, short idchude, int iduser, string tukhoa, string tieude, string hinhthuc,
             char mucdo, string duongdanCT, string duongdanNhap, string nhomnhan, DateTime ngaysoan)
         {
             bantin thembt = new bantin();
             try
             {
                 int idsp = (from tk in data.bantins
                         select tk.idbantin).ToList().Last();
                 thembt.idbantin = idbantin;
             }
             catch
             {
                 thembt.idbantin = 1;
             }                

             thembt.idchude = idchude;
             thembt.iduser = iduser;
             thembt.tukhoa = tukhoa;
             thembt.tieude = tieude;
             thembt.hinhthuc = hinhthuc;
             thembt.mucdo = mucdo;
             thembt.duongdanCT = duongdanCT;
             thembt.duongdanNhap = duongdanNhap;
             thembt.tinhtrangduyet = "CD";
             thembt.xem = 0;
             thembt.nhomnhan = nhomnhan;
             thembt.ngaysoan = ngaysoan;
             data.bantins.InsertOnSubmit(thembt);
             data.SubmitChanges();
         }

         public void Capnhatbt(int idbantin, short idchude, int iduser, string tukhoa, string tieude, string hinhthuc,
             char mucdo, string duongdanCT, string duongdanNhap, string nhomnhan, DateTime ngaysoan)
         {
             bantin thembt = (from tk in data.bantins
                              where tk.idbantin == idbantin
                              select tk).Single();

             thembt.idbantin = idbantin;
             thembt.idchude = idchude;
             thembt.iduser = iduser;
             thembt.tukhoa = tukhoa;
             thembt.tieude = tieude;
             thembt.hinhthuc = hinhthuc;
             thembt.mucdo = mucdo;
             thembt.duongdanCT = duongdanCT;
             thembt.duongdanNhap = duongdanNhap;
             thembt.tinhtrangduyet = "CD";
             thembt.xem = 0;
             thembt.nhomnhan = nhomnhan;
             thembt.ngaysoan = ngaysoan;
             data.SubmitChanges();
         }


         public void Themnguoinhan(int idbantin, List<int> iduser)
         {
             foreach (int id in iduser)
             {
                 bantin_gui users = new bantin_gui();
                 try
                 {
                     int dem = (from tk in data.bantin_guis
                                select tk).ToList().Last().idguibantin;
                     users.idguibantin = dem + 1;
                 }
                 catch
                 {
                     users.idguibantin = 1;
                 }                     

                 users.idbantin = idbantin;
                 users.iduser = id;
                 users.dagui = false;
                 users.daxem = false;
                 users.daphanhoi = false;
                 data.bantin_guis.InsertOnSubmit(users);
                 data.SubmitChanges();
             }

         }

         public void Capnhatnguoinhan(int idbantin, List<int> iduser)
         {
             List<bantin_gui> xoa = (from tk in data.bantin_guis
                                     where tk.idbantin == idbantin
                                     select tk).ToList();
             data.bantin_guis.DeleteAllOnSubmit(xoa);
             data.SubmitChanges();

             foreach (int id in iduser)
             {
                 bantin_gui users = new bantin_gui();
                 try
                 {
                     int dem = (from tk in data.bantin_guis
                                select tk).ToList().Last().idguibantin;
                     users.idguibantin = dem + 1;
                 }
                 catch
                 {
                     users.idguibantin = 1;
                 }

                 users.idbantin = idbantin;
                 users.iduser = id;
                 users.dagui = false;
                 users.daxem = false;
                 users.daphanhoi = false;
                 data.bantin_guis.InsertOnSubmit(users);
                 data.SubmitChanges();
             }

         }

         public List<int> Laynguoinhan(List<int> idnhomnhan)
         {
             List<int> ketqua = new List<int>();
             foreach (int id in idnhomnhan)
             {
                 bantin_kqnhom ketquanhom = new bantin_kqnhom();
                 List<int> nguoidung = (from tk in data.bantin_kqnhoms
                                        where tk.idnhombantin == id
                                        select tk.iduser).ToList();

                 foreach (int item in nguoidung)
                 {
                     if (!ketqua.Contains(item))
                         ketqua.Add(item);
                 }
             }
             return ketqua;
         }
         public List<nhansu> Guithongbaobantin(int idbantin)
         {
             List<nhansu> capnhatgui = (from tk in data.nhansus
                                        join db in data.bantin_guis on tk.iduser equals db.iduser
                                        where db.idbantin == idbantin
                                        select tk).ToList();
             return capnhatgui;
         }
        #endregion
    }
}
