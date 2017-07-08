using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoloProjects.Dudhit.Utilities
{
  public static class FileSystemHelper
  {
    public static bool FolderCreation(string path)
    {
      try
      {
        if(!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
          return FolderVerification(path);
        }
      }
      catch(UnauthorizedAccessException UAE)
      {
        throw new ApplicationException("Failure to create folder using FileSystemHelper", UAE);
      }
      catch(DirectoryNotFoundException DNFE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", DNFE);
      }
      catch(PathTooLongException PTLE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", PTLE);
      }
      return false;

    }

    public static bool FolderVerification(string path)
    {
      try
      {
        return Directory.Exists(path);
      }
      catch(UnauthorizedAccessException UAE)
      {
        throw new ApplicationException("Failure to create folder using FileSystemHelper", UAE);
      }
      catch(DirectoryNotFoundException DNFE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", DNFE);
      }
      catch(PathTooLongException PTLE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", PTLE);
      }

    }

    public static bool CopyFile(string sourcePath, string destinationPath)
    {
      try
      {
        File.Copy(sourcePath, destinationPath, true);
        return true;
      }
      catch(UnauthorizedAccessException UAE)
      {
        throw new ApplicationException("Failure to create folder using FileSystemHelper", UAE);
      }
      catch(DirectoryNotFoundException DNFE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", DNFE);
      }
      catch(PathTooLongException PTLE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", PTLE);
      }
    }

    public static bool FileExists(string path)
    {
      try
      {
        if(File.Exists(path))
          return true;
      }
      catch(UnauthorizedAccessException UAE)
      {
        throw new ApplicationException("Failure to create folder using FileSystemHelper", UAE);
      }
      catch(FileNotFoundException FNFE)
      {
        throw new FileNotFoundException("Failure to locate folder using FileSystemHelper", FNFE);
      }
      catch(PathTooLongException PTLE)
      {
        throw new DirectoryNotFoundException("Failure to locate folder using FileSystemHelper", PTLE);
      }
      return false;
    }

    public static void Logging(string path, string line)
    {
      try
      {
        using(StreamWriter sw = new StreamWriter(path, true))
        {
          sw.Write(DateTime.Now.ToString("yyyy-MM-dd"));
          sw.Write(" ");
          sw.Write(DateTime.Now.ToString("HH:mm:ss"));
          sw.Write(" ");
          sw.WriteLine(line);
        }
      }
      catch(UnauthorizedAccessException UAE)
      {
        throw new ApplicationException("Failure to write to log FileSystemHelper", UAE);
      }
      catch(FileNotFoundException FNFE)
      {
        throw new FileNotFoundException("Failure to write to log using FileSystemHelper", FNFE);
      }
      catch(PathTooLongException PTLE)
      {
        throw new DirectoryNotFoundException("Failure to write to log using FileSystemHelper", PTLE);
      }
    }

    public static string FetchCurrentUserFolder() 
    { 
    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }
    
    public static bool DeleteFile(string path)
    {
      try
      {
        File.Delete(path);
        if(!FileExists(path))
          return true;
         }

      catch(UnauthorizedAccessException UAE)
      {
        throw new ApplicationException("Failure to delete file using FileSystemHelper", UAE);
      }
      catch(FileNotFoundException FNFE)
      {
        throw new FileNotFoundException("Failure to locate file using FileSystemHelper", FNFE);
      }
      catch(PathTooLongException PTLE)
      {
        throw new DirectoryNotFoundException("Failure to locate file using FileSystemHelper", PTLE);
      }
      return false;
    }
  }
}