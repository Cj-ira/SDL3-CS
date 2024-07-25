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
    /// <para>Keyboard button event structure (event.key.*)</para>
    /// <para>The `key` is the base SDL_Keycode generated by pressing the <c>scancode</c>
    /// using the current keyboard layout, applying any options specified in
    /// <see cref="Hints.KeycodeOptions"/>. You can get the <see cref="Keycode"/> corresponding to the
    /// event scancode and modifiers directly from the keyboard layout, bypassing
    /// <see cref="Hints.KeycodeOptions"/>, by calling <see cref="GetKeyFromScancode"/>.</para>
    /// </summary>
    /// <since>This struct is available since SDL 3.0.0.</since>
    /// <seealso cref="GetKeyFromScancode"/>
    /// <seealso cref="Hints.KeycodeOptions"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardEvent
    {
        /// <summary>
        /// <see cref="EventType.KeyDown"/> or <see cref="EventType.KeyUp"/>
        /// </summary>
        public EventType Type;
        private UInt32 Reserved;
        
        /// <summary>
        /// In nanoseconds, populated using <see cref="GetTicksNS"/>
        /// </summary>
        public UInt64 Timestamp;
        
        /// <summary>
        /// The window with keyboard focus, if any 
        /// </summary>
        public UInt32 WindowID;
        
        /// <summary>
        /// The keyboard instance id, or 0 if unknown or virtual
        /// </summary>
        public UInt32 Which;
        
        /// <summary>
        /// SDL physical key code
        /// </summary>
        public Scancode Scancode;
        
        /// <summary>
        /// SDL virtual key code
        /// </summary>
        public Keycode Key;
        
        /// <summary>
        /// current key modifiers
        /// </summary>
        public Keymod Mod;
        
        /// <summary>
        /// The platform dependent scancode for this event
        /// </summary>
        public UInt16 Raw;
        
        /// <summary>
        /// <see cref="Keystate.Pressed"/> or <see cref="Keystate.Released"/>
        /// </summary>
        public Keystate State;
        
        /// <summary>
        /// Non-zero if this is a key repeat
        /// </summary>
        public byte Repeat;
    }
}