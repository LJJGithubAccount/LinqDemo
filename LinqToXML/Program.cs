using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LinqToXML
{
	class Program
	{
		static void Main(string[] args)
		{
			XDocument xdoc = new XDocument();

			XElement Persons = new XElement("Persons");

			//XElement per1 = new XElement("Person");
			//per1.SetAttributeValue("sex", "男");
			//per1.Add(new XElement("name", "tang"));
			//per1.Add(new XElement("age", 18));
			//per1.Add(new XElement("address", "zz"));
			//Persons.Add(per1);

			//XElement per2 = new XElement("Person");
			//per2.SetAttributeValue("sex", "男");
			//per2.Add(new XElement("name", "tuo"));
			//per2.Add(new XElement("age", 25));
			//per2.Add(new XElement("address", "wk"));
			//Persons.Add(per2);
			Random rd = new Random();

			for (int i = 0; i < 100; i++)
			{
				XElement per = new XElement("Person");

				XAttribute sex = new XAttribute("Sex", "男女"[rd.Next(2)]);
				XElement id = new XElement("ID", i.ToString("0000"));
				XElement name = new XElement("Name", "jun"+i);
				XElement age = new XElement("Age");

				per.Add(sex, id, name, age);
				per.Element("Age").Value = rd.Next(14, 30).ToString();
				Persons.Add(per);
				
			}
			xdoc.Add(Persons);

			xdoc.Save(@"C:\Users\summer\Desktop\MyXml.xml");

			/*遍历xml文件*/
			//XDocument xd = XDocument.Load(@"C:\Users\summer\Desktop\MyXml.xml");
			//foreach (var item in xd.Root.Elements())
			//{
			//	Console.WriteLine($@"name:{item.Element("Name").Value},age:{item.Element("Age").Value}");
			//	Console.WriteLine();
			//}


			//var result = xd.Root.Elements()
			//	 .Where(p => p.Element("name").Value.Contains("t"))
			//	 .Select(p => new { name = p.Element("name").Value, age = p.Element("age").Value }).FirstOrDefault(); //若要筛选就用上这个语句  

			//Console.WriteLine(result.name);

			XElement xe = XElement.Load(@"C:\Users\summer\Desktop\MyXml.xml");

			XDocument xd = XDocument.Load(@"C:\Users\summer\Desktop\MyXml.xml");

			var query = from p in xd.Root.Elements("Person")
						where p.Element("Name").Value.Contains("2")
						select p;

			
			//修改节点的值
			foreach (var item in query)
			{
				XElement changeEle = item as XElement;

				/*修改*/
				//changeEle.Element("Name").Value = "shuaigei";
				//changeEle.Attribute("Sex").Value = "漂亮";

				/*删除*/
				//changeEle.Remove();
				//xd.Save(@"C:\Users\summer\Desktop\MyXml.xml");
			}
			

			xd.Save(@"C:\Users\summer\Desktop\MyXml.xml");

			Console.WriteLine("修改");
			Console.ReadKey();
		}
	}
}
