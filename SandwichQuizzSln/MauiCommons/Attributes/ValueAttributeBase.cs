namespace MauiCommons.Attributes;

/// <summary>
/// Base class for value attribute
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public abstract class ValueAttributeBase<T> : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueAttributeBase{T}"/> class.
    /// </summary>
    /// <param name="value">The value of the attribute</param>
    public ValueAttributeBase(T value)
        => this.Value = value;

    /// <summary>
    /// Attribute's value
    /// </summary>
    public T Value { get; }

    public override bool Equals(object? obj)
    {
        if (object.ReferenceEquals(obj, this))
            return true;

        return (obj is ValueAttributeBase<T> other)
               && other.Value?.ToString() == this.Value?.ToString();
    }

    public override int GetHashCode()
        => this.Value?.GetHashCode() ?? 0;
}
