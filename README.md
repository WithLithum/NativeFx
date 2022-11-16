<!--
SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>

SPDX-License-Identifier: Apache-2.0
-->

# NativeFx

An expansion library for Script Hook V .NET that adds various classes and
wrappers to assist with programming for GTA V.

## Building

Add the `https://www.myget.org/F/withlithum/api/v3/index.json` feed to your NuGet config.

### Via Visual Studio (GUI)

- Right click `NativeFx` project in your Solution Explorer, select `Manage NuGet Packages`.
- Click the gear icon on the right side of the NuGet pane, right next to the Package Source.
- Click the Plus icon, and then in address bar below, replace `https://packagesource` with 
  `https://www.myget.org/F/withlithum/api/v3/index.json`, and the replace "Package Source" name with "WithLithum".
- Click Build on the menu bar, then click Build Solution.
- Binaries should be in `bin\Debug\net48` (or `bin\Release\net48`, depending on the config you selected) folder.

### Via Package Manager Console

- Open Package Manager console.
- Click the gear icon right next to the package source selector (combo box).
- Click the Plus icon, and then in address bar below, replace `https://packagesource` with 
  `https://www.myget.org/F/withlithum/api/v3/index.json`, and the replace "Package Source" name with "WithLithum".

### Via .NET CLI (requires .NET Fx)

Run the following commands:

```powershell
dotnet restore --source "https://www.myget.org/F/withlithum/api/v3/index.json"
dotnet restore
dotnet build
```

Then binaries should be in `bin\Debug\net48` (or `bin\Release\net48`, depending on the config you selected) folder,
provided if the build is successful.

## Licence

This library is licenced under the Apache-2.0 licence.