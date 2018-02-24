using Microsoft.AspNetCore.Mvc;
using senai.ifood.domain.Contracts;
using senai.ifood.domain.Entities;

namespace senai.ifood.webapi.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private IBaseRepository<RestauranteDomain> _restauranteRepository;

        public RestauranteController(IBaseRepository<RestauranteDomain> restauranteRepository){
            _restauranteRepository = restauranteRepository;
        }

        [HttpGet]
        public IActionResult GetAction(){
            //O "new string" ESTA CARREGANDO O ICollections DESSA ENTIDADE
            return Ok(_restauranteRepository.Listar(new string[]{"Produtos"}));
        }


        [HttpGet("{id}")]
        public IActionResult GetAction(int id){
            RestauranteDomain result = _restauranteRepository.BuscarPorId(id);
            if(result!=null){
                return Ok(result);
            }else{
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult PostAction([FromBody]RestauranteDomain restaurante){
            var valida = _restauranteRepository.Inserir(restaurante);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
            }
        }


        [HttpDelete]
        public IActionResult DeleteAction([FromBody]RestauranteDomain restaurante){
            var valida = _restauranteRepository.Deletar(restaurante);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
            }
        }
    }
}