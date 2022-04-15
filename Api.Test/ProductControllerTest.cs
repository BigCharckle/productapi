using NUnit.Framework;
using System.Collections.Generic;
using Logic.interfaces;
using ProductApi.Controllers;
using Microsoft.Extensions.Configuration;
using Logic.repositories;
using Models.products;
using System.Threading.Tasks;
using Moq;

namespace ProductApi.Test
{
    public class ProductControllerTest
    {
        private static ProductController _mokCountroller; //for mok test
        private static ProductController _realCountroller; //for unit test
        Product p = new Product();
        Mock<IRepositoryFromExternal<Product>> _mockRepository = new Mock<IRepositoryFromExternal<Product>>();
        Mock<IConfiguration> _mokConfig = new Mock<IConfiguration>();
        private Product[] mokProducts = {
       new Product { id = 1, name = "Eum eaque est aspernatur in.", description = "Voluptatem deserunt suscipit reiciendis a voluptas fugiat mollitia. Totam error praesentium praesentium tempora qui vitae quis laborum. Eius nam eaque minima unde voluptatem repudiandae ut amet.", price = "43.53", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 2, name = "Enim unde quis repellat.", description = "Ad qui vitae a omnis. Sunt voluptas delectus necessitatibus porro ut. Adipisci similique iste similique aut quidem occaecati. Officia inventore quisquam ad neque fugit facere.", price = "31.52", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 3, name = "Incidunt sit et dignissimos.", description = "Corporis velit velit fugiat aut laborum. Molestias velit minima est cumque. Tenetur et quis sapiente. Quia non minus dolores nihil et adipisci harum.", price = "63.72", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 4, name = "Et officia quis quibusdam.", description = "Eaque voluptas qui vel expedita. Esse reprehenderit quibusdam autem voluptatem eius et sed. Inventore qui omnis sit ut. Esse qui et atque quisquam enim qui.", price = "69.72", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 5, name = "Eos voluptas qui culpa a non.", description = "Qui id tempore sit in sit ea. Cumque quos aut vitae quasi quis debitis. Repellat quibusdam ea necessitatibus minima. Itaque debitis ea quaerat.", price = "50.11", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 6, name = "Aut sunt ut aut molestias.", description = "Expedita consequuntur et quia dolores aut incidunt laboriosam consectetur. Corrupti eum aperiam consequatur reiciendis sed dolore velit. Odio id ut quia hic error qui nihil.", price = "64.92", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 7, name = "Sint tenetur earum incidunt.", description = "Omnis voluptatibus iste magnam vero minus inventore nulla eos. Eum quis et atque sit corrupti. Aliquid quia molestiae consequatur tempora ut.", price = "52.42", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 8, name = "Optio ut quis in vero neque.", description = "Consectetur sunt est in veniam provident minus earum. Mollitia earum aut dolorum. Necessitatibus error sit necessitatibus sunt assumenda non voluptas nisi.", price = "89.40", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 9, name = "Ipsam voluptas et adipisci.", description = "Beatae sed aut nostrum vel quod. Ea suscipit delectus qui nostrum consequatur est. Sunt vero labore deserunt voluptatem aliquam. Ea illo et ullam voluptatum amet omnis accusamus.", price = "64.04", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 10, name = "Dolor est autem amet.", description = "Non commodi ipsa optio eius aut dolorem autem. Modi iusto qui mollitia. Qui quidem explicabo saepe iusto occaecati.", price = "101.33", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 11, name = "Quo at corrupti assumenda.", description = "Dolor excepturi et illum. Sit eos iste et voluptatum voluptas et voluptates. Sit necessitatibus harum tempore et eius. Aperiam autem quas voluptatum dolor laborum architecto.", price = "84.03", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 12, name = "Ut illo aut minus possimus.", description = "Neque omnis eligendi molestiae ut. Consequatur nemo minus in totam impedit accusamus ut illo. Provident voluptatibus sit error molestiae commodi qui distinctio. Possimus et quo quia suscipit.", price = "16.46", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 13, name = "Itaque est labore sed id.", description = "Itaque tenetur esse beatae reprehenderit vitae et quisquam. Reprehenderit ipsum omnis illum nobis molestiae eligendi possimus. Aut culpa assumenda fuga.", price = "4.50", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 14, name = "Vel vel quia et quam magni.", description = "Velit architecto aut dolor voluptate autem placeat cum. Voluptatum ut esse aliquam repudiandae id vel excepturi qui. Repellat eaque illum quo eveniet qui voluptas accusantium quas.", price = "92.81", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 15, name = "Quis ab velit dolor velit.", description = "Eius et corrupti laudantium ipsam qui sit. Ut ea mollitia exercitationem veritatis consequatur voluptas non. Inventore ut corrupti dolor qui. Repellat praesentium et est eum quas qui blanditiis.", price = "29.43", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 16, name = "Id et est quae et.", description = "Aliquid expedita occaecati reiciendis laborum quia. Doloribus eum hic doloremque voluptatem mollitia officia. Vero doloremque unde atque. Est iure est aut sed accusamus. Voluptas est aut officia.", price = "14.38", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 17, name = "Voluptas odit est ea.", description = "Ut officia ipsa maxime. Nihil dolorem consectetur voluptatem harum perferendis sed. Aut porro et minima ut sed. Quia inventore distinctio accusamus. Ea aut laborum quia maiores magnam.", price = "47.19", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 18, name = "Est vel ea odit animi hic.", description = "Nostrum temporibus et voluptatem aut et cumque. Neque est possimus voluptatem eaque molestiae. Exercitationem nulla repellendus sint quia id. Aut aut fuga harum dolor.", price = "67.11", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 19, name = "Eveniet nisi animi illum.", description = "Officiis officiis ipsum est. Velit cupiditate ab corporis. Aut doloribus aliquid ea iste quam praesentium fugiat.", price = "58.65", image = "http://placeimg.com/640/480/tech" },
       new Product { id = 20, name = "Et nisi ea nihil eos.", description = "Rem fugit ut soluta dolorem deleniti. Harum velit suscipit ullam.", price = "100.65", image = "http://placeimg.com/640/480/tech" }
        };
        private Product mokCountry = new Product { id = 14, name = "Vel vel quia et quam magni.", description = "Velit architecto aut dolor voluptate autem placeat cum. Voluptatum ut esse aliquam repudiandae id vel excepturi qui. Repellat eaque illum quo eveniet qui voluptas accusantium quas.", price = "92.81", image = "http://placeimg.com/640/480/tech" };

