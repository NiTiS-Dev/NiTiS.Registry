// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Registry;
public class Registrator : IRegistrator, IRegistryType
{
	public static string RegistryName => "registrator";

	private Dictionary<Identifier, IRegistryType> values = new(512);
	public void Clear()
	{
		foreach (IRegistryType key in values.Values)
		{
			IRegistryType.InvokeUnregistry(key);
		}
		values = new(512);
	}
	public void ClearOfType<T>() where T : IRegistryType
	{
		Dictionary<Identifier, IRegistryType> newValues = new(512);
		foreach (KeyValuePair<Identifier, IRegistryType> key in values)
		{
			if (T.RegistryName == key.Key.type)
			{
				IRegistryType.InvokeUnregistry(key.Value);
			}else
			{
				newValues.Add(key.Key, key.Value);
			}
		}
		values = newValues;
	}
	public bool Exists(Identifier id) => values.ContainsKey(id);
	public void Reg<T>(Identifier id, T item) where T : IRegistryType
	{
		IRegistryType.InvokeRegistry(item);
		values[id] = item;
	}
	public void Unreg(Identifier id) => throw new NotImplementedException();
	void IRegistryType.Registry() { }
	void IRegistryType.Unregistry() { }
}
