using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using KFSolutionsModel;
//using static KFSrepository_EF6.AppRepository<T>;

namespace KFSrepository_EF6
{


    public interface IEmployeeRepository : ITDSrepository<Employee>
    {

        EmployeeRepository.EmployeeLoggedInDTO InloggedEmployee { get; }

        EmployeeRepository.EmployeeLoggedInDTO LogIn(string aUsername, string aPassword);
        EmployeeRepository.EmployeeLoggedInDTO LogOut();

        List< Employee> GetAllForOverview();

        Employee Update(Employee employee);

    }
    //==========================================================================================

    public class EmployeeRepository : TDSrepository<Employee>, IEmployeeRepository
    {
        EmployeeLoggedInDTO _inloggedEmployee = null;

        UITcustomEncrypter encrypter = new UITcustomEncrypter();

        EmployeeLoggedInDTO IEmployeeRepository.InloggedEmployee => _inloggedEmployee;

        //=====================================================================================

        public class EmployeeLoggedInDTO
        {
            public enum Permissions
            {
                EmployeeAddNew = 61,
                EmployeeUpdate = 62,
                EmployeeRemove = 63,
            }

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string NameAddition { get; set; }
            public string LastName { get; set; }

            //public List<int> AppPermissions;
            public List<Permissions> AppPermissions { get; set; }
            public string UserName { get; set; }
        }

        //=====================================================================================
        public EmployeeRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        //=====================================================================================
        public override Employee Add(Employee aEntity)
        {
            EmpAppAccount gevonden = null;

            if (aEntity.EmpAppAccount != null)
            {
                using (KfsContext ctx = new KfsContext(_constring))
                {
                    gevonden = ctx.Set<EmpAppAccount>()
                        .FirstOrDefault(u => u.UserName == aEntity.EmpAppAccount.UserName);
                }
            }

            if(gevonden != null)
            {
                throw new DuplicateNameException($"user with {aEntity.EmpAppAccount.UserName} already exist");
            }


            if (aEntity.EmpAppAccount != null)
            {
                //Console.WriteLine(aEntity.EmpAppAccount.Password + " " + aEntity.EmpAppAccount.UserName);
                string encryptedPW = encrypter.EncriptString(aEntity.EmpAppAccount.Password, aEntity.EmpAppAccount.UserName);
                //string decryptedPW = encrypter.DecriptString(encryptedPW, aEntity.EmpAppAccount.UserName);
                //Console.WriteLine("=================" + decryptedPW);
                aEntity.EmpAppAccount.Password = encryptedPW;
            }
            return base.Add(aEntity);
        }

        //=====================================================================================
        public EmployeeLoggedInDTO LogIn(string aUsername, string aPassword)
        {
            //EmployeeLoggedInDTO terug = null;
            Console.WriteLine(aUsername + "   " + aPassword);

            EmpAppAccount gevonden = null;
            using (KfsContext ctx = new KfsContext(_constring))
            {
                gevonden = ctx.Set<EmpAppAccount>()
                    .Include(nameof(EmpAppAccount.Employee))
                    .FirstOrDefault(u => u.UserName == aUsername);
            }

            if(gevonden != null)
            {
                Console.WriteLine("gebruiker gevonden");

                //kijken of pw overeen komt, zoniet null returnen
                string decryptydPw = encrypter.DecriptString(gevonden.Password, aUsername);
                if (decryptydPw != aPassword)
                {
                    _inloggedEmployee = null;
                    return null;
                }

                //permissies inladen
                //------------------
                // de lsb is is de meest rechtse bit
                // de hsb is de meest linkse bit, maar deze gaat maar tot 63, van een UInt64 maakt 
                // EF6 geen tabel, de msb kon ook niet geset worden, daarom hebben we nu maar 63 
                // mogelijkheden ipv 64 :-(
                List<int> tmpPersmisses = new List<int>();
                for(int i = 0; i < 64; i++)
                {
                    if (((gevonden.AppPermissions >> i) & 1) != 0){
                        tmpPersmisses.Add(i+1); 
                    }
                }

                List<EmployeeLoggedInDTO.Permissions> tmptest = new List<EmployeeLoggedInDTO.Permissions>();
                for (int i = 0; i < 64; i++)
                {
                    if (((gevonden.AppPermissions >> i) & 1) != 0)
                    {
                        Console.WriteLine(i + 1);
                        if (Enum.IsDefined(typeof(EmployeeLoggedInDTO.Permissions), (i + 1)))
                        {
                            
                            //tmptest.Add(i + 1);
                            tmptest.Add((EmployeeLoggedInDTO.Permissions)Enum.ToObject(typeof(EmployeeLoggedInDTO.Permissions), i + 1));
                        }
                    }
                }

                //foreach (var item in tmptest)
                //{
                //    //Console.WriteLine(item);
                //}

                //bool IsBitSet(byte b, int pos)
                //{
                //    return ((b >> pos) & 1) != 0;
                //}

                foreach (var item in tmpPersmisses)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine("========================" + tmpPersmisses.Count +"======" + gevonden.AppPermissions) ;

                _inloggedEmployee = new EmployeeLoggedInDTO() {
                    AppPermissions = tmptest,
                    FirstName = gevonden.Employee.FirstName,
                    NameAddition = gevonden.Employee.NameAddition,
                    LastName = gevonden.Employee.LastName,
                    Id = gevonden.Employee.Id,
                    UserName = gevonden.UserName,
                };
            }
            else
            {
                _inloggedEmployee = null;
            }

            return _inloggedEmployee;
        }


