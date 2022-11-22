namespace NativeFx.UI.TestScript;

using GTA;
using LemonUI;
using LemonUI.Menus;

public class MainScript : Script
{
    private int _interval;
    private readonly ObjectPool _pool = new();
    private readonly NativeMenu _menu = new("NativeFx", "UI Test Script");
    private readonly NativeItem _itemNotify = new("Post Simple Feed");
    private readonly NativeItem _itemComplexNotify = new("Post Complex Feed");
    private readonly NativeCheckboxItem _itemSetColour = new("Set Feed Colour");
    private readonly NativeCheckboxItem _itemBlinkNotify = new("Blink Feeds");
    private readonly NativeItem _itemRemoveWaypoint = new("Remove waypoint");

    public MainScript()
    {
        _pool.Add(_menu);

        _menu.Add(_itemNotify);
        _menu.Add(_itemComplexNotify);
        _menu.Add(_itemBlinkNotify);
        _menu.Add(_itemSetColour);
        _menu.Add(_itemRemoveWaypoint);
        _itemNotify.Activated += NotifyActivated;
        _itemComplexNotify.Activated += ComplexNotifyActivated;
        _itemRemoveWaypoint.Activated += RemoveWaypointActivated;

        this.Tick += MainScript_Tick;
    }

    private void MainScript_Tick(object sender, System.EventArgs e)
    {
        _pool.Process();

        if (_interval != 0)
        {
            _interval--;
        }

        Game.DisableControlThisFrame(Control.InteractionMenu);
        if (Game.IsControlJustPressed(Control.InteractionMenu))
        {
            _menu.Visible = !_menu.Visible;
            _interval = 35;
        }
    }

    private void RemoveWaypointActivated(object sender, System.EventArgs e)
    {
        XHud.RemoveWaypoint();
    }

    private void PreNotify()
    {
        if (_itemBlinkNotify.Checked)
        {
            XNotification.SetNextBackgroundColour(6);
        }
    }

    private void ComplexNotifyActivated(object sender, System.EventArgs e)
    {
        PreNotify();
        XNotification.Show(new Texture("web_lossantospolicedept", "web_lossantospolicedept"), "LSPD", "SubLSPD", "Complex", _itemBlinkNotify.Checked);
    }

    private void NotifyActivated(object sender, System.EventArgs e)
    {
        PreNotify();
        XNotification.Show("Simple notification", _itemBlinkNotify.Checked);
    }
}
