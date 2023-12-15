using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    public interface ICommand
    {
        public void GetInfo();
        public void Download();
    }
}
