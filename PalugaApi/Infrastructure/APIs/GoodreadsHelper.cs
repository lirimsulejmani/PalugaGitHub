using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goodreads;

namespace PalugaApi.Infrastructure.APIs
{
    public static class GoodreadsHelper
    {
        public static IGoodreadsClient GetClient()
        {
            return new GoodreadsClient("fDgeHR4fryJiaKCogLibg", "7c1bHkB1LGzp3xM32pgmiqrhtgTbllzDXtz9QHxE");
        }

       
    }
}
