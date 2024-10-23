namespace Application.Exceptions
{
    public class DistrictNotFound : ApplicationLayerException
    {
        public DistrictNotFound(string fieldName)
       : base($"District with name {fieldName} not found.")
        {
        }
    }
}
