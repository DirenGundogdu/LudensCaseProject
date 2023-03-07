using LudensCaseProject.DTO;
using LudensCaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudensCaseProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FundController : ControllerBase
    {

        private readonly Context _context;

        public FundController(Context context)
        {
            _context = context;
        }

        
        [HttpPost]
        public IActionResult FundProfitDaily(FundProfitFilterDTO model)// Günlük Fon Getirisi Hesaplama
        {
            if (model == null)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(model.FundCode))
                return BadRequest();


            var fund = _context.Funds.Where(x => x.Code == model.FundCode).FirstOrDefault();
            if (fund == null)
                return BadRequest();

            DateTime date = model.DateDay;
            DateTime date2 = model.DateDay.AddDays(-1);

            var fundPrice = _context.FundPrices.Where(x => x.FundId == fund.Id && x.Date >= date2 && x.Date <= date).Select(x => new
            {
                date = x.Date,
                closePrice = x.ClosePrice
            }).ToList();

            if (fundPrice.Count == 0)
                return BadRequest();

            var firstPrice = fundPrice.FirstOrDefault();
            var lastPrice = fundPrice.LastOrDefault();

            var result = ((lastPrice.closePrice * 100) / firstPrice.closePrice) - 100;

            return Ok("Fonun Getirisi: " + result);

        }

        [HttpPost]
        public IActionResult FundProfitWeekly(FundProfitFilterDTO model)// Haftalık Fon Getirisi Hesaplama
        {
            if (model == null)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(model.FundCode))
                return BadRequest();


            var fund = _context.Funds.Where(x => x.Code == model.FundCode).FirstOrDefault();
            if (fund == null)
                return BadRequest();

            DateTime date = model.DateDay;
            DateTime date2 = model.DateDay.AddDays(-7);

            var fundPrice = _context.FundPrices.Where(x => x.FundId == fund.Id && x.Date >= date2 && x.Date <= date).Select(x => new
            {
                date = x.Date,
                closePrice = x.ClosePrice
            }).ToList();

            if (fundPrice.Count == 0)
                return BadRequest();

            var firstPrice = fundPrice.FirstOrDefault();
            var lastPrice = fundPrice.LastOrDefault();

            var result = ((lastPrice.closePrice * 100) / firstPrice.closePrice) - 100;

            return Ok("Fonun Getirisi: " + result);

        }


        [HttpPost]
        public IActionResult FundProfitOneMonth(FundProfitFilterDTO model)// Aylık Fon Getirisi Hesaplama
        {
            if (model == null)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(model.FundCode))
                return BadRequest();


            var fund = _context.Funds.Where(x => x.Code == model.FundCode).FirstOrDefault();
            if (fund == null)
                return BadRequest();

            DateTime date = model.DateDay;
            DateTime date2 = model.DateDay.AddDays(-30);

            var fundPrice = _context.FundPrices.Where(x => x.FundId == fund.Id && x.Date >= date2 && x.Date <= date).Select(x => new
            {
                date = x.Date,
                closePrice = x.ClosePrice
            }).ToList();

            if (fundPrice.Count == 0)
                return BadRequest();

            var firstPrice = fundPrice.FirstOrDefault();
            var lastPrice = fundPrice.LastOrDefault();

            var result = ((lastPrice.closePrice * 100) / firstPrice.closePrice) - 100;

            return Ok("Fonun Getirisi: " + result);

        }

        [HttpPost]
        public IActionResult FundProfitQuarterly(FundProfitFilterDTO model)// 3 Aylık Fon Getirisi Hesaplama
        {
            if (model == null)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(model.FundCode))
                return BadRequest();


            var fund = _context.Funds.Where(x => x.Code == model.FundCode).FirstOrDefault();
            if (fund == null)
                return BadRequest();

            DateTime date = model.DateDay;
            DateTime date2 = model.DateDay.AddDays(-90);

            var fundPrice = _context.FundPrices.Where(x => x.FundId == fund.Id && x.Date >= date2 && x.Date <= date).Select(x => new
            {
                date = x.Date,
                closePrice = x.ClosePrice
            }).ToList();

            if (fundPrice.Count == 0)
                return BadRequest();

            var firstPrice = fundPrice.FirstOrDefault();
            var lastPrice = fundPrice.LastOrDefault();

            var result = ((lastPrice.closePrice * 100) / firstPrice.closePrice) - 100;

            return Ok("Fonun Getirisi: " + result);

        }



    }
}
