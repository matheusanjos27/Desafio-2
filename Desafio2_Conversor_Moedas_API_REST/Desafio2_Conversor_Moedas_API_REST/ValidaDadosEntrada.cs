using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desafio2_Conversor_Moedas_API_REST
{
    public class ValidaDadosEntrada
    {
        public ValidaDadosEntrada() { }

        /// <summary>
        /// Verifica se a moeda que o usuário deseja converter não é nula.
        /// </summary>
        /// <param name="moedaorigem"></param>
        /// <param name="moedadestino"></param>
        /// <returns></returns>
        public bool ValidaMoedas(string moedaorigem, string moedadestino)
        {
            if (moedaorigem.Length != 3 || moedadestino.Length != 3)
            {
                Console.WriteLine("Moeda de origem e de destino devem ter exatamente 3 caracteres!");
                return false;
            }
            if (moedaorigem == moedadestino)
            {
                Console.WriteLine("Moedas não podem ser iguais!");
                return false;
            }
            if(!Regex.IsMatch(moedaorigem, "^[a-zA-Z]+$") || !Regex.IsMatch(moedadestino, "^[a-zA-Z]+$"))
            {
                Console.WriteLine("Moeda deve conter somente letras");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica o valor que o usuário deseja converter.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ValidaValor(string valor)
        {
            float fvalor = float.Parse(valor);
            if (string.IsNullOrEmpty(valor))
            {
                Console.WriteLine("Valor Inválido, digite novamente!");
                fvalor = 0;
                return false;
            }
            if (!float.TryParse(valor, out fvalor))
            {
                Console.WriteLine("Valor Inválido, digite novamente!");
                fvalor = 0;
                return false;
            }
            if(fvalor <= 0)
            {
                Console.WriteLine("O valor precisa ser maior que 0");
                fvalor = 0;
                return false;
            }
            return true;
        }
    }
}
