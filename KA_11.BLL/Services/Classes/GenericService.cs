using Azure.Core;
using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Responses;
using KA_11.DAL.Models;
using KA_11.DAL.Repositories.Classes;
using KA_11.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity>
        where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public int Create(TRequest request)
        {
            {
                var entity = request.Adapt<TEntity>();
                return _repository.Add(entity);
            }

        }

        public int Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return 0;
            return _repository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = _repository.GetAll();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity == null ? default : entity.Adapt<TResponse>();
        }

        public int Update(int id, TRequest request)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return 0;
            var updatedEntity = request.Adapt(entity);
            return _repository.Update(entity);
        }
        public bool ToggleStatus(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) return false;
            entity.status = entity.status == Status.Active ? Status.Inactive : Status.Active;
            _repository.Update(entity);
            return true;
        }


    }
}
