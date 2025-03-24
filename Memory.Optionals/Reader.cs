// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory.Optionals;

public class Reader(EndianMode mode, byte[] buffer, Action? failureCallback = null)
{
    public readonly EndianMode Mode = mode;
    private readonly IReader _reader = mode == EndianMode.Big ? new ReaderBig(buffer) : new ReaderLittle(buffer);
    private readonly Action? _failureCallback = failureCallback;

    public byte[] Buffer => _reader.Buffer;
    public int Position { get => _reader.Position; set => _reader.Position = value; }
    public int Length => _reader.Length;
    
    
    public void Reset(int length) => _reader.Reset(length);
    public void Clear() => _reader.Clear();

    public byte PeekByte() {
        var result = _reader.PeekByte();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public byte ReadByte() {
        var result = _reader.ReadByte();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public bool ReadBoolean() {
        var result = _reader.ReadBoolean();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return false;
    }

    public short ReadInt16() {
        var result = _reader.ReadInt16();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public ushort ReadUInt16() {
        var result = _reader.ReadUInt16();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public int ReadInt32() {
        var result = _reader.ReadInt32();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public uint ReadUInt32() {
        var result = _reader.ReadUInt32();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public long ReadInt64() {
        var result = _reader.ReadInt64();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public ulong ReadUInt64() {
        var result = _reader.ReadUInt64();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0;
    }

    public float ReadFloat() {
        var result = _reader.ReadFloat();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0f;
    }

    public double ReadDouble() {
        var result = _reader.ReadDouble();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return 0.0;
    }

    public string ReadString() {
        var result = _reader.ReadString();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return "";
    }

    public string ReadStringInt() {
        var result = _reader.ReadStringInt();
        if (result.IsSuccess)
            return result.Value;
        
        _failureCallback?.Invoke();
        return "";
    }
}