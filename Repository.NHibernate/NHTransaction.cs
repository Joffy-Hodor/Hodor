using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NHibernate;
using HodorTutor.Infrastructure.UnitOfWork;

namespace HodorTutor.Repository.NHibernate
{
	public class NHTransaction
		: Infrastructure.UnitOfWork.ITransaction
	{
		public NHTransaction(global::NHibernate.ITransaction nhTransaction)
		{
			Debug.Assert(nhTransaction != null);

			_nhTransaction = nhTransaction;
			_session = SessionFactory.GetCurrentSession();
		}

		private readonly global::NHibernate.ITransaction _nhTransaction;
		private readonly ISession _session;
		public void Commit()
		{
			try
			{
				_nhTransaction.Commit();
			}
			catch (global::NHibernate.StaleObjectStateException ex)
			{
				_nhTransaction.Rollback();
				throw new ConflictException("変更を確定中に、競合が検出されました。", ex);
			}
			catch
			{
				_nhTransaction.Rollback();
				_session.Clear();

				throw;
			}
		}

		public void Dispose()
		{
			_nhTransaction.Dispose();
		}
	}
}
