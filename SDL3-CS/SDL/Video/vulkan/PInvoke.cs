﻿#region License
/* Copyright (c) 2024 Eduard Gushchin.
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
 */
#endregion

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3;

/**
 *  \name Vulkan support functions
 */

public static partial class SDL
{
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_Vulkan_LoadLibrary([MarshalAs(UnmanagedType.LPUTF8Str)] string path);
    /// <code>extern SDL_DECLSPEC int SDLCALL SDL_Vulkan_LoadLibrary(const char *path);</code>
    /// <summary>
    /// <para>Dynamically load the Vulkan loader library.</para>
    /// <para>This should be called after initializing the video driver, but before
    /// creating any Vulkan windows. If no Vulkan loader library is loaded, the
    /// default library will be loaded upon creation of the first Vulkan window.</para>
    /// <para>It is fairly common for Vulkan applications to link with libvulkan instead
    /// of explicitly loading it at run time. This will work with SDL provided the
    /// application links to a dynamic library and both it and SDL use the same
    /// search path.</para>
    /// <para>If you specify a non-NULL <c>path</c>, an application should retrieve all of the
    /// Vulkan functions it uses from the dynamic library using
    /// <see cref="VulkanGetVkGetInstanceProcAddr"/> unless you can guarantee <c>path</c> points
    /// to the same vulkan loader library the application linked to.</para>
    /// <para>On Apple devices, if <c>path</c> is NULL, SDL will attempt to find the
    /// <c>vkGetInstanceProcAddr</c> address within all the Mach-O images of the current
    /// process. This is because it is fairly common for Vulkan applications to
    /// link with libvulkan (and historically MoltenVK was provided as a static
    /// library). If it is not found, on macOS, SDL will attempt to load
    /// <c>vulkan.framework/vulkan</c>, <c>libvulkan.1.dylib</c>,
    /// <c>MoltenVK.framework/MoltenVK</c>, and <c>libMoltenVK.dylib</c>, in that order. On
    /// iOS, SDL will attempt to load <c>libMoltenVK.dylib</c>. Applications using a
    /// dynamic framework or .dylib must ensure it is included in its application
    /// bundle.</para>
    /// <para>On non-Apple devices, application linking with a static libvulkan is not
    /// supported. Either do not link to the Vulkan loader or link to a dynamic
    /// library version.</para>
    /// </summary>
    /// <param name="path">the platform dependent Vulkan loader library name or NULL.</param>
    /// <returns>0 on success or a negative error code on failure; call
    /// <see cref="GetError"/> for more information.</returns>
    /// <since>This function is available since SDL 3.0.0.</since>
    /// <seealso cref="VulkanGetVkGetInstanceProcAddr"/>
    /// <seealso cref="VulkanUnloadLibrary"/>
    public static int VulkanLoadLibrary(string path) => SDL_Vulkan_LoadLibrary(path);
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial FunctionPointer? SDL_Vulkan_GetVkGetInstanceProcAddr();
    /// <code>extern SDL_DECLSPEC SDL_FunctionPointer SDLCALL SDL_Vulkan_GetVkGetInstanceProcAddr(void);</code>
    /// <summary>
    /// <para>Get the address of the <c>vkGetInstanceProcAddr</c> function.</para>
    /// <para>This should be called after either calling <see cref="VulkanLoadLibrary"/>() or
    /// creating an <see cref="Window"/> with the <see cref="WindowFlags.Vulkan"/> flag.</para>
    /// <para>The actual type of the returned function pointer is
    /// PFN_vkGetInstanceProcAddr, but that isn't available because the Vulkan
    /// headers are not included here. You should cast the return value of this
    /// function to that type, e.g.</para>
    /// <para><c>vkGetInstanceProcAddr = (PFN_vkGetInstanceProcAddr)SDL_Vulkan_GetVkGetInstanceProcAddr();</c></para>
    /// </summary>
    /// <returns>the function pointer for <c>vkGetInstanceProcAddr</c> or <c>NULL</c> on error.</returns>
    /// <since>This function is available since SDL 3.0.0.</since>
    public static FunctionPointer? VulkanGetVkGetInstanceProcAddr() => SDL_Vulkan_GetVkGetInstanceProcAddr();
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_Vulkan_UnloadLibrary();
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_Vulkan_UnloadLibrary(void);</code>
    /// <summary>
    /// Unload the Vulkan library previously loaded by <see cref="VulkanLoadLibrary"/>.
    /// </summary>
    /// <since>This function is available since SDL 3.0.0.</since>
    /// <seealso cref="VulkanLoadLibrary"/>
    public static void VulkanUnloadLibrary() => SDL_Vulkan_UnloadLibrary();
    
    
    [LibraryImport(SDLLibrary)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_Vulkan_GetInstanceExtensions(out uint count);
    /// <code>extern SDL_DECLSPEC char const* const* SDLCALL SDL_Vulkan_GetInstanceExtensions(Uint32 *count);</code>
    /// <summary>
    /// <para>Get the Vulkan instance extensions needed for vkCreateInstance.</para>
    /// <para>This should be called after either calling <see cref="VulkanLoadLibrary"/> or
    /// creating an <see cref="Window"/> with the <see cref="WindowFlags.Vulkan"/> flag.</para>
    /// <para>On return, the variable pointed to by <c>count</c> will be set to the number of
    /// elements returned, suitable for using with
    /// <c>VkInstanceCreateInfo::enabledExtensionCount</c>, and the returned array can be
    /// used with <c>VkInstanceCreateInfo::ppEnabledExtensionNames</c>, for calling
    /// Vulkan's vkCreateInstance API.</para>
    /// <para>You should not free the returned array; it is owned by SDL.</para>
    /// </summary>
    /// <param name="count">a pointer filled in with the number of extensions returned.</param>
    /// <returns>an array of extension name strings on success, <c>NULL</c> on error.</returns>
    /// <since>This function is available since SDL 3.0.0.</since>
    /// <seealso cref="VulkanCreateSurface"/>
    public static string[]? VulkanGetInstanceExtensions(out uint count)
    {
        var ptr = SDL_Vulkan_GetInstanceExtensions(out count);
        if (ptr == IntPtr.Zero) return null;

        if (count == 0) return [];
        
        var extensions = new string[count];
        for (uint i = 0; i < count; i++)
        {
            var strPtr = Marshal.ReadIntPtr(ptr, (int)(i * IntPtr.Size));
            extensions[i] = Marshal.PtrToStringUTF8(strPtr)!;
        }

        return extensions;
    }
}