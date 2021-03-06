﻿using System;
using System.IO;
using System.Text;
using Wire;
using System.Runtime.CompilerServices;

namespace SerializerTests.Serializers
{
    // https://github.com/rogeralsing/Wire
    class Wire<T> : TestBase<T, Serializer> where T : class
    {
        public Wire(Func<int, T> testData, Action<T> data):base(testData, data)
        {
            FormatterFactory = () =>
            {
                var lret = new Serializer();
                return lret;
            };
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Serialize(T obj, Stream stream)
        {
            Formatter.Serialize(obj, stream);
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override T Deserialize(Stream stream)
        {
            return Formatter.Deserialize<T>(stream);
        }
    }
}
