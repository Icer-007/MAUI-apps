namespace MauiCommons.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class DescriptionAttribute(string value) : ValueAttributeBase<string>(value)
{ }
