using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using WebApi.ImportarNfe.Data;
using WebApi.ImportarNfe.Models;

namespace WebApi.ImportarNfe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlController : Controller
    {
        private readonly DbContextNfe _context;

        public XmlController(DbContextNfe context)
        {
            _context = context;
        }

        [HttpPost("nfe")]
        public async Task<ActionResult> PostImportNfe()
        {
            Nfe nfe = new();
            List<Items> items = new();
            List<Duplicata> duplicatas = new();
            try
            {
                XmlReader reader = XmlReader.Create("D:/Projetos/Projeto.API/WebApi.ImportarNfe/Xml/nfe.xml");

                do
                {
                    #region infNFe
                    reader.ReadToFollowing("infNFe");

                    reader.MoveToFirstAttribute();
                    char[] charsToTrim = { 'N', 'F', 'e' };
                    nfe.Chave = reader.Value.TrimStart(charsToTrim);

                    reader.MoveToNextAttribute();
                    nfe.Versao = reader.Value;
                    #endregion

                    #region ide
                    reader.ReadToFollowing("cUF");
                    nfe.cUF = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("cNF");
                    nfe.cNF = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("natOp");
                    nfe.natOp = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("indPag");
                    nfe.indPag = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("mod");
                    nfe.mod = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("serie");
                    nfe.serie = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("nNF");
                    nfe.nNF = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("dhEmi");
                    nfe.dhEmi = reader.ReadElementContentAsDateTime();

                    reader.ReadToFollowing("dhSaiEnt");
                    nfe.dhSaiEnt = reader.ReadElementContentAsDateTime();

                    reader.ReadToFollowing("tpNF");
                    nfe.tpNF = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("idDest");
                    nfe.idDest = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("cMunFG");
                    nfe.cMunFG = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("tpImp");
                    nfe.tpImp = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("tpEmis");
                    nfe.tpEmis = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("cDV");
                    nfe.cDV = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("tpAmb");
                    nfe.tpAmb = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("finNFe");
                    nfe.finNFe = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("indFinal");
                    nfe.indFinal = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("indPres");
                    nfe.indPres = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("procEmi");
                    nfe.procEmi = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("verProc");
                    nfe.verProc = reader.ReadElementContentAsString();
                    #endregion

                    #region emit
                    reader.ReadToFollowing("CNPJ");
                    nfe.CNPJEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("xNome");
                    nfe.xNomeEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("xFant");
                    nfe.xFantEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("xLgr");
                    nfe.xLgrEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("nro");
                    nfe.nroEmit = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("xBairro");
                    nfe.xBairroEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("cMun");
                    nfe.cMunEmit = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("xMun");
                    nfe.xMunEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("UF");
                    nfe.UFEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("CEP");
                    nfe.CEPEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("cPais");
                    nfe.cPaisEmit = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("xPais");
                    nfe.xPaisEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("fone");
                    nfe.foneEmit = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("IE");
                    nfe.IEEmit = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("CRT");
                    nfe.CRTEmit = reader.ReadElementContentAsInt();
                    #endregion

                    #region dest
                    reader.ReadToFollowing("CNPJ");
                    nfe.CNPJDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("xNome");
                    nfe.xNomeDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("xLgr");
                    nfe.xLgrDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("nro");
                    nfe.nroDest = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("xCpl");
                    nfe.xCplDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("xBairro");
                    nfe.xBairroDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("cMun");
                    nfe.cMunDest = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("xMun");
                    nfe.xMunDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("UF");
                    nfe.UFDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("CEP");
                    nfe.CEPDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("cPais");
                    nfe.cPaisDest = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("xPais");
                    nfe.xPaisDest = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("indIEDest");
                    nfe.indIEDestDest = reader.ReadElementContentAsInt();

                    reader.ReadToFollowing("IE");
                    nfe.IEDest = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("email");
                    nfe.emailDest = reader.ReadElementContentAsString();
                    #endregion

                    #region nItem
                    reader.ReadToFollowing("det");
                    do
                    {
                        string ChaveReader = nfe.Chave;

                        reader.MoveToFirstAttribute();
                        int nItemReader = int.Parse(reader.Value);

                        reader.ReadToFollowing("cProd");
                        double cProdReader = reader.ReadElementContentAsDouble();

                        //reader.ReadToFollowing("cEAN");
                        //string cEANReader = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("xProd");
                        string xProdReader = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("NCM");
                        double NCMReader = reader.ReadElementContentAsDouble();

                        reader.ReadToFollowing("CEST");
                        double CESTReader = reader.ReadElementContentAsDouble();

                        reader.ReadToFollowing("CFOP");
                        double CFOPReader = reader.ReadElementContentAsDouble();

                        reader.ReadToFollowing("uCom");
                        string uComReader = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("qCom");
                        decimal qComReader = reader.ReadElementContentAsDecimal();

                        reader.ReadToFollowing("vUnCom");
                        decimal vUnComReader = reader.ReadElementContentAsDecimal();

                        reader.ReadToFollowing("vProd");
                        decimal vProdReader = reader.ReadElementContentAsDecimal();

                        //reader.ReadToFollowing("cEANTrib");
                        //string cEANTribReader = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("uTrib");
                        string uTribReader = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("qTrib");
                        decimal qTribReader = reader.ReadElementContentAsDecimal();

                        reader.ReadToFollowing("vUnTrib");
                        decimal vUnTribReader = reader.ReadElementContentAsDecimal();

                        reader.ReadToFollowing("indTot");
                        int indTotReader = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("orig");
                        int origReader = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("CSOSN");
                        double CSOSNReader = reader.ReadElementContentAsDouble();

                        reader.ReadToFollowing("pCredSN");
                        decimal pCredSNReader = reader.ReadElementContentAsDecimal();

                        reader.ReadToFollowing("vCredICMSSN");
                        decimal vCredICMSSNReader = reader.ReadElementContentAsDecimal();

                        reader.ReadToFollowing("CST");
                        int CSTPisReader = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("CST");
                        int CSTCofinsReader = reader.ReadElementContentAsInt();

                        items.Add(new Items()
                        {
                            Chave = ChaveReader,
                            nItem = nItemReader,
                            cProd = cProdReader,
                            //cEAN = cEANReader,
                            xProd = xProdReader,
                            NCM = NCMReader,
                            CEST = CESTReader,
                            CFOP = CFOPReader,
                            uCom = uComReader,
                            qCom = qComReader,
                            vUnCom = vUnComReader,
                            vProd = vProdReader,
                            //cEANTrib = cEANTribReader,
                            uTrib = uTribReader,
                            qTrib = qTribReader,
                            vUnTrib = vUnTribReader,
                            indTot = indTotReader,
                            orig = origReader,
                            CSOSN = CSOSNReader,
                            pCredSN = pCredSNReader,
                            vCredICMSSN = vCredICMSSNReader,
                            CSTPis = CSTCofinsReader,
                            CSTCofins = CSTCofinsReader
                        });
                    } while (reader.ReadToFollowing("det"));
                    #endregion

                    reader = XmlReader.Create("D:/Projetos/Projeto.API/WebApi.ImportarNfe/Xml/nfe.xml");

                    #region total
                    reader.ReadToFollowing("vBC");
                    nfe.vBC = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vICMS");
                    nfe.vICMS = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vICMSDeson");
                    nfe.vICMSDeson = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vBCST");
                    nfe.vBCST = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vST");
                    nfe.vST = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vProd");
                    nfe.vProd = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vFrete");
                    nfe.vFrete = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vSeg");
                    nfe.vSeg = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vDesc");
                    nfe.vDesc = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vII");
                    nfe.vII = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vIPI");
                    nfe.vIPI = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vPIS");
                    nfe.vPIS = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vCOFINS");
                    nfe.vCOFINS = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vOutro");
                    nfe.vOutro = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vNF");
                    nfe.vNF = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vTotTrib");
                    nfe.vTotTrib = reader.ReadElementContentAsDecimal();
                    #endregion

                    #region transp
                    reader.ReadToFollowing("modFrete");
                    nfe.modFrete = reader.ReadElementContentAsInt();
                    #endregion

                    #region cobr-fat
                    reader.ReadToFollowing("nFat");
                    nfe.nFat = reader.ReadElementContentAsDouble();

                    reader.ReadToFollowing("vOrig");
                    nfe.vOrig = reader.ReadElementContentAsDecimal();

                    reader.ReadToFollowing("vLiq");
                    nfe.vLiq = reader.ReadElementContentAsDecimal();
                    #endregion

                    #region cob-dup
                    reader.ReadToFollowing("dup");
                    do
                    {
                        string ChaveDupReader = nfe.Chave;

                        reader.MoveToFirstAttribute();
                        int qdDupReader = int.Parse(reader.Value);

                        reader.ReadToFollowing("nDup");
                        double nDupReader = reader.ReadElementContentAsDouble();

                        reader.ReadToFollowing("dVenc");
                        DateTime dVencReader = reader.ReadElementContentAsDateTime();

                        reader.ReadToFollowing("vDup");
                        decimal vDupReaderReader = reader.ReadElementContentAsDecimal();

                        duplicatas.Add(new Duplicata()
                        {
                            Chave = ChaveDupReader,
                            qdDup = qdDupReader,
                            nDup = nDupReader,
                            dVenc = dVencReader,
                            vDup = vDupReaderReader
                        });
                    } while (reader.ReadToFollowing("dup"));
                    #endregion

                    reader = XmlReader.Create("D:/Projetos/Projeto.API/WebApi.ImportarNfe/Xml/nfe.xml");

                    #region infAdic
                    reader.ReadToFollowing("infCpl");
                    nfe.infCpl = reader.ReadElementContentAsString();
                    #endregion
                } while (reader.ReadToFollowing("infNFe"));

                _context.Nfe.Add(nfe);

                foreach (var item in items)
                {
                    _context.Items.Add(item);
                }

                foreach (var duplicata in duplicatas)
                {
                    _context.Duplicata.Add(duplicata);
                }

                await _context.SaveChangesAsync();

                return Ok("NFe importada para o banco com sucesso.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
