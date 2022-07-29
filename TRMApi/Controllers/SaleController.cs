﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); /* Old way - RequestContext.Principal.Identity.GetUserId()*/
            data.SaveSale(sale, userId);

        }

        [Authorize(Roles = "Admin")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {

            SaleData data = new SaleData();

            return data.GetSaleReport();
        }
    }
}
