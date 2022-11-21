namespace NativeFx.UI;

/// <summary>
/// Provides methods for displaying various types of notifications.
/// </summary>
public static class XNotification
{
    /// <summary>
    /// Sets the background colour of the next post.
    /// </summary>
    /// <remarks>
    /// This method must be called before each notification showing call to set background colour.
    /// </remarks>
    /// <param name="hudColour">The ID of the HUD colour. This ID is the zero-based index of the colour in <c>hudcolor.dat</c>.</param>
    internal static void SetNextBackgroundColour(int hudColour)
    {
        Natives.ThefeedSetBackgroundColorForNextPost(hudColour);
    }

    internal static void BeginCommand(string text)
    {
        Natives.BeginTextCommandThefeedPost("STRING");
        Natives.AddTextComponentSubstringPlayerName(text);
    }

    /// <summary>
    /// Hides the specified notification.
    /// </summary>
    /// <param name="notification">The ID of the notification to hide.</param>
    public static void Hide(int notification)
    {
        Natives.ThefeedRemoveItem(notification);
    }

    /// <summary>
    /// Shows a simple notification with the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="blink">If <see langword="true"/>, blinks for a few times when the notification is shown.</param>
    /// <returns>The ID of the notification created.</returns>
    public static int Show(string text, bool blink = false)
    {
        BeginCommand(text);
        return Natives.EndTextCommandThefeedPostTicker(blink, false);
    }

    /// <summary>
    /// Shows a complicated notification with the specified text.
    /// </summary>
    /// <param name="texture">The texture to display.</param>
    /// <param name="title">The title.</param>
    /// <param name="subtitle">The subtitle.</param>
    /// <param name="text">The text to display.</param>
    /// <param name="blink">If <see langword="true"/>, blinks for a few times when the notification is shown.</param>
    /// <returns>The ID of the notification created.</returns>
    public static int Show(Texture texture, string title, string subtitle, string text, bool blink = false)
    {
        BeginCommand(text);
        return Natives.EndTextCommandThefeedPostMessagetext(texture.Dictionary, texture.Name, blink, 0, title, subtitle);
    }
}
