// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::FlatBuffers;

public struct LoginResp : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static LoginResp GetRootAsLoginResp(ByteBuffer _bb) { return GetRootAsLoginResp(_bb, new LoginResp()); }
  public static LoginResp GetRootAsLoginResp(ByteBuffer _bb, LoginResp obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public LoginResp __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Guid { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float X { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Y { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Z { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static Offset<LoginResp> CreateLoginResp(FlatBufferBuilder builder,
      int guid = 0,
      float x = 0.0f,
      float y = 0.0f,
      float z = 0.0f) {
    builder.StartObject(4);
    LoginResp.AddZ(builder, z);
    LoginResp.AddY(builder, y);
    LoginResp.AddX(builder, x);
    LoginResp.AddGuid(builder, guid);
    return LoginResp.EndLoginResp(builder);
  }

  public static void StartLoginResp(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddGuid(FlatBufferBuilder builder, int guid) { builder.AddInt(0, guid, 0); }
  public static void AddX(FlatBufferBuilder builder, float x) { builder.AddFloat(1, x, 0.0f); }
  public static void AddY(FlatBufferBuilder builder, float y) { builder.AddFloat(2, y, 0.0f); }
  public static void AddZ(FlatBufferBuilder builder, float z) { builder.AddFloat(3, z, 0.0f); }
  public static Offset<LoginResp> EndLoginResp(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<LoginResp>(o);
  }
  public static void FinishLoginRespBuffer(FlatBufferBuilder builder, Offset<LoginResp> offset) { builder.Finish(offset.Value); }
};

