using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class JobsManager
    {
        // this is not session based, jobs are the same for everyone
        // no dangers of session overiding list / deleting info

        private readonly IJobDataInterface _jobDataStorage;
        public JobsManager(IJobDataInterface dataInterface)
        {
            _jobDataStorage = dataInterface;
        }

        public void AddJob(string jobTitle, double minSalary, double maxSalary)
        {
            _jobDataStorage.AddJobToDatabase(new Job(_jobDataStorage.GetNextId(), jobTitle, minSalary, maxSalary));
        }

        public List<Job> GetAllJobs()
        {
            return _jobDataStorage.GetAllJobs();
        }
        public Job GetJob(int id)
        {
            return _jobDataStorage.GetJob(id);
        }
    }
}
