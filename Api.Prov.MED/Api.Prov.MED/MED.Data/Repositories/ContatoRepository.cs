using System;
using System.Collections.Generic;
using System.Text;
using MED.Data.Repositories.Interface;
using Teste.Domain.Entities;
using Teste.Infrastructure.Data.Contexts;

namespace Teste.Infrastructure.Data.Repositories
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(TesteContext context) : base(context) { }
    }
}
