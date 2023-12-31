﻿using Microsoft.EntityFrameworkCore;
using TRentAPI.Data;
using TRentAPI.Models;

namespace TRentAPI.Repositories;

public class AccommodationRepository
{
    private readonly TrentDataContext _dataContext;

    public AccommodationRepository(TrentDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<Accommodation>> GetAccommodationsAsync(int idR)
    {
        return await _dataContext.Set<Accommodation>()
            .Where(a=> a.RenterID == idR)
            .ToListAsync();
    }
    public async Task<Accommodation> GetAccommodationAsync(int id,int idR)
    {
        var accommodation = await _dataContext.Set<Accommodation>()
            .FirstOrDefaultAsync(a => a.RenterID == idR && a.Id == id);
        return accommodation;
    }
    public async Task<Accommodation> AddAccommodationAsync(Accommodation accommodation,int idR)
    {
        var toAdd = accommodation;
        accommodation.RenterID = idR;
        _dataContext.Set<Accommodation>().Add(toAdd);
        await _dataContext.SaveChangesAsync();
        return toAdd;
    }

    public async Task UpdateAccommodationAsync(Accommodation accommodation,int idR)
    {
        _dataContext.Accommodations.Update(accommodation);
        await _dataContext.SaveChangesAsync();
        // var AccommodationToUpdate = await _dataContext.Accommodations.FirstOrDefaultAsync(o => o.Id == accommodation.Id && o.RenterID ==idR);
        // if (AccommodationToUpdate == null)
        // {
        //     return false;
        // }   
        // //here assign changes
        // AccommodationToUpdate.Location = accommodation.Location;
        // AccommodationToUpdate.Instructions = accommodation.Instructions;
        // try
        // {
        //     await _dataContext.SaveChangesAsync();
        //     return true;
        // }
        // catch (Exception)
        // {
        //     throw;
        // }
        
    }
    public async Task<bool> DeleteAccommodationAsync(int id,int idR)
    {
        var srchResult = await _dataContext.Accommodations.FirstOrDefaultAsync(a=>a.Id==id && a.RenterID == idR);
        if (srchResult == null)
            return false;
        _dataContext.Accommodations.Remove(srchResult);
        await _dataContext.SaveChangesAsync();
        return true;
    }
}