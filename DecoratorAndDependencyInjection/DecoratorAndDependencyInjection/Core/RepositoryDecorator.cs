using System.Collections.Generic;

namespace DecoratorAndDependencyInjection.Core
{
    internal abstract class RepositoryDecorator : IRepository
    {
        protected IRepository BaseRepository { get; }

        public RepositoryDecorator(IRepository repository) => BaseRepository = repository;

        public virtual IEnumerable<string> GetAllCustomers() => BaseRepository.GetAllCustomers();
    }
}
