// ReSharper disable once CheckNamespace
namespace OryxEngine.Memory.Optionals;
public class Writer(EndianMode mode, byte[] buffer, Action? failureCallback = null)
{
    private readonly IWriter _writer = mode == EndianMode.Big ?
            new WriterBig(buffer) :
            new WriterLittle(buffer);
    
    private readonly Action? _failureCallback = failureCallback;
    
    public readonly EndianMode Mode = mode;
    public byte[] Buffer => _writer.Buffer;
    public int Position => _writer.Position;
    public void Reset() => _writer.Reset();
    public void SetPosition(int position) => _writer.SetPosition(position);
    public void Write(byte value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(bool value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(ushort value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(short value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(uint value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(int value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(float value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(double value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(ulong value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void Write(long value)
    {
        var result = _writer.Write(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void WriteString(ReadOnlySpan<char> value)
    {
        var result = _writer.WriteString(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }

    public void WriteStringInt(ReadOnlySpan<char> value)
    {        
        var result = _writer.WriteStringInt(value);
        if (result.IsSuccess)
            return;
        
        _failureCallback?.Invoke();
    }
}