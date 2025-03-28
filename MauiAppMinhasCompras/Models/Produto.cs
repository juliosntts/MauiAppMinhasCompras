using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        private string _descricao;
        private double _quantidade;
        private double _preco;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }
                _descricao = value;
            }
        }
        public double Quantidade { 
            get => _quantidade;
            set 
            {
                if (value <= 0)
                {
                    throw new Exception("Por favor, preencha uma quantidade valida");
                }
                _quantidade = value;
            }
        }
        public double Preco { 
            get => _preco;
            set 
            {
                if (value <= 0)
                {
                    throw new Exception("Por favor, preencha um preço valido");
                }
                _preco = value;
            }
        }
        public double Total { get => Quantidade * Preco; }
    }
}
