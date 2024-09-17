using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


public static class XmlHelper
{
    public static void XmlSerialize(Type dataType, object data, string FilePath)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(FilePath)) File.Delete(FilePath);
            TextWriter writer = new StreamWriter(FilePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public static object XmlDeserialize(Type dataType, string FilePath)
    {
        object obj = null;

        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(FilePath))
            {
                TextReader reader = new StreamReader(FilePath);
                obj = xmlSerializer.Deserialize(reader);
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n\nXML HATASI OLUŞTU\n\nHata:\n" + ex.ToString() + "\n\n\nHata Bitti\n\n");
            throw ex;
        }

        return obj;
    }
}