using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DomphGame_v1.Classes
{
    /// <summary>
    /// class for saving/reading current minigame id
    /// </summary>
    class SaveGame
    {
        private int id;

        public void SetId(int i)
        {
            id = i;

            SaveToFile(id);
        }

        public void GetId()
        {
            LoadFromFile();
        }

        private void SaveToFile(int id)
        {

            string idtext = id.ToString();

            var xmlWriter = new XmlTextWriter("levels.xml", null);

            xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
            xmlWriter.WriteStartElement("ListOfLevels");      // <ListOfBooks>
            xmlWriter.WriteStartElement("Level");             //      <Book>
            xmlWriter.WriteString(idtext);                //              id
            xmlWriter.WriteEndElement();                     //       </Book>

            xmlWriter.WriteEndElement();                     // </ListOfBooks>

            xmlWriter.Close();
        }


        private void LoadFromFile()
        {
            FileStream stream = new FileStream("levels.xml", FileMode.Open);

            XmlTextReader xmlReader = new XmlTextReader(stream);

            while (xmlReader.Read())
            {
                Debug.WriteLine("{0,-15} {1,-15} {2,-15}",
                    xmlReader.NodeType,
                    xmlReader.Name,
                    xmlReader.Value);
            }

            xmlReader.Close();
            stream.Close();
        }
    }
}