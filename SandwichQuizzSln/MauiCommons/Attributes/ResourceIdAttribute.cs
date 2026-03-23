namespace MauiCommons.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class ResourceIdAttribute(string value) : ValueAttributeBase<string>(value)
{ }
