namespace Catalog.Infrastructure.Extensions;

public static class BaseEntityCollectionExtensions
{
    public static Guid? GetRandomId(this IEnumerable<BaseEntity>? entities)
    {
        if (entities is null)
            return null;
        
        var ids = entities.Select(e => e.Id)
            .ToArray();
        
        if (ids.Length == 0)
        {
            return null;
        }
        
        var index = Random.Shared.Next(0, ids.Length);
        return ids[index];
    }
}