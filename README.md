# Space-Engineers-fuel-monitoring-graph
Elevate your Space Engineers experience with the Hydrogen Thruster Monitor Script. Track fuel usage in real-time, receive alerts, and log historical data. Install, configure, and play smarter.

# Space Engineers Script: Hydrogen Thruster Monitor

## Overview

Space Engineers stands out as a captivating voxel-based sandbox game, meticulously crafted by the skilled team at Keen Software House, an independent game development company based in the Czech Republic. This immersive gaming experience took its first steps into the gaming realm in 2013 when it made its debut as part of the Steam Early Access program, marking the initial phase of its developmental journey.

This Space Engineers script provides a comprehensive solution for monitoring the fuel usage of hydrogen thrusters. It offers real-time visual feedback through a graph on a cockpit's LCD screen, includes an alert system to notify players of high fuel usage, and logs historical fuel data to a text panel. This README guide will cover various aspects of the script, from installation and configuration to advanced customization and troubleshooting.

The intial codes of this script is taken from reddit and I think this was great idea to make improvments. Welcome fellow game fans and developers to contribute the project. Inspired by real world [vehicle fuel monitoring systems](https://kommnet.lk/fuel-monitoring-system/).

## Table of Contents

1. [Installation](#installation)
2. [Configuration](#configuration)
3. [Usage](#usage)
   - [Graph Display](#graph-display)
   - [Alert System](#alert-system)
   - [Fuel Usage Logging](#fuel-usage-logging)
4. [Advanced Customization](#advanced-customization)
   - [Graph Parameters](#graph-parameters)
   - [Adding New Alerts](#adding-new-alerts)
5. [Troubleshooting](#troubleshooting)
6. [Contributing](#contributing)
7. [License](#license)

## Installation

1. **Script Placement:**
   - Copy the script and paste it into a Programmable Block in your Space Engineers world.

2. **Configuration:**
   - Set the `cockpitName` and `textPanelName` constants to match the names of your cockpit and text panel blocks.
   - Adjust parameters like `updateInterval` and `fuelAlertThreshold` according to your preferences.

3. **Run the Script:**
   - Trigger the script manually or automate it by connecting it to a timer block or another programmable block.

## Configuration

- **`cockpitName`:** Replace with the name of your cockpit block.
- **`textPanelName`:** Replace with the name of your text panel block.
- **`updateInterval`:** Time interval between updates in seconds.
- **`graphWidth` and `graphHeight`:** Dimensions of the fuel usage graph.
- **`fuelAlertThreshold`:** Fuel usage threshold for triggering alerts.

## Usage

### Graph Display

The cockpit's LCD screen will display a graph representing the fuel usage history of hydrogen thrusters. Each update interval adds a new data point to the graph.

### Alert System

An alert message will be displayed on the cockpit's main screen if the total fuel usage exceeds the defined threshold (`fuelAlertThreshold`). This can serve as a warning for players to check their hydrogen thrusters or take corrective action.

### Fuel Usage Logging

Fuel usage data is logged to the specified text panel (`textPanelName`). This provides a historical record that players can reference to track changes in fuel consumption over time.

## Advanced Customization

### Graph Parameters

- Adjust `graphWidth` and `graphHeight` to customize the dimensions of the fuel usage graph on the cockpit's LCD screen.

### Adding New Alerts

To add new alerts or customize existing ones, modify the `AlertPlayer` method in the script. You can extend the logic based on specific conditions or introduce different alert types.

## Troubleshooting

If you encounter issues or unexpected behavior, consider the following steps:

1. **Check Block Names:**
   - Ensure that the names specified in `cockpitName` and `textPanelName` match the actual block names in your game.

2. **Script Echo Output:**
   - Check the Programmable Block's "Echo" output in the terminal for any error messages or diagnostic information.

3. **Community Support:**
   - Visit the Space Engineers community forums or GitHub repository for assistance and discussions.

## Contributing

Contributions are welcome! If you have suggestions, improvements, or bug fixes, please open an issue or submit a pull request on the repository.

## License

This script is released under the [MIT License]. Feel free to modify and share it as needed.

