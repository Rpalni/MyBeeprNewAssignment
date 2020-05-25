using FinalTestAssignment.Module.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers
{
    public class WorkingDaysController : ApiController
    {
       private readonly IWorkingDays _service;

        public WorkingDaysController(IWorkingDays service)
        {
            _service = service;
        }

        [HttpGet]
        public int WorkingDays(DateTime from, DateTime to)
        {
            return _service.GetWorkingDays(from, to);
        }
    }
}
