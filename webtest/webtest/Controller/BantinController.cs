using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Text;
using Newtonsoft;

namespace webtest.Controller
{
    public class BantinController : ApiController
    {
        BUS taikhoan = new BUS();

        [HttpGet]
        [Route("api/dangnhap/{account}/{password}")]
        public account dangnhap(string account, string password)
        {
            bool ketqua = taikhoan.KTdangnhap(account, password);
            if (ketqua)
            {
                nhansu dangnhap = taikhoan.Laytaikhoan(account);
                account trave = new account();
                trave.iduser = dangnhap.iduser;
                trave.acc = account;
                trave.password = password;
                trave.quyen = dangnhap.quyen;
                return trave;
            }
            else
                return null;
        }
        public class account
        {
            public int iduser;
            public string acc;
            public string password;
            public int quyen;
        }

        #region Bản tin
        [HttpPost]
        [Route("api/guimail/{idbantin}")]
        public string SendEmail(int idbantin)
        {
            string chude = taikhoan.Laybantin(idbantin).bantin_chude.tenchude;
            string tieude = taikhoan.Laybantin(idbantin).tieude;

            string senderID = "tung.sto.03@gmail.com";
            string senderPassword = "tungnene";
            string result = "Email Sent Successfully";

            string body = @"Một bản tin mới đã được gửi cho quý đồng nghiệp.
Chủ đề: " + chude + @"
Tiêu đề: " + tieude + @"
Quý đồng nghiệp vui lòng dành chút thời gian để đọc và phản hồi.
Xin cảm ơn!";
            foreach (nhansu item in taikhoan.Guithongbaobantin(idbantin))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(item.email);
                    mail.From = new MailAddress(senderID);
                    mail.Subject = "Bản tin mới";
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                    smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                    result = "problem occurred" + ex;
                }
            }
            return result;
        }
        //[HttpGet]
        //public List<Food> GetFoodLists()
        //{
        //    DBFoodDataContext db = new DBFoodDataContext();
        //    return db.Foods.ToList();
        //}
        //[HttpGet]
        //public Food GetFood(int id)
        //{
        //    DBFoodDataContext db = new DBFoodDataContext();
        //    return db.Foods.FirstOrDefault(x => x.id == id);
        //}
        //[HttpGet]
        //public List<nhansu> GetNhanSu()
        //{
        //    DBFoodDataContext db = new DBFoodDataContext();
        //    return db.nhansus.ToList();
        //}

        //[HttpGet]
        //public HttpResponseMessage Index()
        //{
        //    var response = new HttpResponseMessage();
        //    response.Content = new StringContent("<html><body>Hello World</body></html>");
        //    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");
        //    return response;
        //}
        

        ////Provide pdf
        [HttpGet]
        [Route("api/xembantin/{iduser}/{idbantin}")]
        public string Xem(int iduser, int idbantin)
        {
            taikhoan.Xembantin(idbantin, iduser);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            bantin_filedata filebantin = taikhoan.Layfilebantin(idbantin, 'X');
            byte[] bytes = filebantin.filedata.ToArray();

            string strBase64 = Convert.ToBase64String(bytes);
            return strBase64;
        }

        //Provide pdf
        //[HttpGet]
        //[Route("api/xembantin/{bantin}")]
        //public HttpResponseMessage Xem(string bantin)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    string fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Documents\" + bantin + ".pdf");

        //    FileStream fileStream = File.OpenRead(fileName);
        //    response.Content = new StreamContent(fileStream);
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

        //    return response;
        //}

        //Provide html
        //[HttpGet]
        //[Route("api/xembantin/{bantin}")]
        //public HttpResponseMessage Xem(string bantin)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    string fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Documents\" + bantin + ".html");

        //    response.Content = new StringContent(File.ReadAllText(fileName));
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

        //    return response;
        //}

        //[HttpGet]
        //[Route("api/getpdf")]
        //public HttpResponseMessage Laypdf()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    string fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Documents\" + bantin + ".html");

        //    response.Content = new StringContent(File.ReadAllText(fileName));
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

        //    return response;
        //}

        [HttpGet]
        [Route("api/dsbantin/{iduser}")]
        public List<bantin2> Danhsach(int iduser)
        {
            List<bantin2> ketqua = new List<bantin2>();
            List<bantin> ds = taikhoan.Laybantinxem(iduser);

            foreach (bantin item in ds)
            {
                bantin2 test = new bantin2();
                test.idbantin = item.idbantin;
                test.mabantin = string.Format("BT{0:0000}", item.idbantin);
                test.tieude = item.tieude;
                test.chude = taikhoan.Laychude().Single(x => x.idchude == item.idchude).tenchude;
                test.tenfile = item.duongdanCT;
                //test.ngaysoan = item.ngaysoan;
                test.daxem = taikhoan.Checkbantin(iduser, test.idbantin).daxem;
                test.daphanhoi = taikhoan.Checkbantin(iduser, test.idbantin).daphanhoi;
                ketqua.Add(test);
            }
            return ketqua;
        }

        //[HttpGet]
        // public List<nhombantin> Getbantinlist()
        // {
        //     KetnoiCSDLDataContext db = new KetnoiCSDLDataContext();
        //     List<nhombantin> ketqua = new List<nhombantin>();
        //     List<bantin_nhom> test = (from tk in db.bantin_nhoms
        //                               select tk).ToList();

        //     foreach (bantin_nhom item in test)
        //     {
        //         nhombantin test2 = new nhombantin();
        //         test2.idnhom = item.idnhombantin;
        //         test2.tennhom = item.tennhom;
        //         test2.mota = item.mota;
        //         ketqua.Add(test2);
        //     }
        //     return ketqua;
        // }

        //[HttpGet]
        // public List<bantin_nhom> Getbantinlist()
        //{
        //    KetnoiCSDLDataContext db = new KetnoiCSDLDataContext();
        //    List<nhombantin> ketqua = new List<nhombantin>();
        //    List<bantin_nhom> test = (from tk in db.bantin_nhoms
        //                              select tk).ToList();

        //    foreach (bantin_nhom item in test)
        //    {
        //        nhombantin test2 = new nhombantin();
        //        test2.idnhom = item.idnhombantin;
        //        test2.tennhom = item.tennhom;
        //        test2.mota = item.mota;
        //        ketqua.Add(test2);
        //    }
        //    return test;
        //}

        //[HttpPut]
        //[Route("api/daxem/{idbantin}/{iduser}")]
        //public bool Xemtin(int iduser, int idbantin)
        //{
        //    try
        //    {
        //        taikhoan.Xembantin(idbantin, iduser);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        [HttpPost]
        [Route("api/phanhoi/{idbantin}/{iduser}")]
        public bool Xemtin(int iduser, int idbantin, string ndphanhoi)
        {
            try
            {
                byte[] binarydata = Convert.FromBase64String(ndphanhoi);
                string decodephanhoi = System.Text.Encoding.UTF8.GetString(binarydata);
                
                DateTime thoigianph = DateTime.Now;
                taikhoan.Themphanhoi(idbantin, iduser, decodephanhoi, thoigianph);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public class bantin2
        {
            public int idbantin { get; set; }
            public string mabantin { get; set; }
            public string tieude { get; set; }
            public string chude { get; set; }
            public int iduser { get; set; }
            public bool daxem { get; set; }
            public bool daphanhoi { get; set; }
            public string tenfile { get; set; }

        }

        //[HttpPost, Route("api/upload")]
        //public HttpResponseMessage Post()
        //{
        //    var httpRequest = System.Web.HttpContext.Current.Request;
            
        //    if (httpRequest.Files.Count < 1)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    foreach (string file in httpRequest.Files)
        //    {
        //        var postedFile = httpRequest.Files[file];
        //        var filePath = System.Web.HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
        //        postedFile.SaveAs(filePath);
        //        // NOTE: To store in memory use postedFile.InputStream
        //    }

        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

        //[HttpPost]
        //public bool InsertNewFood(string name, string type, int price)
        //{
        //    try
        //    {
        //        DBFoodDataContext db = new DBFoodDataContext();
        //        Food food = new Food();
        //        food.name = name;
        //        food.type = type;
        //        food.price = price;
        //        db.Foods.InsertOnSubmit(food);
        //        db.SubmitChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //[HttpPost]
        //[Route("GetTestPDF")]
        //public HttpResponseMessage Get()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

        //    string fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Documents\CTBT0004.pdf");

        //    FileStream fileStream = File.OpenRead(fileName);
        //    response.Content = new StreamContent(fileStream);
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

        //    return response;
        //}
        //[HttpPut]
        //public bool UpdateFood(int id, string name, string type, int price)
        //{
        //    try
        //    {
        //        DBFoodDataContext db = new DBFoodDataContext();
        //        //lấy food tồn tại ra
        //        Food food = db.Foods.FirstOrDefault(x => x.id == id);
        //        if (food == null) return false;//không tồn tại false
        //        food.name = name;
        //        food.type = type;
        //        food.price = price;
        //        db.SubmitChanges();//xác nhận chỉnh sửa
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //[HttpDelete]
        //public bool DeleteFood(int id)
        //{
        //    DBFoodDataContext db = new DBFoodDataContext();
        //    //lấy food tồn tại ra
        //    Food food = db.Foods.FirstOrDefault(x => x.id == id);
        //    if (food == null) return false;
        //    db.Foods.DeleteOnSubmit(food);
        //    db.SubmitChanges();
        //    return true;
        //}

        #endregion
        #region KSDB     
        [HttpGet]
        [Route("api/chophepduyet/{iduser}")]
        public bool chophepduyet(int iduser)
        {
            return taikhoan.LaykqnhomKSDB().Contains(taikhoan.Laytaikhoan2(iduser));
        }

        [HttpGet]
        [Route("api/layphieucdcd/{iduser}")]
        public List<phieu2> dsphieucdcd(int iduser)
        {
            List<phieu2> ketqua = new List<phieu2>();
            List<phieuksdb> ds = taikhoan.Loadphieuuserchuaduyet(iduser);

            foreach (phieuksdb item in ds)
            {
                phieuksdb_ykien ykien1 = taikhoan.Loadykien(item.idphieu)[0];
                string tenbs = taikhoan.Laytaikhoan2(ykien1.iduser).hoten;

                phieu2 test = new phieu2();
                test.idphieu = item.idphieu;
                test.maphieu = string.Format("{0:0000}", item.idphieu);
                test.tenbs = tenbs;
                test.danhgiaxn = item.danhgiaxn;
                test.khoals = item.benhan.khoa.ten;
                test.tenbn = item.benhan.tenbn;
                test.tuoi = DateTime.Now.Year - item.benhan.ngaysinh.Year;
                test.gioitinh = (item.benhan.gioitinh == true) ? "Nam" : "Nữ";
                test.chidinh = item.chidinh;
                test.tenks = item.khangsinhdacbiet.thuoc.hoatchat.tenhc;
                test.duongdung = item.duongsd;
                test.lieudung = item.lieusd;
                test.ghichu = item.ghichu;

                ketqua.Add(test);
            }
            return ketqua;
        }

        [HttpGet]
        [Route("api/layphieucddd/{iduser}")]
        public List<phieu2> dsphieucddd(int iduser)
        {
            List<phieu2> ketqua = new List<phieu2>();
            List<phieuksdb> ds = taikhoan.Loadphieuuserdaduyet(iduser);

            foreach (phieuksdb item in ds)
            {
                phieuksdb_ykien ykien1 = taikhoan.Loadykien(item.idphieu)[0];
                string tenbs = taikhoan.Laytaikhoan2(ykien1.iduser).hoten;

                phieu2 test = new phieu2();
                test.idphieu = item.idphieu;
                test.maphieu = string.Format("{0:0000}", item.idphieu);
                test.tenbs = tenbs;
                test.khoals = item.benhan.khoa.ten;
                test.tenbn = item.benhan.tenbn;
                test.danhgiaxn = item.danhgiaxn;
                test.tuoi = DateTime.Now.Year - item.benhan.ngaysinh.Year;
                test.gioitinh = (item.benhan.gioitinh == true) ? "Nam" : "Nữ";
                test.chidinh = item.chidinh;
                test.tenks = item.khangsinhdacbiet.thuoc.hoatchat.tenhc;
                test.duongdung = item.duongsd;
                test.lieudung = item.lieusd;
                test.ghichu = item.ghichu;

                ketqua.Add(test);
            }
            return ketqua;
        }

        [HttpPost]
        [Route("api/phieuksdb/ykien/{idphieu}/{iduser}")]
        public bool Ykienphieu( int idphieu,int iduser, string ndykien)
        {
            try
            {
                byte[] binarydata = Convert.FromBase64String(ndykien);
                string decodeykien = System.Text.Encoding.UTF8.GetString(binarydata);

                DateTime thoigian = DateTime.Now;
                taikhoan.Themykienphieu(idphieu, iduser, taikhoan.Laytaikhoan2(iduser).khoa.ten, thoigian, decodeykien);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/phieuksdb/duyetphieu/{idphieu}/{iduser}")]
        public bool Duyetphieu(int idphieu, int iduser)
        {
            try
            {
                DateTime thoigian = DateTime.Now;
                taikhoan.Duyetphieu(idphieu, iduser,
                    (taikhoan.Laytaikhoan2(iduser).idkhoa==null)?"":taikhoan.Laytaikhoan2(iduser).khoa.ten, thoigian);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public class phieu2
        {
            public int idphieu { get; set; }
            public string maphieu { get; set; }
            public string tenbs { get; set; }
            public string khoals { get; set; }
            public string tenbn { get; set; }
            public int tuoi { get; set; }
            public string gioitinh { get; set; }
            public string danhgiaxn { get; set; }
            public string chidinh { get; set; }
            public string tenks { get; set; }
            public string duongdung { get; set; }
            public string lieudung { get; set; }
            public string ghichu { get; set; }
        }
        #endregion
    }


    

}
