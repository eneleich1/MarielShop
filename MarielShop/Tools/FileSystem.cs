using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarielShop.Tools
{
    public abstract class FileSystem
    {
        public abstract void Serialize(string filePath, object value, Type type);
        public abstract object Deserialize(string filePath, Type type);
        public abstract bool Exist(string filePath);
    }
}
