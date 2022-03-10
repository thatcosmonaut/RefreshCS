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
using System.Runtime.InteropServices;

namespace RefreshCS
{
	public static class Refresh
	{
		private const string nativeLibName = "Refresh";

		/* Version */

		public const uint REFRESH_MAJOR_VERSION = 1;
		public const uint REFRESH_MINOR_VERSION = 3;
		public const uint REFRESH_PATCH_VERSION = 0;

		public const uint REFRESH_COMPILED_VERSION = (
			(REFRESH_MAJOR_VERSION * 100 * 100) +
			(REFRESH_MINOR_VERSION * 100) +
			(REFRESH_PATCH_VERSION)
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint Refresh_LinkedVersion();

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

		public enum IndexElementSize
		{
			Sixteen,
			ThirtyTwo
		}

		public enum TextureFormat
		{
			R8G8B8A8,
			B8G8R8A8,
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
			R16G16B16A16_SFLOAT,
			D16,
			D32,
			D16S8,
			D32S8
		}

		[Flags]
		public enum TextureUsageFlags : uint
		{
			Sampler = 1,
			ColorTarget = 2,
			DepthStencilTarget = 4
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

		public enum CubeMapFace : uint
		{
			PositiveX,
			NegativeX,
			PositiveY,
			NegativeY,
			PositiveZ,
			NegativeZ
		}

		[Flags]
		public enum BufferUsageFlags : uint
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
			Line
		}

		public enum CullMode
		{
			None,
			Front,
			Back
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
			SourceAlphaSaturate,
			SourceOneColor,
			OneMinusSourceOneColor,
			SourceOneAlpha,
			OneMinusSourceOneAlpha
		}

		[Flags]
		public enum ColorComponentFlags : uint
		{
			R = 1,
			G = 2,
			B = 4,
			A = 8,

			RG = R | G,
			RB = R | B,
			RA = R | A,
			GB = G | B,
			GA = G | A,
			BA = B | A,

			RGB = R | G | B,
			RGA = R | G | A,
			GBA = G | B | A,

			RGBA = R | G | B | A
		}

		public enum ShaderStageType
		{
			Vertex,
			Fragment
		}

		public enum Filter
		{
			Nearest,
			Linear
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
		public struct ColorAttachmentBlendState
		{
			public byte blendEnable;
			public BlendFactor sourceColorBlendFactor;
			public BlendFactor destinationColorBlendFactor;
			public BlendOp colorBlendOp;
			public BlendFactor sourceAlphaBlendFactor;
			public BlendFactor destinationAlphaBlendFactor;
			public BlendOp alphaBlendOp;
			public ColorComponentFlags colorWriteMask;
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
			public TextureFormat format;
			public TextureUsageFlags usageFlags; /* Refresh_TextureUsageFlags */
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GraphicsShaderInfo
		{
			public IntPtr shaderModule;
			[MarshalAs(UnmanagedType.LPStr)]
			public string entryPointName;
			public ulong uniformBufferSize;
			public uint samplerBindingCount;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ComputeShaderInfo
		{
			public IntPtr shaderModule;
			[MarshalAs(UnmanagedType.LPStr)]
			public string entryPointName;
			public ulong uniformBufferSize;
			public uint bufferBindingCount;
			public uint imageBindingCount;
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
		public struct ColorAttachmentDescription
		{
			public TextureFormat format;
			public SampleCount sampleCount;
			public ColorAttachmentBlendState blendState;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GraphicsPipelineAttachmentInfo
		{
			public IntPtr colorAttachmentDescriptions; /* Max size 4 */
			public uint colorAttachmentCount;
			public byte hasDepthStencilAttachment;
			public TextureFormat depthStencilFormat;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct GraphicsPipelineCreateInfo
		{
			public GraphicsShaderInfo vertexShaderInfo;
			public GraphicsShaderInfo fragmentShaderInfo;
			public VertexInputState vertexInputState;
			public PrimitiveType primitiveType;
			public RasterizerState rasterizerState;
			public MultisampleState multisampleState;
			public DepthStencilState depthStencilState;
			public GraphicsPipelineAttachmentInfo attachmentInfo;
			public fixed float blendConstants[4];
		}

		public struct ColorAttachmentInfo
		{
			public IntPtr texture;
			public uint depth;
			public uint layer;
			public uint level;
			public SampleCount sampleCount;
			public Vec4 clearColor;
			public LoadOp loadOp;
			public StoreOp storeOp;
		}

		public struct DepthStencilAttachmentInfo
		{
			public IntPtr texture;
			public uint depth;
			public uint layer;
			public uint level;
			public DepthStencilValue depthStencilClearValue;
			public LoadOp loadOp;
			public StoreOp storeOp;
			public LoadOp stencilLoadOp;
			public StoreOp stencilStoreOp;
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
			in PresentationParameters presentationParameters,
			byte debugMode
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_DestroyDevice(IntPtr device);

		/* Drawing */

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
		public static extern IntPtr Refresh_CreateComputePipeline(
			IntPtr device,
			in ComputeShaderInfo computeShaderInfo
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Refresh_CreateGraphicsPipeline(
			IntPtr device,
			in GraphicsPipelineCreateInfo graphicsPipelineCreateInfo
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Refresh_CreateSampler(
			IntPtr device,
			in SamplerStateCreateInfo samplerStateCreateInfo
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Refresh_CreateShaderModule(
			IntPtr device,
			in ShaderModuleCreateInfo shaderModuleCreateInfo
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Refresh_CreateTexture(
			IntPtr device,
			in TextureCreateInfo textureCreateInfo
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Refresh_CreateBuffer(
			IntPtr device,
			BufferUsageFlags usageFlags,
			uint sizeInBytes
		);

		/* Setters */

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_SetTextureData(
			IntPtr device,
			IntPtr commandBuffer,
			in TextureSlice textureSlice,
			IntPtr data,
			uint dataLengthInBytes
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_SetTextureDataYUV(
			IntPtr device,
			IntPtr commandBuffer,
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
			in TextureSlice sourceTextureSlice,
			in TextureSlice destinationTextureSlice,
			Filter filter
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_CopyTextureToBuffer(
			IntPtr device,
			IntPtr commandBuffer,
			in TextureSlice textureSlice,
			IntPtr buffer
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_GetBufferData(
			IntPtr device,
			IntPtr buffer,
			IntPtr data,
			uint dataLengthInBytes
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_SetBufferData(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr buffer,
			uint offsetInBytes,
			IntPtr data,
			uint dataLengthInBytes
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint Refresh_PushVertexShaderUniforms(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr data,
			uint dataLengthInBytes
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint Refresh_PushFragmentShaderUniforms(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr data,
			uint dataLengthInBytes
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint Refresh_PushComputeShaderUniforms(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr data,
			uint dataLengthInBytes
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
		public static extern void Refresh_QueueDestroyShaderModule(
			IntPtr device,
			IntPtr shaderModule
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
			in Rect renderArea,
			IntPtr colorAttachmentInfos,
			uint colorAttachmentCount,
			IntPtr depthStencilAttachmentInfo /* can be NULL */
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_BeginRenderPass(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr renderArea, /* can be NULL */
			IntPtr colorAttachmentInfos,
			uint colorAttachmentCount,
			IntPtr depthStencilAttachmentInfo /* can be NULL */
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static unsafe extern void Refresh_BeginRenderPass(
			IntPtr device,
			IntPtr commandBuffer,
			in Rect renderArea,
			ColorAttachmentInfo* colorAttachmentInfos,
			uint colorAttachmentCount,
			DepthStencilAttachmentInfo* depthStencilAttachmentInfo /* can be NULL */
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static unsafe extern void Refresh_BeginRenderPass(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr renderArea, /* can be NULL */
			ColorAttachmentInfo* colorAttachmentInfos,
			uint colorAttachmentCount,
			DepthStencilAttachmentInfo* depthStencilAttachmentInfo /* can be NULL */
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
		public static extern void Refresh_SetViewport(
			IntPtr device,
			IntPtr commandBuffer,
			in Viewport viewport
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Refresh_SetScissor(
			IntPtr device,
			IntPtr commandBuffer,
			in Rect scissor
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
		public static extern IntPtr Refresh_AcquireSwapchainTexture(
			IntPtr device,
			IntPtr commandBuffer,
			IntPtr windowHandle,
			out uint width,
			out uint height
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern TextureFormat Refresh_GetSwapchainFormat(
			IntPtr device,
			IntPtr windowHandle
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
			byte bgra,
			IntPtr data
		);
	}
}
