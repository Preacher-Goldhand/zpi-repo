using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model {
    public class Owner : User
    {
        public virtual List<Car> Cars {get; set;} = new List<Car>();
    }
}
