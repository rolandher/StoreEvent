using System.Text.Json.Serialization;

namespace Domain.ObjectValues.ObjectValuesProduct
{
    public class ProductObjectName
    {
        
        public string Name { get; set; }

        public ProductObjectName(string name)
        {
            Name = name;
        }
    }
}
