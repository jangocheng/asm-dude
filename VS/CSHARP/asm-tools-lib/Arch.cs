﻿// The MIT License (MIT)
//
// Copyright (c) 2017 Henk-Jan Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Text;

namespace AsmTools {

    public enum Arch {

        NONE,

        ARCH_8086,
        ARCH_186,
        ARCH_286,
        ARCH_386,
        ARCH_486,
        /// <summary>1993 (also knonw as i586)</summary>
        PENT,
        /// <summary>1995 (also known as i686)</summary>
        P6,

        MMX,

        SSE,
        SSE2,
        SSE3,
        SSSE3,
        SSE4_1,
        SSE4_2,
        SSE4A,
        /// <summary>AMD</summary>
        SSE5,

        AVX,
        AVX2,

        ///<summary>AVX512 foundation (Knights Landing, Intel Xeon)</summary>
        AVX512_F,

        ///<summary>AVX512 conflict detection (Knights Landing, Intel Xeon)</summary>
        AVX512_CD,

        ///<summary>AVX512 exponential and reciprocal (Knights Landing)</summary>
        AVX512_ER,

        ///<summary>AVX512 prefetch (Knights Landing)</summary>
        AVX512_PF,

        ///<summary>AVX512 byte and word (Intel Xeon)</summary>
        AVX512_BW,

        ///<summary>AVX512 doubleword and quadword (Intel Xeon)</summary>
        AVX512_DQ,

        ///<summary>AVX512 Vector Length Extensions (Intel Xeon)</summary>
        ///An additional orthogonal capability known as Vector Length Extensions provide for most AVX-512 instructions 
        ///to operate on 128 or 256 bits, instead of only 512. Vector Length Extensions can currently be applied to
        ///most Foundation Instructions, the Conflict Detection Instructions as well as the new Byte, Word, Doubleword 
        ///and Quadword instructions. These AVX-512 Vector Length Extensions are indicated by the AVX512VL CPUID flag. 
        ///The use of Vector Length Extensions extends most AVX-512 operations to also operate on XMM (128-bit, SSE) 
        ///registers and YMM (256-bit, AVX) registers. The use of Vector Length Extensions allows the capabilities of 
        ///EVEX encodings, including the use of mask registers and access to registers 16..31, to be applied to XMM 
        ///and YMM registers instead of only to ZMM registers.
        AVX512_VL,

        //Cannon Lake
        AVX512_IFMA,

        //Cannon Lake
        AVX512_VBMI,

        //Knight Mill, Ice Lake
        AVX512_VPOPCNTDQ,

        //Knight Mill
        AVX512_4VNNIW,

        //Knight Mill
        AVX512_4FMAPS,

        //Ice Lake
        AVX512_VBMI2,
        //Ice Lake
        AVX512_VNNI,

        //Ice Lake
        AVX512_BITALG,

        //Ice Lake
        AVX512_GFNI,

        //Ice Lake
        AVX512_VAES,
        //Ice Lake
        AVX512_VPCLMULQDQ,


        #region Misc Intel
        /// <summary>Multi-Precision Add-Carry Instruction Extensions</summary>
        ADX,

        /// <summary>Advanced Encryption Standard Instruction Set </summary>
        AES,

        /// <summary>Virtual Machine Extensions (VMX)</summary>
        VMX,

        /// <summary>Bit Manipulation Instructions Sets 1</summary>
        BMI1,

        /// <summary>Bit Manipulation Instructions Sets 2</summary>
        BMI2,

        /// <summary>half precision floating point conversion (also known as CVT16) </summary>
        F16C,

        /// <summary>Fused Multiply-Add</summary>
        FMA,

        /// <summary>TODO</summary>
        FSGSBASE,

        ///<summary>Hardware Lock Elision</summary>
        HLE,

        /// <summary>Invalidates TLBs, two instructions</summary>
        INVPCID,

        /// <summary>Secure Hash Algorithm Extensions</summary>
        SHA,

        /// <summary>Transactional Synchronization Extensions</summary>
        RTM,

        /// <summary>Memory Protection Extensions</summary>
        MPX,

        /// <summary>Two instruction PCLMULQDQ (Carry-Less Multiplication Quadword)</summary>
        PCLMULQDQ,

        /// <summary>One instruction LZCNT</summary>
        LZCNT,

        /// <summary>One instruction: PREFETCHWT1</summary>
        PREFETCHWT1,

        /// <summary>One instruction: PREFETCHW</summary>
        PRFCHW,

        /// <summary>One instruction: RDPID (Read Processor ID)</summary>
        RDPID,

        /// <summary>One instruction: RDRAND (Read Random Number)</summary>
        RDRAND,

        /// <summary>One instruction: RDSEED (Read Random SEED)</summary>
        RDSEED,

        /// <summary>One instruction: XSAVEOPT (Save Processor Extended States Optimized)</summary>
        XSAVEOPT,
        #endregion

        //Software Guard Extensions
        SGX1,
        
