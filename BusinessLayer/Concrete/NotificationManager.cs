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
    public class NotificationManager : INotificationService
    {
        INotificationDal _natificationDal;

        public NotificationManager(INotificationDal natificationDal)
        {
            _natificationDal = natificationDal;
        }

        public List<Notification> GetList()
        {
           return  _natificationDal.GetListAll();
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
