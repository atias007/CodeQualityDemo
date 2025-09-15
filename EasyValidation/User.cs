using EasyValidate.Abstractions;
using EasyValidate.Attributes;

namespace EasyValidation
{
    public partial class User : IGenerate
    {
        [NotNull, NotEmpty]
        public string Name { get; set; }

        [NotNull, NotEmpty, EmailAddress]
        public string Email { get; set; }

        [Range(18, 120)]
        public int Age { get; set; }
    }
}