        //=====================================================================================
        public EmployeeLoggedInDTO LogOut()
        {
            this._inloggedEmployee = null;
            return null;
        }

        public List< Employee> GetAllForOverview()
        {
            List<Employee> terug = new List<Employee>();
            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Set<Employee>()
                    .Include(nameof(Employee.EmpDepartment))
                    .Include(nameof(Employee.EmpAddress))
                    .Include(nameof(Employee.EmpContract) +"."+nameof(EmpContract.EmpContractStatuutType))
                    .Include(nameof(Employee.EmpContract) + "." + nameof(EmpContract.EmpContractType))
                    .Include(nameof(Employee.EmpAppAccount))
                    .Where(x => x.IsActive)
                    .ToList();
            }
            return terug;
        }

        public Employee Update(Employee aEmployee)
        {
            Employee gevonden = null;


            using (KfsContext ctx = new KfsContext(_constring))
            {
                gevonden = ctx.Set<Employee>()
                    .FirstOrDefault(u => u.Id == aEmployee.Id);

                if (gevonden == null)
                {
                    throw new DuplicateNameException($"user with {aEmployee.EmpAppAccount.UserName} not exist");
                }

                //gevonden = aEmployee;

                Console.WriteLine("999999999999999 " +gevonden.FirstName);
                ctx.Entry(gevonden).CurrentValues.SetValues(aEmployee);
                ctx.Entry(gevonden.EmpAddress).CurrentValues.SetValues(aEmployee.EmpAddress);
                ctx.Entry(gevonden.EmpContract).CurrentValues.SetValues(aEmployee.EmpContract);
                ctx.SaveChanges();

            }




            return gevonden;
        }







        //==================================================================================
        private class UITcustomEncrypter : TDSencryption.TDScrypto
        {
            public override bool IsValidKeyToDecrypt(string aKeyToDecrypt)
            {
                return new Regex("^[0-9A-Za-z_]{5,20}$").IsMatch(aKeyToDecrypt);
            }
            public override bool IsValidKeyToEncrypt(string aKeyToDecrypt)
            {
                //cijfers, grote en kleine letters, underscores en range
                return new Regex("^[0-9A-Za-z_]{5,20}$").IsMatch(aKeyToDecrypt);
            }


            public override bool IsValidStringToEncrypt(string aStringToEncrypt)
            {
                string geldigPaswoordRegString =
                    "^"
                    +
                    "(?=.*[A-Z]+)"          // [A-Z] betekend een hoofdletter, het plusje betekend '1 of meer'
                    +
                    "(?=.*[a-z]+)"          // [a-z] betekend een kleine letter, het plusje betekend '1 of meer'
                    +
                    "(?=.*[0-9]+)"          // [0-9] betekend een digital, het plusje betekend '1 of meer'
                    +
                    $"(?=.*[_]+)"           //tekens tss aanhalingstekenz, het plusje betekend '1 of meer'
                    +
                    ".{8,20}$"         // !!! zou moeten kijken of het geheel 8tot 20 lang is, bovengrens is niet gelukt !!!
                ;

                return new Regex(geldigPaswoordRegString).IsMatch(aStringToEncrypt);
            }
        }

    }

}
