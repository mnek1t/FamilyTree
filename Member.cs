using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Member
    {
        public int BirthYear { get; }
        public string FullName { get; }
        public Member(string name, int year)
        {
            FullName = name;
            BirthYear = year;
        }
        //public static bool operator ==(Member a, Member b)
        //{
        //    if (a != null && b != null)
        //    {
        //        if (a.FullName == b.FullName && a.BirthYear == b.BirthYear)
        //        {
        //            return true;
        //        }
        //        else return false;
        //    }
        //    else throw new NullReferenceException();
        //}
        //public static bool operator !=(Member a, Member b)
        //{
        //    if (a != null && b != null)
        //    {
        //        if (a.Equals(b))
        //        {
        //            return false;
        //        }
        //        else return true;
        //    }
        //    else throw new NullReferenceException();
        //}
    }
}
