using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml;
using WebApi.XmlImportar.Data;
using WebApi.XmlImportar.Models;

namespace WebApi.XmlImportar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : Controller
    {
        private readonly DbContextXml _context;

        public XmlController(DbContextXml context)
        {
            _context = context;
        }

        #region user

        [HttpPost("user")]
        public async Task<ActionResult> PostImport(User users)
        {
            try
            {
                var xmlFile = "D:/Projetos/Projeto.API/WebApi.XmlImportar/Xml/users.xml";
                var doc = new XmlDocument();
                doc.Load(xmlFile);

                XmlNodeList nodes = doc.SelectNodes("/users/user");

                foreach (XmlNode node in nodes)
                {
                    users.Id = int.Parse(node.Attributes?.GetNamedItem("id")?.Value!);
                    users.Name = node.ChildNodes[0]?.InnerText;
                    users.Occupation = node.ChildNodes[1]?.InnerText;

                    _context.Users.Add(users);
                    await _context.SaveChangesAsync();
                }
                return Ok("Usuários importados para o banco com sucesso.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region continents

        [HttpPost("continents")]
        public async Task<ActionResult> PostImport(Cidades cidades)
        {
            try
            {
                var xmlFile = "D:/Projetos/Projeto.API/WebApi.XmlImportar/Xml/continents.xml";
                var doc = new XmlDocument();
                doc.Load(xmlFile);

                XmlNodeList nodes = doc.SelectNodes("/continents/*/*");

                foreach (XmlNode xmlNode in nodes)
                {
                    cidades.Capital = xmlNode.ChildNodes[0]?.InnerXml;
                    cidades.Population = decimal.Parse(xmlNode.ChildNodes[1]?.InnerXml);

                    _context.Cidades.Add(cidades);
                    await _context.SaveChangesAsync();
                }
                return Ok("Cidades importadas para o banco com sucesso.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
