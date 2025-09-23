using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Domain.IRepository.Command;

public interface ICommandRepository<in T> where T : class
{
    public Task<bool> Insert(T entity);
    public Task<bool> Delete(T entity);
    public Task<bool> Update(T entity);
}