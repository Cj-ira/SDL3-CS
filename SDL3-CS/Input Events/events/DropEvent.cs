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

using System.Runtime.InteropServices;

namespace SDL3;

public static partial class SDL
{
    /// <summary>
    /// An event used to drop text or request a file open by the system
    /// (event.drop.*)
    /// </summary>
    /// <remarks>The source and data strings follow the
    /// <a href="https://github.com/libsdl-org/SDL/blob/main/docs/README-strings.md">SDL_GetStringRule</a>.</remarks>
    /// <since>This struct is available since SDL 3.0.0.</since>
    [StructLayout(LayoutKind.Sequential)]
    public struct DropEvent
    {
        /// <summary>
        /// <see cref="EventType.DropBegin"/> or <see cref="EventType.DropFile"/>
        /// or <see cref="EventType.DropText"/> or <see cref="EventType.DropComplete"/>
        /// or <see cref="EventType.DropPosition"/>
        /// </summary>
        public EventType Type;
        private UInt32 Reserved;
        
        /// <summary>
        /// In nanoseconds, populated using <see cref="GetTicksNS"/>
        /// </summary>
        public UInt64 Timestamp;
        
        /// <summary>
        /// The window that was dropped on, if any
        /// </summary>
        public UInt32 WindowID;
        
        /// <summary>
        /// X coordinate, relative to window (not on begin)
        /// </summary>
        public float X;
        
        /// <summary>
        /// Y coordinate, relative to window (not on begin)
        /// </summary>
        public float Y;
        private IntPtr source;
        private IntPtr data;
        
        /// <summary>
        /// The source app that sent this drop event, or NULL if that isn't available
        /// </summary>
        public string? Source => Marshal.PtrToStringUTF8(source);
        
        /// <summary>
        /// The text for SDL_EVENT_DROP_TEXT and the file name for SDL_EVENT_DROP_FILE, NULL for other events
        /// </summary>
        public string? Data => Marshal.PtrToStringUTF8(data);
    }
}