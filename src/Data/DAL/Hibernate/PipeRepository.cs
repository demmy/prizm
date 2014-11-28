﻿using Data.DAL.Mill;
using Domain.Entity;
using Domain.Entity.Mill;
using NHibernate;
using NHibernate.Exceptions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Hibernate
{
    public class PipeRepository : AbstractHibernateRepository<Guid, Pipe>, IPipeRepository
    {
        [Inject]
        public PipeRepository(ISession session)
            : base(session)
        {

        }

        public Pipe GetByNumber(string number)
        {
            try
            {
                return session.QueryOver<Pipe>().Where(n => n.Number == number).SingleOrDefault();
            }
            catch (GenericADOException ex)
            {
                throw new RepositoryException("GetByNumber", ex);
            }
        }


        public IList<Pipe> GetStored()
        {
            try
            {
                return session.QueryOver<Pipe>().Where(n => n.Status == PipeMillStatus.Stocked).List<Pipe>();
            }
            catch (GenericADOException ex)
            {
                throw new RepositoryException("GetStored", ex);
            }

        }

        public IList<Pipe> GetActiveByNumber(Pipe pipe)
        {
            try
            {
                return session
                    .QueryOver<Pipe>()
                    .Where(x => x.IsActive && x.Number == pipe.Number && x.Id != pipe.Id)
                    .List<Pipe>();
            }
            catch (GenericADOException ex)
            {
                throw new RepositoryException("Get", ex);
            }

        }

    }
}
