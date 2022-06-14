// The NiTiS-Dev licenses this file to you under the MIT license.
using System;

namespace NiTiS.Registry;
public readonly struct Identifier : IEquatable<Identifier>, IEquatable<string?>
{
	public readonly string name, type;
	public static readonly char InvalidCharacter = ':';
	public Identifier(string type, string name)
	{
		this.name = name;
		this.type = type;
		if (name.Contains(InvalidCharacter)) throw new InvalidIdentifierException(nameof(name));
		if (type.Contains(InvalidCharacter)) throw new InvalidIdentifierException(nameof(type));
	}
	public static Identifier Create<T>(string name) where T : IRegistryType
		=> new(T.RegistryName, name);
	public override string ToString() 
		=> $"{type}:{name}";
	public bool Equals(Identifier other)
		=> name == other.name && type == other.type;
	public bool Equals(string? other)
		=> this.ToString() == other;
	public override bool Equals(object? obj)
		=> obj is Identifier id ? Equals(id) : obj is string str ? Equals(str) : false;
	public static Identifier Parse(string id)
	{
		int splitIndex = id.IndexOf(InvalidCharacter);
		if (splitIndex == -1) throw new InvalidIdentifierException(nameof(id));
		return new(id[0..(splitIndex)], id[(splitIndex + 1)..id.Length]);
	}
	public static bool operator ==(Identifier left, Identifier right)
		=> left.Equals(right);
	public static bool operator !=(Identifier left, Identifier right)
		=> !left.Equals(right);
	public static bool operator ==(Identifier left, string? right)
		=> left.Equals(right);
	public static bool operator !=(Identifier left, string? right)
		=> !left.Equals(right);
	public override int GetHashCode()
		=> HashCode.Combine(type, name);
	public static explicit operator string(Identifier id)
		=> id.ToString();
	public static explicit operator Identifier(string id)
		=> Identifier.Parse(id);
}
