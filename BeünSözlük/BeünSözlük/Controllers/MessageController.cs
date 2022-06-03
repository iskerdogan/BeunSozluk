using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string mail)
        {
            var messageList = messageManager.GetListInbox(mail);
            return View(messageList);
        }

        public ActionResult Sendbox(string mail)
        {
            var messageList = messageManager.GetListSendbox(mail);
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetMessageById(id);
            return View(values);
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
            ValidationResult validationResult = validationRules.Validate(message);
            if (validationResult.IsValid)
            {
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
    }
}