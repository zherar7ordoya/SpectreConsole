using Integrador.Abstract;

namespace Integrador.Persistence;

public class CRUD<T> : ICRUD<T> where T : IEntity
{
    private readonly XmlPersister<T> _persister = new();

    public T Create(T entity)
    {
        var entities = _persister.Read();
        entity.Id = entities.Count > 0 ? entities.Max(x => x.Id) + 1 : 1;
        entities.Add(entity);
        _persister.Write(entities);
        return entity;
    }

    public bool Delete(T entity)
    {
        var entities = _persister.Read();
        int removedCount = entities.RemoveAll(x => x.Id == entity.Id);
        return removedCount > 0 && _persister.Write(entities);
    }

    public List<T> Read()
    {
        var entities = _persister.Read();
        return entities;
    }

    public bool Update(T entity)
    {
        var entities = _persister.Read();
        var entityToUpdate = entities.FirstOrDefault(x => x.Id == entity.Id);
        if (entityToUpdate == null) return false;

        var index = entities.IndexOf(entityToUpdate);
        if (index >= 0)
        {
            entities[index] = entity;
        }

        return _persister.Write(entities);
    }
}
