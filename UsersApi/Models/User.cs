using System;


namespace UsersApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

      //public int Age { get; set; } 
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = GetAge(DateTime.Today, Birthday);
               //age = (DateTime.Today - Birtday).Days/365;
            }
        }
        public int GetAge(DateTime d1, DateTime d2)
        {
            var years = 0;
            while (d1.AddYears(years) <= d2)
                years++;

            return years - 1;
             
        }
      

    }
}
