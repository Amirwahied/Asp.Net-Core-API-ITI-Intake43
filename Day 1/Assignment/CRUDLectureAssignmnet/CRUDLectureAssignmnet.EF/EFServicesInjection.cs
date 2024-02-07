using CRUDLectureAssignmnet.Core.Interface;
using CRUDLectureAssignmnet.EF.Context;
using CRUDLectureAssignmnet.EF.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.EF
{
    public static class EFServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDbConnection(this IServiceCollection services, string? connection)
        {
            return services.AddDbContext<ApplicatioDbContext>(options => options.UseSqlServer(connection));
        }
    }
}
