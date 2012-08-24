using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ShowLib;



namespace CloudRaid
{
    public class CloudRAID
    {
        FrmMain Form;
        public List<String> SourceDirs = new List<string>();
        public List<CloudStorage> CloudStorageLst = new List<CloudStorage>();
        public IniFile Ini;
        public string ConfigFilename; // With full path        
        public List<CloudFile> ToBeCopiedLst = new List<CloudFile>();
        public List<CloudFile> OutputFileLst = new List<CloudFile>();
        public long SourceSize = 0;
        public long OutputSize = 0;
        public long OutputUsed = 0;
        public string Report = "";

        public long OutputFree {
            get {
                return OutputSize - OutputUsed;
            }
        }

        public string DirForOutput = "\\Auto";

        public CloudRAID(FrmMain form) {
            Form = form;
            string AppDir = D.AppDir; //Just to make sure D is called
            ConfigFilename = D.AppDir + D.ConfigFile;
            Ini = new IniFile();            
        }

        public void CreateEmptyConfigFile() {
            Ini.AddSection("SOURCE_DIRS").AddKey("DIRS").SetValue("");
            Ini.AddSection("OUTPUT_DIRS").AddKey("DIRS").SetValue("");
            Ini.Save(ConfigFilename);
        }

        public void LoadConfig() {
            string[] cloudStorage;
            if (File.Exists(ConfigFilename)) {
                Ini.Load(ConfigFilename);
                if (Ini.GetKeyValue("SOURCE_DIRS", "DIRS") != null) {
                    foreach (String dir in Ini.GetKeyValue("SOURCE_DIRS", "DIRS").Split('|'))
                        if(dir!="")
                            SourceDirs.Add(dir);
                }
                if (Ini.GetKeyValue("OUTPUT_DIRS", "DIRS") != null) {
                    foreach (String dir in Ini.GetKeyValue("OUTPUT_DIRS", "DIRS").Split('|'))
                        if (dir != "") {
                            cloudStorage = dir.Split(';');
                            CloudStorageLst.Add(new CloudStorage(cloudStorage[0], cloudStorage[1], Convert.ToInt64(cloudStorage[2])));
                        }                            
                }
            } else {
                CreateEmptyConfigFile();
                LoadConfig();
            }
        }

        public void SaveConfig() {
            Ini = new IniFile();
            string dirs="";
            foreach (String dir in SourceDirs) {
                if(Directory.Exists(dir))
                    dirs += dir + "|";
            }
            Ini.AddSection("SOURCE_DIRS").AddKey("DIRS").SetValue(dirs);
            dirs = "";
            foreach (CloudStorage dir in CloudStorageLst) {
                if (Directory.Exists(dir.Path))
                    dirs += dir.Name + ";" + dir.Path + ";" + dir.Size + "|";
            }
            Ini.AddSection("OUTPUT_DIRS").AddKey("DIRS").SetValue(dirs);
            Ini.Save(ConfigFilename);            
        }

        public void CreateOutputFileList() {
            OutputFileLst.Clear();
            CloudFile cf;
            FileInfo info;
            OutputUsed = 0;
            foreach (CloudStorage dir in CloudStorageLst) {
                foreach (string file in DirectoryGetFilesRecursive(dir.Path)) {
                    cf = new CloudFile();
                    info = new FileInfo(file);
                    cf.Size = info.Length;
                    cf.Path = file;
                    OutputFileLst.Add(cf);
                    OutputUsed += cf.Size;
                }
            }
        }

        public void CalculateOutputSize() {
            OutputSize = 0;
            foreach (CloudStorage cs in CloudStorageLst)
                OutputSize += cs.Size;
        }

        public void Checks() {
            CreateSourceList();
            CalculateOutputSize();
            CreateOutputFileList();            
        }

        public void CreateSourceList() {
            ToBeCopiedLst.Clear();
            CloudFile cf;
            FileInfo info;
            foreach(string dir in SourceDirs){
                foreach (string file in DirectoryGetFilesRecursive(dir)) {
                    cf = new CloudFile();
                    info  = new FileInfo(file);
                    cf.Size = info.Length;
                    cf.Path = file;
                    ToBeCopiedLst.Add(cf);
                    SourceSize += cf.Size;
                }
            }

        }

        public CloudFile NextFileToBeCopied(long maxSize) {
            foreach (CloudFile cf in ToBeCopiedLst) {
                if (cf.Size <= maxSize)
                    return cf;
            }
            return null;
        }


