﻿using Microsoft.EntityFrameworkCore;
using ProvaTecnicaEAuditoria.Data;
using ProvaTecnicaEAuditoria.Models;

namespace ProvaTecnicaEAuditoria.Repositories
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {

        private EAuditoriaDataContext _auditoriaDataContext;

        public LocacaoRepositorio(EAuditoriaDataContext eAuditoriaDataContext)
        {
            _auditoriaDataContext = eAuditoriaDataContext;
        }

        public IList<Locacao> ObterIntervalo(int pular, int pegar)
        {
            return _auditoriaDataContext.Locacoes.AsNoTracking().Skip(pular).Take(pegar).ToList();
        }

        public Locacao ObterPorId(int id)
        {
            return _auditoriaDataContext.Locacoes.Find(id);
        }

        public void Inserir(Locacao locacao)
        {
            _auditoriaDataContext.Locacoes.Add(locacao);
            _auditoriaDataContext.SaveChanges();
        }

        public void Atualizar(Locacao locacao)
        {
            _auditoriaDataContext.Locacoes.Update(locacao);
            _auditoriaDataContext.SaveChanges();
        }

        public void Deletar(Locacao locacao)
        {
            _auditoriaDataContext.Locacoes.Remove(locacao);
            _auditoriaDataContext.SaveChanges();
        }

        public bool LocacaoValida(int clienteId, int filmeId)
        {
            var clienteExistente = _auditoriaDataContext.Clientes.Any(e => e.Id.Equals(clienteId));
            var filmeExistente = _auditoriaDataContext.Filmes.Any(e => e.Id.Equals(filmeId));

            return clienteExistente && filmeExistente;
        }

        public void Dispose()
        {
            _auditoriaDataContext.Dispose();
        }
    }
}
