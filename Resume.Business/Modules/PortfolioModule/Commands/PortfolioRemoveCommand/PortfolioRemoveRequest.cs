using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Commands.PortfolioRemoveCommand
{
    public class PortfolioRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
