using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.ProCSharpBook.OOPTips
{
    class OOPTips
    {
    }


    class Source1 { public void source1Method() { Console.WriteLine("source1 m"); } }
    class Source2 { public void source2Method(){ Console.WriteLine("source2 m"); } }
    class Source3 { public void source3Method(){ Console.WriteLine("source3 m"); } }
                    
    // design say that Target must use Source1 , Source2 , and Source3

    class Target
    {
        private Source1 source1;
        private Source2 source2;
        private Source3 source3;


        public void DoSomeWorkWithSource1()
        {
            source1.source1Method();
        }

        public void DoSomeWorkWithSource2()
        {
            source2.source2Method();
        }

        public void DoSomeWorkWithSource3()
        {
            source3.source3Method();
        }

        public void DoAnotherThingWithSource1()
        {
            source1.source1Method();
        }

        public void DoAnotherThingWithSource2()
        {
            source2.source2Method();
        }

        public void DoAnotherThingWithSource3()
        {
            source3.source3Method();
        }

    }

    // so now if i has another Source with name Source4 and have another behaviour than the other ones
    // and i should add it to Target then now Target is Open for Extension /not closed for modification

    // the solution is using OOP Concepts

    // lets make dependency inversion control using dependency Injection: 
    // 1 - constructor / 

    abstract class BaseSource
    {
        public virtual void Method()
        {
            Console.WriteLine("I am base Method Version");
        }
    }

    class SubSource1 : BaseSource { public override void Method() { Console.WriteLine("source1 m"); } }

    class SubSource2 : BaseSource { public override void Method() { Console.WriteLine("source2 m"); } }

    class SubSource3 : BaseSource { public override void Method() { Console.WriteLine("source3 m"); } }





}
