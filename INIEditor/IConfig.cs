using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIEditor
{
    public interface IConfig
    {
        void SaveToFile(string path);
        void LoadFromLines(string[] lines);
        void LoadFromFile(string path);
        void ReasetToDefault();
    }
}
