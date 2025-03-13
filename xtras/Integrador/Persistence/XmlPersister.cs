using Integrador.Abstract;

using System.Text;
using System.Xml.Serialization;

namespace Integrador.Persistence;

public class XmlPersister<T> : IPersister<T> where T : IEntity
{
    public List<T> Read()
    {
        string file = $"{typeof(T).Name}.xml";

        if (!File.Exists(file))
        {
            XmlPersister<T>.CreateEmptyFile(file);
            return [];
        }

        StreamReader? reader = null;

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            reader = new StreamReader(file, Encoding.Unicode);
            var result = serializer.Deserialize(reader) as List<T>;
            return result ?? [];
        }
        catch (Exception ex)
        {
            var logMessage = $"[{DateTime.Now}] \t Error en {nameof(XmlPersister<T>)}: {ex.Message}";
            File.AppendAllText("Log.txt", logMessage + Environment.NewLine);

            throw new PersisterException($"Error en {nameof(XmlPersister<T>)} al leer {typeof(T).Name}.xml", ex);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
        }
    }

    public bool Write(List<T> datos)
    {
        string file = $"{typeof(T).Name}.xml";

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, datos);
            return true;
        }
        catch (Exception ex)
        {
            var logMessage = $"[{DateTime.Now}] \t Error en {nameof(XmlPersister<T>)}: {ex.Message}";
            File.AppendAllText("Log.txt", logMessage + Environment.NewLine);

            throw new PersisterException($"Error en {nameof(XmlPersister<T>)} al leer {typeof(T).Name}.xml", ex);
        }
    }

    private static void CreateEmptyFile(string file)
    {
        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, new List<T>());
        }
        catch (Exception ex)
        {
            var logMessage = $"[{DateTime.Now}] \t Error en {nameof(XmlPersister<T>)}: {ex.Message}";
            File.AppendAllText("Log.txt", logMessage + Environment.NewLine);

            throw new PersisterException($"Error en {nameof(XmlPersister<T>)} al leer {typeof(T).Name}.xml", ex);
        }
    }
}
