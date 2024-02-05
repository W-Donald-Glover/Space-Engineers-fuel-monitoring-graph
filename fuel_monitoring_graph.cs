// Space Engineers Script: Hydrogen Thruster Fuel Usage with Graph, Alerts, and Logging

const string cockpitName = "Your Cockpit Name"; // Replace with the name of your cockpit
const string textPanelName = "Your Text Panel Name"; // Replace with the name of your text panel
const double updateInterval = 0.25; // Update interval in seconds
const int graphWidth = 78; // Width of the graph in characters
const int graphHeight = 40; // Height of the graph in characters
const double fuelAlertThreshold = 500; // Fuel usage threshold for alerts

double timeSinceLastUpdate = 0;
List<double> fuelUsageHistory = new List<double>();

void Main(string argument, UpdateType updateType)
{
    Runtime.UpdateFrequency = UpdateFrequency.Update1;
    if (updateType == UpdateType.Update1 || updateType == UpdateType.Terminal)
    {
        timeSinceLastUpdate += Runtime.TimeSinceLastRun.TotalSeconds;

        if (timeSinceLastUpdate >= updateInterval)
        {
            UpdateFuelUsage();
            timeSinceLastUpdate = 0;
        }
    }
}

void UpdateFuelUsage()
{
    var cockpit = GridTerminalSystem.GetBlockWithName(cockpitName) as IMyCockpit;
    var textPanel = GridTerminalSystem.GetBlockWithName(textPanelName) as IMyTextPanel;

    if (cockpit == null)
    {
        Echo($"Cockpit '{cockpitName}' not found.");
        return;
    }

    double totalFuelUsage = 0;
    var thrusters = new List<IMyThrust>();
    GridTerminalSystem.GetBlocksOfType(thrusters);

    var hydrogenThrusters = new List<IMyThrust>();

    foreach (var thruster in thrusters)
    {
        if (IsHydrogenThruster(thruster))
        {
            hydrogenThrusters.Add(thruster);
            float currentThrust = thruster.CurrentThrustPercentage * 0.01f;
            float maxConsumption = GetMaxConsumption(thruster);
            double fuelUsage = maxConsumption * currentThrust;
            totalFuelUsage += fuelUsage;
        }
    }

    fuelUsageHistory.Add(totalFuelUsage);
    if (fuelUsageHistory.Count > (20 / updateInterval))
    {
        fuelUsageHistory.RemoveAt(0);
    }

    string graph = GenerateFuelUsageGraph();

    cockpit.GetSurface(1).WriteText(graph);

    // Check if fuel usage exceeds the threshold for alerts
    if (totalFuelUsage > fuelAlertThreshold)
    {
        AlertPlayer("Fuel usage is high! Check your hydrogen thrusters.");
    }

    // Log fuel usage data to a text panel
    LogFuelUsageData(textPanel);
}

void AlertPlayer(string message)
{
    var cockpit = GridTerminalSystem.GetBlockWithName(cockpitName) as IMyCockpit;
    if (cockpit != null)
    {
        cockpit.GetSurface(0).WriteText(message);
    }
}

void LogFuelUsageData(IMyTextPanel textPanel)
{
    if (textPanel != null)
    {
        textPanel.WriteText($"Fuel Usage Data:\n");

        for (int i = 0; i < fuelUsageHistory.Count; i++)
        {
            textPanel.WriteText($"{i}: {fuelUsageHistory[i]:F2}\n");
        }
    }
}

bool IsHydrogenThruster(IMyThrust thruster)
{
    var definitionId = thruster.BlockDefinition;
    return definitionId.SubtypeName.Contains("HydrogenThrust");
}

float GetMaxConsumption(IMyThrust thruster)
{
    string subtype = thruster.BlockDefinition.SubtypeName;
    float maxConsumption = 0f;

    switch (subtype)
    {
        case "SmallBlockSmallHydrogenThrust":
        case "SmallBlockSmallHydrogenThrustIndustrial":
            maxConsumption = 80f;
            break;
        case "SmallBlockLargeHydrogenThrust":
        case "SmallBlockLargeHydrogenThrustIndustrial":
            maxConsumption = 386f;
            break;
        case "LargeBlockSmallHydrogenThrust":
        case "LargeBlockSmallHydrogenThrustIndustrial":
            maxConsumption = 803f;
            break;
        case "LargeBlockLargeHydrogenThrust":
        case "LargeBlockLargeHydrogenThrustIndustrial":
            maxConsumption = 4820f;
            break;
        default:
            break;
    }

    return maxConsumption;
}

string GenerateFuelUsageGraph()
{
    int maxHistoryCount = (int)(20 / updateInterval);
    int count = fuelUsageHistory.Count;
    double maxValue = GetMaxFuelUsage();
    double valueRange = maxValue;
    double heightRatio = graphHeight / valueRange;

    StringBuilder graphBuilder = new StringBuilder();

    for (int y = graphHeight - 1; y >= 0; y--)
    {
        for (int x = 0; x < graphWidth; x++)
        {
            int index = count - graphWidth + x;
            if (index >= 0)
            {
                double value = fuelUsageHistory[index];
                int height = (int)(value * heightRatio);
                if (y < height)
                {
                    graphBuilder.Append("█");
                }
                else
                {
                    graphBuilder.Append(" ");
                }
            }
            else
            {
                graphBuilder.Append(" ");
            }
        }
        graphBuilder.AppendLine();
    }

    return graphBuilder.ToString();
}

double GetMaxFuelUsage()
{
    double maxFuelUsage = 0;
    var thrusters = new List<IMyThrust>();
    GridTerminalSystem.GetBlocksOfType(thrusters);

    foreach (var thruster in thrusters)
    {
        if (IsHydrogenThruster(thruster))
        {
            float maxConsumption = GetMaxConsumption(thruster);
            maxFuelUsage += maxConsumption;
        }
    }

    return maxFuelUsage;
}

// (Remaining code remains unchanged)
