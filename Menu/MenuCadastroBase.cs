using System;
using Seven.Repositorios;
using Seven.Interface;

namespace Seven.Menu
{
    public abstract class MenuCadastroBase<T> where T : IEntidadeCadastral
    {
        private string entidade;
        protected BaseReposirorio<T> baseRepositorio;

        protected MenuCadastroBase(string entidade,BaseReposirorio<T> baseRepositorio)
        {
            this.entidade=entidade;
            this.baseRepositorio=baseRepositorio;
        }

        public abstract void Adicionar();

        public void Editar();
        
        public void Listar();
        
        public void Pesquisar();
        
        public void Excluir()
        {
            Console.WriteLine("Favor informar CPF: ");
            var cpfInformado = Console.ReadLine();

            var valorInformado = baseRepositorio.LocalizarCPF(Int64.Parse(cpfInformado));

            if (valorInformado != null)
            {
                baseRepositorio.Excluir(baseRepositorio.LocalizarCPF(Int64.Parse(cpfInformado)));
                Console.WriteLine($"{entidade} não encontrado.\n");
            }

        }

    }
}