        /// <summary>
        /// Case 1: Free space file does not exist
        /// Case 2: No free space at storage break
        /// </summary>
        public void CloudCopy() {
            
            CloudFile nextFile;
            Form.SetControlPropertyValue(Form.btChecks, "enabled", false);
            string destination;
            string destinationPath;
            int valor;
            int total = ToBeCopiedLst.Count;
            foreach (CloudStorage cs in CloudStorageLst) {
                //try to copy until space is more than 3MB
                cs.UsedCached = cs.Used;
                while (cs.FreeEvaluatedFromUsedCached > 3 * 1024 * 1024) {
                    nextFile = NextFileToBeCopied(cs.FreeEvaluatedFromUsedCached);
                    try {
                        if (nextFile != null) {
                            destination = cs.Path + DirForOutput + nextFile.Path.Substring(2, nextFile.Path.Length - 2);
                            destinationPath = Fcn.FilePath(destination);
                            if (!Directory.Exists(destinationPath))
                                Directory.CreateDirectory(destinationPath);
                            File.Copy(nextFile.Path, destination, true);
                            ToBeCopiedLst.Remove(nextFile);
                            cs.UsedCached += nextFile.Size;
                            valor = (int)(-1 * (double)(ToBeCopiedLst.Count - total) / total * 100);
                            Form.SetControlPropertyValue(Form.progressBar, "value", valor);
                            Form.SetControlPropertyValue(Form.lbProgress, "text", "Progress: " + valor + "%");
                        } else
                            break;
                    } catch (Exception ex) {
                        Report += "Erro ao copiar o arquivo " + nextFile.Path + " Motivo: " + ex.Message + Environment.NewLine; ;
                        ToBeCopiedLst.Remove(nextFile);
                        cs.UsedCached -= nextFile.Size;
                        valor = (int)(-1 * (double)(ToBeCopiedLst.Count - total) / total * 100);
                        Form.SetControlPropertyValue(Form.progressBar, "value", valor);
                        Form.SetControlPropertyValue(Form.lbProgress, "text", "Progress: " + valor + "%");
                    }
                }
            }
            
            Form.SetControlPropertyValue(Form.btChecks, "enabled", true);
        }

        public void Syncronize() {

            CreateSourceList();

            CloudCopy();
            File.WriteAllText("\\CloudRaid_Report.txt", Report);
            
            //1st fill the directories from the cloud

            //foreach (string dir in OutputDirs) {
            //    foreach(CloudStorage cl in CloudStorageLst)
            //        if (cl.Path.ToLower() == dir.ToLower()) {
                        
            //        }
            //}
        }

        static long GetDirectorySize(string p) {
            long totalSize=0;
            FileInfo f;

            foreach (string file in DirectoryGetFilesRecursive(p)) {
                f = new FileInfo(file);
                totalSize+=f.Length;
            }
            return totalSize;
        }


        /// <summary>Gera uma lista lista dos arquivos contidos num determinado diretório</summary>
        /// <param name="b">Caminho do diretório desejado</param>
        /// <returns>Stringlist com os caminhos dos arquivos existentes no diretório</returns>
        public static List<string> DirectoryGetFilesRecursive(string b) {
            // 1.
            // Store results in the file results list.
            List<string> result = new List<string>();

            // 2.
            // Store a stack of our directories.
            Stack<string> stack = new Stack<string>();

            // 3.
            // Add initial directory.
            stack.Push(b);

            // 4.
            // Continue while there are directories to process
            while (stack.Count > 0) {
                // A.
                // Get top directory
                string dir = stack.Pop();

                try {
                    // B
                    // Add all files at this directory to the result List.
                    result.AddRange(Directory.GetFiles(dir, "*.*"));

                    // C
                    // Add all directories at this directory.
                    foreach (string dn in Directory.GetDirectories(dir)) {
                        stack.Push(dn);
                    }
                } catch {
                    // D
                    // Could not open the directory
                }
            }
            return result;
        }


/*
 * Inner classes
 * */
        public class CloudStorage
        {
            public string Name;
            public long Size; //size in bytes
            public string Path;
            public long UsedCached;

            public long Used {
                get {
                    return GetDirectorySize(Path); 
                }
            }

            public long Free {
                get {
                    return Size - Used;
                }
            }

            public long FreeEvaluatedFromUsedCached {
                get {
                    return Size - UsedCached;
                }
            }

            public CloudStorage(string name, string path, double sizeInBytes){
                Name = name;
                Path = path;
                Size = (long)(sizeInBytes);
            }
        }

        public class CloudFile
        {
            public long Size; //size in bytes
            public string Path;
            public bool AtSource = false;
            public string MD5; // Avoid doubles
            
            public long SizeInMB {
                get {
                    return Size / 1024 / 1024;
                }
            }
        }


      
    }
}
