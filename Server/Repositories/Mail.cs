using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using System.Net;
using System.Net.Mail;

namespace ECommerceApp.Server.Repositories
{
    public class Mail : IMail
    {
        private readonly DataContext _context;

        public Mail(DataContext context)
        {
            _context = context;
        }

        public void SendMail(List<CartDTO> cartdto)
        {
            try
            {

                AddOrder(cartdto); 

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential NetworkCred = new NetworkCredential("chettykubeshan0@gmail.com", "fzvhxxwhttuopwue");
                smtp.Credentials = NetworkCred;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = 25;

                MailMessage mm = new MailMessage("chettykubeshan0@gmail.com", "chettykubeshan1999@gmail.com");

                float total = 0;

                string textbody = "<head><style> td { text-align:center; }</style ></head> ";

                textbody += " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + "><thead><tr bgcolor='#4da6ff'><th><b>Name</b></th> <th> <b> Quantity</b> </th><th> <b> Price</b> </th></tr><thead>";

                for (int i = 0; i < cartdto.Count; i++)
                {
                    textbody += "<tr><td>" + cartdto[i].ProductName + "</td><td> " + cartdto[i].Quantity + "</td><td> R" + cartdto[i].Price * cartdto[i].Quantity +"</td></tr>";
                    total = total + cartdto[i].Price * cartdto[i].Quantity;
                }

                textbody += "</table> <br>";

                textbody += "Grand Total: R" + total.ToString();

                mm.Subject = "Order Placed";
                mm.Body = textbody;
                mm.IsBodyHtml = true;

                smtp.Send(mm);

                smtp.Dispose();



            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        void AddOrder(List<CartDTO> cartdto) {

            try
            {

                char delim = ',';

                int UserID = 0;

                Order order = new Order();
                User user = new User();

                for (int i = cartdto.Count - 1; i < cartdto.Count; i++)
                {

                    UserID = cartdto[i].UserID;

                }

                user = _context.Users.Find(UserID);

                order.Products = String.Join(delim, cartdto.Select(x => x.ProductID));
                order.Quantities = String.Join(delim, cartdto.Select(x => x.Quantity));
                order.Prices = String.Join(delim, cartdto.Select(x => x.Price * x.Quantity));
                order.date = DateTime.Now;
                order.Userid = user;

                _context.orders.Add(order);

                _context.SaveChanges();

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

    }
}