        //Software Guard Extensions
        SGX2,

        /// <summary>SAFER MODE EXTENSIONS</summary>
        SMX,
        #region Misc Other
        X64,

        IA64,

        UNDOC,
        #endregion 


        #region AMD
        AMD,

        /// <summary>AMD: Trailing Bit Manipulation</summary>
        TBM,

        ARCH_3DNOW,

        #endregion
        CYRIX,
        CYRIXM,
    }

    public static class ArchTools {

        public static Arch ParseArch(string str, bool warn = true)
        {
            switch (str.Replace("_", "").ToUpper())
            {
                case "NONE": return Arch.NONE;

                case "8086": return Arch.ARCH_8086;
                case "186": return Arch.ARCH_186;
                case "286": return Arch.ARCH_286;
                case "386": return Arch.ARCH_386;
                case "486": return Arch.ARCH_486;
                case "PENT": return Arch.PENT;
                case "P6": return Arch.P6;

                case "MMX": return Arch.MMX;
                case "SSE": return Arch.SSE;
                case "SSE2": return Arch.SSE2;
                case "SSE3": return Arch.SSE3;
                case "SSSE3": return Arch.SSSE3;
                case "SSE41": return Arch.SSE4_1;
                case "SSE42": return Arch.SSE4_2;
                case "SSE4A": return Arch.SSE4A;
                case "SSE5": return Arch.SSE5;

                case "AVX": return Arch.AVX;
                case "AVX2": return Arch.AVX2;
                case "AVX512VL": return Arch.AVX512_VL;
                case "AVX512DQ": return Arch.AVX512_DQ;
                case "AVX512BW": return Arch.AVX512_BW;
                case "AVX512ER": return Arch.AVX512_ER;
                case "AVX512F": return Arch.AVX512_F;
                case "AVX512CD": return Arch.AVX512_CD;
                case "AVX512PF": return Arch.AVX512_PF;

                case "AVX512IFMA": return Arch.AVX512_IFMA;
                case "AVX512VBMI": return Arch.AVX512_VBMI;
                case "AVX512VPOPCNTDQ": return Arch.AVX512_VPOPCNTDQ;
                case "AVX5124VNNIW": return Arch.AVX512_4VNNIW;
                case "AVX5124FMAPS": return Arch.AVX512_4FMAPS;

                case "VBMI2":                case "AVX512VBMI2": return Arch.AVX512_VBMI2;                case "VNNI":
                case "AVX512VNNI": return Arch.AVX512_VNNI;
                case "BITALG":
                case "AVX512BITALG": return Arch.AVX512_BITALG;
                case "GFNI":
                case "AVX512GFNI": return Arch.AVX512_GFNI;
                case "VAES":
                case "AVX512VAES": return Arch.AVX512_VAES;
                case "VPCLMULQDQ":
                case "AVX512VPCLMULQDQ": return Arch.AVX512_VPCLMULQDQ;

                case "HLE": return Arch.HLE;
                case "BMI1": return Arch.BMI1;
                case "BMI2": return Arch.BMI2;
                case "FMA": return Arch.FMA;
                case "AES": return Arch.AES;
                case "TBM": return Arch.TBM;

                case "AMD": return Arch.AMD;
                case "3DNOW": return Arch.ARCH_3DNOW;
                case "IA64": return Arch.IA64;

                case "CYRIX": return Arch.CYRIX;
                case "CYRIXM": return Arch.CYRIXM;
                case "INVPCID": return Arch.INVPCID;
                case "VMX": return Arch.VMX;
                case "ADX": return Arch.ADX;

                case "X64": return Arch.X64;
                case "PCLMULQDQ": return Arch.PCLMULQDQ;
                case "PRFCHW": return Arch.PRFCHW;
                case "RDPID": return Arch.RDPID;
                case "RDRAND": return Arch.RDRAND;
                case "RDSEED": return Arch.RDSEED;

                case "XSAVEOPT": return Arch.XSAVEOPT;
                case "XSS": return Arch.XSAVEOPT;
                case "XSAVE": return Arch.XSAVEOPT;
                case "XSAVEC": return Arch.XSAVEOPT;


                case "FSGSBASE": return Arch.FSGSBASE;
                case "LZCNT": return Arch.LZCNT;
                case "F16C": return Arch.F16C;
                case "MPX": return Arch.MPX;
                case "SHA": return Arch.SHA;
                case "RTM": return Arch.RTM;
                case "PREFETCHWT1": return Arch.PREFETCHWT1;

                case "SGX1": return Arch.SGX1;
                case "SGX2": return Arch.SGX2;
                case "SMX": return Arch.SMX;
                


                case "UNDOC": return Arch.UNDOC;
                default:
                    if (warn) Console.WriteLine("WARNING: parseArch: no arch for str " + str);
                    return Arch.NONE;
            }
        }

