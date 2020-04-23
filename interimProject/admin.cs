using System;
using System.Data;
using System.Data.SqlClient;

namespace interimProject
{
    class Admin 
    {
        public string aLastName {get; set;}
        public string aFirstName {get; set;}
        public string aLogin {get; set;}

        public string aPassportID {get; set;}
        public string aGender {get; set;}
        public string aMaritalStatus {get; set;}
        public int aBirthDate {get; set;}
        public string aCitizenship {get; set;}
        public string aSystemPassword {get; set;}
        public Admin()
        {

        }
    }
}