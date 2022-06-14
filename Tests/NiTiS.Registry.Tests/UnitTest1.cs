namespace NiTiS.Registry.Tests;

[TestClass]
public class IdentifierTests
{
	[TestMethod]
	public void Parse_WorkTest1()
	{
		Identifier parsedId = Identifier.Parse("hta:1_113asd{AQ.s");
		Identifier expected = new("hta", "1_113asd{AQ.s");
		Assert.AreEqual(expected, parsedId);
	}
	[TestMethod]
	public void Create_WorkTest1()
	{
		Identifier createdId = Identifier.Create<secret1>("gogol");
		Identifier expected = new("c1a", "gogol");
		Assert.AreEqual(expected, createdId);
	}
	private class secret1 : IRegistryType
	{
		public static string RegistryName => "c1a";
		public void Registry() { }
		public void Unregistry() { }
	}
}