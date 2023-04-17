using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AnotherClient
{

    [ComVisible(true)]
    [ComDefaultInterface(typeof(ICreateCar))]
    [ComSourceInterfaces(typeof(IStats))]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("29a236dc-7387-4c94-8cb9-61b045990a80")]
    public class Car : ICreateCar
    {
        private string petName;
        private int maxSpeed;

        public void SetPetName(string petName)
        {
            this.petName = petName;
        }

        public void SetMaxSpeed(int maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }
    }

   
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36044104-02c7-42aa-8577-14afb709b62c")]
    public interface ICreateCar
    {
        void SetPetName(string petName);
        void SetMaxSpeed(int maxSp);
    }

    
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4c3ab7d6-d754-4d49-9efb-2f9d9bb5dabe")]
    public interface IStats
    {
        void DisplayStats();
        void GetPetName(ref string petName);
    }
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d81b7af5-5ffd-4a8f-8f27-8f9c6123da1e")]
    public interface IEngine
    {
        void SpeedUp();
        void GetMaxSpeed(ref int curSpeed);
        void GetCurSpeed(ref int maxSpeed);
    }


    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            ICreateCar iCrCar = (ICreateCar)myCar;
            Console.WriteLine("Ваше имя: ");
            iCrCar.SetPetName(Console.ReadLine());
            iCrCar.SetMaxSpeed(300);


            Type comType = Type.GetTypeFromCLSID(new Guid("29a236dc-7387-4c94-8cb9-61b045990a80"));
            dynamic comObject = Activator.CreateInstance(comType);
            object comInterface = comObject as object;

        }
    }
}
