using HealthCare.Core.DataAccess.Models.Patient;

namespace HealthCare.Core.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Guid> AddPatient(Patient model);
        Task<Guid> UpdatePatient(Patient model); 
        Task RemovePatient(Guid patientId);
        Task<Patient?> GetById(Guid patientId);
        Task<List<Patient>> PatientSearch(string[] conditions);
        Task<List<Patient>> GetAllPatients();
    }
}
