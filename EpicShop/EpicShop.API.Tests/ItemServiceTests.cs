using EpicShop.API.Exceptions;
using EpicShop.API.Interfaces;
using EpicShop.API.Objects;
using EpicShop.API.Services;
using FluentAssertions;
using Moq;

namespace EpicShop.API.Tests;

public class ItemServiceTests
{
    private readonly Mock<IItemRepository> _itemRepositoryMock;
    private readonly ItemService _itemService;
    public ItemServiceTests()
    {
        _itemRepositoryMock = new Mock<IItemRepository>();
        _itemService = new ItemService(_itemRepositoryMock.Object);
    }

    [Fact]
    public async void Get_GivenValidId_ReturnsValidObject()
    {
        // Arrange
        int id = 0;
        string name = "Test";

        _itemRepositoryMock.Setup(m => m.Get(id)).ReturnsAsync(new ItemEntity() { Id = id, Name = name, Price = 100.0m, Quantity = 100});

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
        _itemRepositoryMock.Setup(m => m.Get(id)).ReturnsAsync(new ItemEntity());

        // Act, assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() => _itemService.Get(id));
    }
}