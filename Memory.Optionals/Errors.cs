using OryxEngine.Optionals;

// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory.Optionals;

public static class Errors {
    private const string OutOfBounds = "OutOfBounds";
    public static readonly ErrorDetailed OutOfBoundsErrorByte = OutOfBounds + "Byte";
    public static readonly ErrorDetailed OutOfBoundsErrorBool = OutOfBounds + "Bool";
    public static readonly ErrorDetailed OutOfBoundsErrorInt16 = OutOfBounds + "Short";
    public static readonly ErrorDetailed OutOfBoundsErrorUInt16 = OutOfBounds + "UShort";
    public static readonly ErrorDetailed OutOfBoundsErrorInt32 = OutOfBounds + "Int";
    public static readonly ErrorDetailed OutOfBoundsErrorUInt32 = OutOfBounds + "UInt";
    public static readonly ErrorDetailed OutOfBoundsErrorInt64 = OutOfBounds + "Long";
    public static readonly ErrorDetailed OutOfBoundsErrorUInt64 = OutOfBounds + "ULong";
    public static readonly ErrorDetailed OutOfBoundsErrorFloat = OutOfBounds + "Float";
    public static readonly ErrorDetailed OutOfBoundsErrorDouble = OutOfBounds + "Double";
    public static readonly ErrorDetailed OutOfBoundsErrorString = OutOfBounds + "String";
    public static readonly ErrorDetailed OutOfBoundsErrorStringInt = OutOfBounds + "StringInt";
}