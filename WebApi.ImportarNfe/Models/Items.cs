namespace WebApi.ImportarNfe.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        //<det nItem="1">
        //<prod>
        public int nItem { get; set; }
        public double cProd { get; set; }
        //public string cEAN { get; set; }
        public string xProd { get; set; }
        public double NCM { get; set; }
        public double CEST { get; set; }
        public double CFOP { get; set; }
        public string uCom { get; set; }
        public decimal qCom { get; set; }
        public decimal vUnCom { get; set; }
        public decimal vProd { get; set; }
        //public string cEANTrib { get; set; }
        public string uTrib { get; set; }
        public decimal qTrib { get; set; }
        public decimal vUnTrib { get; set; }
        public int indTot { get; set; }
        //<imposto>
        //<ICMS>
        //<ICMSSN101>
        public int orig { get; set; }
        public double CSOSN { get; set; }
        public decimal pCredSN { get; set; }
        public decimal vCredICMSSN { get; set; }
        //<PIS>
        //<PISNT>
        public int CSTPis { get; set; }
        //<COFINS>
        //<COFINSNT>
        public int CSTCofins { get; set; }
    }
}