        [SetUp]
        public void Setup()
        {
            List<Product> data = new List<Product>(mokProducts);
            _mockRepository.Setup(m => m.GetFromExternalAsyn(It.IsAny<string>())).Returns(Task.FromResult(data));
            this._mokConfig.Setup(c => c.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);
            //_mokConfig.Setup(m => m.GetValue<string>(It.IsAny<string>())).Returns("url string"); //this won't work as it is static.
            _mokCountroller = new ProductController(_mockRepository.Object, _mokConfig.Object);
           
        }

        [Test]
        public void GetAllProductsMokTest()
        {
            var result = _mokCountroller.GetFromExternalAsyn().Result;
            Assert.AreEqual(result.Count, mokProducts.Length);

        }

        /// <summary>
        /// this should be in Repository unit test. I didnt find the way to inject concret object of Configuration. Will resolve later.
        /// </summary>
        [Test]
        public void GetAllProductsUnitTest()
        {
            var repository = new ProductRepository();
            var result =  repository.GetFromExternalAsyn("https://fakerapi.it/api/v1/products?_quantity=20&_price_max=100&_seed=88");
            var lst = result.Result;
            Assert.AreEqual(lst.Count, 20);  //In real method we retrieve 20 records of fake data from fake api: https://fakerapi.it/api/v1/products?_quantity=20&_price_max=100&_seed=88
        }
    }
}