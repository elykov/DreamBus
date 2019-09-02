using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayerLibrary.Services
{
    public abstract class AGenericService<T, D> : IGenericService<D>, INotifyPropertyChanged
        where T : class, new()
        where D : class, new()
    {
        
        IGenericRepository<T> repository;
        private readonly IMapper _mapper;

        public event PropertyChangedEventHandler PropertyChanged;

        public AGenericService(IGenericRepository<T> repository)
        {
            this.repository = repository;
            _mapper = GetMapper();
        }

        abstract protected IMapper GetMapper();

        public D Add(D obj)
        {
            try
            {
                T elem = _mapper.Map<T>(obj);
                repository.AddOrUpdate(elem);
                repository.Save();
                return _mapper.Map<D>(elem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public D Delete(int id)
        {
            T elem = repository.Get(id);
            repository.Delete(elem);
            repository.Save();
            return _mapper.Map<D>(elem);
        }

        public IEnumerable<D> FindBy(Expression<Func<D, bool>> predicate)
        {
            try
            {
                var predicateElem = _mapper.Map<Expression<Func<T, bool>>>(predicate);
                return repository.FindBy(predicateElem)
                    .Select(c => _mapper.Map<D>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public D Get(int id)
        {
            T elem = repository.Get(id);
            return _mapper.Map<D>(elem);
        }

        public IEnumerable<D> GetAll()
        {
            return repository.GetAll().Select(elem => _mapper.Map<D>(elem));
        }

        public void Save()
        {
            repository.Save();
        }

        public D Update(D obj)
        {
            T elem = _mapper.Map<T>(obj);
            repository.AddOrUpdate(elem);
            repository.Save();
            return _mapper.Map<D>(elem);
        }
    }
}