        public static string ArchDocumentation(Arch arch) {
            switch (arch) {
                case Arch.NONE: return "";
                case Arch.ARCH_8086: return "";
                case Arch.ARCH_186: return "";
                case Arch.ARCH_286: return "";
                case Arch.ARCH_386: return "";
                case Arch.ARCH_486: return "";
                case Arch.PENT: return "Instruction set of the Pentium, 1994 (also known as i585)";
                case Arch.P6: return "Instruction set of the Pentium 6, 1995 (also knows as i686)";
                case Arch.MMX: return "";
                case Arch.SSE: return "";
                case Arch.SSE2: return "";
                case Arch.SSE3: return "";
                case Arch.SSSE3: return "";
                case Arch.SSE4_1: return "";
                case Arch.SSE4_2: return "";
                case Arch.SSE4A: return "Instruction set SSE4A, AMD";
                case Arch.SSE5: return "Instruction set SSE5, AMD";
                case Arch.AVX: return "";
                case Arch.AVX2: return "";
                case Arch.AVX512_F: return "AVX512-F - Foundation";
                case Arch.AVX512_CD: return "AVX512-CD - Conflict Detection";
                case Arch.AVX512_ER: return "AVX512-ER - Exponential and Reciprocal";
                case Arch.AVX512_PF: return "AVX512-PF - Prefetch";
                case Arch.AVX512_BW: return "AVX512-BW - Byte and Word";
                case Arch.AVX512_DQ: return "AVX512-DQ - Doubleword and QuadWord";
                case Arch.AVX512_VL: return "AVX512-VL - Vector Length Extensions";
                case Arch.AVX512_IFMA: return "AVX512-IFMA - Integer Fused Multiply Add";
                case Arch.AVX512_VBMI: return "AVX512-VBMI - Vector Byte Manipulation Instructions";
                case Arch.AVX512_VPOPCNTDQ: return "AVX512-VPOPCNTDQ - Vector Population Count instructions for Dwords and Qwords";
                case Arch.AVX512_4VNNIW: return "AVX512-4VNNIW - Vector Neural Network Instructions Word variable precision";
                case Arch.AVX512_4FMAPS: return "AVX512-4FMAPS - Fused Multiply Accumulation Packed Single precision";

                case Arch.ADX: return "Multi-Precision Add-Carry Instruction Extension";
                case Arch.AES: return "Advanced Encryption Standard Extension";
                case Arch.VMX: return "Virtual Machine Extension";
                case Arch.BMI1: return "Bit Manipulation Instruction Set 1";
                case Arch.BMI2: return "Bit Manipulation Instruction Set 2";
                case Arch.F16C: return "Half Precision Floating Point Conversion Instructions";
                case Arch.FMA: return "Fused Multiply-Add Instructions";
                case Arch.FSGSBASE: return "";
                case Arch.HLE: return "Hardware Lock Elision Instructions";
                case Arch.INVPCID: return "Invalidate Translation Lookaside Buffers (TLBs)";
                case Arch.SHA: return "Secure Hash Algorithm Extensions";
                case Arch.RTM: return "Transactional Synchronization Extensions";
                case Arch.MPX: return "Memory Protection Extensions";
                case Arch.PCLMULQDQ: return "Carry-Less Multiplication Instructions";
                case Arch.LZCNT: return "";
                case Arch.PREFETCHWT1: return "";
                case Arch.PRFCHW: return "";
                case Arch.RDPID: return "Read processor ID";
                case Arch.RDRAND: return "Read random number";
                case Arch.RDSEED: return "Reed random seed";
                case Arch.XSAVEOPT: return "Save Processor Extended States Optimized";
                case Arch.X64: return "64-bit Mode Instructions";
                case Arch.IA64: return "Intel Architecture 64";
                case Arch.UNDOC: return "Undocumented Instructions";
                case Arch.AMD: return "AMD";
                case Arch.TBM: return "Trailing Bit Manipulation (AMD)";
                case Arch.ARCH_3DNOW: return "3DNow (AMD)";
                case Arch.CYRIX: return "Cyrix Instructions Set";
                case Arch.CYRIXM: return "Cyrix M Instruction Set";
                default:
                    return "";
            }
        }

        public static string ToString(IEnumerable<Arch> archs) {
            bool empty = true;
            StringBuilder sb = new StringBuilder();
            foreach (Arch arch in archs) {
                sb.Append(ArchTools.ToString(arch));
                sb.Append(",");
                empty = false;
            }
            if (empty) {
                return "";
            } else {
                sb.Length--; // get rid of the last comma;
                sb.Append("]");
                return " [" + sb.ToString();
            }
        }

        public static string ToString(Arch arch) {
            switch (arch) {
                case Arch.ARCH_8086: return "8086";
                case Arch.ARCH_186: return "186";
                case Arch.ARCH_286: return "286";
                case Arch.ARCH_386: return "386";
                case Arch.ARCH_486: return "486";
                case Arch.ARCH_3DNOW: return "3DNOW";
                default:
                    break;
            }
            return arch.ToString();
        }
    }
}
