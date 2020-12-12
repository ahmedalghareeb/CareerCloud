using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemCountryCodeLogic
	{
		protected IDataRepository<SystemCountryCodePoco> _repository;
		public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
		{
			_repository = repository;
		}

		protected virtual void Verify(SystemCountryCodePoco[] pocos)
		{

			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (SystemCountryCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.Code))
				{
					exceptions.Add(new ValidationException(900, "can not be empty"));
				}
				if (string.IsNullOrEmpty(poco.Name))
				{
					exceptions.Add(new ValidationException(901, "can not be empty"));
				}
				if (exceptions.Count > 0)
				{
					throw new AggregateException(exceptions);
				}
			}
		}

		public virtual SystemCountryCodePoco Get(string id)
		{
			return _repository.GetSingle(c => c.Code == id);
		}

		public virtual List<SystemCountryCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}

		public virtual void Add(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Add(pocos);
		}

		public virtual void Update(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}

		public void Delete(SystemCountryCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}
	}
}
