using HealthCare.Core.DataAccess.Context;
using HealthCare.Core.DataAccess.Models.Patient;
using HealthCare.Core.Services.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Core.Services
{
    public class PatientService : IPatientService
    {

        private readonly ApiDbContext _context;

        public PatientService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.Where( p=> p.Active.HasValue && p.Active.Value).ToListAsync();
        }

        public async Task<Guid> AddPatient(Patient model)
        {
            model.Id = Guid.NewGuid();
            await _context.Patients.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<Guid> UpdatePatient(Patient model)
        {
            if (model.Id == Guid.Empty)
                throw new ApplicationException("The patient id is empty.");
            var patientToUpdate = await _context.Patients.FindAsync(model.Id);

            if (patientToUpdate == null)
                throw new ApplicationException($"Cannot find patient {model.Id}");

            var properties = typeof(Patient).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            _context.Entry(patientToUpdate).State = EntityState.Modified;
            foreach (var property in properties)
            {
                property.SetValue(property.GetValue(model) ?? property.GetValue(patientToUpdate), patientToUpdate);
            }
            
            await _context.SaveChangesAsync();

            return patientToUpdate.Id;
        }

        public async Task RemovePatient(Guid patientId)
        {
            if (patientId == Guid.Empty)
                throw new ApplicationException("The patient id is empty.");

            Patient patient = new Patient() { Id = patientId };
            _context.Patients.Attach(patient);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<Patient?> GetById(Guid patientId)
        {
            if (patientId == Guid.Empty)
                throw new ApplicationException("The patient id is empty.");

            var result = await _context.Patients.FindAsync(patientId);

            return result;
        }

        public async Task<List<Patient>> PatientSearch(string[] conditions)
        {
            var query = BuildSearchQuery(conditions);

            return await query.ToListAsync();
        }

        private IQueryable<Patient> BuildSearchQuery(string[] conditions)
        {
            IQueryable<Patient> query = _context.Patients;

            foreach (var input in conditions)
            {
                string operation = input.Substring(0, 2);
                DateTime date = DateTime.Parse(input.Substring(2));
                switch (operation)
                {
                    case "eq":
                        query = query.Where(e => e.BirthDate == date);
                        break;
                    case "ne":
                        query = query.Where(e => e.BirthDate != date);
                        break;
                    case "gt":
                        query = query.Where(e => e.BirthDate > date);
                        break;
                    case "lt":
                        query = query.Where(e => e.BirthDate < date);
                        break;
                    case "ge":
                        query = query.Where(e => e.BirthDate >= date);
                        break;
                    case "le":
                        query = query.Where(e => e.BirthDate <= date);
                        break;
                    default:
                        throw new ArgumentException($"Invalid operation: {operation}");
                }
            }

            return query;
        }
    }
}
