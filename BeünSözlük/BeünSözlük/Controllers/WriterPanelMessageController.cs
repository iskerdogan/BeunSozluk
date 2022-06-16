using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string writerMail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListInbox(writerMail).OrderByDescending(x => x.MessageDate).ToList();
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetMessageById(id);
            return View(values);
        }

        public ActionResult Sendbox()
        {
            string writerMail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendbox(writerMail).OrderByDescending(x => x.MessageDate).ToList();
            return View(messageList);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetMessageById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string senderMail = (string)Session["WriterMail"];
            ValidationResult validationResult = validationRules.Validate(message);
            if (validationResult.IsValid)
            {
                message.SenderMail = senderMail;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.AddMessageBusinessLayer(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult PartialWriterMailSidebar()
        {
            return PartialView();
        }
    }
}