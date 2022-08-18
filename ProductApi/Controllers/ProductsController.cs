using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Modlel;
using ProductApi.Repository;
using ProductApi.ViewModels;

namespace ProductApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManagerRepository _repo;

        public ProductsController(IProductManagerRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> Add(ProductViewModel viewModel)
        {
            var date = DateTime.Now.Year.ToString();
            var year = date.Substring(date.Length - 3);
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 5; i++)
                s = String.Concat(s, random.Next(10).ToString());
            var serialnumber = year + "R" + s;
            var isexist  = await _repo.IsExist(serialnumber);
            while(isexist == true)
            {
                s = string.Empty;
                for (int i = 0; i < 5; i++)
                    s = String.Concat(s, random.Next(10).ToString());
                serialnumber = year + "R" + s;
                isexist = await _repo.IsExist(serialnumber);
            }
            viewModel.SerialNumber = serialnumber;
            Product pro = new Product();
            pro.SerialNumber = viewModel.SerialNumber;
            pro.ArticleName = viewModel.ArticleName;
            pro.CustomerName = viewModel.CustomerName;
            pro.Date = DateTime.Now;
            var pr = await _repo.CreateProduct(pro);
            //return Ok(pr); //return is always in json fromat
            return new JsonResult(new {SerialNumber = pr.SerialNumber });
        }
    }
}
