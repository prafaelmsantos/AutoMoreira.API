﻿namespace AutoMoreira.Tests.Infrastructure
{
    public class ModelServiceTests : BaseClassTests
    {
        #region Private variables

        private readonly Mock<IModelRepository> _modelRepositoryMock;
        private readonly IModelService _modelService;

        #endregion

        #region Constructors

        public ModelServiceTests(ITestOutputHelper output) : base(output)
        {
            AutoMoreira.Core.Mapper.AutoMapperProfile myProfile = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            _modelRepositoryMock = new Mock<IModelRepository>(MockBehavior.Strict);
            _modelService = new ModelService(Mapper, _modelRepositoryMock.Object);
        }

        #endregion

        #region GetAllModelsAsync

        [Fact]
        public async Task GetAllModelsAsync_GetAll_Successfully()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Id = 0;

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryable(dto)));

            // Act
            List<ModelDTO> result = await _modelService.GetAllModelsAsync();

            // Assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(ModelBuilder.ModelDTOList(dto));

            _modelRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllModelsAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange   
            _modelRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.GetAllModelsAsync()).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.GetAllModelsAsyncException} {ExceptionBuilder.ExceptionMessage}");
        }
        #endregion

        #region GetModelByIdAsync

        [Fact]
        public async Task GetModelByIdAsync_ValidModel_Successfully()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Id = 0;

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryable(dto)));

            // Act
            ModelDTO result = await _modelService.GetModelByIdAsync(dto.Id);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
            result.MarkId.Should().Be(dto.MarkId);

            _modelRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetModelByIdAsync_ModelNotFoundException_ThrowsExceptionAsync()
        {
            // Arrange   
            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryableEmpty()));

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.GetModelByIdAsync(It.IsAny<int>())).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.GetModelByIdAsyncException} {DomainResource.ModelNotFoundException}");
        }

        [Fact]
        public async Task GetModelByIdAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange
            _modelRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.GetModelByIdAsync(It.IsAny<int>())).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.GetModelByIdAsyncException} {ExceptionBuilder.ExceptionMessage}");
        }

        #endregion

        #region GetModelsByMarkIdAsync

        [Fact]
        public async Task GetModelsByMarkIdAsync_GetAll_Successfully()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Id = 0;

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryable(dto)));

            // Act
            List<ModelDTO> result = await _modelService.GetModelsByMarkIdAsync(dto.MarkId);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(ModelBuilder.ModelDTOList(dto));

            _modelRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetModelsByMarkIdAsync_GetAllNotBreak_ThrowsExceptionAsync()
        {
            // Arrange   
            _modelRepositoryMock.Setup(x => x.GetAll()).Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.GetModelsByMarkIdAsync(It.IsAny<int>())).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.GetModelsByMarkIdAsyncException} {ExceptionBuilder.ExceptionMessage}");
        }
        #endregion

        #region AddModelAsync

        [Fact]
        public async Task AddModelAsync_ValidModel_Successfully()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryableEmpty()));

            _modelRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Model>())).ReturnsAsync(ModelBuilder.Model(dto));

            // Act
            ModelDTO result = await _modelService.AddModelAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
            result.MarkId.Should().Be(dto.MarkId);

            _modelRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _modelRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Model>()), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddModelAsync_ModelAlreadyExists_ThrowsExceptionAsync()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryable(dto)));

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.AddModelAsync(dto)).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.AddModelAsyncException} {DomainResource.ModelAlreadyExistsException}");
        }

        [Fact]
        public async Task AddModelAsync_AddAsyncNotBreak_ThrowsExceptionAsync()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryableEmpty()));

            _modelRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Model>())).ThrowsAsync(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.AddModelAsync(dto)).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.AddModelAsyncException} {ExceptionBuilder.ExceptionMessage}");
        }

        #endregion

        #region UpdateModelAsync

        [Fact]
        public async Task UpdateModelAsync_ValidModel_Successfully()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(ModelBuilder.Model(dto));

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryableEmpty()));

            _modelRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Model>())).ReturnsAsync(ModelBuilder.Model(dto));

            // Act
            ModelDTO result = await _modelService.UpdateModelAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
            result.MarkId.Should().Be(dto.MarkId);

            _modelRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _modelRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _modelRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Model>()), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task UpdateModelAsync_ModelNotFoundException_ThrowsExceptionAsync()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null!);

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.UpdateModelAsync(dto)).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.UpdateModelAsyncException} {DomainResource.ModelNotFoundException}");
        }

        [Fact]
        public async Task UpdateModelAsync_ModelAlreadyExistsException_ThrowsExceptionAsync()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>()))!.ReturnsAsync(ModelBuilder.Model(dto));

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryable(dto)));

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.UpdateModelAsync(dto)).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.UpdateModelAsyncException} {DomainResource.ModelAlreadyExistsException}");
        }

        [Fact]
        public async Task UpdateModelAsync_UpdateAsyncNotBreak_ThrowsExceptionAsync()
        {
            // Arrange   
            ModelDTO dto = ModelBuilder.ModelDTO();

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(ModelBuilder.Model(dto));

            _modelRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Model>(ModelBuilder.IQueryableEmpty()));

            _modelRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Model>())).ThrowsAsync(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _modelService.UpdateModelAsync(dto)).Should()
                .ThrowAsync<Exception>()
                .WithMessage($"{DomainResource.UpdateModelAsyncException} {ExceptionBuilder.ExceptionMessage}");
        }

        #endregion

        #region DeleteModelsAsync

        [Fact]
        public async Task DeleteModelsAsync_ValidModel_Successfully()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Id = 0;
            Model model = ModelBuilder.Model(dto);
            List<ResponseMessageDTO> responseMessageDTOs = ResponseMessageDTOBuilder.ResponseMessageDTOList(null, model.Id, model.Name);

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(model);

            _modelRepositoryMock.Setup(repo => repo.RemoveAsync(It.IsAny<Model>())).ReturnsAsync(true);

            // Act
            List<ResponseMessageDTO> results = await _modelService.DeleteModelsAsync(new List<int> { dto.Id });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _modelRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _modelRepositoryMock.Verify(repo => repo.RemoveAsync(It.IsAny<Model>()), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();

        }

        [Fact]
        public async Task DeleteModelsAsync_InvalidModel_ModelNotFoundException()
        {
            // Arrange
            Model? model = null;
            string errorMessage = DomainResource.ModelNotFoundException;
            List<ResponseMessageDTO> responseMessageDTOs = ResponseMessageDTOBuilder.ResponseMessageDTOList(errorMessage);

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>()))!.ReturnsAsync(model);

            // Act
            List<ResponseMessageDTO> results = await _modelService.DeleteModelsAsync(new List<int> { 0 });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _modelRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteModelsAsync_FindByIdAsync_DeleteModelsAsyncException()
        {
            // Arrange
            string errorMessage = DomainResource.DeleteModelsAsyncException;

            List<ResponseMessageDTO> responseMessageDTOs = ResponseMessageDTOBuilder.ResponseMessageDTOList(errorMessage);

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            List<ResponseMessageDTO> results = await _modelService.DeleteModelsAsync(new List<int> { 0 });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _modelRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteModelsAsync_RemoveAsync_DeleteModelsAsyncException()
        {
            // Arrange
            ModelDTO dto = ModelBuilder.ModelDTO();
            dto.Id = 0;
            Model model = ModelBuilder.Model(dto);
            string errorMessage = DomainResource.DeleteModelsAsyncException;

            List<ResponseMessageDTO> responseMessageDTOs = ResponseMessageDTOBuilder.ResponseMessageDTOList(errorMessage, model.Id, model.Name);

            _modelRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(model);

            _modelRepositoryMock.Setup(repo => repo.RemoveAsync(It.IsAny<Model>())).ThrowsAsync(new Exception());

            // Act
            List<ResponseMessageDTO> results = await _modelService.DeleteModelsAsync(new List<int> { dto.Id });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _modelRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _modelRepositoryMock.Verify(repo => repo.RemoveAsync(It.IsAny<Model>()), Times.Once);
            _modelRepositoryMock.VerifyNoOtherCalls();
        }
        #endregion
    }
}
