using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SemanticKernel;

public class LightsPlugin
{
    private readonly LightsDataLayer _dataLayer = new();

    [KernelFunction("get_lights")]
    [Description("Gets a list of lights and their current state")]
    public async Task<List<LightModel>> GetLightsAsync()
    {
        return await _dataLayer.GetLightsAsync();
    }

    [KernelFunction("change_state")]
    [Description("Changes the state of the light")]
    public async Task<LightModel?> ChangeStateAsync(int id, bool isOn)
    {
        var light = await _dataLayer.GetLightAsync(id);

        if (light == null)
        {
            return null;
        }

        // Update the light with the new state
        light.IsOn = isOn;

        return light;
    }
}