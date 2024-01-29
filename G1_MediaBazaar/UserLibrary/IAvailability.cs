namespace UserLibrary
{
    public interface IAvailability
    {
        void AddAvailability(Availability availability);
        void DeleteAvailability(Availability availability);
        List<Availability> AvailaibilityOfEmployee(Employee employee);
    }
}