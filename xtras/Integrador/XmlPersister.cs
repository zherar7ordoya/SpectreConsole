using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Integrador;

public class XmlPersister<T> : IPersister<T> where T : IEntity
{
    public IList<T> Read()
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
        catch (XmlException ex) { throw new XmlException("Se produjo un error al procesar el archivo XML.", ex); }
        catch (IOException ex) { throw new IOException("Se produjo un error al leer el archivo.", ex); }
        catch (Exception ex) { throw new Exception("Se produjo un error al intentar leer los datos.", ex); }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
        }
    }

    public bool Write(IList<T> datos)
    {
        string file = $"{typeof(T).Name}.xml";

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, datos);
            return true;
        }
        catch (XmlException ex) { throw new XmlException("Se produjo un error al procesar el archivo XML.", ex); }
        catch (IOException ex) { throw new IOException("Se produjo un error al escribir el archivo.", ex); }
        catch (Exception ex) { throw new Exception("Se produjo un error al intentar escribir los datos.", ex); }
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
            throw new Exception("Se produjo un error al intentar crear el archivo XML.", ex);
        }
    }
}
