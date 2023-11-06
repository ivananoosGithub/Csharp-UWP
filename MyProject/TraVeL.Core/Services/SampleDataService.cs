using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TraVeL.Core.Models;
using TraVeL.Core.Helpers; // This is your DbContext, make sure it's properly referenced

namespace TraVeL.Core.Services
{
    public class SampleDataService
    {
        private static IEnumerable<DestinationModel> _allDestinations;
        private readonly AppDbContext _dbContext;

        public SampleDataService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DestinationModel>> GetAllDestinationsAsync()
        {
            return await _dbContext.Destination.ToListAsync();
        }

        public async Task<IEnumerable<DestinationModel>> GetContentGridDataAsync()
        {
            if (_allDestinations == null)
            {
                _allDestinations = await GetAllDestinationsAsync();
            }

            return _allDestinations;
        }
    }
}
