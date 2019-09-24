
using System;

namespace pro_csharp_book_training
{
    public static class StructuresTraining
    {
        static StructuresTraining() { }

        public static void TestStructures()
        {
            Console.WriteLine("Test Structures");
        }
    }

    struct MyStruct
    {
        public int myField;
        private int myField2;
        // Error structure doesn't accept protected Members
        // protected int myField3;

        // 


    }




}