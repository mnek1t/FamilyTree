using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    internal class Program
    {
        static void Print(Tree<Member> tree)
        {
            foreach (Member item in tree)
            {
                Console.WriteLine(item.FullName + " " + item.BirthYear);
            }
        }
        static void Main(string[] args)
        {
            Tree<Member> tree = new Tree<Member>();
            #region Initialize relatives
            var nikita = new Member("Nikita", 2004);
            var maria = new Member("Maria", 2010);
            var andrii = new Member("Andrii", 1980);
            var nataliia = new Member("Nataliia", 1982);
            var nina = new Member("Nina", 1952);
            var anatoliy = new Member("Anatoliy", 1952);
            var raisa = new Member("Raisa", 1956);
            var olexandr = new Member("Olexandr", 1956);
            #endregion
            Console.WriteLine("-------------------------------------After Adding-------------------------------------");
            tree.Add(nina);
            tree.Add(anatoliy);
            tree.Add(raisa);
            tree.Add(olexandr);
            tree.AddChild(andrii, raisa, olexandr);
            tree.AddChild(nataliia, nina, anatoliy);
            tree.AddChild(maria, andrii, nataliia);
            tree.AddChild(nikita, andrii, nataliia);
            Print(tree);
            tree.PrintDescendants(andrii);
            tree.PrintDescendants(raisa);
            tree.PrintDescendants(olexandr);
            tree.PrintDescendants(nina);
            tree.PrintDescendants(anatoliy);
            tree.PrintDescendants(nataliia);
            #region Query for a BirthYear
            int year = 2004;
            var query = tree.Cast<Member>().Where(y => y.BirthYear == year).Select(y => y.FullName);
            Console.WriteLine("-------------------------------------Query for the Birth year-------------------------------------");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Проверка методов пользовательской коллекции

            //Console.WriteLine("-------------------------------------After IndexOf-------------------------------------");
            //Console.WriteLine(tree.IndexOf(nataliia));
            //Console.WriteLine("-------------------------------------After Insertion-------------------------------------");
            //tree.Insert(1, new Member("Ivan", 2014));
            //Print(tree);
            //Console.WriteLine("-------------------------------------After Removing-------------------------------------");
            //tree.Remove(andrii);
            //Print(tree);
            //Console.WriteLine("-------------------------------------After Removing At Index-------------------------------------");
            //tree.RemoveAt(2);
            //Print(tree);
            //Console.WriteLine("-------------------------------------After Clearing-------------------------------------");
            //tree.Clear();
            //Print(tree);
            #endregion

        }
    }
}
