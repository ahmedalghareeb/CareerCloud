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
using static CareerCloud.gRPC.Protos.ApplicantProfileServic;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService : ApplicantProfileServicBase
    {
        public override Task<ApplicantProfile> GetApplicantProfile(ApplicantProfileIdRequest request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            ApplicantProfilePoco poco = logic.Get(Guid.Parse(request.Id));

            if (poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<ApplicantProfile>(() => { return TranslateFromPoco(poco); });
        }

        public override Task<Empty> CreateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach(ApplicantProfile proto in request.AppProfile)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach (ApplicantProfile proto in request.AppProfile)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach (ApplicantProfile proto in request.AppProfile)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        private ApplicantProfile TranslateFromPoco(ApplicantProfilePoco poco)
        {
            return new ApplicantProfile()
            {
                 Id = poco.Id.ToString(),
                 Login = poco.Login.ToString(),
                 CurrentSalary = (double)poco.CurrentSalary,
                 CurrentRate = (double)poco.CurrentRate,
                 Currency = poco.Currency,
                 Country =poco.Country,
                 Province = poco.Province,
                 Street = poco.Province,
                 City = poco.City,
                 PostalCode = poco.PostalCode
        };
        }

        private ApplicantProfilePoco TranslateFromProto(ApplicantProfile proto)
        {
            return new ApplicantProfilePoco()
            {
                Id = Guid.Parse(proto.Id),
                Login = Guid.Parse(proto.Login),
                CurrentSalary = (decimal?)proto.CurrentSalary,
                CurrentRate = (decimal?)proto.CurrentRate,
                Currency = proto.Currency,
                Country = proto.Country,
                Province = proto.Province,
                Street = proto.Province,
                City = proto.City,
                PostalCode = proto.PostalCode
            };
        }
    }
}
