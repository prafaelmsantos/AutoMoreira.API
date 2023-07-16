﻿namespace AutoMoreira.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        #region Properties

        private readonly IVeiculoService _veiculoService;
        private readonly IWebHostEnvironment _hostEnvironment;

        #endregion

        #region Constructors

        public VeiculosController(IVeiculoService veiculoService, IWebHostEnvironment hostEnvironment)
        {
            _veiculoService = veiculoService;
            _hostEnvironment = hostEnvironment;
        }
        #endregion

        #region CRUD Methods

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            try
            {
                var veiculos = await _veiculoService.GetAllVeiculosAsync(pageParams);
                if (veiculos == null) return NoContent();

                Response.AddPagination(veiculos.CurrentPage, veiculos.PageSize, veiculos.TotalCount, veiculos.TotalPages);

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar veiculos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar veiculos. Erro: {ex.Message}");
            }
        }
        [HttpGet("GetByNovidade")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNovidade()
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculoByNovidadeAsync();
                if (veiculos == null) return NoContent();

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar encontrar novidades. Erro: {ex.Message}");
            }
        }

        [HttpPost("upload-image/{veiculoId}")]
        public async Task<IActionResult> UploadImage(int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(veiculoId);
                if (veiculo == null) return NoContent();

                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    DeleteImage(veiculo.ImagemURL);
                    veiculo.ImagemURL = await SaveImage(file);
                }
                var veiculoRetorno = await _veiculoService.UpdateVeiculo(veiculoId, veiculo);

                return Ok(veiculoRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar foto ao veiculo. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(VeiculoDTO model)
        {
            try
            {
                var veiculo = await _veiculoService.AddVeiculos(model);
                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar veiculos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VeiculoDTO model)
        {
            try
            {
                var veiculo = await _veiculoService.UpdateVeiculo(id, model);
                if (veiculo == null) return NoContent();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar veiculos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
                if (veiculo == null) return NoContent();

                if (await _veiculoService.DeleteVeiculo(id))
                {
                    DeleteImage(veiculo.ImagemURL);
                    return Ok(new { message = "Apagado" });

                }
                else
                {
                    throw new Exception("Veiculo não apagado");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar veiculos. Erro: {ex.Message}");
            }
        }


        // Não é um endpoint e nao pode ser acedido
        // Take pega apenas os primeiros 10 caracteres de um nome grande. Replace substitui o espaço de um nome por um traço
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/Images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);

            }
            return imageName;
        }


        // Não é um endpoint e nao pode ser acedido
        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/Images", imageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
        #endregion
    }
}
