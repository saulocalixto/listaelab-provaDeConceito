using FluentValidation;
using ListElab.Data.Repositorios;
using ListElab.Dominio.Abstrato;

namespace ListElab.Servico.Validacoes
{
    public abstract class ValidadorPadrao<T> : AbstractValidator<T> where T : ObjetoComId
    {
        private IRepositorio<T> _repositorio;

        /// <summary>
        /// Valida se um objeto é válido ou não.
        /// </summary>
        public void Valide(T objeto)
        {
            var resultado = Validate(objeto);

            if (!resultado.IsValid)
            {
                throw new ValidationException(resultado.Errors[0].ErrorMessage);
            }
        }

        /// <summary>
        /// Assina regras para o cenário de itens duplicados.
        /// </summary>
        public void AssineRegraItemNaoDuplicado()
        {
            RuleFor(x => x.Codigo)
                .Must(codigo => !Repositorio().ItemExiste(x => x.Codigo == codigo))
                .WithMessage("Esse item já foi cadastrado");
        }

        protected abstract void AssineRegrasDeCadastro();

        protected abstract void AssineRegrasDeAtualizacao();

        protected abstract void AssineRegrasDeExclusao();

        /// <summary>
        /// Assina regras para o cenário de cadastro.
        /// </summary>
        public void AssineRegrasCadastro()
        {
            AssineRegrasDeCadastro();
            AssineRegraItemNaoDuplicado();
        }

        /// <summary>
        /// Assina regras para o cenário de atualização.
        /// </summary>
        public void AssineRegrasAtualizacao()
        {
            AssineRegrasDeAtualizacao();
        }

        /// <summary>
        /// Assina regras para o cenário de exclusão.
        /// </summary>
        public void AssineRegrasExclusao()
        {
            AssineRegrasDeAtualizacao();
        }

        protected IRepositorio<T> Repositorio()
        {
            return _repositorio ?? (new Repositorio<T>());
        }
    }
}
