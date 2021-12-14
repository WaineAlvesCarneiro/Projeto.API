using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ImportarNfe.Models
{
    public class Nfe
    {
        //infNFe
        [Key]
        public string Chave { get; set; }
        public string Versao { get; set; }
        //<ide>
        public int cUF { get; set; }
        public double cNF { get; set; }
        public string natOp { get; set; }
        public int indPag { get; set; }
        public int mod { get; set; }
        public int serie { get; set; }
        public double nNF { get; set; }
        public DateTime dhEmi { get; set; }
        public DateTime dhSaiEnt { get; set; }
        public int tpNF { get; set; }
        public int idDest { get; set; }
        public double cMunFG { get; set; }
        public int tpImp { get; set; }
        public int tpEmis { get; set; }
        public int cDV { get; set; }
        public int tpAmb { get; set; }
        public int finNFe { get; set; }
        public int indFinal { get; set; }
        public int indPres { get; set; }
        public int procEmi { get; set; }
        public string verProc { get; set; }
        //<emit>
        public string CNPJEmit { get; set; }
        public string xNomeEmit { get; set; }
        public string xFantEmit { get; set; }
        //<enderEmit>
        public string xLgrEmit { get; set; }
        public double nroEmit { get; set; }
        public string xBairroEmit { get; set; }
        public double cMunEmit { get; set; }
        public string xMunEmit { get; set; }
        public string UFEmit { get; set; }
        public string CEPEmit { get; set; }
        public double cPaisEmit { get; set; }
        public string xPaisEmit { get; set; }
        public string foneEmit { get; set; }
        public double IEEmit { get; set; }
        public int CRTEmit { get; set; }
        //<dest>
        public string CNPJDest { get; set; }
        public string xNomeDest { get; set; }
        //<enderDest>
        public string xLgrDest { get; set; }
        public double nroDest { get; set; }
        public string xCplDest { get; set; }
        public string xBairroDest { get; set; }
        public double cMunDest { get; set; }
        public string xMunDest { get; set; }
        public string UFDest { get; set; }
        public string CEPDest { get; set; }
        public double cPaisDest { get; set; }
        public string xPaisDest { get; set; }
        public int indIEDestDest { get; set; }
        public double IEDest { get; set; }
        public string emailDest { get; set; }
        //<total>
        //<ICMSTot>
        public decimal vBC { get; set; }
        public decimal vICMS { get; set; }
        public decimal vICMSDeson { get; set; }
        public decimal vBCST { get; set; }
        public decimal vST { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vDesc { get; set; }
        public decimal vII { get; set; }
        public decimal vIPI { get; set; }
        public decimal vPIS { get; set; }
        public decimal vCOFINS { get; set; }
        public decimal vOutro { get; set; }
        public decimal vNF { get; set; }
        public decimal vTotTrib { get; set; }
        //<transp>
        public int modFrete { get; set; }
        //<cobr>
        //<fat>
        public double nFat { get; set; }
        public decimal vOrig { get; set; }
        public decimal vLiq { get; set; }
        //<infAdic>
        public string infCpl { get; set; }
    }
}
