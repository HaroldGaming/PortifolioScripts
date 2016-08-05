using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager 
{
	public string fileName = "StuffToSave" + ".xml";

	public void SaveData(StuffToSave stuffToSave)
	{
		Safe(fileName, stuffToSave);
	}

	void Safe(string path, StuffToSave stuffToSave)
	{
		var serializer = new XmlSerializer (typeof(StuffToSave));
		using (var stream = new FileStream (path, FileMode.Create))
		{
			serializer.Serialize(stream, stuffToSave);
		}
	}

	public StuffToSave Load()
	{
		XmlSerializer serializedStuffToSave = new XmlSerializer(typeof(StuffToSave));
		FileStream stuffToSaveinfo = new FileStream ("StuffToSave.xml", FileMode.Open);
		StuffToSave newStuffToSave = ((StuffToSave)serializedStuffToSave.Deserialize(stuffToSaveinfo));
		stuffToSaveinfo.Close();
		stuffToSaveinfo.Dispose();
		return (newStuffToSave);
	}

	public bool StuffToSaveExists()
	{
		if(!System.IO.File.Exists(fileName + "xml"))
		{
			return(false);
		}
		else
		{
			return(true);
		}
	}
}
