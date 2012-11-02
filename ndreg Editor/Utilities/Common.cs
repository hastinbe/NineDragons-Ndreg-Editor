//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;
using System.Text;

namespace ndreg_Editor.Utilities
{
    internal class Common
    {
        public static void NdcStringToFixedByteArray(string source, ref byte[] dest)
        {
            NdcStringToFixedByteArray(source, ref dest, 0x0);
        }

        public static void NdcStringToFixedByteArray(string source, ref byte[] dest, uint xorc)
        {
            byte[] bsource = Encoding.ASCII.GetBytes(source);
            Array.Resize(ref bsource, dest.Length);
            dest = Xorcize(bsource, 0xDC);
        }

        public static byte[] Xorcize(byte[] buffer, uint rval)
        {
            for (uint i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)(buffer[i] ^ rval);
            return buffer;
        }

        public static uint Xorcize(uint number, uint rval)
        {
            return number & 0xffffffff ^ rval;
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        public static string ByteToHex(byte[] buffer)
        {
            return ByteToHex(buffer, buffer.Length);
        }

        public static string ByteToHex(byte[] buffer, int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
                str = str + buffer[i].ToString("X2") + " ";
            return str;
        }

        public static string ByteToText(byte[] buffer)
        {
            return ByteToText(buffer, 0, buffer.Length);
        }

        public static string ByteToText(byte[] buffer, int length)
        {
            return ByteToText(buffer, 0, length);
        }

        public static string ByteToText(byte[] buffer, int index, int length)
        {
            char[] chArray = Encoding.UTF7.GetChars(buffer, index, length);
            string str = "";
            for (int i = 0; i < chArray.Length; i++)
                str = str + chArray[i].ToString();
            return str;
        }
    }
}
