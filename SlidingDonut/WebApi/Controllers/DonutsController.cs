using Core.Models;
using Core.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    public class DonutsController : ApiController
    {
        private readonly IRepository<Donut> donutRepository;

        public DonutsController(IRepository<Donut> donutRepository) => this.donutRepository = donutRepository;

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var donuts = await donutRepository.GetAll();
            var donutDtos = donuts.Select(d => new DonutDto
            {
                Id = d.Id,
                Name = d.Name,
                Toppings = d.Toppings.Select(t => new ToppingDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Color = t.Color
                }).ToList()
            });
            return Ok(donutDtos);
        }
    }
}