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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeadingBusinessLayer(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public Heading GetHeadingById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {

            return _headingDal.List();
        }

        public List<Heading> GetListBySearch(string search)
        {
            return _headingDal.List(x => x.HeadingName.Contains(search));
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public List<Heading> GetListByWriterAndSearch(int id, string search)
        {
            return _headingDal.List(x => x.WriterId == id && x.HeadingName.Contains(search));
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            heading.HeadingStatus = true;
            _headingDal.Update(heading);
        }
    }
}
