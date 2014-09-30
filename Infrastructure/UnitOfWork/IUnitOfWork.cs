using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HodorTutor.Infrastructure.UnitOfWork
{
	public interface IUnitOfWork
	{
		void RegisterModify(object entity);
		void RegisterCreate(object entity);	                
		void RegisterDelete(object entity);
		void Commit();
		ITransaction BeginTransaction();
		void Flush();
		void Clear();
	}
}
