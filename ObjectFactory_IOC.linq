<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class ObjectFactory{
	private IDictionary<string,object> objContainer = new Dictionary<string,object>();
	private ObjectFactory(string fileName)
	{
		InstanceObjects(fileName);
		DIObjects(fileName);
	}
	private static ObjectFactory instance;
	private static object lockHelper = new object();
	public static ObjectFactory Instance(string fileName)
	{
		if(null == instance)
		{
			lock (lockHelper)
			{
				instance = instance?? new ObjectFactory(fileName);
			}
		}
		return instance;
	}
	
	private void InstanceObjects(string fileName)
	{
		// 无参构造函数
		XElement root = XElement.Load(fileName);
		var objs = from obj in root.Elements("object")
				   select obj;
		objContainer = objs.Where(obj => obj.Element("constructor-arg") == null).ToDictionary(
		k => k.Attribute("id").Value, 
		v => {
			string typeName = v.Attribute("type").Value;
			Type type = Type.GetType(typeName);
			return Activator.CreateInstance(type);
		});
		
		// 有参构造函数、
		foreach(XElement item in objs.Where(obj=>obj.Element("constructor-arg")!=null))
		{
			string id = item.Attribute("id").Value;
			string typeName = item.Attribute("type").Value;
			Type type = Type.GetType(typeName);
			var args = from prop in type.GetConstructors()[0].GetParameters()
						join e1 in item.Elements("contructor-arg")
						on prop.Name equals e1.Attribute("name").Value
						select Convert.ChangeType(e1.Attribute("value").Value, prop.ParameterType);
			object obj = Activator.CreateInstance(type,args);
			objContainer.Add(id,obj);
		}
	}
	
	private void DIObjects(string fileName)
	{
		XElement root = XElement.Load(fileName);
		var objs = from obj in root.Elements("object") select obj;
		
		foreach(KeyValuePair<string,object> item in objContainer)
		{
			foreach(var e1 in objs.Where(e => e.Attribute("id").Value == item.Key).Elements("property"))
			{
				Type type = item.Value.GetType();
				foreach(PropertyInfo property in type.GetProperties())
				{
					if(property.Name == e1.Attribute("name").Value)
					{
						if(e1.Attribute("value") != null)
						{
							property.SetValue(item.Value,Convert.ChangeType(e1.Attribute("value").Value,property.PropertyType),null);
						}else if(e1.Attribute("ref") != null)
						{
							object refObj = null;
							if(objContainer.ContainsKey(e1.Attribute("ref").Value))
							{
								refObj = objContainer[e1.Attribute("ref").Value];
							}
							property.SetValue(item.Value, refObj, null);
						}
					}
				}
			}
		}
	}
	
	public object GetObject(string id)
	{
		object result = null;
		if(objContainer.ContainsKey(id))
		{
			result = objContainer[id];
		}
		return result;
	}
}