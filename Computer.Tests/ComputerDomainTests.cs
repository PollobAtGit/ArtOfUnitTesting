using Xunit;

namespace Computer.Tests
{
    public class ComputerDomainTests
    {
        [Fact]
        public void Create_Computer()
        {
            var computer = new Computer();
        }

        [Fact]
        public void Create_Computer_With_Ram_Info_And_Operating_System_Info()
        {
            var computer = new Computer();

            //computer.Ram = 32;
            computer.OperatingSystem = "Windows";
        }

        [Fact]
        public void Create_Computer_With_Valid_Ram_Using_Ctor()
        {
            var computer = new Computer(-32, "Linux");
        }

        //[Fact]
        //public void Create_Computer_With_Valid_Operating_System_Using_Ctor()
        //{

        //}

        [Fact]
        public void Make_Class_Member_For_Ram_Private()
        {
            var computer = new Computer(-32, "Linux");

            //computer.Ram = -3;
        }

        [Fact]
        public void Make_Class_Member_For_Ram_Private_Read_Only()
        {

        }

        [Fact]
        public void Allow_Computer_To_Change_Ram_Capacity()
        {

        }

        [Fact]
        public void Provide_Property_For_Ram()
        {

        }

        [Fact]
        public void Consolidate_Ram_Property_And_Member()
        {

        }

        [Fact]
        public void Make_Ram_Property_Read_Only()
        {

        }

        [Fact]
        public void Override_ToString_To_Show_Computer_Details()
        {

        }
    }

    public class Computer
    {
        private int Ram;

        public string OperatingSystem;

        // multiple ctor
        public Computer()
        {

        }

        public Computer(int ram, string os) // constructor AKA ctor
        {
            if (ram > 0)
                Ram = ram;

            if (os == "Windows")
                OperatingSystem = os;
        }
    }
}
