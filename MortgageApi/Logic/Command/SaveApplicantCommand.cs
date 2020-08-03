using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PodiumInterview.Database;
using PodiumInterview.MortgageApi.Models;

namespace PodiumInterview.MortgageApi.Logic.Command
{
    public class SaveApplicantCommand : ICommand
    {
        private Applicant _applicantDb;
        private readonly CreateApplicantModel _applicantModel;
        private readonly long _userId;

        public SaveApplicantCommand(CreateApplicantModel applicantModel, long userId)
        {
            _applicantModel = applicantModel;
            _userId = userId;
        }

        public async Task ExecuteAsync()
        {
            using (var db = new PodiumDbContext())
            {
                try
                {
                    _applicantDb = new Applicant()
                    {
                        CreationDate = DateTimeOffset.Now,
                        DateOfBirth = _applicantModel.DateOfBirth,
                        Email = _applicantModel.Email,
                        FirstName = _applicantModel.FirstName,
                        LastName = _applicantModel.LastName,
                        Id = _userId
                    };
                    db.Applicants.Add(_applicantDb);
                    await db.SaveChangesAsync();

                    //TODO: Log
                    System.Diagnostics.Debugger.Log(0,"SaveApplicantCommand", "Saved Applicant with ID " + _userId);
                }
                catch (Exception ex)
                {
                    //TODO: Log
                    System.Diagnostics.Debugger.Log(100, "SaveApplicantCommand", "Error saving Applicant " + ex.Message);
                    throw;
                }
            } 
        }
    }
}
