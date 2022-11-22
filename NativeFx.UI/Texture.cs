/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx.UI;

using GTA;

/// <summary>
/// Represents a texture inside a texture dictionary that supports script access.
/// </summary>
/// <remarks>
/// <para>
/// Only select texture dictionaries in the game are accessible via scripts, most of these are either in
/// client scaleform <c>rpf</c>s or in <c>script_txds.rpf</c>.
/// </para>
/// </remarks>
public class Texture
{
    /// <summary>
    /// Initialises a new instance of the <see cref="Texture"/> class.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="name">The name of the texture.</param>
    public Texture(string dictionary, string name)
    {
        Dictionary = dictionary;
        Name = name;
    }

    /// <summary>
    /// Gets the dictionary of this instance.
    /// </summary>
    public string Dictionary { get; }

    /// <summary>
    /// Gets the name of this instance.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a value indicating whether this instance is loaded.
    /// </summary>
    public bool IsLoaded => Natives.HasStreamedTextureDictLoaded(Dictionary);

    /// <summary>
    /// Loads the dictionary of this instance.
    /// </summary>
    public void Load()
    {
        if (!IsLoaded)
        {
            Natives.RequestStreamedTextureDict(Dictionary, true);
        }
    }

    /// <summary>
    /// Dismisses this instance.
    /// </summary>
    public void Dismiss()
    {
        if (IsLoaded)
        {
            Natives.SetStreamedTextureDictAsNoLongerNeeded(Dictionary);
        }
    }

    /// <summary>
    /// Loads the dictionary of this instance, and waits indefinitely for it to complete.
    /// </summary>
    /// <remarks>
    /// <note type="warning">
    /// You must call this method inside the ticking routine (aka the Tick event or anything called in its handler)
    /// of a script instead of its constructor. It is illegal to call this method inside script constructors.
    /// </note>
    /// </remarks>
    public void LoadAndWait()
    {
        Load();

        while (!IsLoaded)
        {
            Script.Yield();
        }
    }
}
