using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// NB: Probably don't needed
// TODO: check it later
public class StorageHandler
{
    /// <summary>
    /// Serialize an object to the devices File System.
    /// </summary>
    /// <param name="objectToSave">The Object that will be Serialized.</param>
    /// <param name="fileName">Name of the file to be Serialized.</param>
    public void SaveData(object objectToSave, string fileName)
    {
        // Add the File Path together with the files name and extension.
        // We will use .bin to represent that this is a Binary file.
        var fullFilePath = Application.persistentDataPath + "/" + fileName + ".bin";
        // We must create a new Formatter to Serialize with.
        var formatter = new BinaryFormatter();
        // Create a streaming path to our new file location.
        var fileStream = new FileStream(fullFilePath, FileMode.Create);
        // Serialize the object to the File Stream
        formatter.Serialize(fileStream, objectToSave);
        // Finally Close the FileStream and let the rest wrap itself up.
        fileStream.Close();
    }

    /// <summary>
    /// Deserialize an object from the FileSystem.
    /// </summary>
    /// <param name="fileName">Name of the file to deserialize.</param>
    /// <returns>Deserialized Object</returns>
    public object LoadData(string fileName)
    {
        var fullFilePath = Application.persistentDataPath + "/" + fileName + ".bin";
        // Check if our file exists, if it does not, just return a null object.
        if (File.Exists(fullFilePath))
        {
            var formatter = new BinaryFormatter();
            var fileStream = new FileStream(fullFilePath, FileMode.Open);
            var obj = formatter.Deserialize(fileStream);
            fileStream.Close();
            // Return the uncast untyped object.
            return obj;
        }
        else
        {
            return null;
        }
    }
}