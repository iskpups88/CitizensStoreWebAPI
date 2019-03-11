using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtJsWebApi
{
    public class Citizen
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
