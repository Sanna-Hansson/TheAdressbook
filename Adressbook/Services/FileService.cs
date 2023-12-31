

using Adressbook.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Adressbook.Services;

public class FileService
{
    private readonly string _filePath;

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    public bool SaveContentToFile(string content)
    {
        try
        {
            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }
}
