namespace AutoMoreira.Tests.Infrastructure
{
    public class MarkServiceTests : BaseClassTests
    {
        #region Private variables

        private readonly Mock<IMarkRepository> _markRepositoryMock;
        private readonly IMarkService _markService;

        #endregion

        #region Constructors

        public MarkServiceTests(ITestOutputHelper output) : base(output)
        {
            AutoMoreira.Core.Mapper.AutoMapperProfile myProfile = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            _markRepositoryMock = new Mock<IMarkRepository>(MockBehavior.Strict);
            _markService = new MarkService(_mapper, _markRepositoryMock.Object);
        }

        #endregion

        #region GetAllMarksAsync

        [Fact]
        public async Task GetAllMarksAsync_GetAll_Successfully()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();
            dto.Id = 0;

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryable(dto)));

            // Act
            List<MarkDTO> result = await _markService.GetAllMarksAsync();

            // Assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(MarkBuilder.MarkListDTO(dto));

            _markRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAllMarksAsync_GetAll_NotBreak()
        {
            // Arrange   
            _markRepositoryMock.Setup(x => x.GetAll())
                .Throws(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.GetAllMarksAsync()).Should()
                .ThrowAsync<Exception>();
        }
        #endregion

        #region GetMarkByIdAsync

        [Fact]
        public async Task GetMarkByIdAsync_ValidMark_Successfully()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(MarkBuilder.Mark(dto));

            // Act
            MarkDTO result = await _markService.GetMarkByIdAsync(dto.Id);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);

            _markRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetMarkByIdAsync_MarkNotFoundException_ThrowsExceptionAsync()
        {
            // Arrange   
            Mark? mark = null;

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>()))!.ReturnsAsync(mark);

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.GetMarkByIdAsync(0)).Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task GetMarkByIdAsync_FindByIdAsync_NotBreak()
        {
            // Arrange
            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.GetMarkByIdAsync(0)).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region AddMarkAsync

        [Fact]
        public async Task AddMarkAsync_ValidMark_Successfully()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryableEmpty()));

            _markRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Mark>())).ReturnsAsync(MarkBuilder.Mark(dto));

            // Act
            MarkDTO result = await _markService.AddMarkAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);

            _markRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _markRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Mark>()), Times.Once);      
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task AddMarkAsync_MarkAlreadyExists_ThrowsExceptionAsync()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryable(dto)));

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.AddMarkAsync(dto)).Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task AddMarkAsync_AddAsync_NotBreak()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryableEmpty()));

            _markRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Mark>())).ThrowsAsync(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.AddMarkAsync(dto)).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region UpdateMarkAsync

        [Fact]
        public async Task UpdateMarkAsync_ValidMark_Successfully()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();
            Mark mark = MarkBuilder.Mark(dto);

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(mark);

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryableEmpty()));

            _markRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Mark>())).ReturnsAsync(mark);

            // Act
            MarkDTO result = await _markService.UpdateMarkAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
       
            _markRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _markRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _markRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Mark>()), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task UpdateMarkAsync_MarkNotFoundException_ThrowsExceptionAsync()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();
            Mark? mark = null;

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>()))!.ReturnsAsync(mark);

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.UpdateMarkAsync(dto)).Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task UpdateMarkAsync_MarkAlreadyExistsException_ThrowsExceptionAsync()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>()))!.ReturnsAsync(MarkBuilder.Mark(dto));

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryable(dto)));

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.UpdateMarkAsync(dto)).Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task UpdateMarkAsync_UpdateAsync_NotBreak()
        {
            // Arrange   
            MarkDTO dto = MarkBuilder.MarkDTO();

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(MarkBuilder.Mark(dto));

            _markRepositoryMock.Setup(x => x.GetAll())
                .Returns(new TestAsyncEnumerable<Mark>(MarkBuilder.IQueryableEmpty()));

            _markRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Mark>())).ThrowsAsync(new Exception());

            // Act & Assert
            await FluentActions.Invoking(async () => await _markService.UpdateMarkAsync(dto)).Should()
                .ThrowAsync<Exception>();
        }

        #endregion

        #region DeleteMarksAsync

        [Fact]
        public async Task DeleteMarksAsync_ValidMark_Successfully()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            dto.Id = 0;
            Mark mark = MarkBuilder.Mark(dto);
            List<ResponseMessageDTO> responseMessageDTOs = MarkBuilder.ResponseMessageDTOList(mark);

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(mark);

            _markRepositoryMock.Setup(repo => repo.RemoveAsync(It.IsAny<Mark>())).ReturnsAsync(true);

            // Act
            List<ResponseMessageDTO> results = await _markService.DeleteMarksAsync(new List<int> { dto.Id });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _markRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _markRepositoryMock.Verify(repo => repo.RemoveAsync(It.IsAny<Mark>()), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteMarksAsync_InvalidMark_MarkNotFoundException()
        {
            // Arrange
            Mark? mark = null;
            string errorMessage = DomainResource.MarkNotFoundException;
            List<ResponseMessageDTO> responseMessageDTOs = BaseBuilder.ResponseMessageDTOErrorList(errorMessage);

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>()))!.ReturnsAsync(mark);

            // Act
            List<ResponseMessageDTO> results = await _markService.DeleteMarksAsync(new List<int> { 0 });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _markRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteMarksAsync_FindByIdAsync_DeleteMarksAsyncException()
        {
            // Arrange
            string errorMessage = DomainResource.DeleteMarksAsyncException;

            List<ResponseMessageDTO> responseMessageDTOs = BaseBuilder.ResponseMessageDTOErrorList(errorMessage);

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            List<ResponseMessageDTO> results = await _markService.DeleteMarksAsync(new List<int> { 0 });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _markRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteMarksAsync_RemoveAsync_DeleteMarksAsyncException()
        {
            // Arrange
            MarkDTO dto = MarkBuilder.MarkDTO();
            dto.Id = 0;
            Mark mark = MarkBuilder.Mark(dto);
            string errorMessage = DomainResource.DeleteMarksAsyncException;

            List<ResponseMessageDTO> responseMessageDTOs = BaseBuilder.ResponseMessageDTOErrorList(errorMessage, mark.Name);

            _markRepositoryMock.Setup(repo => repo.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(mark);

            _markRepositoryMock.Setup(repo => repo.RemoveAsync(It.IsAny<Mark>())).ThrowsAsync(new Exception());

            // Act
            List<ResponseMessageDTO> results = await _markService.DeleteMarksAsync(new List<int> { dto.Id });

            // Assert
            results.Should().NotBeEmpty();
            results.Should().BeEquivalentTo(responseMessageDTOs);

            _markRepositoryMock.Verify(repo => repo.FindByIdAsync(It.IsAny<int>()), Times.Once);
            _markRepositoryMock.Verify(repo => repo.RemoveAsync(It.IsAny<Mark>()), Times.Once);
            _markRepositoryMock.VerifyNoOtherCalls();
        }
        #endregion
    }
}
