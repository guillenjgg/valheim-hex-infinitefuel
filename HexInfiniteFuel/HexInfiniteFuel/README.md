# HexInfiniteFuel

HexInfiniteFuel is a lightweight Valheim mod that keeps supported fireplaces lit without needing fuel.

> ⚠️ **Compatibility Notice**
> This mod sets `m_infiniteFuel = true` on all `Fireplace` components at instantiation. It may conflict with any other mod that reads or writes the `Fireplace.m_infiniteFuel` field. If you experience issues, disable one of the conflicting mods or check mod load order.

## Multiplayer Compatibility

> ⚠️ **All players must install this mod.**
>
> HexInfiniteFuel is a **client-side** mod. Every player on a multiplayer server should have the mod installed.
>
> Installing the mod only on a dedicated server is **not supported** due to technical limitations in Valheim's multiplayer synchronization. Players without the mod will continue to consume fireplace fuel normally, which can result in inconsistent behavior when fireplace ownership changes between modded and unmodded clients.

## Features

* Keeps fireplaces, bonfires, torches, hearths, and any other prefab using the `Fireplace` component permanently lit without consuming fuel.
* Lightweight client-side gameplay tweak.

## Requirements

* BepInExPack Valheim

## Installation

### Thunderstore / r2modman

Install the mod through Thunderstore or r2modman.

### Manual

1. Install BepInExPack Valheim.
2. Extract this package.
3. Copy `HexInfiniteFuel.dll` to:
   `BepInEx/plugins/HexInfiniteFuel/`

## Support and Feedback

https://discord.gg/wU2FXD94v4

## GitHub

https://github.com/guillenjgg/valheim-hex-infinitefuel