using System.Web.Mvc;
using System.Net.Mail;
using SuperHeroes.Models;
using System.Net;
using System;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormViewModel contact)
        {
            if (ModelState.IsValid)
            {
                //How to send email:
                //Construct a string value that will represent the 
                //mail message.

                //SET DEFAULT VALUES
                contact.TimeStamp = DateTime.Now;
                //optionally you can hard code your subject (helps with 
                //mail sorting)--Usually this is done when you OMIT the 
                //subject field from the mail form

                string messageContent = $"Name: {contact.Name}<br />Email:" +
                    $"{contact.Email}<br />Subject: {contact.Subject}<br />" +
                    $"<h4>Message<h4> {contact.Message}<br />TimeStamp: {contact.TimeStamp}";

                //If you wanted them to see their subjec, you could change the order of operations
                //and move the hard code of the subject here(you would see their original subject as part
                //of the messageContent variable).


                //Create a Mail Message Object (System.Net.Mail)
                //From :                    //To:                   //subject:     //Body:
                MailMessage m = new MailMessage("noreply@alexcroth.com", "a.c.roth89@gmail.com", contact.Subject, messageContent);
                //allow for html body
                m.IsBodyHtml = true;
                //replyto set to reply to the original emailer, not your
                //website
                m.ReplyToList.Add(contact.Email);//Respond to the persons
                                                 //email that SENT you a message from your website.

                //CC/BCC
                //m.CC.Add(contact.Email);
                //Carbon Copy all recipients can see each other on the 
                //email

                //BCC is added the same way, BCC is a blind carbon copy
                //Priority
                m.Priority = MailPriority.High;//optional setting 
                                               //Smtp client
                SmtpClient client = new SmtpClient("mail.alexcroth.com");
                //assign client credentials
                client.Credentials = new NetworkCredential("noreply@alexcroth.com",
                    "Gibson89u@");


                //send the message
                using (client)
                {
                    try
                    {
                        client.Send(m);
                    }

                    catch
                    {
                        ViewBag.ErrorMessage = "There was an error sending your message. Please try again";
                        return View(contact);
                    }
                }//Closes the connection on client

                //redirect to the confirmation
                return View("ContactConfirm", contact);

            }
            //if it fails validation return to the form
            //sending the contact object back to the view
            //to repopulate the form.
            return View(contact);
        }


        public ActionResult Archive()
        {
            return View();
        }

        public ActionResult Single()
        {
            return View();
        }
    }

}
