using System;
using Medical.Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;

namespace Medical.System.BLL
{
    public class BLLLX
    {
        DALLX dal;
        public BLLLX(IOptions<ConnectionStrings> conn)
        {
            dal = new DALLX(conn);
        }
    }
}
