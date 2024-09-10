using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Model
{
    public class Hotel : ISerializable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int YearOpened { get; set; }
        public Dictionary<int, Apartment> Apartments { get; set; }
        public int Stars {  get; set; }
        public string OwnerJmbg {  get; set; }

        public Hotel() { }
        public Hotel(string id, string name, int yearOpened, Dictionary<int, Apartment> apartments, int stars, string ownerJmbg)
        {
            Id = id;
            Name = name;
            YearOpened = yearOpened;
            Apartments = new Dictionary<int, Apartment>();
            Apartments = apartments;
            Stars = stars;
            OwnerJmbg = ownerJmbg;
        }

        public void FromCSV(string[] values)
        {
            // Populate the basic properties from CSV values
            Id = values[0];
            Name = values[1];
            YearOpened = Convert.ToInt32(values[2]);
            Stars = Convert.ToInt32(values[3]);
            OwnerJmbg = values[4];

            // Clear the existing Apartments dictionary
            //Apartments.Clear();

            // Parse the Apartments CSV string and add to the dictionary
            /*
            string apartmentsCSV = values[5];
            if (!string.IsNullOrEmpty(apartmentsCSV))
            {
                string[] apartmentsArray = apartmentsCSV.Split(';');
                foreach (string apartmentData in apartmentsArray)
                {
                    string[] apartmentValues = apartmentData.Split(',');
                    int apartmentId = Convert.ToInt32(apartmentValues[0]);
                    string apartmentName = apartmentValues[1];

                    Apartments.Add(apartmentId, new Apartment(apartmentId, apartmentName));
                }
            }
            */
        }

        public string[] ToCSV()
        {
            // Convert the basic properties to CSV values
            string[] basicValues = { Id, Name, YearOpened.ToString(), Stars.ToString(), OwnerJmbg };

            // Convert the Apartments dictionary to a CSV string
            
            //string apartmentsCSV = string.Join(";", Apartments.Select(a => $"{a.Key},{a.Value.Name}"));

            // Combine all values into one array
            
            //Array.Copy(basicValues, csvValues, basicValues.Length);
            //csvValues[basicValues.Length] = apartmentsCSV;
            
            return basicValues;
        }
    }
}
