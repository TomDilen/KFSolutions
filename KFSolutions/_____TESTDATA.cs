using KFSolutionsModel;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutions
{
    public static class _____TESTDATA
    {
        public static void LoadTestData(AppRepository<KfsContext> appRespository)
        {


            #region------------------------------------------- Add Departments------------------------------

            Department newDep1 = new Department()
            {
                DefaultPermissions = 0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111,
                Description = "Administrator"
            };
            appRespository.Department.Add(newDep1);

            Department newDep2 = new Department()
            {
                DefaultPermissions = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111,
                Description = "Sales"
            };
            appRespository.Department.Add(newDep2);


            Department newDep3 = new Department()
            {
                DefaultPermissions = 0b0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111_0000_0000_0000_0000_0000,
                Description = "Ware House"
            };
            appRespository.Department.Add(newDep3);


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
                
                //Adress = new Address()
                //{
                //    Street = "E34",
                //    //HouseNumber = 15,
                //    //HouseNumberAddition = "bus 1",
                //    //Zipcode = "2000",
                //    //City = "Antwaarpe",
                //    //Country = "Belgium",
                //}
            };

            appRespository.Employee.Add(emp1);

            

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
}
