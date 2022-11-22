namespace NativeFx.UI.TestScript;

using GTA;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
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
    private readonly NativeCheckboxItem _itemFakeSpectator = new("Fake spectator mode");
    private readonly NativeCheckboxItem _itemBigMap = new("Big map");
    private readonly NativeCheckboxItem _itemFullAsBig = new("Full map as big map");

    private readonly NativeMenu _menuExp = new("NativeFx", "Experimental");
    private readonly NativeCheckboxItem _itemAbility = new("Ability bar visible");
    private readonly NativeCheckboxItem _itemAllowAbility = new("Allow ability bar");
    private readonly NativeCheckboxItem _itemDirectorMode = new("Director Mode");

    private readonly ScaledText _textBlips = new(new System.Drawing.PointF(1.5f, 1.5f), "Loading")
    {
        Scale = 0.25f
    };

    public MainScript()
    {
        _pool.Add(_menu);

        _menu.Add(_itemNotify);
        _menu.Add(_itemComplexNotify);
        _menu.Add(_itemBlinkNotify);
        _menu.Add(_itemSetColour);
        _menu.Add(_itemRemoveWaypoint);
        _menu.Add(_itemFakeSpectator);
        _menu.Add(_itemBigMap);
        _menu.Add(_itemFullAsBig);
        _itemNotify.Activated += NotifyActivated;
        _itemComplexNotify.Activated += ComplexNotifyActivated;
        _itemRemoveWaypoint.Activated += RemoveWaypointActivated;
        _itemFakeSpectator.CheckboxChanged += FakeSpectatorCheckbox;
        _itemBigMap.CheckboxChanged += BigMapActivated;

        _pool.Add(_menuExp);
        _menu.AddSubMenu(_menuExp).AltTitle = "";
        _menuExp.Add(_itemAbility);
        _menuExp.Add(_itemAllowAbility);
        _menuExp.Add(_itemDirectorMode);

        _itemAbility.CheckboxChanged += AbilityChanged;
        _itemAllowAbility.CheckboxChanged += _itemAllowAbility_CheckboxChanged;
        _itemDirectorMode.CheckboxChanged += DirectoryChanged;

        this.Tick += MainScript_Tick;
    }

    private void DirectoryChanged(object sender, System.EventArgs e)
    {
        Natives.SetPlayerIsInDirectorMode(_itemDirectorMode.Checked);
    }

    private void _itemAllowAbility_CheckboxChanged(object sender, System.EventArgs e)
    {
        Natives.SetAllowAbilityBar(_itemAllowAbility.Checked);
    }

    private void AbilityChanged(object sender, System.EventArgs e)
    {
        Natives.SetAbilityBarVisibility(_itemAbility.Checked);
    }

    private void BigMapActivated(object sender, System.EventArgs e)
    {
        XHud.ToggleBigMap(_itemBigMap.Checked, _itemFullAsBig.Checked);
    }

    private void FakeSpectatorCheckbox(object sender, System.EventArgs e)
    {
        XNotification.Show("Fake spectator");
        XHud.FakeSpectatorMode = _itemFakeSpectator.Checked;
    }

    private void MainScript_Tick(object sender, System.EventArgs e)
    {
        if (_menu.Visible)
        {
            _textBlips.Text = $"{XHud.CountActiveBlips()} blips";
            _textBlips.Draw();
        }

        _pool.Process();

        if (_interval != 0)
        {
            _interval--;
        }

        Game.DisableControlThisFrame(Control.InteractionMenu);
        if (Game.IsControlJustPressed(Control.InteractionMenu) && !_pool.AreAnyVisible)
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
