using Microsoft.EntityFrameworkCore;
using OperationsManagementApp.Data;
using OperationsManagementApp.Models;

namespace OperationsManagementApp.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly AppDbContext _context;

    public InventoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryItem>> GetAllAsync()
    {
        return await _context.InventoryItems.ToListAsync();
    }
    
    public async Task<InventoryItem> CreateAsync(InventoryItem item)
    {
        _context.InventoryItems.Add(item);
        await _context.SaveChangesAsync();
        
        return item;
    }

    public async Task<InventoryItem?> GetByIdAsync(int id)
    {
        return await _context.InventoryItems.FindAsync(id);
    }
    
    
    public async Task<InventoryItem> UpdateAsync(InventoryItem item)
    {
        _context.InventoryItems.Update(item);
        await _context.SaveChangesAsync();
        
        return item;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.InventoryItems.FindAsync(id);

        if (item == null)
            return false;
        
        _context.InventoryItems.Remove(item);
        await _context.SaveChangesAsync();
        
        return true;
    }
}