using Endeavour.DomainClasses.FormBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.RepositoryInterfaces.FormBuilder
{
    public interface IFormRepository: IReadOnlyEntityRepository<Form>
    {
    }
}
