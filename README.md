# terminal-tower-defense (ttd)

<p align="center">
  <img src="/res/ttd_icon.png" align="center" width="200">
</p>

## General Outline
`terminal-tower-defense` (ttd) is a hybrid game combining tower defense and factory simulation genres. Played entirely in the terminal, it leverages VT-100 escape sequences for a platform-independent display. The game runs as a daemon in the background and is interfaced via the command line, using commands prefixed with `> ttd`.

## Project Structure

```
/terminal-tower-defense
|-- /experiments  # temporary files and experiments for development
|-- /src
|   |-- /main
|   |   |-- /java  # source code
|-- /docs
|   |-- design.md         # design documentation
|   |-- architecture.md   # system architecture
|-- README.md
```

The project board is available [here](https://github.com/users/DrChristophFH/projects/1).

## Installation and Requirements
### Requirements

<!-- todo -->

### Installation

<!-- todo -->

## Documentation
For more detailed information, refer to the [docs](./docs) directory.

## Hints
- Make sure your terminal supports VT-100 escape sequences.
- Use `> ttd help` to get a list of all available commands.