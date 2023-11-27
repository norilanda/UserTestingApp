﻿using Ardalis.Specification.EntityFrameworkCore;
using UserTestingApp.DAL.Context;
using UserTestingApp.DAL.Interfaces;

namespace UserTestingApp.DAL.Services;

public class EfRepository<T> : RepositoryBase<T>, IGenericRepository<T> where T : class
{
    public EfRepository(UserTestingAppContext dbContext) : base(dbContext)
    {
    }
}
