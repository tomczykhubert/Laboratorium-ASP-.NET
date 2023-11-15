﻿using Data.Entities;
using Laboratorium_3.Models;
using Microsoft.EntityFrameworkCore;

public class MemoryContactService : IContactService
{
    private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();

    private IDateTimeProvider _dateTimeProvider;

    public MemoryContactService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public int Add(Contact item)
    {
        int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
        item.Id = id + 1;
        item.Created = _dateTimeProvider.dateNow();
        _items.Add(item.Id, item);
        return item.Id;
    }

    public void DeleteById(int id)
    {
        _items.Remove(id);
    }

    public List<Contact> FindAll()
    {
        return _items.Values.ToList();
    }

    public List<OrganizationEntity> FindAllOrganizations()
    {
        throw new NotImplementedException();
    }

    public Contact? FindById(int id)
    {
        return _items[id];
    }

    public void Update(Contact item)
    {
        item.Created = _items[item.Id].Created;
        _items[item.Id] = item;
    }

}
