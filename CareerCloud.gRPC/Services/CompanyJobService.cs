using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.CompanyJobService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobService : CompanyJobServiceBase
    {
        public override Task<CompanyJob> GetCompanyJob(CompanyJobIdRequest request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
            CompanyJobPoco poco = logic.Get(Guid.Parse(request.Id));
            if (poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Task<CompanyJob>(() => { return TranslateFromPoco(poco); });

        }

        public override Task<Empty> CreateCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach(CompanyJob proto in request.CompanyJob)
            {
                pocos.Add(TranslateFromProto(proto));
            }

            logic.Add(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        public override Task<Empty> UpdateCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
           
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach (CompanyJob proto in request.CompanyJob)
            {
                pocos.Add(TranslateFromProto(proto));
            }

            logic.Update(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        public override Task<Empty> DeleteCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
           
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach (CompanyJob proto in request.CompanyJob)
            {
                pocos.Add(TranslateFromProto(proto));
            }

            logic.Delete(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        private CompanyJob TranslateFromPoco(CompanyJobPoco poco)
        {
            return new CompanyJob()
            {
             Id = poco.Id.ToString(),
             Company = poco.Company.ToString(),
             ProfileCreated = Timestamp.FromDateTime((DateTime)poco.ProfileCreated),
             IsCompanyHidden = poco.IsCompanyHidden,
        };
        }

        private CompanyJobPoco TranslateFromProto(CompanyJob proto)
        {
            return new CompanyJobPoco()
            {
                Id = Guid.Parse(proto.Id),
                Company = Guid.Parse(proto.Company),
                ProfileCreated = proto.ProfileCreated.ToDateTime(),
                IsCompanyHidden = proto.IsCompanyHidden,
            };
        }
    }
}
