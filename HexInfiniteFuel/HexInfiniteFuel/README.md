# HexInfiniteFuel

HexInfiniteFuel is a lightweight Valheim mod that keeps supported fireplaces lit without needing fuel.

> ⚠️ **Compatibility Notice**
> This mod sets `m_infiniteFuel = true` on all `Fireplace` components at instantiation. It may conflict with any other mod that reads or writes the `Fireplace.m_infiniteFuel` field. If you experience issues, disable one of the conflicting mods or check mod load order.

## Features

- No fuel requirement for fireplaces, Bonfires, Torches, or any other prefab that uses the `Fireplace` component.
- Simple client-side style gameplay tweak
- Minimal setup

## Requirements

- BepInExPack Valheim

## Installation

### Thunderstore / r2modman
Install the mod through Thunderstore or r2modman.

### Manual
1. Install BepInExPack Valheim.
2. Extract this package.
3. Copy the `plugins/HexInfiniteFuel/HexInfiniteFuel.dll` file into your Valheim `BepInEx/plugins/HexInfiniteFuel/` folder.