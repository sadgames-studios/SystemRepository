using System;
namespace appdll.Code.SystemRepository
{
	public interface ISystemRepository
	{
	}

	public class SystemRepository : ISystemRepository
	{
		private static Dictionary<object, object> managers = new Dictionary<object, object>();
		public SystemRepository()
		{
		}

        public static void Register<T>(T component) where T : IComponent
        {
            var t = typeof(T);
            if (managers.TryAdd(t, component))
            {
                Console.WriteLine($"[SystemRepository]: Added manager {t}");
            }
            else
            {
                Console.WriteLine($"[SystemRepository]: Error, this element: {t} exists in list");
            }
        }

        public static T GetComponent<T>() where T : IComponent
        {
            var t = typeof(T);
            if (managers.TryGetValue(t, out object value))
            {
                Console.WriteLine($"[SystemRepository]: return manager {t}");
                return (T)value;
            }
            else
            {
                Console.WriteLine($"[SystemRepository]: Error, this element: {t} not exists in managers.");
                return default;
            }
        }

        public static void RemoveComponent<T>() where T : IComponent
        {
            var t = typeof(T);
            Console.WriteLine($"[SystemRepository]: Try to remove element: {t}.");

            managers = managers
            .Where(kvp => !kvp.Key.Equals(t))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Console.WriteLine($"[SystemRepository]: element remove successfull.");
        }
    }
}

