using Microsoft.EntityFrameworkCore;

namespace SemanticKernel
{
    internal class LightsDataLayer
    {
        private readonly LightsDbContext _context;

        public LightsDataLayer()
        {
            var builder = new DbContextOptionsBuilder<LightsDbContext>().UseInMemoryDatabase("LightsDatabase");
            _context = new LightsDbContext(builder.Options);
            _context.Seed();
        }

        public async Task<List<LightModel>> GetLightsAsync()
        {
            return await _context.Lights.ToListAsync();
        }

        public async Task<LightModel?> GetLightAsync(int id)
        {
            return await _context.Lights.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}