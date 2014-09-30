using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HodorTutor.Infrastructure.UnitOfWork;
using NHibernate;

namespace HodorTutor.Repository.NHibernate
{
	public class NHUnitOfWork : IUnitOfWork
	{
		private ISession _session;

		private ISession Session
		{
			get 
			{
				if (_session == null)
					_session = SessionFactory.GetCurrentSession();
				return _session;
			}
		}

		public void RegisterModify(object entity)
		{
			Session.SaveOrUpdate(entity);
		}

		public void RegisterCreate(object entity)
		{
			Session.Save(entity);
		}

		public void RegisterDelete(object entity)
		{
			Session.Delete(entity);
		}

		public void Commit()
		{
			using (global::NHibernate.ITransaction transaction = Session.BeginTransaction())
			{
				try
				{
					transaction.Commit();
				}
				catch (StaleObjectStateException ex)
				{
					transaction.Rollback();
					throw new ConflictException("変更を確定中に、競合が検出されました。", ex);
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
			}
		}

		public Infrastructure.UnitOfWork.ITransaction BeginTransaction()
		{
			return new NHTransaction(Session.BeginTransaction());
		}

		public void Flush()
		{
			Session.Flush();
		}

		public void Clear()
		{
			Session.Clear();
		}
	}
}
