using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public interface IJobDataInterface
    {
        int GetNextId();
        void AddJobToDatabase(Job job);
        List<Job> GetAllJobs();
        Job GetJob(int id);
    }
}
