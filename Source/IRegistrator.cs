// The NiTiS-Dev licenses this file to you under the MIT license.

namespace NiTiS.Registry;
public interface IRegistrator
{
	public void Reg<T>(Identifier id, T item) where T : IRegistryType;
	public void Unreg(Identifier id);
	public bool Exists(Identifier id);
	public void Clear();
	public void ClearOfType<T>() where T : IRegistryType;
}
