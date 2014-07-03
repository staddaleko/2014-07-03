using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContosoMedicalUtilities
{
    public class Doctor
    {
        private int _doctorID;
        public int DoctorID
        {
          get { return _doctorID; }
          set { _doctorID = value; }
        }

        private string _firstName;
        public string FirstName
        {
          get { return _firstName; }
          set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
          get { return _lastName; }
          set { _lastName = value; }
        }

        private string _specialty;
        public string Specialty
        {
          get { return _specialty; }
          set { _specialty = value; }
        }

        public Doctor(int doctorID, string firstName, string lastName, string specialty)
        {
            _doctorID = doctorID;
            _firstName = firstName;
            _lastName = lastName;
            _specialty = specialty;
        }
    }
}
