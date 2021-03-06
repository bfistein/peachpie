﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pchp.Core.Dynamic
{
    /// <summary>
    /// Specifies how the value is accessed.
    /// </summary>
    [Flags]
    public enum AccessFlags : int
    {
        Default = 0,

        /// <summary>
        /// Value should be converted to an object before it is read and returned as <see cref="object"/>.
        /// </summary>
        EnsureObject = 1,

        /// <summary>
        /// Value should be converted to an array before it is read.
        /// </summary>
        EnsureArray = 2,

        /// <summary>
        /// Value should be aliased if not yet and returned as <see cref="PhpAlias"/>.
        /// </summary>
        EnsureAlias = 4,

        /// <summary>
        /// Value is read within <c>isset</c> operator and all read warnings should be ignored.
        /// </summary>
        CheckOnly = 8,

        /// <summary>
        /// Value will be written to.
        /// </summary>
        WriteValue = 16,

        /// <summary>
        /// Alias will be written, RValue is expected to be <see cref="PhpAlias"/>.
        /// </summary>
        WriteAlias = 32,

        /// <summary>
        /// The variable has to be unset. Valid for fields and runtime fields.
        /// </summary>
        Unset = 64,

        /// <summary>
        /// The variable is checked for existance.
        /// </summary>
        Isset = 128,

        /// <summary>
        /// Read access flags.
        /// </summary>
        ReadMask = EnsureObject | EnsureArray | EnsureAlias | CheckOnly | Isset,

        /// <summary>
        /// Write access flags.
        /// </summary>
        WriteMask = WriteValue | WriteAlias | Unset,
    }

    internal static class AccessFlagsExtensions
    {
        public static bool EnsureObject(this AccessFlags flags) => (flags & AccessFlags.EnsureObject) == AccessFlags.EnsureObject;
        public static bool EnsureArray(this AccessFlags flags) => (flags & AccessFlags.EnsureArray) == AccessFlags.EnsureArray;
        public static bool EnsureAlias(this AccessFlags flags) => (flags & AccessFlags.EnsureAlias) == AccessFlags.EnsureAlias;
        public static bool Quiet(this AccessFlags flags) => (flags & AccessFlags.CheckOnly) == AccessFlags.CheckOnly;
        public static bool WriteAlias(this AccessFlags flags) => (flags & AccessFlags.WriteAlias) == AccessFlags.WriteAlias;
        public static bool Write(this AccessFlags flags) => (flags & (AccessFlags.WriteAlias | AccessFlags.WriteValue)) != 0;
        public static bool Unset(this AccessFlags flags) => (flags & AccessFlags.Unset) == AccessFlags.Unset;
        public static bool Isset(this AccessFlags flags) => (flags & AccessFlags.Isset) == AccessFlags.Isset;
    }
}
