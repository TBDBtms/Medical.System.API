﻿using Medical.Model;
using Medical.Model.ZZH_Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.System.BLL
{
    public class Zzh_PatientBLL
    {
        public IOptions<ConnectionStrings> _conn;
        Zzh_PatientServers _Zzh_PatientServers;
        public Zzh_PatientBLL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            _Zzh_PatientServers = new Zzh_PatientServers(conn);

        }
        public List<Patient> GetPatient()
        {
            return _Zzh_PatientServers.GetPatient();
        }
    }
}
