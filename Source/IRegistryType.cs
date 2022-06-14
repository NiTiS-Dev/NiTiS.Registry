// The NiTiS-Dev licenses this file to you under the MIT license.
namespace NiTiS.Registry;
public interface IRegistryType
{
	public static void InvokeRegistry(IRegistryType item)
		=> item.Registry();
	public static void InvokeUnregistry(IRegistryType item)
		=> item.Unregistry();
	protected void Registry();
	protected void Unregistry();
	/// <summary>
	/// Registry type name
	/// </summary>
	public static abstract string RegistryName { get; }
}
