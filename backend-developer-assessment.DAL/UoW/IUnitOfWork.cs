using backend_developer_assessment.DAL.Repositories;
using backend_developer_assessment.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_developer_assessment.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository AritstRepository { get; }
        void Commit();

    }
}
