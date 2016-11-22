using System.Collections.Generic;

namespace AppControladorDeFinancas
{
    interface ICartao
    {
        double somaValores();
        void adicionaItem(string descricaoItem, int valorItem);
        void retiraItem(string descricaoItem);
        List<string> listarItems();
        
    }
}
