using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;

namespace eNutridealWebservice
{
    public class ServiceNutrideal : IServiceNutrideal
    {
        public static string FILEPATH;

        public ServiceNutrideal()
        {
            FILEPATH = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data");
        }

        public void CalcularPesoIdeal(Dados d)
        {

        }

        public void CalculadoraCalorias(Dados d)
        {
               
        }



        public List<Refeicao> GetRefeicoes()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            List<Refeicao> refeicoes = new List<Refeicao>();
            XmlNodeList refeicaoNodes = doc.SelectNodes("/refeicao");

            foreach (XmlNode refeicaoNode in refeicaoNodes)
            {
                XmlNode nomeRefeicaoNode = refeicaoNode.SelectSingleNode("nomeRestaurante");
                XmlNode itemNode = refeicaoNode.SelectSingleNode("item");
                XmlNode quantidadeNode = refeicaoNode.SelectSingleNode("quantidade");
                XmlNode caloriasNode = refeicaoNode.SelectSingleNode("calorias");

                Refeicao refeicao = new Refeicao(
                    nomeRefeicaoNode.InnerText, itemNode.InnerText,
                    quantidadeNode.InnerText, caloriasNode.InnerText);

                refeicoes.Add(refeicao);

            }
            return refeicoes;
        }


        public void AddRefeicao(Refeicao refeicao)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            XmlNode refeicoesNode = doc.SelectSingleNode("/refeicao");

            XmlElement refeicaoNode = doc.CreateElement("Refeicao");
            XmlElement nomeRefeicaoNode = doc.CreateElement("nomeRefeicao");
            nomeRefeicaoNode.InnerText = refeicao.NomeRefeicao;
            refeicaoNode.AppendChild(nomeRefeicaoNode);
            XmlElement itemNode = doc.CreateElement("item");
            itemNode.InnerText = refeicao.Item;
            refeicaoNode.AppendChild(itemNode);
            XmlElement quantidadeNode = doc.CreateElement("nomeRefeicao");
            quantidadeNode.InnerText = refeicao.Quantidade;
            refeicaoNode.AppendChild(quantidadeNode);
            XmlElement caloriasNode = doc.CreateElement("nomeRefeicao");
            caloriasNode.InnerText = refeicao.Calorias;
            refeicaoNode.AppendChild(caloriasNode);

            doc.Save(FILEPATH);
        }



    }
}


