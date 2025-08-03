using Microsoft.EntityFrameworkCore;

namespace SemanticKernel;

public class LightsDbContext(DbContextOptions<LightsDbContext> options) : DbContext(options)
{
    public DbSet<LightModel> Lights { get; set; }

    public void Seed()
    {
        // Ensure the database is created
        Database.EnsureCreated();
        if (!Lights.Any())
        {
            Lights.Add(new LightModel { Id = 1, Name = "Table Lamp", IsOn = false });
            Lights.Add(new LightModel { Id = 2, Name = "Porch light", IsOn = false });
            Lights.Add(new LightModel { Id = 3, Name = "Chandelier", IsOn = true });
            Lights.Add(new LightModel { Id = 4, Name = "Pendant Light", IsOn = false });
            Lights.Add(new LightModel { Id = 5, Name = "Flush Mount", IsOn = false });
            Lights.Add(new LightModel { Id = 6, Name = "Semi-Flush Mount", IsOn = true });
            Lights.Add(new LightModel { Id = 7, Name = "Recessed Lighting", IsOn = false });
            Lights.Add(new LightModel { Id = 8, Name = "Track Lighting", IsOn = false });
            Lights.Add(new LightModel { Id = 9, Name = "Sconce", IsOn = false });
            Lights.Add(new LightModel { Id = 10, Name = "Vanity Light", IsOn = true });
            Lights.Add(new LightModel { Id = 11, Name = "Porch Light", IsOn = false });
            Lights.Add(new LightModel { Id = 12, Name = "Table Lamp", IsOn = false });
            Lights.Add(new LightModel { Id = 13, Name = "Floor Lamp", IsOn = true });
            Lights.Add(new LightModel { Id = 14, Name = "Arc Lamp", IsOn = false });
            Lights.Add(new LightModel { Id = 15, Name = "Task Lamp", IsOn = true });
            Lights.Add(new LightModel { Id = 16, Name = "Porch Light", IsOn = false });
            Lights.Add(new LightModel { Id = 17, Name = "Post Light", IsOn = false });
            Lights.Add(new LightModel { Id = 18, Name = "Floodlight", IsOn = false });
            Lights.Add(new LightModel { Id = 19, Name = "Spotlight", IsOn = false });
            Lights.Add(new LightModel { Id = 20, Name = "String Lights", IsOn = true });
            Lights.Add(new LightModel { Id = 21, Name = "Step Lights", IsOn = false });
            Lights.Add(new LightModel { Id = 22, Name = "Under-Cabinet Lighting", IsOn = false });
            Lights.Add(new LightModel { Id = 23, Name = "Picture Light", IsOn = true });
            Lights.Add(new LightModel { Id = 24, Name = "Strip Lights", IsOn = false });
            Lights.Add(new LightModel { Id = 25, Name = "Display Case Lighting", IsOn = false });
        }

        SaveChanges();
    }
}