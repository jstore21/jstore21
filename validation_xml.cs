using System;
using System.Xml;

class Program
{
    static void Main()
    {
        try
        {
            // Ruta del archivo XML que deseas validar
            string xmlFilePath = "documento.xml";

            // Configura la configuración de validación
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.None; // Deshabilita la validación con esquema
            settings.ValidationEventHandler += ValidationCallback;

            // Crea un XmlReader para leer y validar el documento XML
            using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
            {
                while (reader.Read()) { }
            }

            Console.WriteLine("Documento XML válido según la estructura XML.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de validación: {ex.Message}");
        }
    }

    private static void ValidationCallback(object sender, ValidationEventArgs e)
    {
        Console.WriteLine($"Error de validación: {e.Message}");
    }
}
