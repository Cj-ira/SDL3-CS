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
    /// Touch finger event structure (event.tfinger.*)
    /// </summary>
    /// <since>This struct is available since SDL 3.0.0.</since>
    [StructLayout(LayoutKind.Sequential)]
    public struct TouchFingerEvent
    {
        /// <summary>
        /// <see cref="EventType.FingerMotion"/> or <see cref="EventType.FingerDown"/> or <see cref="EventType.FingerUp"/>
        /// </summary>
        public EventType Type;
        private UInt32 reserved;
        
        /// <summary>
        /// In nanoseconds, populated using <see cref="GetTicksNS"/>
        /// </summary>
        public UInt64 Timestamp;
        
        /// <summary>
        /// The touch device id
        /// </summary>
        public UInt64 TouchID;
        
        /// <summary>
        /// The touch device id
        /// </summary>
        public UInt64 FingerID;
        
        /// <summary>
        /// Normalized in the range 0...1
        /// </summary>
        public float X;
        
        /// <summary>
        /// Normalized in the range 0...1 
        /// </summary>
        public float Y;
        
        /// <summary>
        /// Normalized in the range -1...1
        /// </summary>
        public float DX;
        
        /// <summary>
        /// Normalized in the range -1...1
        /// </summary>
        public float DY;
        
        /// <summary>
        /// Normalized in the range 0...1
        /// </summary>
        public float Pressure;
        
        /// <summary>
        /// The window underneath the finger, if any
        /// </summary>
        public UInt32 WindowID;
    }
}