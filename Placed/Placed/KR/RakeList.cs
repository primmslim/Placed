using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Placed.KR
{
    [Serializable]
    public class RakeList
    {
       
        public ObservableCollection<Rake> rakes;

        public RakeList()
        {
            
        }

        public void PopulateList()
        {
            GetList();
        }
        public void SaveList()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filepath = Path.Combine(path, "rakes.txt");
            XmlSerializer serializer = new XmlSerializer(typeof(RakeList));
            Stream writer = new FileStream(filepath, FileMode.OpenOrCreate,FileAccess.Write,FileShare.None);
            serializer.Serialize(writer, this);
            writer.Close();


        }

        private void GetList()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(RakeList));
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filepath = Path.Combine(path, "rakes.txt");
            if (!File.Exists(filepath))
            {
                rakes = new ObservableCollection<Rake>();
                return;
            }

            Stream reader = new FileStream(filepath, FileMode.Open,FileAccess.Read,FileShare.None);
            RakeList deserializedList;

            deserializedList = (RakeList)deserializer.Deserialize(reader);
            rakes = deserializedList.rakes;
            reader.Close();
        }

    }
}
