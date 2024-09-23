using AutoDto.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSourceGenerator
{
    public class SourceEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    [DtoFrom(typeof(SourceEntity))]
    public partial class SomeDto
    {
    }
}