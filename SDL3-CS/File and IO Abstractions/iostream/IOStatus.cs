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

namespace SDL3;

public static partial class SDL
{
    /// <summary>
    /// <see cref="IOStream"/> status, set by a read or write operation.
    /// </summary>
    /// <since>This enum is available since SDL 3.0.0.</since>
    public enum IOStatus
    {
        /// <summary>
        /// Everything is ready (no errors and not EOF).
        /// </summary>
        Ready,
        
        /// <summary>
        /// Read or write I/O error
        /// </summary>
        Error,
        
        /// <summary>
        /// End of file
        /// </summary>
        Eof,
        
        /// <summary>
        /// Non blocking I/O, not ready
        /// </summary>
        NotReady,
        
        /// <summary>
        /// Tried to write a read-only buffer
        /// </summary>
        Readonly, 
        
        /// <summary>
        /// Tried to read a write-only buffer
        /// </summary>
        Writeonly
    }
}