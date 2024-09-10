using BookingApp.Serializer;
using System;
using System.Web;


namespace BookingApp.Model
{
    public class Apartment : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int MaxCapacity { get; set; }

        public Apartment() { }

        public Apartment(int id, string name, string description, int numberOfRooms, int maxCapacity)
        {
            Id = id;
            Name = name;
            Description = description;
            NumberOfRooms = numberOfRooms;
            MaxCapacity = maxCapacity;
        }

        public Apartment(int id, string name)
        {
            Id = id;
            Name = name;
            Description = "0";
            NumberOfRooms=0;
            MaxCapacity=0;
        }


        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Description = values[2];
            NumberOfRooms = Convert.ToInt32(values[3]);
            MaxCapacity = Convert.ToInt32(values[4]);
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Name, Description, NumberOfRooms.ToString(), MaxCapacity.ToString() };
            return csvValues;
        }
    }
}
