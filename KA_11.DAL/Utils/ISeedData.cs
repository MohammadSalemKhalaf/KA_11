using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Utils
{
    public interface ISeedData
    {
        Task DataSeedingAsync(); //make it async // this seem as Task<void>  
        Task IdentityDataSeedingAsync();

    }
}
