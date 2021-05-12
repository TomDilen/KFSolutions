using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{


    public static class _____TESTDATA
    {
        public static void LoadTestDatas(object appRespository)
        {


            #region------------------------------------------- Add Departments------------------------------

            Department newDep1 = new Department()
            {
                DefaultPermissions = 77,
                Description = "Administrator"
            };
            //appRespository.Department.Add(newDep1);

            Department newDep2 = new Department()
            {
                DefaultPermissions = 88,
                Description = "Sales"
            };
            //appRespository.Department.Add(newDep2);


            Department newDep3 = new Department()
            {
                DefaultPermissions = 4,
                Description = "Ware House"
            };
            //appRespository.Department.Add(newDep3);


            #endregion--------------------------------------------------------------------------------------





            #region------------------------------------------- Add Employees  ------------------------------

            Employee emp1 = new Employee()
            {
                //----------------------people---------
                FirstName = "Joske",
                NameAddition = "De",
                LastName = "Keizer",
                Email = "tomtom@tomtom.com",
                IsMale = true,
                DateOfBirth = new DateTime(1920, 12, 8),
                MobileNumber = "20000020000",
                PhoneNumber = null,
                //--------------------Employee---------
                PassPortID = "011-111-44",
                IBAN = "BE444444444444",
                Id_Department = 1, // TODO : nog bijweerken
                //AppPermissions = UInt64.MaxValue, //TODO
                RecruitedAt = DateTime.Now,
                FiredAt = DateTime.Now,

                //-------------------Adress------------

                Adress = new Address()
                {
                    Street = "E34",
                    //HouseNumber = 15,
                    //HouseNumberAddition = "bus 1",
                    //Zipcode = "2000",
                    //City = "Antwaarpe",
                    //Country = "Belgium",
                }
            };




            #endregion--------------------------------------------------------------------------------------










            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------


        }
    }




























    public partial class Employee : Person{
        //public UInt64 AppPermissions { get; set; }

        public DateTime RecruitedAt { get; set; }

        public DateTime? FiredAt { get; set; }
        //=========================================================worden in de acceslayer aangemaakt
        [Required]
        [MaxLength(20)]
        public string Password { get; set; } //random bij een nieuwe

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(15)]
        public string UserName { get; set; } //random bij een nieuwe


        public bool IsPaswordUsernameResseted { get; set; } //bij nieuwe, of passwoord verloren
        //===========================================================================================
    }
    public partial class Person : DBentity
    {
        //=======================navigation properties=============//
        public virtual Address Adress { get; set; }
        public  int? Id_Adress { get; set; }
    }
    public partial class Address : DBentity { }
}
