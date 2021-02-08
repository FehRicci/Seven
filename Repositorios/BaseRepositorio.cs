using System;
using System.Linq;
using Seven.Interface;

namespace Seven.Repositorios
{
    public abstract class BaseRepositorio<T> where T : ICPFCadastral
    {
        private uint contadorId;
        private List<T> listaDados;

        public BaseRepositorio()
        {
            listaDados = new List<T>();
            contadorId = listaDados.Count;
        }

        public void Adicionar(T entidade)
        {
            entidade.Cpf = contadorId + 1 ;

            listaDados.Add(entidade);
            contadorId++;
        }

        public List<T> Listar()
        {
            return listaDados;
        }

        public T LocalizarCPF(uint cpf)
        {
            var entidade = listaDados.FirstOrDefaul(item => item.Cpf == cpf);
            return entidade;
        }

        public void Excluir(T entidade)
        {
            listaDados.Remove(entidade);
        }
    }
}