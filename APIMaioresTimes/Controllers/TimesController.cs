using APIMaioresTimes.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMaioresTimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListarTimes()
        {
            TimeDAO dao = new TimeDAO();
            var times = dao.ListarTimes();
            return Ok(times);
        }

        [HttpPost]
        public IActionResult Cadastrar(TimeDTO time)
        {
            TimeDAO dao = new TimeDAO();
            dao.CadastrarTime(time);
            return Ok();
        }

        [HttpPut]
        public IActionResult AlterarTime(TimeDTO time)
        {
            TimeDAO dao = new TimeDAO();
            dao.AlterarTime(time);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoverTime(int id)
        {
            TimeDAO dao = new TimeDAO();
            dao.RemoverTime(id);
            return Ok();
        }


    }
}
