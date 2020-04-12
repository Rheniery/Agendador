using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agendador.Models;

namespace Agendador.Controllers
{
    public class PessoasController : Controller
    {
        private readonly GerenciaContext _context;

        public PessoasController(GerenciaContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        /// <summary>
        /// Consulta Todas as pessoas
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoa.ToListAsync());
        }

        // GET: Pessoas/Details/5
        /// <summary>
        /// Consulta pessoa específica
        /// </summary>
        /// <param name="id">Id da Pessoa</param>
        /// <returns>Obj Pessoa</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        /// <summary>
        /// Apresenta View para criação da Pessoa
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        /// <summary>
        /// Criar Pessoa
        /// </summary>
        /// <param name="pessoa">Objeto Pessoa</param>
        /// <returns>Retorna para View com obj criado</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,DescNomeA,DescTelefoneA,DescCpfcnpjA,DescEnderecoA,DescEmailA,IndrTipoA,IndrConvenioA,DescConvenioA,DescNumconvenioA")] Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(pessoa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(pessoa);
            }
            catch(Exception ex)
            {
                ViewData["ValidaPessoa"] = "Não foi possível cadastrar essa pessoa no momento.";
                return View(pessoa);
            }
            
        }

        // GET: Pessoas/Edit/5
        /// <summary>
        /// Apresenta dados da pessoa específica
        /// </summary>
        /// <param name="id">Id da Pessoa</param>
        /// <returns>Obj da Pessoa</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        /// <summary>
        /// Altera dados da Pessoa específica
        /// </summary>
        /// <param name="id">id da pessoa</param>
        /// <param name="pessoa">Obj Pessoa</param>
        /// <returns>Se der certo, redireciona para lista de pessoas</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,DescNomeA,DescTelefoneA,DescCpfcnpjA,DescEnderecoA,DescEmailA,IndrTipoA,IndrConvenioA,DescConvenioA,DescNumconvenioA")] Pessoa pessoa)
        {
            if (id != pessoa.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.PessoaId))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        /// <summary>
        /// Apresenta dados para excluir uma pessoa
        /// </summary>
        /// <param name="id">Id da Pessoa</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        /// <summary>
        /// Exclui uma pessoa
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Retorna para View Index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var pessoa = await _context.Pessoa.FindAsync(id);
                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewData["ValidaPessoa"] = "Ocorreu um erro ao excluir a Pessoa.";
                return RedirectToAction("Delete", new { id = id });
            }
            
        }

        /// <summary>
        /// Verifica se pessoa existe no banco
        /// </summary>
        /// <param name="id">id da pessoa</param>
        /// <returns></returns>
        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.PessoaId == id);
        }
    }
}
