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
    public class TestePessoa
    {
        /// <summary>
        /// Instância do Context
        /// </summary>
        private readonly GerenciaContext _context = new GerenciaContext();

        /// <summary>
        /// Member Employee object
        /// </summary>
        /// <returns></returns>
        public Pessoa MontaPessoaFisica()
        {
            var pessoa = new Pessoa()
            {
                DescNomeA = "Rheniery Mendes dos Santos",
                DescEmailA = "rhenierymendes@gmail.com",
                DescCpfcnpjA = "03415424154",
                IndrTipoA = "F",
                IndrConvenioA = "S",
                DescConvenioA = "UNIMED",
                DescNumconvenioA = "1234560",
                DescTelefoneA = "62982751282"
            };

            return pessoa;
        }

        public Pessoa MontaPessoaJuridica()
        {
            var pessoa = new Pessoa()
            {
                DescNomeA = "Ponto Id",
                DescCpfcnpjA = "11111111111111",
                DescTelefoneA = "9999999999",
                DescEnderecoA = "Av. Jamel Cecílio",
                IndrTipoA = "J"
            };

            return pessoa;
        }

        /// <summary>
        /// Criar Pessoas
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var pessoaFisica = MontaPessoaFisica();
            var pessoaJuridica = MontaPessoaJuridica();
            _context.Add(pessoaFisica);
            _context.Add(pessoaJuridica);
            _context.SaveChanges();
            Assert.IsTrue(pessoaFisica.PessoaId > 0);
            Assert.IsTrue(pessoaJuridica.PessoaId > 0);
        }

        /// <summary>
        /// Consultar todas as Pessoas
        /// </summary>
        [TestMethod]
        public void Get()
        {
            var list = _context.Pessoa.ToList();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }

        /// <summary>
        /// Editar Pessoa
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var pessoaFisica = _context.Pessoa.Where(x => x.PessoaId == 9).FirstOrDefault();
            var pessoaJuridica = _context.Pessoa.Where(x => x.PessoaId == 10).FirstOrDefault();
            Assert.IsTrue(pessoaFisica.PessoaId == 9);
            Assert.IsTrue(pessoaJuridica.PessoaId == 10);
            pessoaFisica.DescConvenioA = "IPASGO";
            pessoaJuridica.DescEnderecoA = "Flamboyant";
            _context.Update(pessoaFisica);
            _context.Update(pessoaJuridica);
            _context.SaveChanges();
            pessoaFisica = _context.Pessoa.Where(x => x.PessoaId == 9).FirstOrDefault();
            pessoaJuridica = _context.Pessoa.Where(x => x.PessoaId == 10).FirstOrDefault();
            Assert.IsTrue(pessoaFisica.DescConvenioA == "IPASGO");
            Assert.IsTrue(pessoaJuridica.DescEnderecoA == "Flamboyant");
        }

        /// <summary>
        /// Deletar pessoa
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var pessoaFisica = _context.Pessoa.Where(x => x.PessoaId == 9).FirstOrDefault();
            var pessoaJuridica = _context.Pessoa.Where(x => x.PessoaId == 10).FirstOrDefault();
            Assert.IsTrue(pessoaFisica.PessoaId == 9);
            Assert.IsTrue(pessoaJuridica.PessoaId == 10);
            _context.Remove(pessoaFisica);
            _context.Remove(pessoaJuridica);
            _context.SaveChanges();
            pessoaFisica = _context.Pessoa.Where(x => x.PessoaId == 9).FirstOrDefault();
            pessoaJuridica = _context.Pessoa.Where(x => x.PessoaId == 10).FirstOrDefault();
            Assert.IsNull(pessoaFisica);
            Assert.IsNull(pessoaJuridica);
        }
    }
}
