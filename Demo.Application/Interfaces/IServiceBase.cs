using Demo.Application.ViewModels.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        ResultWrap<TEntity> Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        ResultWrap<TEntity> Update(TEntity obj);
        ResultWrap<TEntity> Remove(Guid id);
        void Dispose();
    }
}
