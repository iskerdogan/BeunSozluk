using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        List<Heading> GetListBySearch(string search);
        List<Heading> GetListByWriterAndSearch(int id,string search);
        void AddHeadingBusinessLayer(Heading heading);
        Heading GetHeadingById(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);

    }
}
