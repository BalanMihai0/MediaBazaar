using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{

    /// <summary>
    /// this class is mostly used for extracting available jobs to assign
    /// </summary>
    public class Job
    {
        private int id;
        private string jobTitle;
        private double minSalary;
        private double maxSalary;

        #region properties + validation
        public int Id
        {
            get { return id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ID must be greater than 0");
                }
                id = value;
            }
        }

        public string JobTitle
        {
            get { return jobTitle; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Job title cannot be null or empty");
                }
                jobTitle = value;
            }
        }

        public double MinSalary
        {
            get { return minSalary; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Minimum salary must be greater than or equal to 0");
                }
                minSalary = value;
            }
        }

        public double MaxSalary
        {
            get { return maxSalary; }
            private set
            {
                if (value < 0 || value < minSalary)
                {
                    throw new ArgumentException("Maximum salary must be greater than or equal to 0 and greater than or equal to minimum salary");
                }
                maxSalary = value;
            }
        }
        #endregion

        public Job(int id, string jobTitle, double minSalary, double maxSalary)
        {
            Id = id;
            JobTitle = jobTitle;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }

        public override string ToString()
        {
            return this.jobTitle.ToString();
        }
    }
}
