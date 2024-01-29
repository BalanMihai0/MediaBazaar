using StoreLibrary;
using UserLibrary;

namespace SharedLibrary
{
    /// <summary>
    /// this class is responsible for accessing all the logic of the manager classes in StoreLibrary
    /// and UserLibrary
    /// this is a '4th layer' of the app, between the logic layer and the UX/UI layer
    /// justification: it is more organized like this
    /// Use this class in forms
    /// static class: not an expandability issue; only one shared logic class should exist
    /// Singleton class: only one instance of this class can be created. Also thread safe using Lazy<T>
    /// </summary>
    public sealed class MediaBazzar
    {
        private static readonly Lazy<MediaBazzar> lazy = new Lazy<MediaBazzar>(() => new MediaBazzar());

        //properties used for singe instance
        public static MediaBazzar Instance { get { return lazy.Value; } }

        public UserManager UserManager { get; private set; }
        public JobsManager JobsManager { get; private set; }
        public DepartmentsManager DepartmentsManager { get; private set; }
        public LocationsManager LocationsManager { get; private set; }
        public WorkshiftManager WorkshiftsManager { get; private set; }
        public ProductManager ProductsManager { get; private set; }

        public AnnouncementManager AnnouncementManager { get; private set; }

        public AvailabilityManager AvailabilityManager { get; private set; }

        private MediaBazzar(IUserDataInterface userDataStorage, IJobDataInterface jobDataStorage,
                            IDepartmentsDataInterface departmentDataStorage, ILocationsDataInterface locationDataStorage, IWorkshiftDataInterface workshiftDataStorage, IProductDataInterface productDataStorage, IAnnouncementDataInterface announcementDataStorage, IAvailability availability)
        {
            UserManager = new UserManager(userDataStorage);
            JobsManager = new JobsManager(jobDataStorage);
            DepartmentsManager = new DepartmentsManager(departmentDataStorage);
            LocationsManager = new LocationsManager(locationDataStorage);
            WorkshiftsManager = new WorkshiftManager(workshiftDataStorage);
            ProductsManager = new ProductManager(productDataStorage);
            AnnouncementManager = new AnnouncementManager(announcementDataStorage);
            AvailabilityManager = new AvailabilityManager(availability);
        }

        //managers need to be constructed with interface
        public static void Initialize(IUserDataInterface userDataStorage, IJobDataInterface jobDataStorage,
                                       IDepartmentsDataInterface departmentDataStorage, ILocationsDataInterface locationDataStorage, IWorkshiftDataInterface workshiftDataStorage, IProductDataInterface productDataStorage, IAnnouncementDataInterface announcementDataStorage, IAvailability availability)
        {
            if (Instance.UserManager != null || Instance.JobsManager != null || Instance.DepartmentsManager != null || Instance.LocationsManager != null || Instance.AnnouncementManager != null)
            {
                throw new Exception("Managers are already initialized");
            }

            Instance.UserManager = new UserManager(userDataStorage);
            Instance.JobsManager = new JobsManager(jobDataStorage);
            Instance.DepartmentsManager = new DepartmentsManager(departmentDataStorage);
            Instance.LocationsManager = new LocationsManager(locationDataStorage);
            Instance.WorkshiftsManager = new WorkshiftManager(workshiftDataStorage);
            Instance.ProductsManager = new ProductManager(productDataStorage);
            Instance.AnnouncementManager = new AnnouncementManager(announcementDataStorage);
			Instance.AvailabilityManager = new AvailabilityManager(availability);
		}
		private MediaBazzar() // prevents another instance of mediabazzar to be created outside of the static
        {
        }

        public static MediaBazzar GetInstance()
        {
            return lazy.Value;
        }
    }
}