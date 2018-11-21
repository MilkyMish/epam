using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Medvedev_Mikhail_Task12
{
    public class WatchAndBackUI : WatchAndNBackup
    {
        static public void MainMenu()
        {
            Console.WriteLine("Choose mode \n 1 Watch \n 2 restore");
            int choose;
            do
            {
                choose = Int32.Parse(Console.ReadLine());
            } while ((choose != 1) && (choose != 2));
            if (choose == 1) StartWatcher();
            if (choose == 2) StartRestore();
        }

        public static void StartRestore()
        {
            Console.WriteLine("Choose backup \n");
            String[] listOfFiles = Directory.GetDirectories(backupPath);
            for (int i = 0; i < listOfFiles.Count(); i++)
            {
                Console.WriteLine(i + listOfFiles[i]);
            }
            Restore(listOfFiles[Int32.Parse(Console.ReadLine())]);
        }
    }

    public class WatchAndNBackup
    {

        protected static String backupPath = @"J:\1\Backup";
        protected static String directoryWatch = @"J:\1\test_dir";



        static private void DirectoryCopy(String sourceDirName, String destDirName, bool copySubDirs)
        {

            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // если папки нет - создаем
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // копирование в другую папку
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // копируем содержимое
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static void StartWatcher()
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directoryWatch;
          
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
           
            watcher.Filter = "*.*";
         
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            Console.ReadKey();
        }

        public static void Restore(String pathOfChooseBackup)
        {
            Directory.Delete(directoryWatch, true);
            DirectoryCopy(pathOfChooseBackup, directoryWatch, true);
        }


        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            DirectoryCopy(directoryWatch, Path.Combine(backupPath, DateTime.Now.ToString("DD-HH-mm-ss")), true);
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            DirectoryCopy(directoryWatch, Path.Combine(backupPath, DateTime.Now.ToString("DD-HH-mm-ss")), true);
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
