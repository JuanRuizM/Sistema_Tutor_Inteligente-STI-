using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STI.Models;

namespace STI.Data
{
    public class DbInitializer
    {
        public static void Initialize(STIContext context)
        {
            context.Database.EnsureCreated();
            if (context.ejercicios.Any())
            {
                return;
            }
            var ejercicios = new ejercicios[]
            {
                //
            };
            foreach (ejercicios a in ejercicios)
            {
                context.ejercicios.Add(a);
            }
            context.SaveChanges();
        }

    }
}
