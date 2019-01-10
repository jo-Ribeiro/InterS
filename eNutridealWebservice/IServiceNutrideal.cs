using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace eNutridealWebservice
{

    [ServiceContract]
    public interface IServiceNutrideal
    {
        // calculadora peso ideal

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "pesoideal")]
        [Description("Calcula o peso ideal")]
        double CalcularPesoIdeal(Dados d);

        // Calculadora Calorias

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "calorias")]
        [Description("Calcula as calorias")]
        double CalculadoraCalorias(Dados d);


        // Get refeicao
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes")]
        [Description("Todas as refiecoes apresentadas na base de dados")]
        List<Refeicao> GetRefeicoes();

        // add refeicao

        [OperationContract]
        [WebInvoke(Method = "Post", UriTemplate = "/refeicoes")]
        [Description("Adicionar todos as refeicoes")]
        void AddRefeicao(Refeicao refeicao);

      
    }

    [DataContract]
    public class Dados
    {
        [DataMember]
        public int Idade { get; set; }

        [DataMember]
        public double Altura { get; set; }

        [DataMember]
        public double Peso { get; set; }

        [DataMember]
        public String Sexo { get; set; }

    }

    [DataContract]
    public class Refeicao
    {
        public Refeicao(string nomeRefeicao, string item, string quantidade, string calorias)
        {
            this.NomeRefeicao = nomeRefeicao;
            this.Item = item;
            this.Quantidade = quantidade;
            this.Calorias = calorias;
        }

        [DataMember]
        public string NomeRefeicao { get; set; }
        [DataMember]
        public string Item { get; set; }
        [DataMember]
        public string Quantidade { get; set; }
        [DataMember]
        public string Calorias { get; set; }

        public override string ToString()
        {
            string res = string.Empty;
            res += "Nome da Refeição: " + NomeRefeicao + Environment.NewLine;
            res += "Item: " + Item + Environment.NewLine;
            res += "Quantidade: " + Quantidade + Environment.NewLine;
            res += "Calorias: " + Calorias + Environment.NewLine;
            return res;

        }
    }
}