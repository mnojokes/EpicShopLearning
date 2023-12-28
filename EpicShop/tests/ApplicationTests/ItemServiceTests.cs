using AutoFixture;
using Application.Services;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Objects;
using FluentAssertions;
using Moq;

namespace ApplicationTests;

public class ItemServiceTests
{
    private readonly Mock<IItemRepository> _itemRepositoryMock;
    private readonly ItemService _itemService;
    private readonly Fixture _fixture;
    public ItemServiceTests()
    {
        _itemRepositoryMock = new Mock<IItemRepository>();
        _itemService = new ItemService(_itemRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async void Get_GivenValidId_ReturnsValidObject()
    {
        // Arrange
        int id = 0;
        string name = "Test";

        _itemRepositoryMock.Setup(r => r.Get(id)).ReturnsAsync(new ItemEntity() { Id = id, Name = name, Price = 100.0m, Quantity = 100 });

        // Act
        var result = await _itemService.Get(id);

        // Assert
        result.Name.Should().Be(name);
    }

    [Fact]
    public async void Get_GivenInvalidId_ThrowsItemNotFoundException()
    {
        // Arrange
        int id = 0;
        _itemRepositoryMock.Setup(r => r.Get(id)).ReturnsAsync(new ItemEntity());

        // Act, assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() => _itemService.Get(id));
    }

    [Fact]
    public async void Delete_GivenValidId_DoesNotThrowItemNotFoundException()
    {
        // Arrange
        int id = 1;
        _itemRepositoryMock.Setup(r => r.Delete(id)).ReturnsAsync(true);

        // Act and assert
        await _itemService.Invoking(s => s.Delete(id)).Should().NotThrowAsync<ItemNotFoundException>();
        _itemRepositoryMock.Verify(r => r.Delete(id), Times.Once());
    }

    [Fact]
    public async void Delete_GivenInvalidId_ThrowsItemNotFoundException()
    {
        // Arrange
        int id = 0;
        _itemRepositoryMock.Setup(r => r.Delete(id)).ReturnsAsync(false);

        // Act and assert
        await _itemService.Invoking(s => s.Delete(id)).Should().ThrowAsync<ItemNotFoundException>();
        _itemRepositoryMock.Verify(r => r.Delete(id), Times.Once());
    }

    [Fact]
    public async void Add_GivenValidItem_ReturnsId()
    {
        // Arrange
        int id = 1;
        AddItem item = _fixture.Create<AddItem>();
        _itemRepositoryMock.Setup(m => m.Add(It.IsAny<ItemEntity>())).ReturnsAsync(id);

        // Act
        string res = await _itemService.Add(item);

        // Assert
        res.Should().Be($"{{\"id\":\"{id}\"}}");
        _itemRepositoryMock.Verify(r => r.Add(It.Is<ItemEntity>(entity => entity.Name == item.Name && entity.Price == item.Price && entity.Quantity == item.Quantity)), Times.Once());
    }

    [Fact]
    public async void Add_ValidItemUnableToAdd_ThrowsInvalidOperationException()
    {
        // Arrange
        AddItem item = _fixture.Create<AddItem>();
        _itemRepositoryMock.Setup(r => r.Add(item.ToEntity())).ReturnsAsync((int?)null);

        // Act and assert
        await _itemService.Invoking(s => s.Add(item)).Should().ThrowAsync<InvalidOperationException>();
        _itemRepositoryMock.Verify(r => r.Add(It.Is<ItemEntity>(entity => entity.Name == item.Name && entity.Price == item.Price && entity.Quantity == item.Quantity)), Times.Once());
    }

    [Fact]
    public async void Update_ValidItemId_Success()
    {
        // Arrange
        UpdateItem item = _fixture.Create<UpdateItem>();
        _itemRepositoryMock.Setup(r => r.Update(It.IsAny<ItemEntity>())).ReturnsAsync(true);

        // Act and assert
        await _itemService.Invoking(s => s.Update(item)).Should().NotThrowAsync<ItemNotFoundException>();
        _itemRepositoryMock.Verify(r => r.Update(It.Is<ItemEntity>(entity =>
            entity.Id == item.Id && entity.Name == item.Name && entity.Price == item.Price && entity.Quantity == item.Quantity)), Times.Once());
    }

    [Fact]
    public async void Update_InvalidItemId_ThrowsItemNotFoundException()
    {
        // Arrange
        UpdateItem item = _fixture.Create<UpdateItem>();
        _itemRepositoryMock.Setup(r => r.Update(It.IsAny<ItemEntity>())).ReturnsAsync(false);

        // Act and assert
        await _itemService.Invoking(s => s.Update(item)).Should().ThrowAsync<ItemNotFoundException>();
        _itemRepositoryMock.Verify(r => r.Update(It.Is<ItemEntity>(entity =>
            entity.Id == item.Id && entity.Name == item.Name && entity.Price == item.Price && entity.Quantity == item.Quantity)), Times.Once());
    }
}
