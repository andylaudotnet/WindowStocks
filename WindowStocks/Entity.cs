// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the Entity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.IO;
	using System.Reflection;
	using System.Runtime.Serialization.Formatters.Binary;
	using System.Xml;

	[Serializable]
	internal class Entity
	{
		#region Methods (4) 

		// Protected Methods (2) 

		protected static T Load<T>(T entity, string filePath)
		{
			Type eType = entity.GetType();
			PropertyInfo[] eProperties = eType.GetProperties();
			MethodInfo readMethod = eType.GetMethod("ReadXmlNode", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo saveMehotd = eType.GetMethod("Save");

			if (!File.Exists(filePath))
				saveMehotd.Invoke(entity, new object[] { filePath });
			else {
				XmlDocument xmlDoc = new XmlDocument();
				try {
					xmlDoc.Load(filePath);
				} catch (XmlException) {
					saveMehotd.Invoke(entity, new object[] { filePath });
					return entity;
				}

				//读取用户数据文件
				foreach (PropertyInfo p in eProperties) {
					object[] result;

					try {
						result = readMethod.MakeGenericMethod(p.PropertyType).Invoke(entity, new object[] { xmlDoc, string.Format("/{0}/{1}", eType.Name, p.Name) }) as object[];
					} catch (TargetInvocationException) {
						continue;
					}

					if ((bool)result[0])
						p.SetValue(entity, result[1], null);
				}
			}

			return entity;

		}

		protected void Save(Type type, string filePath)
		{
			PropertyInfo[] properties = type.GetProperties();

			XmlDocument xmlDoc = new XmlDocument();

			//建立Xml的定义声明
			xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));

			//创建根节点
			XmlElement root = xmlDoc.CreateElement(type.Name);
			xmlDoc.AppendChild(root);

			//反射遍历type创建各属性nodes
			foreach (PropertyInfo p in properties) {
				XmlElement node = xmlDoc.CreateElement(p.Name);
				object pValue = p.GetValue(this, null);
				node.InnerText = pValue == null ? string.Empty : Convert.ToBase64String(Serialize(pValue));
				root.AppendChild(node);
			}

			xmlDoc.Save(filePath);

		}
		// Private Methods (2) 

		private static T Deserialize<T>(byte[] bytes)
		{
			BinaryFormatter bSer = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream()) {
				ms.Write(bytes, 0, bytes.Length);
				ms.Seek(0, SeekOrigin.Begin);
				return (T)bSer.Deserialize(ms);
			}
		}

		private static byte[] Serialize(object obj)
		{
			BinaryFormatter bSer = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream()) {
				bSer.Serialize(ms, obj);
				return ms.ToArray();
			}
		}

		#endregion Methods 

		// ReSharper disable UnusedMember.Local
		protected object[] ReadXmlNode<T>(XmlNode xmlDoc, string xPath)
		// ReSharper restore UnusedMember.Local
		{
			XmlNode node = xmlDoc.SelectSingleNode(xPath);
			object[] result = new object[2];
			result[0] = node == null ? false : true;
			result[1] = node == null || node.InnerText.Length == 0 ? default(T) : Deserialize<T>(Convert.FromBase64String(node.InnerText));
			return result;
		}
	}
}
