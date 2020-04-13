using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agendador.Models;
using Agendador.Validadores.Agenda;

namespace Agendador.Controllers
{
    public class AgendaController : Controller
    {
        private readonly GerenciaContext _context;
        private readonly ValidaAgenda validaAgenda;


        public AgendaController(GerenciaContext context)
        {
            _context = context;
            validaAgenda = new ValidaAgenda();
        }

        // GET: Agenda
        /// <summary>
        /// Index do Agendador
        /// </summary>
        /// <returns>Retorna lista da Agenda</returns>
        public async Task<IActionResult> Index()
        {
            var gerenciaContext = _context.Agenda.Include(a => a.Clinica).Include(a => a.Paciente).OrderByDescending(x => x.DataInicioD);
            return View(await gerenciaContext.ToListAsync());
        }

        // GET: Agenda/Details/5
        /// <summary>
        /// View com Detalhes da Consulta
        /// </summary>
        /// <param name="id">Id da Agenda</param>
        /// <returns>Retorna dados do Objeto na View de detalhes</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var agenda = await _context.Agenda
                .Include(a => a.Clinica)
                .Include(a => a.Paciente)
                .FirstOrDefaultAsync(m => m.AgendaId == id);
                if (agenda == null)
                {
                    return NotFound();
                }

                return View(agenda);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            
        }

        // GET: Agenda/Create
        /// <summary>
        /// Retorna View para criação do Agendamento
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["ClinicaId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "J"), "PessoaId", "DescNomeA");
            ViewData["PacienteId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "F"), "PessoaId", "DescNomeA");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Cria Agendamento
        /// </summary>
        /// <param name="agenda">Agenda</param>
        /// <returns>Retorna resposta para o usuário com sucesso ou não da criação</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendaId,DataInicioD,DataFimD,IndrStatusN,ClinicaId,PacienteId")] Agenda agenda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ValidaRegistro(agenda))
                    {
                        _context.Add(agenda);
                        await _context.SaveChangesAsync();
                        ViewData["ValidaAgenda"] = "Sucesso";
                        return RedirectToAction(nameof(Index));
                    }
                }
                ViewData["ClinicaId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "J"), "PessoaId", "DescNomeA", agenda.ClinicaId);
                ViewData["PacienteId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "F"), "PessoaId", "DescNomeA", agenda.PacienteId);
                return View(agenda);
            }
            catch(Exception ex)
            {
                ViewData["ValidaAgenda"] = "Erro";
                return View(agenda);
            }
            
        }

        // GET: Agenda/Edit/5
        /// <summary>
        /// Consulta dados a partir de um id
        /// </summary>
        /// <param name="id">Id da Agenda</param>
        /// <returns>Obj da Agenda</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var agenda = await _context.Agenda.FindAsync(id);
                if (agenda == null)
                {
                    return NotFound();
                }
                ViewData["ClinicaId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "J"), "PessoaId", "DescNomeA", agenda.ClinicaId);
                ViewData["PacienteId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "F"), "PessoaId", "DescNomeA", agenda.PacienteId);
                return View(agenda);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            
        }

        // POST: Agenda/Edit/5
        /// <summary>
        /// Edita dados da Consulta
        /// </summary>
        /// <param name="id">Id da Agenda</param>
        /// <param name="agenda">Obj agenda</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaId,DataInicioD,DataFimD,IndrStatusN,ClinicaId,PacienteId")] Agenda agenda)
        {
            if (id != agenda.AgendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.AgendaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicaId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "J"), "PessoaId", "DescNomeA", agenda.ClinicaId);
            ViewData["PacienteId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "F"), "PessoaId", "DescNomeA", agenda.PacienteId);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        /// <summary>
        /// Deletar Consulta
        /// </summary>
        /// <param name="id">ID da agenda</param>
        /// <returns>Retorna para a View para confirmação de exclusão</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var agenda = await _context.Agenda
                    .Include(a => a.Clinica)
                    .Include(a => a.Paciente)
                    .FirstOrDefaultAsync(m => m.AgendaId == id);
                if (agenda == null)
                {
                    return NotFound();
                }

                return View(agenda);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        // POST: Agenda/Delete/5
        /// <summary>
        /// Confirmar exclusão do dado
        /// </summary>
        /// <param name="id">Id da Agenda</param>
        /// <returns>Retorna para o Index da Agenda</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var agenda = await _context.Agenda.FindAsync(id);
                _context.Agenda.Remove(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewData["ErroDelete"] = "Erro";
                return RedirectToAction("Delete", new { id = id });
            }
            
        }

        /// <summary>
        /// Carrega View para Filtro da Agenda
        /// </summary>
        /// <param name="agenda">Agenda</param>
        /// <param name="dataConsulta">Data da Consulta para filtro com Clínicas</param>
        /// <returns>Lista filtrada por parâmetros passados</returns>
        [HttpGet]
        public ActionResult GetConsultaPorParam(Agenda agenda, [FromQuery(Name ="DataConsulta")] DateTime dataConsulta)
        {
            try
            {
                ViewData["ClinicaId"] = new SelectList(_context.Pessoa.Where(x => x.IndrTipoA == "J"), "PessoaId", "DescNomeA", agenda.ClinicaId);

                var listaConsultas = new List<Agenda>();
                listaConsultas = _context.Agenda
                                .Include(a => a.Clinica)
                                .Include(a => a.Paciente).ToList();
                if (agenda.ClinicaId > 0)
                {
                    listaConsultas = listaConsultas.Where(x => x.ClinicaId == agenda.ClinicaId
                            && string.Compare(x.DataInicioD.ToString("d"), dataConsulta.ToString("d")) == 0).ToList();
                    ViewBag.QtdeConsultasDisp = 20 - listaConsultas.Where(x => x.IndrStatusN != EnumStatus.CanceladoClinica && x.IndrStatusN != EnumStatus.CanceladoUsuario).Count();
                }
                else
                {
                    if (agenda.DataInicioD != default)
                    {
                        listaConsultas = listaConsultas.Where(x => x.DataInicioD >= agenda.DataInicioD).ToList();
                    }
                    if (agenda.DataFimD != default)
                    {
                        listaConsultas = listaConsultas.Where(x => x.DataFimD <= agenda.DataFimD).ToList();
                    }
                    if (agenda.IndrStatusN != 0)
                    {
                        listaConsultas = listaConsultas.Where(x => x.IndrStatusN == (EnumStatus)agenda.IndrStatusN).ToList();
                    }
                }
                
                return PartialView("_ListConsultas", listaConsultas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Verifica se aquele Obj existe no banco a partir do Id
        /// </summary>
        /// <param name="id">Id da Agenda</param>
        /// <returns>Retorna boolean</returns>
        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.AgendaId == id);
        }

        /// <summary>
        /// Validação do Registro da Consulta
        /// </summary>
        /// <param name="agenda">obj agenda</param>
        /// <returns></returns>
        private bool ValidaRegistro(Agenda agenda)
        {
            try
            {
                if (validaAgenda.ValidaPacienteConsulta(agenda.PacienteId, agenda.DataInicioD))
                {
                    ViewData["ValidaAgenda"] = "Paciente possui consulta agendada nesta data.";
                    return false;
                }
                else if (validaAgenda.ValidaQtdeConsultaClinica(agenda.ClinicaId, agenda.DataInicioD))
                {
                    ViewData["ValidaAgenda"] = "Clínica já atingiu seu limite diário de consultas.";
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro na validação:" + ex.Message);
            }
        }
    }
}
