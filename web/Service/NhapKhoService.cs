/*using Microsoft.EntityFrameworkCore;
using web.Models;

public class NhapKhoService
{
    private readonly ApplicationDbContext _context;

    public NhapKhoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<NhapKho>> GetNhapKhoAsync()
    {
        return await _context.NhapKhos
            .Include(nk => nk.Kho)
            .Include(nk => nk.NCC)
            .ToListAsync();
    }
    public async Task<NhapKho> GetNhapKhoAsyncById(int id)
    {
        return await _context.NhapKhos.FindAsync(id);
    }

    public async Task<List<Kho>> GetKhoNhapAsync()
    {
        return await _context.Khos.ToListAsync();
    }

    public async Task<List<NCC>> GetNCCNhapAsync()
    {
        return await _context.NCCs.ToListAsync();
    }

    public async Task<NhapKho> AddNhapKhoAsync(NhapKho nhapk)
    {
        _context.NhapKhos.Add(nhapk);
        await _context.SaveChangesAsync();
        return nhapk;
    }

    public async Task<bool> DeleteNhapKhoAsync(int id)
    {
        var nko = await _context.NhapKhos.FindAsync(id);
        if (nko == null)
        {
            return false;
        }
        _context.NhapKhos.Remove(nko);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> NhapKhoExistsAsync(string phieu)
    {
        return await _context.NhapKhos.AnyAsync(spn => spn.SoPhieuNhapKho == phieu);
    }
    public async Task UpdateNhapKhoAsync(NhapKho nhapKho)
    {
        _context.NhapKhos.Update(nhapKho);
        await _context.SaveChangesAsync();
    }
}



*/