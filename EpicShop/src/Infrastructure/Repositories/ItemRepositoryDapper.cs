using Domain.Interfaces;
using Domain.Objects;
using System.Data;
using Dapper;

namespace Infrastructure.Repositories;

public class ItemRepositoryDapper : IItemRepository
{
    private const string _tableName = "store";
    private readonly IDbConnection _connection;
    public ItemRepositoryDapper(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<int?> Add(ItemEntity item)
    {
        string sql = $"INSERT INTO {_tableName} (name, price, quantity) VALUES (@name, @price, @quantity) RETURNING id";
        return await _connection.QuerySingleOrDefaultAsync<int>(sql, new { name = item.Name, price = item.Price, quantity = item.Quantity });
    }

    public async Task<ItemEntity> Buy(ItemEntity item)
    {
        string sql = $"SELECT * FROM {_tableName} WHERE id = @id";
        return await _connection.QuerySingleOrDefaultAsync<ItemEntity>(sql) ?? new ItemEntity();
    }

    public async Task<bool> Delete(int id)
    {
        string sql = $"DELETE FROM {_tableName} WHERE id = @id";
        return await _connection.QuerySingleOrDefaultAsync<ItemEntity>(sql, new { id = id }) != null;
    }

    public async Task<IEnumerable<ItemEntity>> Get()
    {
        return await _connection.QueryAsync<ItemEntity>($"SELECT * FROM {_tableName}");
    }

    public async Task<ItemEntity> Get(int id)
    {
        return await _connection.QuerySingleOrDefaultAsync<ItemEntity>($"SELECT * FROM {_tableName} WHERE id = @id", new { id = id }) ?? new ItemEntity();
    }

    public async Task<bool> Update(ItemEntity item)
    {
        string sql = $"UPDATE {_tableName} SET";
        bool args = false;
        if (item.Name != null) { sql += " name = @name"; args = true; }
        if (item.Price != null) { sql += args ? ", " : " " + "price = @price"; args = true; }
        if (item.Quantity != null) { sql += args ? ", " : " " + "quantity = @quantity"; args = true; }

        if (args)
        {
            return await _connection.ExecuteAsync(sql, new { name = item.Name, price = item.Price, quantity = item.Quantity }) == 1;
        }

        return false;
    }
}
