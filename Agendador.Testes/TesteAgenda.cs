using Agendador.Controllers;
using Agendador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agendador.Testes
{
    [TestClass]
    public class TesteAgenda
    {
        /// <summary>
        /// Instância do Context
        /// </summary>
        private readonly GerenciaContext _context = new GerenciaContext();

        /// <summary>
        /// Member Employee object
        /// </summary>
        /// <returns></returns>
        public Agenda MontaConsulta()
        {
            var agenda = new Agenda()
            {
                DataInicioD = DateTime.Now,
                DataFimD = DateTime.Now.AddHours(1),
                ClinicaId = _context.Pessoa.Where(x => x.IndrTipoA == "J").FirstOrDefault().PessoaId,
                PacienteId = _context.Pessoa.Where(x => x.IndrTipoA == "F").FirstOrDefault().PessoaId,
                IndrStatusN = EnumStatus.AguardandoAtendimento
            };

            return agenda;
        }

        /// <summary>
        /// Criar Consulta
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var agenda = MontaConsulta();
            _context.Add(agenda);
            _context.SaveChanges();
            Assert.IsTrue(agenda.AgendaId > 0);
        }

        /// <summary>
        /// Consultar todos as Consultas
        /// </summary>
        [TestMethod]
        public void Get()
        {
            var list = _context.Agenda.Include(a => a.Clinica).Include(a => a.Paciente).OrderByDescending(x => x.DataInicioD).ToList();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }

        /// <summary>
        /// Editar Consulta
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var agenda = _context.Agenda.Where(x => x.AgendaId == 2).FirstOrDefault();
            Assert.IsTrue(agenda.AgendaId == 2);
            agenda.IndrStatusN = EnumStatus.Atendido;
            _context.Update(agenda);
            _context.SaveChanges();
            agenda = _context.Agenda.Where(x => x.AgendaId == 2).FirstOrDefault();
            Assert.IsTrue(agenda.IndrStatusN == EnumStatus.Atendido);
        }

        /// <summary>
        /// Deletar uma consulta
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var agenda = _context.Agenda.Where(x => x.AgendaId == 2).FirstOrDefault();
            Assert.IsTrue(agenda.AgendaId == 2);
            _context.Remove(agenda);
            _context.SaveChanges();
            agenda = _context.Agenda.Where(x => x.AgendaId == 2).FirstOrDefault();
            Assert.IsNull(agenda);
        }
    }
}
