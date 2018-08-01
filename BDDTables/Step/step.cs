using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BDDTables.Step
{
    [Binding]

    public class step
    {
        [When(@"I press add")]
        public void WhenIPressAdd(Table table)
        {
            var Details = table.CreateSet<employee>();
            foreach (employee e in Details)
            {
                Console.WriteLine("Details of Employee : " + e.FirstName);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(e.Initial);
                Console.WriteLine(e.FirstName);
                Console.WriteLine(e.MiddleName);
                Console.WriteLine(e.Language);

            }
        }

    }
}
