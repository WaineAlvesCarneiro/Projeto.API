using Microsoft.EntityFrameworkCore;
using System;
using WebApi.ImportarNfe.Models;

namespace WebApi.ImportarNfe.Data
{
    public class DbContextNfe : DbContext
    {
        public DbContextNfe(DbContextOptions<DbContextNfe> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Nfe
            modelBuilder.Entity("WebApi.ImportarNfe.Models.Nfe", b =>
            {
                //infNFe
                b.Property<string>("Chave")
                    .HasColumnType("varchar(45)");

                b.Property<string>("Versao")
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                //<ide>
                b.Property<int>("cUF")
                    .HasColumnType("int");

                b.Property<double>("cNF")
                    .HasColumnType("float");

                b.Property<string>("natOp")
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                b.Property<int>("indPag")
                    .HasColumnType("int");

                b.Property<int>("mod")
                    .HasColumnType("int");

                b.Property<int>("serie")
                    .HasColumnType("int");

                b.Property<double>("nNF")
                    .HasColumnType("float");

                b.Property<DateTime>("dhEmi")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("dhSaiEnt")
                    .HasColumnType("datetime2");

                b.Property<int>("tpNF")
                    .HasColumnType("int");

                b.Property<int>("idDest")
                    .HasColumnType("int");

                b.Property<double>("cMunFG")
                    .HasColumnType("float");

                b.Property<int>("tpImp")
                    .HasColumnType("int");

                b.Property<int>("tpEmis")
                    .HasColumnType("int");

                b.Property<int>("cDV")
                    .HasColumnType("int");

                b.Property<int>("tpAmb")
                    .HasColumnType("int");

                b.Property<int>("finNFe")
                    .HasColumnType("int");

                b.Property<int>("indFinal")
                    .HasColumnType("int");

                b.Property<int>("indPres")
                    .HasColumnType("int");

                b.Property<int>("procEmi")
                    .HasColumnType("int");

                b.Property<string>("verProc")
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                //<emit>
                b.Property<string>("CNPJEmit")
                    .IsRequired()
                    .HasColumnType("varchar(14)");

                b.Property<string>("xNomeEmit")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<string>("xFantEmit")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<string>("xLgrEmit")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<double>("nroEmit")
                    .HasColumnType("float");

                b.Property<string>("xBairroEmit")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<double>("cMunEmit")
                    .HasColumnType("float");

                b.Property<string>("xMunEmit")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<string>("UFEmit")
                    .IsRequired()
                    .HasColumnType("varchar(3)");

                b.Property<string>("CEPEmit")
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                b.Property<double>("cPaisEmit")
                    .HasColumnType("float");

                b.Property<string>("xPaisEmit")
                    .IsRequired()
                    .HasColumnType("varchar(7)");

                b.Property<string>("foneEmit")
                    .IsRequired()
                    .HasColumnType("varchar(16)");

                b.Property<double>("IEEmit")
                    .HasColumnType("float");

                b.Property<int>("CRTEmit")
                    .HasColumnType("int");

                //<dest>
                b.Property<string>("CNPJDest")
                    .IsRequired()
                    .HasColumnType("varchar(14)");

                b.Property<string>("xNomeDest")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<string>("xLgrDest")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<double>("nroDest")
                    .HasColumnType("float");

                b.Property<string>("xCplDest")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<string>("xBairroDest")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<double>("cMunDest")
                    .HasColumnType("float");

                b.Property<string>("xMunDest")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<string>("UFDest")
                    .IsRequired()
                    .HasColumnType("varchar(3)");

                b.Property<string>("CEPDest")
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                b.Property<double>("cPaisDest")
                    .HasColumnType("float");

                b.Property<string>("xPaisDest")
                    .IsRequired()
                    .HasColumnType("varchar(7)");

                b.Property<int>("indIEDestDest")
                    .HasColumnType("int");

                b.Property<double>("IEDest")
                    .HasColumnType("float");

                b.Property<string>("emailDest")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                //<total>
                //<ICMSTot>
                b.Property<decimal>("vBC")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vICMS")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vICMSDeson")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vBCST")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vST")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vProd")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vFrete")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vSeg")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vDesc")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vII")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vIPI")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vPIS")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vCOFINS")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vOutro")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vNF")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vTotTrib")
                    .HasColumnType("decimal(18,2)");

                //<transp
                b.Property<int>("modFrete")
                    .HasColumnType("int");

                //<cobr>
                //<fat>
                b.Property<double>("nFat")
                    .HasColumnType("float");

                b.Property<decimal>("vOrig")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vLiq")
                    .HasColumnType("decimal(18,2)");

                //<infAdic>
                b.Property<string>("infCpl")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.HasKey("Chave");

                b.ToTable("Nfe");
            });
            #endregion

            #region Items
            modelBuilder.Entity("WebApi.ImportarNfe.Models.Items", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Chave")
                    .HasColumnType("varchar(45)");

                b.Property<int>("nItem")
                    .HasColumnType("int");

                b.Property<double>("cProd")
                    .HasColumnType("float");

                b.Property<string>("xProd")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                b.Property<double>("NCM")
                    .HasColumnType("float");

                b.Property<double>("CEST")
                    .HasColumnType("float");

                b.Property<double>("CFOP")
                    .HasColumnType("float");

                b.Property<string>("uCom")
                    .IsRequired()
                    .HasColumnType("varchar(3)");

                b.Property<decimal>("qCom")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vUnCom")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vProd")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("uTrib")
                    .IsRequired()
                    .HasColumnType("varchar(3)");

                b.Property<decimal>("qTrib")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vUnTrib")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("indTot")
                    .HasColumnType("int");

                b.Property<int>("orig")
                    .HasColumnType("int");

                b.Property<double>("CSOSN")
                    .HasColumnType("float");

                b.Property<decimal>("pCredSN")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("vCredICMSSN")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("CSTPis")
                    .HasColumnType("int");

                b.Property<int>("CSTCofins")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Items");
            });
            #endregion

            #region Duplicata
            modelBuilder.Entity("WebApi.ImportarNfe.Models.Duplicata", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Chave")
                    .HasColumnType("varchar(45)");

                b.Property<DateTime>("dVenc")
                    .HasColumnType("datetime2");

                b.Property<double>("nDup")
                    .HasColumnType("float");

                b.Property<int>("qdDup")
                    .HasColumnType("int");

                b.Property<decimal>("vDup")
                    .HasColumnType("decimal(18,2)");

                b.HasKey("Id");

                b.ToTable("Duplicata");
            });
            #endregion
        }

        public DbSet<Nfe> Nfe { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Duplicata> Duplicata { get; set; }
    }
}
