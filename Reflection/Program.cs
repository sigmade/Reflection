namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type typeSomeClass = typeof(SomeClass);
            var name = typeSomeClass.FullName;
            var constructor = typeSomeClass.GetConstructors().Single();
            var constructorParams = constructor.GetParameters();

            var paramsObjects = new List<object>();

            foreach (var obj in constructorParams)
            {
                if (obj.ParameterType.IsClass)
                {
                    paramsObjects.Add(Activator.CreateInstance(obj.ParameterType));
                }
            }

            var ourClass = Activator.CreateInstance(typeSomeClass, paramsObjects.ToArray());



            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }


    }

    public class SomeClass
    {
        private string someClassField = "SomeClassFIELD";
        private SomeService _service;
        private SomeDataService _someDataService;
        public SomeClass(SomeService service, SomeDataService someDataService)
        {
            _service = service;
            _someDataService = someDataService;
        }

        public void SomeMeth()
        {
            _service.MethodDerrClass();
            Console.WriteLine("SomeClass");
        }
    }

    public class SomeService
    {
        private string someServiceField = "SomeServiceFIELD";
        private DeepService _deepService;        

        public SomeService(DeepService deepService)
        {
            _deepService = deepService;
        }

        public void MethodDerrClass()
        {
            Console.WriteLine("Derr meth");
        }
    }

    public class SomeDataService
    {
        private string SomeDataServiceField = "SomeDataServiceFIELD";
    }

    public class DeepService
    {

    }
}