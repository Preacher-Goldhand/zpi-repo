using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Model {
    public class Car 
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public int YearOfProduction { get; set; }
    }
}