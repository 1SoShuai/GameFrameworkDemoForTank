using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Tank
{
    /// <summary>
    /// ProtoBuf工具类，提供编码和解码功能
    /// </summary>
    public class ProtoTools
    {
        public static byte[] Encode(IExtensible msgBase)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Serializer.Serialize(memory, msgBase);
                return memory.ToArray();
            }
        }

        public static IExtensible Decode(string protoName, byte[] bytes, int offset, int count)
        {
            using (MemoryStream memory = new MemoryStream(bytes, offset, count))
            {
                Type t = Type.GetType(protoName);
                return (IExtensible)Serializer.Deserialize(t, memory);
            }
        }
    }
}
