/* RefreshCS - C# bindings for the Refresh graphics Library
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

namespace RefreshCS
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

        public enum ClearOptionsBits
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

        public enum BufferUsageFlagBits
        {
            Vertex = 1,
            Index = 2,
            Compute = 4
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
        public struct VertexInputState
        {
            public IntPtr vertexBindings;
            public uint vertexBindingCount;
            public IntPtr vertexAttributes;
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

        [StructLayout(LayoutKind.Sequential)]
        public struct ColorTargetBlendState
        {
            public byte blendEnable;
            public BlendFactor sourceColorBlendFactor;
            public BlendFactor destinationColorBlendFactor;
            public BlendOp colorBlendOp;
            public BlendFactor sourceAlphaBlendFactor;
            public BlendFactor destinationAlphaBlendFactor;
            public BlendOp alphaBlendOp;
            public uint colorWriteMask;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ComputePipelineLayoutCreateInfo
        {
            public uint bufferBindingCount;
            public uint imageBindingCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GraphicsPipelineLayoutCreateInfo
        {
            public uint vertexSamplerBindingCount;
            public uint fragmentSamplerBindingCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ColorTargetDescription
        {
            public ColorFormat format;
            public SampleCount multisampleCount;
            public LoadOp loadOp;
            public StoreOp storeOp;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DepthStencilTargetDescription
        {
            public DepthFormat depthFormat;
            public LoadOp loadOp;
            public StoreOp storeOp;
            public LoadOp stencilLoadOp;
            public StoreOp stencilStoreOp;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RenderPassCreateInfo
        {
            public IntPtr colorTargetDescriptions; /* Refresh_ColorTargetDescription */
            public uint colorTargetCount;
            public IntPtr depthStencilTargetDescription;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ShaderModuleCreateInfo
        {
            public UIntPtr codeSize; /* size_t */
            public IntPtr byteCode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TextureCreateInfo
        {
            public uint width;
            public uint height;
            public uint depth;
            public byte isCube;
            public SampleCount sampleCount;
            public uint levelCount;
            public ColorFormat format;
            public uint usageFlags; /* Refresh_TextureUsageFlags */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ShaderStageState
        {
            public IntPtr shaderModule;
            [MarshalAs(UnmanagedType.LPStr)]
            public string entryPointName;
            public UInt64 uniformBufferSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ViewportState
        {
            public IntPtr viewports;
            public uint viewportCount;
            public IntPtr scissors;
            public uint scissorCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RasterizerState
        {
            public byte depthClampEnable;
            public FillMode fillMode;
            public CullMode cullMode;
            public FrontFace frontFace;
            public byte depthBiasEnable;
            public float depthBiasConstantFactor;
            public float depthBiasClamp;
            public float depthBiasSlopeFactor;
            public float lineWidth;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MultisampleState
        {
            public SampleCount multisampleCount;
            public uint sampleMask;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DepthStencilState
        {
            public byte depthTestEnable;
            public byte depthWriteEnable;
            public CompareOp compareOp;
            public byte depthBoundsTestEnable;
            public byte stencilTestEnable;
            public StencilOpState frontStencilState;
            public StencilOpState backStencilState;
            public float minDepthBounds;
            public float maxDepthBounds;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct ColorBlendState
        {
            public byte logicOpEnable;
            public LogicOp logicOp;
            public IntPtr blendStates;
            public uint blendStateCount;
            public fixed float blendConstants[4];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ComputePipelineCreateInfo
        {
            ShaderStageState computeShaderState;
            ComputePipelineLayoutCreateInfo pipelineLayoutCreateInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GraphicsPipelineCreateInfo
        {
            public ShaderStageState vertexShaderState;
            public ShaderStageState fragmentShaderState;
            public VertexInputState vertexInputState;
            public PrimitiveType primitiveType;
            public ViewportState viewportState;
            public RasterizerState rasterizerState;
            public MultisampleState multisampleState;
            public DepthStencilState depthStencilState;
            public ColorBlendState colorBlendState;
            public GraphicsPipelineLayoutCreateInfo pipelineLayoutCreateInfo;
            public IntPtr renderPass;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FramebufferCreateInfo
        {
            public IntPtr renderPass;
            public IntPtr pColorTargets;
            public uint colorTargetCount;
            public IntPtr depthStencilTarget;
            public uint width;
            public uint height;
        }

        /* Logging */

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Refresh_LogFunc(IntPtr msg);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_HookLogFunctions(
            Refresh_LogFunc info,
            Refresh_LogFunc warn,
            Refresh_LogFunc error
        );

        /* Init/Quit */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateDevice(
            ref PresentationParameters presentationParameters,
            byte debugMode
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_DestroyDevice(IntPtr device);

        /* Drawing */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_Clear(
            IntPtr device,
            IntPtr commandBuffer,
            ref Rect clearRect,
            uint clearOptions,
            ref Color[] colors,
            uint colorCount,
            float depth,
            int stencil
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_DrawInstancedPrimitives(
            IntPtr device,
            IntPtr commandBuffer,
            uint baseVertex,
            uint startIndex,
            uint primitiveCount,
            uint instanceCount,
            uint vertexParamOffset,
            uint fragmentParamOffset
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_DrawIndexedPrimitives(
            IntPtr device,
            IntPtr commandBuffer,
            uint baseVertex,
            uint startIndex,
            uint primitiveCount,
            uint vertexParamOffset,
            uint fragmentParamOffset
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_DrawPrimitives(
            IntPtr device,
            IntPtr commandBuffer,
            uint vertexStart,
            uint primitiveCount,
            uint vertexParamOffset,
            uint fragmentParamOffset
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_DispatchCompute(
            IntPtr device,
            IntPtr commandBuffer,
            uint groupCountX,
            uint groupCountY,
            uint groupCountZ,
            uint computeParamOffset
        );

        /* Creates */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateRenderPass(
            IntPtr device,
            ref RenderPassCreateInfo renderPassCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateComputePipeline(
            IntPtr device,
            ref ComputePipelineCreateInfo computePipelineCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateGraphicsPipeline(
            IntPtr device,
            ref GraphicsPipelineCreateInfo graphicsPipelineCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateSampler(
            IntPtr device,
            ref SamplerStateCreateInfo samplerStateCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateFramebuffer(
            IntPtr device,
            ref FramebufferCreateInfo framebufferCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateShaderModule(
            IntPtr device,
            ref ShaderModuleCreateInfo shaderModuleCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateTexture(
            IntPtr device,
            ref TextureCreateInfo textureCreateInfo
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateColorTarget(
            IntPtr device,
            SampleCount multisampleCount,
            ref TextureSlice textureSlice
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateDepthStencilTarget(
            IntPtr device,
            uint width,
            uint height,
            DepthFormat format
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_CreateBuffer(
            IntPtr device,
            uint usageFlags, /* BufferUsageFlagBits */
            uint sizeInBytes
        );

        /* Setters */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_SetTextureData(
            IntPtr device,
            ref TextureSlice textureSlice,
            IntPtr data,
            uint dataLengthInBytes
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_SetTextureDataYUV(
            IntPtr device,
            IntPtr y,
            IntPtr u,
            IntPtr v,
            uint yWidth,
            uint yHeight,
            uint uvWidth,
            uint uvHeight,
            IntPtr data,
            uint dataLength
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_CopyTextureToTexture(
            IntPtr device,
            IntPtr commandBuffer,
            ref TextureSlice sourceTextureSlice,
            ref TextureSlice destinationTextureSlice,
            Filter filter
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_CopyTextureToBuffer(
            IntPtr device,
            IntPtr commandBuffer,
            ref TextureSlice textureSlice,
            IntPtr buffer
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_SetBufferData(
            IntPtr device,
            IntPtr buffer,
            uint offsetInBytes,
            IntPtr data,
            uint dataLength
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint Refresh_PushVertexShaderParams(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr data,
            uint paramBlockCount
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint Refresh_PushFragmentShaderParams(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr data,
            uint paramBlockCount
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint Refresh_PushComputeShaderParams(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr data,
            uint paramBlockCount
        );

        /* Disposal */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyTexture(
            IntPtr device,
            IntPtr texture
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroySampler(
            IntPtr device,
            IntPtr sampler
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyBuffer(
            IntPtr device,
            IntPtr buffer
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyColorTarget(
            IntPtr device,
            IntPtr colorTarget
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyDepthStencilTarget(
            IntPtr device,
            IntPtr depthStencilTarget
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyFramebuffer(
            IntPtr device,
            IntPtr framebuffer
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyShaderModule(
            IntPtr device,
            IntPtr shaderModule
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyRenderPass(
            IntPtr device,
            IntPtr renderPass
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyComputePipeline(
            IntPtr device,
            IntPtr computePipeline
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueueDestroyGraphicsPipeline(
            IntPtr device,
            IntPtr graphicsPipeline
        );

        /* Graphics State */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BeginRenderPass(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr renderPass,
            IntPtr framebuffer,
            ref Rect renderArea,
            IntPtr pColorClearValues,
            uint colorClearCount,
            ref DepthStencilValue depthStencilClearValue
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BeginRenderPass(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr renderPass,
            IntPtr framebuffer,
            ref Rect renderArea,
            IntPtr pColorClearValues,
            uint colorClearCount,
            IntPtr depthStencilClearValue /* NULL */
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_EndRenderPass(
            IntPtr device,
            IntPtr commandBuffer
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindGraphicsPipeline(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr graphicsPipeline
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindVertexBuffers(
            IntPtr device,
            IntPtr commandBuffer,
            uint firstBinding,
            uint bindingCount,
            IntPtr pBuffers,
            IntPtr pOffsets
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindIndexBuffer(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr buffer,
            uint offset,
            IndexElementSize indexElementSize
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindVertexSamplers(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr pTextures,
            IntPtr pSamplers
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindFragmentSamplers(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr pTextures,
            IntPtr pSamplers
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindComputePipeline(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr computePipeline
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindComputeBuffers(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr pBuffers
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_BindComputeTextures(
            IntPtr device,
            IntPtr commandBuffer,
            IntPtr pTextures
        );

        /* Submission/Presentation */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_AcquireCommandBuffer(
            IntPtr device,
            byte isFixed
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueuePresent(
            IntPtr device,
            IntPtr commandBuffer,
            ref TextureSlice textureSlice,
            ref Rect destinationRectangle,
            Filter filter
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_QueuePresent(
            IntPtr device,
            IntPtr commandBuffer,
            ref TextureSlice textureSlice,
            IntPtr destinationRectangle, /* null Rect */
            Filter filter
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_Submit(
            IntPtr device,
            uint commandBufferCount,
            IntPtr pCommandBuffers
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_Wait(
            IntPtr device
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Refresh_Image_Load(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            out int width,
            out int height,
            out int numChannels
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_Image_Free(
            IntPtr mem
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Refresh_Image_SavePNG(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int w,
            int h,
            IntPtr data
        );
    }
}
