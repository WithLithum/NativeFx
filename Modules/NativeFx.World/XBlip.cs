namespace NativeFx.World;

using GTA;
using GTA.Math;
using NativeFx.World.Interfaces;
using System;
using IDeletable = Interfaces.IDeletable;

public class XBlip : IHandleable, IDeletable
{
    protected XBlip(int handle)
    {
        Handle = handle;
    }

    public int Handle { get; }

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

    public bool IsValid()
    {
        return Natives.DoesBlipExist(Handle);
    }

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
}
