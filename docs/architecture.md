# terminal-tower-defense (ttd) System Architecture

## Overview
- **Daemon**: The core game logic running in the background.
- **CLI Client**: Interacts with the daemon and provides user commands.
- **Renderer**: Handles display updates using VT-100 escape sequences.

Both the daemon and the CLI client communicate through a Unix socket to enable potential future expansion to networked multiplayer, remote control and custom clients. All current implementations are in Java 21.

## Daemon

### Game

The "engine" classes are how the game logic is implemented.

- `Entity`: The base class for all game entities.
- `Component`: The base class for all game components.
- `System`: The base class for all game systems.

Entities are the game objects, such as towers, enemies, and resources, and are composed of components. Components are the data containers for entities, such as health, position, and behavior. Systems are the logic that operates on entities and components, such as movement, collision detection, and rendering. Therefore, the game logic is implemented by creating entities, adding components to them, and running systems to update the game state.

As an example, a 'IronMine' entity might have an 'Inventory' component that stores the amount of iron ore it has produced, a 'Production' component that determines how much iron ore it produces per tick, and a 'Position' component that determines where it is on the map. A 'ProductionSystem' would then update the 'Inventory' component based on the 'Production' component.

#### Systems

For efficient tracking of entities and components, each system must declare which components it operates on via a `SystemEntityRequirement` object. To seperate the systems from the entities, the systems don't directly track the entities, but fetch them from the `World` class.

#### World

The `World` class is the container for all entities. Systems register themselves with the world, to inform the world which components they operate on, so the world can efficiently keep track of which entities need to be updated by which systems.

## CLI Client

## Renderer

The rendering is done by holding two `StringBuilders` as screen buffers. One buffer holds the current screen state, and the other holds the desired screen state. Once the desired screen state is updated, the renderer compares the two buffers and only updates the terminal with the necessary changes. This approach minimizes the number of terminal updates and reduces flickering. Updates are done using VT-100 escape sequences. 

> [!ATTENTION]
> The current implementation does not optimize color changes, moving the cursor, or using other advanced VT-100 features for speed.
> This is a potential area for future optimization.

The `Screen` class offers the API to draw on the screen, i.e., to write to the screen buffers. It serves as the "canvas" for the game.

### Colors in the Screen Buffer

For more efficient memory usage, a `ScreenBufferCell` safes both foreground and background colors in one `long` value. 

The layout of the `long` value is as follows:

```text
| 63-57 | 56         | 55-48 | 47-40 | 39-32 | 31-25  | 24         | 23-16 | 15-8 | 7-0  |
| unused| default BG | BG-R  | BG-G  | BG-B  | unused | default-FG | FG-R  | FG-G | FG-B |
```

