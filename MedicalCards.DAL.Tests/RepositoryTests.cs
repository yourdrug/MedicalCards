using FluentAssertions;
using MedicalCards.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Tests
{
    public abstract class RepositoryTests<TEntity> : IDisposable
        where TEntity : class
    {
        protected readonly DbContext _context  = new AppContext();
        protected Repository<TEntity> repository;
        protected RepositoryTests(Func<DbContext, Repository<TEntity>> createReporitory)
        {
            _context.Database.EnsureCreated();
            repository = createReporitory(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public async Task GetAll_EntitiesDoNotExist_ReturnsEmptyList()
        {
            var actual = await repository.GetAll();

            actual.Should().BeEmpty();

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
