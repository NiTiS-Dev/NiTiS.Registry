// The NiTiS-Dev licenses this file to you under the MIT license.

using System;

namespace NiTiS.Registry;
public sealed class InvalidIdentifierException : Exception
{
	public InvalidIdentifierException(string argName) : base($"Invalid characters at {argName}")
	{

	}
}
