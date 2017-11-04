using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Model.Base
{
    public class BasePager
    {
        private int _PageSize = 0;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        private int _PageIndex = 0;
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
    }
}
