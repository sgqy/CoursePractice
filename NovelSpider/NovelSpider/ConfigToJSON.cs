using System.IO;
using System.Runtime.Serialization.Json;

namespace NovelSpider
{
    public class ConfigToJSON : IConfig
    {
        public Configuration config { get; set; }
        private DataContractJsonSerializer ser { get; set; }

        public ConfigToJSON()
        {
            config = new Configuration();
            ser = new DataContractJsonSerializer(typeof(Configuration));            
        }

        public void Load(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            config = (Configuration)ser.ReadObject(fs);
            fs.Dispose();
        }

        public void Save(string path)
        {
            var ms = new MemoryStream();
            ser.WriteObject(ms, config);

            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            fs.SetLength(0);
            ms.WriteTo(fs);

            fs.Dispose();
            ms.Dispose();
        }
    }
}