using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication5
{
    public class FileLoader
    {
        public string ice_folder = @"\textures\ice\";
        public string jersey_folder = @"\textures\jerseys\";
        public string true_folder = @"\data\model\";
        public string curDirName;

        public Dictionary<string, string> Dict_ice;
        public Dictionary<string, string> Dict_jersey;

        public FileLoader()
        {

            Dict_ice = new Dictionary<string, string>();
            Dict_jersey = new Dictionary<string, string>();

            curDirName = System.IO.Directory.GetCurrentDirectory();

            string[] ices = System.IO.Directory.GetDirectories(curDirName + ice_folder);
            string[] jerseys = System.IO.Directory.GetDirectories(curDirName + jersey_folder);


            foreach (string s in ices)
            {
                Dict_ice.Add(s.Replace(System.IO.Path.GetDirectoryName(s) +"\\", ""), s);
            }

            foreach (string s in jerseys)
            {
                Dict_jersey.Add(s.Replace(System.IO.Path.GetDirectoryName(s) + "\\", ""), s);
            }
        }

        public List<string> returnJerseyList()
        {
            return Dict_jersey.Keys.ToList<string>();
        }

        public List<string> returnIceList()
        {
            return Dict_ice.Keys.ToList<string>();
        }

        public void set_ice(string name)
        {
            Debug.Print(name);
            string icefolder = Dict_ice[name];

            foreach (string s in System.IO.Directory.GetFiles(icefolder))
            {
                System.IO.File.Copy(s, curDirName + true_folder + s.Replace(icefolder, ""), true);
            }


        }

        public void set_blue(string name)
        {
            string bluefolder = Dict_jersey[name] + @"\blue\";

            foreach (string s in System.IO.Directory.GetFiles(bluefolder))
            {
                System.IO.File.Copy(s, curDirName + true_folder + s.Replace(bluefolder, ""), true);
            }
        }

        public void set_red(string name)
        {
            string redfolder = Dict_jersey[name] + @"\red\";

            foreach (string s in System.IO.Directory.GetFiles(redfolder))
            {
                System.IO.File.Copy(s, curDirName + true_folder + s.Replace(redfolder, ""), true);
            }

        }

        public void launch()
        {
            string swag = curDirName + @"\hockey.exe";
            System.Diagnostics.Process.Start(curDirName + @"\hockey.exe"); 
        }
    }
}
