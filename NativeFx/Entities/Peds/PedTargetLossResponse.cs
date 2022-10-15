namespace NativeFx.Entities.Peds;
/// <summary>
/// An enumeration of all possible responses after an actor lost its target in a combat.
/// </summary>
public enum PedTargetLossResponse
{
    /// <summary>
    /// Stops task after target has been lost.
    /// </summary>
    ExitTask,
    /// <summary>
    /// This instance will keep going after its target (like if they have GPS tracked the target) even if it lost it.
    /// </summary>
    NeverLoseTarget,
    /// <summary>
    /// This instance will look for the target around its position / last seen position if the target has been lost, and continue to perform its task
    /// on target after the target is found.
    /// </summary>
    SearchForTarget
}
