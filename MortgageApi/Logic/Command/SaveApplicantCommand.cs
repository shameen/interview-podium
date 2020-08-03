using System;
using PodiumInterview.MortgageApi.Models;

namespace PodiumInterview.MortgageApi.Logic.Command
{
    public class SaveApplicantCommand : ICommand
    {
        private CreateApplicantModel _applicant;
        private long _userId;

        public SaveApplicantCommand(CreateApplicantModel applicant, long userId)
        {
            _applicant = applicant;
            _userId = userId;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
