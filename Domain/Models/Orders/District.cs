using Domain.Exceptions;
using Domain.Primitives;

namespace Domain.Models.Orders
{
    public class District : Entity
    {
        public string Name { get; private set; }

        public District() { }

        public District(string name)
        {
            Name = name;

            Validate();
        }

        private void Validate()
        {
            if (Name == null)
                throw new FieldIsNullOrEmptyException(nameof(Name));
        }
    }
}
