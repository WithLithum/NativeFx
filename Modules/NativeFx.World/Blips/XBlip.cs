namespace NativeFx.World.Blips;

using GTA;
using GTA.Math;
using NativeFx.World.Interfaces;
using NativeFx.World.Internal;
using SHVDN;
using System;
using System.Collections.Generic;
using System.Configuration;
using IDeletable = Interfaces.IDeletable;

/// <summary>
/// Represents a blip (marker) on radar and the pause menu map.
/// </summary>
/// <remarks>
/// <para>
/// Blips can be attached to an entity, or stationarily placed at a coordinate; however, you cannot place a
/// blip already placed at a coordinate attached to an entity, and same goes otherwise.
/// </para>
/// <para>
/// To create blips, <see cref="Create(Entity)"/>, <see cref="Create(Vector3)"/>, &amp;c. methods are used. To obtain
/// a blip via its handle, use <see cref="FromHandle(int)"/> to do so safely.
/// </para>
/// </remarks>
public sealed class XBlip : IHandleable, IDeletable, IEqualityComparer<XBlip>
    , IEquatable<XBlip>
{
    internal XBlip(int handle)
    {
        Handle = handle;
    }

    /// <summary>
    /// Gets or sets the category of this instance.
    /// </summary>
    /// <remarks>
    /// <note type="warning">
    /// The getter of this property uses <b>memory access</b>. To avoid logic errors in user code, whenever a memory operation is
    /// not available (because memory address cannot be obtained), <see cref="NotSupportedException"/> will be thrown. The user code is excepted
    /// to catch this exception and to implement fallbacks. This behaviour is different than the SHVDN, which would return default values (usually <c>0</c>, <c>null</c> or equivalent).
    /// </note>
    /// <para>
    /// The category of a blip determines how a blip is shown in the legend section, and affects certain natives.
    /// </para>
    /// </remarks>
    public BlipCategoryType Category
    {
        get
        {
            SafeHandle();

            return (BlipCategoryType)VdnInterop.GetBlipCategory(MemoryAddress);
        }
        set => Natives.SetBlipCategory(SafeHandle(), (int)value);
    }

    /// <summary>
    /// Gets the memory address of this instance.
    /// </summary>
    /// <remarks>
    /// This property will not attempt to validate this instance.
    /// </remarks>
    public IntPtr MemoryAddress => NativeMemory.GetBlipAddress(Handle);

    /// <summary>
    /// Gets or sets the name of this instance.
    /// </summary>
    /// <remarks>
    /// <note type="warning">
    /// The getter of this property uses <b>memory access</b>. To avoid logic errors in user code, whenever a memory operation is
    /// not available (because memory address cannot be obtained), <see cref="NotSupportedException"/> will be thrown. The user code is excepted
    /// to catch this exception and to implement fallbacks. This behaviour is different than the SHVDN, which would return default values (usually <c>0</c>, <c>null</c> or equivalent).
    /// </note>
    /// <para>
    /// The name of the blip is displayed in the pause menu legend.
    /// </para>
    /// </remarks>
    /// <value>
    /// The name of this instance.
    /// </value>
    /// <exception cref="InvalidOperationException">This instance is invalid.</exception>
    /// <exception cref="NotSupportedException">Memory access is unavailable.</exception>
    public string Name
    {
        get
        {
            SafeHandle();

            if (MemoryAddress == IntPtr.Zero)
            {
                VdnInterop.ThrowUnsupported();
                return null;
            }

            return VdnInterop.GetBlipName(MemoryAddress);
        }
        set
        {
            SetName(value);
        }
    }

    public int Handle { get; }

    /// <summary>
    /// Gets or sets the integral rotation of this instance.
    /// </summary>
    public int Rotation
    {
        get => Natives.GetBlipRotation(SafeHandle());
        set => Natives.SetBlipRotation(SafeHandle(), value);
    }

    /// <summary>
    /// Gets or sets the colour of this instance.
    /// </summary>
    /// <remarks>
    /// Despite documentation of <see cref="BlipColor"/> claiming different indices with exactly the same
    /// colour, such colours actually are just slightly different.
    /// </remarks>
    public BlipColor Colour
    {
        get => (BlipColor)Natives.GetBlipColour(SafeHandle());
        set => Natives.SetBlipColour(SafeHandle(), (int)value);
    }

    /// <summary>
    /// Gets or sets the priority of this instance.
    /// </summary>
    /// <remarks>
    /// <note type="warning">
    /// The getter of this property uses <b>memory access</b>. To avoid logic errors in user code, whenever a memory operation is
    /// not available (because memory address cannot be obtained), <see cref="NotSupportedException"/> will be thrown. The user code is excepted
    /// to catch this exception and to implement fallbacks. This behaviour is different than the SHVDN, which would return default values (usually <c>0</c>, <c>null</c> or equivalent).
    /// </note>
    /// <para>
    /// The priority of the blip determines the display order of the blip. When several blips are visually stacked each other, the blip currently
    /// selected in pause menu map displays first. If not in pause menu map, or no blip is selected, the blip with the highest priority value displays first.
    /// The priority of the player's own blip is somewhere around <c>3</c>.
    /// </para>
    /// <para>
    /// To obtain the priority value, the getter of this instance accesses memory; however, for setting such value, the native
    /// <see cref="Natives.SetBlipPriority(int, int)"/> is used instead.
    /// </para>
    /// </remarks>
    public int Priority
    {
        get
        {
            SafeHandle();

            return VdnInterop.GetBlipPriority(MemoryAddress);
        }
        set => Natives.SetBlipPriority(SafeHandle(), value);
    }

    /// <summary>
    /// Sets the sprite of this instance.
    /// </summary>
    /// <remarks>
    /// <note type="warning">
    /// The value of the <see cref="Name"/> property will be reset to the default localised name associated with
    /// the sprite value set in this property every time the setter is called.
    /// </note>
    /// <para>
    /// The sprite (or icon) of the blip depicts what icon to display. In most instances you do not have to specifically set
    /// the name of the blip (via <see cref="Name"/> property) as your blip sprite and colour will determine the name of the blip.
    /// </para>
    /// </remarks>
    public BlipSprite Sprite
    {
        get => (BlipSprite)Natives.GetBlipSprite(SafeHandle());
        set => Natives.SetBlipSprite(SafeHandle(), (int)value);
    }

    private int SafeHandle()
    {
        if (!IsValid())
        {
            throw new InvalidOperationException("The operation is invalid because this blip is not valid.");
        }

        return Handle;
    }

    public void Delete()
    {
        var x = SafeHandle();
        Natives.RemoveBlip(ref x);
    }

    /// <summary>
    /// Displays the specified number at centre of this blip.
    /// </summary>
    /// <param name="number">The number.</param>
    public void DisplayNumber(int number)
    {
        Natives.ShowNumberOnBlip(SafeHandle(), number);
    }

    public bool IsValid()
    {
        return Natives.DoesBlipExist(Handle);
    }

    /// <summary>
    /// Sets whether or not this instance is regarded as friendly.
    /// </summary>
    /// <remarks>
    /// Whether or not a blip is friendly affects how its colour is displayed to the user, for
    /// certain colour types in <see cref="BlipColor"/> enumeration. However, that enumeration failed to
    /// describe such type of colours and the user is required to test.
    /// </remarks>
    /// <param name="value">The value.</param>
    public void SetFriendly(bool value)
    {
        Natives.SetBlipAsFriendly(SafeHandle(), value);
    }

    /// <summary>
    /// Sets the name of this instance.
    /// </summary>
    /// <param name="name">The name.</param>
    public void SetName(string name)
    {
        Natives.BeginTextCommandSetBlipName("STRING");
        Natives.AddTextComponentSubstringPlayerName(name);
        Natives.EndTextCommandSetBlipName(Handle);
    }

    public void ShowGoldenTick(bool toggle) =>
        Natives.ShowGoldTickOnBlip(SafeHandle(), toggle);

    public void SetHighDetail(bool toggle)
    {
        Natives.SetBlipHighDetail(SafeHandle(), toggle);
    }

    public void SetRotationAsFloat(float rotation)
    {
        Natives.SetBlipRotationWithFloat(SafeHandle(), rotation);
    }

    public void ShowTick(bool toggle) =>
        Natives.ShowTickOnBlip(SafeHandle(), toggle);

    /// <summary>
    /// Creates a stationary instance of <see cref="XBlip"/> at the specified point.
    /// </summary>
    /// <param name="position">The position to create a blip at.</param>
    /// <returns>An instance representing the blip created.</returns>
    public static XBlip Create(Vector3 position)
    {
        return new XBlip(Natives.AddBlipForCoord(position.X, position.Y, position.Z));
    }

    /// <summary>
    /// Creates an instance of <see cref="XBlip"/> attached the specified entity.
    /// </summary>
    /// <param name="entity">The entity to attach the created blip to.</param>
    /// <returns>An instance representing the blip created.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="entity"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="entity"/> is invalid.</exception>
    public static XBlip Create(Entity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (!entity.Exists())
        {
            throw new ArgumentException("The entity is invalid.", nameof(entity));
        }

        return new XBlip(Natives.AddBlipForEntity(entity.Handle));
    }

    /// <summary>
    /// Creates a stationary instance of <see cref="XBlip"/> at the specified circular area depicted by
    /// a <paramref name="position"/> and a <paramref name="radius"/>.
    /// </summary>
    /// <param name="position">The centre of the area.</param>
    /// <param name="radius">The radius of the area.</param>
    /// <returns>An instance representing the blip created.</returns>
    public static XBlip Create(Vector3 position, float radius)
    {
        return new XBlip(Natives.AddBlipForRadius(position.X, position.Y, position.Z, radius));
    }

    /// <summary>
    /// Creates a stationary instance of <see cref="XBlip"/> at the specified rectangluar area depicted by
    /// a <paramref name="position"/>, <paramref name="width"/> and <paramref name="height"/>.
    /// </summary>
    /// <param name="position">The centre of the area.</param>
    /// <param name="width">The width of area.</param>
    /// <param name="height">The height of area.</param>
    /// <remarks>
    /// <para>
    /// A rectangular area blip is often used in GTA Online rather than in Story Mode. If the blip is outside
    /// player view when displayed, the rectangular area blips fallback to a normal stationary coordinate blip
    /// (with the specified sprite and colour).
    /// </para>
    /// <note type="note">
    /// By default, rectangular area blips may rotate, so it is recommended to set the <see cref="Rotation"/>
    /// property to prevent it from rotating.
    /// </note>
    /// </remarks>
    /// <returns>An instance representing the blip created.</returns>
    public static XBlip Create(Vector3 position, float width, float height)
    {
        return new XBlip(Natives.AddBlipForArea(position.X, position.Y, position.Z, width, height));
    }

    /// <summary>
    /// Creates an instance of <see cref="XBlip"/> from the specified handle.
    /// </summary>
    /// <param name="handle">The handle.</param>
    /// <returns>An instance representing the specified blip.</returns>
    /// <exception cref="ArgumentException">The handle is invalid.</exception>
    public static XBlip FromHandle(int handle)
    {
        if (!Natives.DoesBlipExist(handle))
        {
            throw new ArgumentException("The handle is invalid.", nameof(handle));
        }

        return new XBlip(handle);
    }

    public bool Equals(XBlip x, XBlip y)
    {
        return x != null && y != null && x.Handle == y.Handle;
    }

    public bool Equals(XBlip other)
    {
        return other != null && other.Handle == Handle;
    }

    public override bool Equals(object obj)
    {
        return obj is XBlip xblip && Equals(xblip);
    }

    public int GetHashCode(XBlip obj)
    {
        return obj.Handle;
    }

    public override int GetHashCode()
    {
        return Handle;
    }

    public static bool operator !=(XBlip left, XBlip right)
    {
        return left != right;
    }

    public static bool operator ==(XBlip left, XBlip right)
    {
        if (left == null && right == null)
        {
            return true;
        }

        return left.Equals(right);
    }

    public int CompareTo(XBlip other)
    {
        if (other == null)
        {
            return 1;
        }

        if (!IsValid())
        {
            if (!other.IsValid())
            {
                return 0;
            }

            return -1;
        }

        if (!other.IsValid())
        {
            return 1;
        }

        if (other.Priority == Priority)
        {
            return 0;
        }

        if (other.Priority > Priority)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
