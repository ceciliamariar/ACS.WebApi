using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        public IPacienteNegocio PacienteNegocio { get; set; }
        public IMedicaoNegocio MedicaoNegocio { get; set; }
        public IRespostaNegocio RespostaNegocio { get; set; }

        public PacientesController(IPacienteNegocio _IPacienteNegocio,
            IMedicaoNegocio _IMedicaoNegocio,
            IRespostaNegocio _IRespostaNegocio)
        {
            PacienteNegocio = _IPacienteNegocio;
            MedicaoNegocio = _IMedicaoNegocio;
            RespostaNegocio = _IRespostaNegocio;
        }

        [HttpPost]
        public async Task<ActionResult<PacienteSaida>> Post([FromBody] PacienteEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<PacienteSaida>>.Run(() => PacienteNegocio.Insert(value));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{nome}")]
        public async Task<ActionResult<IList<PacienteSaida>>> RecuperaPacientesPorNome(string  nome)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => PacienteNegocio.RecuperaPacientesPorNome(nome));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{idPaciente}/Detalhes")]
        public async Task<ActionResult<IList<PacienteSaida>>> RecuperaPacientesCompleto(int idPaciente)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => PacienteNegocio.RecuperaPacientesPorNome("nome"));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{idPaciente}/Medicoes")]
        public async Task<ActionResult<IList<PacienteSaida>>> RecuperaMedicoesPorPaciente(int idPaciente)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => MedicaoNegocio.RecuperaPorPaciente(idPaciente));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("{idPaciente}/Pergunta/{idPergunta}")]
        public async Task<ActionResult<RespostaSaida>> ResponderPergunta(int idPaciente, int idPergunta, [FromBody] RespostaEntrada respostaEntrada)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => RespostaNegocio.Insert(respostaEntrada));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public ActionResult Put([FromBody] PacienteEntrada value)
        {
            try
            {
                Task.Run(() => PacienteNegocio.Update(value));

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
    }
}
