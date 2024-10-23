namespace Application.Exceptions
{
    public class DistrictNotFound : Exception
    {
        public DistrictNotFound(string fieldName)
       : base($"District with name {fieldName} not found.")
        {
        }
    }
}
