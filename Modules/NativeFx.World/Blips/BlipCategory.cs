namespace NativeFx.World.Blips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum BlipCategory
{
    /// <summary>
    /// Also known as "no distance".
    /// </summary>
    Default = 1,
    ShowDistance = 2,
    /// <summary>
    /// Depicts that the blips of this category belongs to other players in multiplayer environment.
    /// </summary>
    /// <remarks>
    /// <para>
    /// All blips in this category will be categorised under "Other Players" regardless of <see cref="XBlip.Sprite"/> and
    /// <see cref="XBlip.Name"/> properties, and distance will be shown.
    /// </para>
    /// <para>
    /// The name of the blips in this category, when not using a CJK language, uses a "Chalet Comprime Cologne" font; when using a
    /// CJK language, no special font is used and the name is displayed in the default font for that language.
    /// </para>
    /// </remarks>
    OtherPlayers = 7,
    /// <summary>
    /// Depicts that the blips of this category belongs to properties that is available to players to purchase.
    /// </summary>
    /// <remarks>
    /// All blips in this category will be categorised under "Property" regardless of <see cref="XBlip.Sprite"/> and
    /// <see cref="XBlip.Name"/> properties.
    /// </remarks>
    Property = 9,
    /// <summary>
    /// Depicts that the blips of this category belongs to a property already owned by the player.
    /// </summary>
    /// <remarks>
    /// All blips in this category will be categorised under "Owned Property" regardless of <see cref="XBlip.Sprite"/> and
    /// <see cref="XBlip.Name"/> properties.
    /// </remarks>
    OwnedProperty = 10
}
