using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace HW_ClassStudent
{
    public static class MyFile
    {
        private static BinaryFormatter formater = new BinaryFormatter();

        public static void WriteFile<T>(string path, T data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                formater.Serialize(fs, data);
            }
        }

        public static T ReadFile<T>(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (T)formater.Deserialize(fs);
            }
        }
    }
}
