//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using System;

namespace ndreg_Editor.Data
{
    class NdcInfoPos
    {
        public long start = 0;
        public long end = 0;

        public NdcInfoPos()
        {
        }

        public NdcInfoPos(long start, long end)
        {
            this.start = start;
            this.end = end;
        }
    }

    class NdcInfo
    {
        public NdcInfoPos pos = new NdcInfoPos();
        public uint len = 0;
        public byte[] status_server = new Byte[32];
        public uint status_port;
        public byte[] patch_server = new Byte[64];
        public byte[] login_server = new Byte[32];
        public uint login_port;

        public void calculateLen()
        {

            this.len = (uint) this.status_server.Length
                + sizeof(uint)
                + (uint) this.patch_server.Length
                + (uint) this.login_server.Length
                + sizeof(uint);
        }
    }

    /*
    class NdcOption
    {
        public int name_len;
        public char[] name;
        public int value_len;
        public byte[] value;
    }
    */
}
