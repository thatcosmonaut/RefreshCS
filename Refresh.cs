/* Refresh - C# bindings for the Refresh graphics Library
 *
 * Copyright (c) 2020 Evan Hemsley
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Evan "cosmonaut" Hemsley <evan@moonside.games>
 *
 */

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace RefreshSharp
{
    public static class Refresh
    {
        private const string nativeLibName = "Refresh";

        /* Enums */

        public enum PresentMode
        {
            Immediate,
            Mailbox,
            FIFO,
            FIFORelaxed
        }

        public enum PrimitiveType
        {
            PointList,
            LineList,
            LineStrip,
            TriangleList,
            TriangleStrip
        }

        public enum LoadOp
        {
            Load,
            Clear,
            DontCare
        }

        public enum StoreOp
        {
            Store,
            DontCare
        }

        public enum ClearOptions
        {
            Color = 1,
            Depth = 2,
            Stencil = 4
        }

        public enum IndexElementSize
        {
            Sixteen,
            ThirtyTwo
        }

        public enum ColorFormat
        {
            R8G8B8A8,
            R5G6B5,
            A1R5G5B5,
            B4G4R4A4,
            BC1,
            BC2,
            BC3,
            R8G8_SNORM,
            R8G8B8A8_SNORM,
            A2R10G10B10,
            R16G16,
            R16G16B16A16,
            R8,
            R32_SFLOAT,
            R32G32_SFLOAT,
            R32G32B32A32_SFLOAT,
            R16_SFLOAT,
            R16G16_SFLOAT,
            R16G16B16A16_SFLOAT
        }

        public enum DepthFormat
        {
            Depth16,
            Depth32,
            Depth16Stencil8,
            Depth32Stencil8
        }

        public enum TextureUsageFlagBits
        {
            SamplerBit = 1,
            ColorTargetBit = 2
        }

        public enum SampleCount
        {
            One,
            Two,
            Four,
            Eight,
            Sixteen,
            ThirtyTwo,
            SixtyFour
        }

        public enum CubeMapFace
        {
            PositiveX,
            NegativeX,
            PositiveY,
            NegativeY,
            PositiveZ,
            NegativeZ
        }

        public enum VertexElementFormat
        {
            Single,
            Vector2,
            Vector3,
            Vector4,
            Color,
            Byte4,
            Short2,
            Short4,
            NormalizedShort2,
            NormalizedShort4,
            HalfVector2,
            HalfVector4
        }

        public enum VertexInputRate
        {
            Vertex,
            Instance
        }

        public enum FillMode
        {
            Fill,
            Line,
            Point
        }

        public enum CullMode
        {
            None,
            Front,
            Back,
            FrontAndBack
        }

        public enum FrontFace
        {
            CounterClockwise,
            Clockwise
        }

        public enum CompareOp
        {
            Never,
            Less,
            Equal,
            LessOrEqual,
            Greater,
            NotEqual,
            GreaterOrEqual,
            Always
        }

        public enum StencilOp
        {
            Keep,
            Zero,
            Replace,
            IncrementAndClamp,
            DecrementAndClamp,
            Invert,
            IncrementAndWrap,
            DecrementAndWrap
        }

        public enum BlendOp
        {
            Add,
            Subtract,
            ReverseSubtract,
            Min,
            Max
        }

        public enum LogicOp
        {
            Clear,
            And,
            AndReverse,
            Copy,
            AndInverted,
            NoOp,
            Xor,
            Or,
            Nor,
            Equivalent,
            Invert,
            OrReverse,
            CopyInverted,
            OrInverted,
            Nand,
            Set
        }

        public enum BlendFactor
        {
            Zero,
            One,
            SourceColor,
            OneMinusSourceColor,
            DestinationColor,
            OneMinusDestinationColor,
            SourceAlpha,
            OneMinusSourceAlpha,
            DestinationAlpha,
            OneMinusDestinationAlpha,
            ConstantColor,
            OneMinusConstantColor,
            ConstantAlpha,
            OneMinusConstantAlpha,
            SourceAlphaSaturate,
            SourceOneColor,
            OneMinusSourceOneColor,
            SourceOneAlpha,
            OneMinusSourceOneAlpha
        }

        public enum ColorComponentFlagBits
        {
            R = 1,
            G = 2,
            B = 4,
            A = 8
        }

        public enum ShaderStageType
        {
            Vertex,
            Fragment
        }

        public enum Filter
        {
            Nearest,
            Linear,
            Cubic
        }

        public enum SamplerMipmapMode
        {
            Nearest,
            Linear
        }

        public enum SamplerAddressMode
        {
            Repeat,
            MirroredRepeat,
            ClampToEdge,
            ClampToBorder
        }

        public enum BorderColor
        {
            FloatTransparentBlack,
            IntTransparentBlack,
            FloatOpaqueBlack,
            IntOpaqueBlack,
            FloatOpaqueWhite,
            IntOpaqueWhite
        }

        /* Native Structures */

        [StructLayout(LayoutKind.Sequential)]
        public struct Color
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DepthStencilValue
        {
            public float depth;
            public uint stencil;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int x;
            public int y;
            public int w;
            public int h;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Vec4
        {
            public float x;
            public float y;
            public float z;
            public float w;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Viewport
        {
            public float x;
            public float y;
            public float w;
            public float h;
            public float minDepth;
            public float maxDepth;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TextureSlice
        {
            public IntPtr texture;
            public Rect rectangle;
            public uint depth;
            public uint layer;
            public uint level;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PresentationParameters
        {
            public IntPtr deviceWindowHandle;
            public PresentMode presentMode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SamplerStateCreateInfo
        {
            public Filter minFilter;
            public Filter magFilter;
            public SamplerMipmapMode mipmapMode;
            public SamplerAddressMode addressModeU;
            public SamplerAddressMode addressModeV;
            public SamplerAddressMode addressModeW;
            public float mipLodBias;
            public byte anisotropyEnable;
            public float maxAnisotropy;
            public byte compareEnable;
            public CompareOp compareOp;
            public float minLod;
            public float maxLod;
            public BorderColor borderColor;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct VertexBinding
        {
            public uint binding;
            public uint stride;
            public VertexInputRate inputRate;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct VertexAttribute
        {
            public uint location;
            public uint binding;
            public VertexElementFormat format;
            public uint offset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct VertexInputState
        {
            public VertexBinding* vertexBindings;
            public uint vertexBindingCount;
            public VertexAttribute* vertexAttributes;
            public uint vertexAttributeCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct StencilOpState
        {
            public StencilOp failOp;
            public StencilOp passOp;
            public StencilOp depthFailOp;
            public CompareOp compareOp;
            public uint compareMask;
            public uint writeMask;
            public uint reference;
        }
    }
}
