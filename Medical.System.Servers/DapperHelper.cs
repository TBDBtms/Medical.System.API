using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model;
using Microsoft.Extensions.Options;

namespace Medical.System.Servers
{
  public  class DapperHelper
    {
        public IOptions<ConnectionStrings> _conn;

        public DapperHelper(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
        }
    }
}
