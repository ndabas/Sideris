#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Sideris.SiderisServer
{
    internal class ByteParser
    {
        private byte[] bytes;
        private int currentOffset;

        public ByteParser(byte[] bytes)
        {
            this.bytes = bytes;
            currentOffset = 0;
        }

        public int CurrentOffset
        {
            get
            {
                return currentOffset;
            }
        }

        public ByteString ReadLine()
        {
            ByteString line = null;

            for(int i = currentOffset; i < bytes.Length; i++)
            {
                if(bytes[i] == (byte) '\n')
                {
                    int len = i - currentOffset;
                    if(len > 0 && bytes[i - 1] == (byte) '\r')
                        len--;

                    line = new ByteString(bytes, currentOffset, len);
                    currentOffset = i + 1;
                    return line;
                }
            }

            if(currentOffset < bytes.Length)
                line = new ByteString(bytes, currentOffset, bytes.Length - currentOffset);

            currentOffset = bytes.Length;
            return line;
        }

    }
}
