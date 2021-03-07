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
using static CareerCloud.gRPC.Protos.SystemLanguageCodeService;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeService : SystemLanguageCodeServiceBase
    {
        public override Task<SystemLanguageCode> GetSystemLanguageCode(SystemLanguageCodeIdRequest request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
            SystemLanguageCodePoco poco = logic.Get(request.Id);

            if (poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<SystemLanguageCode>(() => { return TranslateFromPoco(poco); });
        }

        public override Task<Empty> CreateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());

            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();

            foreach (SystemLanguageCode proto in request.SystemLanguage)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());

            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();

            foreach (SystemLanguageCode proto in request.SystemLanguage)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }
        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());

            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();

            foreach (SystemLanguageCode proto in request.SystemLanguage)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return new Task<Empty>(() => { return null; });
        }

        private SystemLanguageCode TranslateFromPoco(SystemLanguageCodePoco poco)
        {
            return new SystemLanguageCode()
            {
                 LanguageID= poco.LanguageID,
                 Name = poco.Name,
                 NativeName =poco.NativeName
        };
        }

        private SystemLanguageCodePoco TranslateFromProto(SystemLanguageCode proto)
        {
            return new SystemLanguageCodePoco()
            {
                LanguageID = proto.LanguageID,
                Name = proto.Name,
                NativeName = proto.NativeName
            };
        }
    }
}
