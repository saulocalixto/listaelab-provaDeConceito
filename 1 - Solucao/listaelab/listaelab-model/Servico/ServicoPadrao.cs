using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using listaelab_model.Model;
using listaelab_model.Servico.Contratos;
using listelab_database.Repositorios;
using listelab_database.Repositorios.Contratos;
using Microsoft.Win32.SafeHandles;

namespace listaelab_model.Servico
{
    public abstract class ServicoPadrao<T> : IDisposable, IServicoPadrao<T> where T : Questao
    {
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposed;

        /// <summary>
        /// Retorna repositório do conceito.
        /// </summary>
        /// <returns>Repositório para acesso ao banco de dados.</returns>
        protected abstract RepositorioPadrao<T> Repositorio();

        public void Cadastre(T questao)
        {
           Repositorio().Cadastre(questao);
        }

        public void Atualize(T questao)
        {
            Repositorio().Atualize(questao);
        }

        public void Exclua(int codigo)
        {
            Repositorio().Exclua(codigo);
        }

        public T Consulte(int codigo)
        {
            return Repositorio().Consulte(codigo);
        }

        public List<T> Consulte()
        {
            return Repositorio().Consulte().ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle.Dispose();
                Repositorio().Sessao.Dispose();
            }

            _disposed = true;
        }
    }
}
