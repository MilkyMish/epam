using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Medvedev_Mikhail_Task12
{
    public static class Watcher
    {
        public static void Watch()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"J:\1\test_dir";
           
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        
            watcher.Filter = "*.*";

            
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
            Console.ReadKey();
        }

       
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // если изменен, создан или удален.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
