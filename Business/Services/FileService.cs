﻿using Business.Interface;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    //Fick hjälp av tobbas i klassen för smidigare directoryPath
    public FileService(string fileName = "contactlist.json", string directoryPath = null!)
    {
        _directoryPath = directoryPath ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ContactApp", "Data");
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public bool SaveContactToList(List<ContactRegForm> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
            return true;

        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex);
            return false;
           
        }
    }


    public IEnumerable<ContactRegForm> GetContactList()
    {
        try
        {
            if (!File.Exists(_filePath))
                return [];

            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<ContactRegForm>>(json, _jsonSerializerOptions);
            return list ?? [];

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];

        }
    }





}
