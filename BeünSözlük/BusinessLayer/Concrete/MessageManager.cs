using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessageBusinessLayer(Message message)
        {
            _messageDal.Add(message);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail);
        }

        public List<Message> GetListSendbox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail);
        }

        public Message GetMessageById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
