using Agendador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendador.Validadores.Agenda
{
    public class ValidaAgenda
    {
        private readonly GerenciaContext _context = new GerenciaContext();

        /// <summary>
        /// Valida se o paciente já tem algo marcado naquela data
        /// </summary>
        /// <returns>True para marcado e False para não marcado</returns>
        public bool ValidaPacienteConsulta(decimal pacienteId, DateTime dataConsulta)
        {
            try
            {
                var existeConsulta = _context.Agenda.ToList().Any(x => x.PacienteId == pacienteId && string.Compare(x.DataInicioD.ToString("d"), dataConsulta.ToString("d")) == 0);
                return existeConsulta;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro na validação de paciente já agendado.");
            }
        }

        /// <summary>
        /// Valida quantidade de Consultas para uma Clínica em um dia.
        /// </summary>
        /// <param name="clinicaId">Id da Clínica</param>
        /// <param name="dataConsulta">Data da Consulta</param>
        /// <returns>True para abaixo do limite e False para não disponível</returns>
        public bool ValidaQtdeConsultaClinica(decimal clinicaId, DateTime dataConsulta)
        {
            try
            {
                var existeConsulta = _context.Agenda.ToList().Where(x => x.ClinicaId == clinicaId && string.Compare(x.DataInicioD.ToString("d"), dataConsulta.ToString("d")) == 0 && (x.IndrStatusN != EnumStatus.CanceladoClinica && x.IndrStatusN != EnumStatus.CanceladoUsuario)) ;
                return existeConsulta.ToList().Count > 20;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na validação de quantidade de consultas da Clínica.");
            }
        }
    }
}
