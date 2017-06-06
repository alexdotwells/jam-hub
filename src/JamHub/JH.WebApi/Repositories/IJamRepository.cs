using JH.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JH.WebApi.Repositories
{
    internal interface IJamRepository
    {
        List<Jam> Retrieve();
        Jam Save(Jam jam);
    }
}