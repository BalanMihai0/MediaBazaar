using DataLibrary;
using SharedLibrary;
using StoreLibrary;
using UserLibrary;

namespace G1_MediaBazaar
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IUserDataInterface userDataInterface = new UserDataHandler();
            IJobDataInterface jobDataInterface = new JobDataHandler();
            IDepartmentsDataInterface departmentDataInterface = new DepartmentDataHandler();
            ILocationsDataInterface locationDataInterface = new LocationDataHandler();
            IWorkshiftDataInterface workshiftDataInterface = new WorkshiftDataHandler();
            IProductDataInterface productDataInterface = new ProductDataHandler();
            IAnnouncementDataInterface announcementDataInterface = new AnnouncementDataHandler();
            IAvailability availabilityDataInterface = new AvailabilityDataHandler();

            MediaBazzar.Initialize(userDataInterface, jobDataInterface, departmentDataInterface, locationDataInterface, workshiftDataInterface, productDataInterface, announcementDataInterface, availabilityDataInterface);
            Application.Run(new Form1());
            //Admin testing
            //Application.Run(new MenuAdministrator());
        }
    }
}