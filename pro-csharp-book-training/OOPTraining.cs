using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace pro_csharp_book_training
{
    // --- OOP Notes ---
    // -----------------------------------------------------------------------------------------
    // - a class is a blueprint, and an object is a building made from that blueprint.
    // To define a class:

    class TestClass
    {
        // Constructors, Methods, properties, fields,, events, delegates.
        // and nested Types(classes, enums, structures,delegate) go here.

    }




    public static class OOPTraining
    {
        public static void TestOOP()
        {

        }

    }

    public class TestOOP1
    {
        // Field
        // [Modifier] Type fieldName;
        // [Modifier] Type fieldName = Initialization;
        // e.g: 

        int field1; // when no modifier it is considered private
        private int field2;
        public string field;

        // Properties
        private int id;
        public int ID
        {
            set { id = value; } 
            // note that value is Contextual Keyword -keyword only in the set scope-
            // and it can be used outside the set scope as a
            get { return id; }
        }

        // Auto-Property
        private string Name { get; set; }






    }
}