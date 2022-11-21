namespace NativeFx.UI;

using GTA;

public class Texture
{
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
    /// Loads the dictionary of this instance.
    /// </summary>
    public void Load()
    {
        if (!Natives.HasStreamedTextureDictLoaded(Dictionary))
        {
            Natives.RequestStreamedTextureDict(Dictionary, true);
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

        while (!Natives.HasStreamedTextureDictLoaded(Dictionary))
        {
            Script.Yield();
        }
    }
}
