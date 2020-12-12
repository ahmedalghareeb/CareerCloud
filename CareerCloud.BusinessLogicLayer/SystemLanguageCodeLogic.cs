using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
	{
		protected IDataRepository<SystemLanguageCodePoco> _repository;
		public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
		{
			_repository = repository;
		}

		protected virtual void Verify(SystemLanguageCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (SystemLanguageCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.LanguageID))
				{
					exceptions.Add(new ValidationException(1000, "can not be empty"));
				}
				if (string.IsNullOrEmpty(poco.Name))
				{
					exceptions.Add(new ValidationException(1001, "can not be empty"));
				}
				if (string.IsNullOrEmpty(poco.NativeName))
				{
					exceptions.Add(new ValidationException(1002, "can not be empty"));
				}
				if (exceptions.Count > 0)
				{
					throw new AggregateException(exceptions);
				}
			}
		}

		public virtual SystemLanguageCodePoco Get(string id)
		{
			return _repository.GetSingle(c => c.LanguageID == id);
		}

		public virtual List<SystemLanguageCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}

		public virtual void Add(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Add(pocos);
		}

		public virtual void Update(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}

		public void Delete(SystemLanguageCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}
	}
}
