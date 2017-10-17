using Core.Models;
using Core.Repositories;
using FakeItEasy;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Controllers;
using WebApi.Dtos;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public class DonutsControllerTests
    {
        [Fact]
        public void Can_create_instance()
        {
            var donutRepository = A.Fake<IRepository<Donut>>();
            var controller = new DonutsController(donutRepository);
            controller.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAll_should_return_all_donuts_in_db_as_list_of_donnutDtos()
        {
            var donutRepository = A.Fake<IRepository<Donut>>();
            A.CallTo(() => donutRepository.GetAll())
             .Returns(new[]
             {
                 new Donut
                 {
                     Id = 1,
                     Name = "Donut1",
                     Toppings = new List<Topping>
                     {
                         new Topping { Id = 1, Name = "SchokoSauce", Color = "Rosa" },
                         new Topping { Id = 2, Name = "SchokoSauce", Color = "Grün" },
                         new Topping { Id = 3, Name = "SchokoSauce", Color = "Blau" },
                     }
                 },
                 new Donut
                 {
                     Id = 2,
                     Name = "Donut2",
                     Toppings = new List<Topping>
                     {
                         new Topping { Id = 4, Name = "Zuckerglasur", Color = "Pink" },
                         new Topping { Id = 5, Name = "Zuckerglasur", Color = "Gelb" },
                         new Topping { Id = 6, Name = "Zuckerglasur", Color = "Schwarz" },
                     }
                 },
                 new Donut
                 {
                     Id = 3,
                     Name = "Donut3",
                     Toppings = new List<Topping>
                     {
                         new Topping { Id = 7, Name = "Streusel", Color = "Orange" },
                         new Topping { Id = 8, Name = "Streusel", Color = "Weiß" },
                         new Topping { Id = 9, Name = "Streusel", Color = "Braun" },
                     }
                 }
             });

            var controller = new DonutsController(donutRepository)
            {
                Request = new HttpRequestMessage()
            };
            controller.Request.Properties["MS_HttpConfiguration"] = new HttpConfiguration();

            var response = await controller.GetAll();
            var result = await response.ExecuteAsync(CancellationToken.None);

            result.StatusCode.ShouldBe(HttpStatusCode.OK);
            var donuts = await result.Content.ReadAsAsync<IEnumerable<DonutDto>>();
            donuts.Count().ShouldBe(3);
            donuts.ShouldContain(d => d.Id == 1 && d.Name == "Donut1");
            donuts.ShouldContain(d => d.Id == 2 && d.Name == "Donut2");
            donuts.ShouldContain(d => d.Id == 3 && d.Name == "Donut3");

            var toppings = donuts.SelectMany(d => d.Toppings);
            toppings.Select(t => t.Id).ShouldBeSubsetOf(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }
    }
}
