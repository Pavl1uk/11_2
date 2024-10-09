namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);
            
            ConstructorInfo constructor = blackBoxType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
            object blackBoxInstance = constructor.Invoke(null);
            
            MethodInfo[] methods = blackBoxType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandParts = input.Split('_');
                string methodName = commandParts[0];
                int value = int.Parse(commandParts[1]);
                
                MethodInfo method = blackBoxType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                
                method.Invoke(blackBoxInstance, new object[] { value });
                
                FieldInfo innerValueField = blackBoxType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
                int currentValue = (int)innerValueField.GetValue(blackBoxInstance);
                
                Console.WriteLine(currentValue);
            }
        }
    }
}