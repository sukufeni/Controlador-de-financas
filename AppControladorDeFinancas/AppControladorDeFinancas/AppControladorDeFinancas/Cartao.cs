using System;
using System.Collections.Generic;

namespace AppControladorDeFinancas
{
    public class Cartao : ICartao
    {
        private List<double> valores;
        private List<string> descricaoValores;
        private string nomeCartao { get; }

        public Cartao(string nomeCartao)
        {
            this.nomeCartao = nomeCartao;
            this.valores= new List<double>();
            this.descricaoValores= new List<string>();
        }

        public string nomecartao()
        {
            return this.nomeCartao;
        }
        public void adicionaItem(string descricaoValor,int valorItem)
        {
            this.valores.Add(valorItem);
            this.descricaoValores.Add(descricaoValor);

        }

        public double somaValores()
        {
            double soma = 0;
            foreach(int item in valores)
            {
                soma += item;
            }
            return soma;
        }

        public void retiraItem(string descricaoItem)
        {
            // pegar o index de acordo com a palavra e retirar pelo index o valor das duas listas e ressomar
        }

        public List<string> listarItems()
        {
            return this.descricaoValores;
        }
    }
}

