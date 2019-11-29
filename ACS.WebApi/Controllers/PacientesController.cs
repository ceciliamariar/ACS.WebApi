using ACS.WebApi.Dominio.Entradas;
using ACS.WebApi.Dominio.Saidas;
using ACS.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        public IPacienteNegocio _PacienteNegocio { get; set; }
        public IMedicaoNegocio _MedicaoNegocio { get; set; }
        public IRespostaNegocio _RespostaNegocio { get; set; }

        public PacientesController(IPacienteNegocio pacienteNegocio,
            IMedicaoNegocio medicaoNegocio,
            IRespostaNegocio respostaNegocio)
        {
            _PacienteNegocio = pacienteNegocio;
            _MedicaoNegocio = medicaoNegocio;
            _RespostaNegocio = respostaNegocio;
        }
        /// <summary>
        /// Serviço responsável pelo cadastro de um novo paciente
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PacienteSaida>> Post([FromBody] PacienteEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<PacienteSaida>>.Run(() => _PacienteNegocio.Insert(value, HttpContext.Request.Headers["Authorization"].ToString()));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Serviço responsável pela busca de pacientes pelo nome, deve ser informado pelo menos 3 letras do nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{nome}")]
        public async Task<ActionResult<IList<PacienteSaida>>> RecuperaPacientesPorNome(string nome)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => _PacienteNegocio.RecuperaPacientesPorNome(nome));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Serviço responsável pela busca de pacientes pelo identificador
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{idPaciente}/Detalhes")]
        public async Task<ActionResult<IList<PacienteSaida>>> RecuperaPacientesCompleto(int idPaciente)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => _PacienteNegocio.RecuperaPaciente(idPaciente));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Serviço responsável pela busca de medições do paciente
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{idPaciente}/Medicoes")]
        public async Task<ActionResult<IList<PacienteSaida>>> RecuperaMedicoesPorPaciente(int idPaciente)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => _MedicaoNegocio.RecuperaPorPaciente(idPaciente));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Serviço responsável pelo cadastro de respostas
        /// </summary>
        /// <param name="idPaciente">Identificador do paciente que respondeu a pergunta</param>
        /// <param name="idPergunta">Identificador da pergunta</param>
        /// <param name="respostaEntrada">Entidade com os dados respondidos pelo paciente</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idPaciente}/Perguntas/{idPergunta}")]
        public async Task<ActionResult<RespostaSaida>> ResponderPergunta(int idPaciente, int idPergunta, [FromBody] RespostaEntrada respostaEntrada)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteSaida>>>.Run(() => _RespostaNegocio.Insert(respostaEntrada));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Serviço responsável pelo cadastro de remedios para um paciente
        /// </summary>
        /// <param name="idPaciente">Identificador do paciente</param>
        /// <param name="pacienteRemedioEntrada">Entidade com dados do remedio</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idPaciente}/Remedio")]
        public async Task<ActionResult<PacienteRemedioSaida>> CadastrarRemedioUtilizado(int idPaciente, [FromBody] PacienteRemedioEntrada pacienteRemedioEntrada)
        {
            try
            {
                var retorno = await Task<IEnumerable<IList<PacienteRemedioSaida>>>.Run(() => _PacienteNegocio.CadastrarRemedio(pacienteRemedioEntrada, HttpContext.Request.Headers["Authorization"].ToString()));

                if (retorno == null)
                {
                    return BadRequest();
                }
                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Serviço responsável pela edição de paciente
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PacienteEntrada value)
        {
            try
            {
                bool update = await Task.Run(() => _PacienteNegocio.Update(value));

                if (!update)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Serviço responsável pelo cadastro de medição
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idPaciente}/Medicoes")]
        public async Task<ActionResult<MedicaoSaida>> Post(long idPaciente, [FromBody] MedicaoEntrada value)
        {
            try
            {
                var retorno = await Task<IEnumerable<MedicaoSaida>>.Run(() => _MedicaoNegocio.Insert(value, HttpContext.Request.Headers["Authorization"].ToString()));

                return Ok(retorno);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Serviço responsável pela edição de medição 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPut]
        [Route("{idPaciente}/Medicoes/{idMedicao}")]
        public async Task<ActionResult> Put([FromBody] MedicaoEntrada value)
        {
            try
            {
                bool update = await _MedicaoNegocio.Update(value);

                if (!update)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
