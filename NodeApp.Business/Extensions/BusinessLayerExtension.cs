using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodeApp.Business.Services.Abstract;
using NodeApp.Business.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.Business.Extensions
{
    public static class BusinessLayerExtension
    {
        public static void LoadBusinessLayerExtension(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<INoteService, NoteService>();
        }
    }
}
