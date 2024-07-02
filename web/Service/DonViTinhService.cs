using Microsoft.EntityFrameworkCore;
using web.Models;

public class DonViTinhService
{
    private readonly ApplicationDbContext _context;

    public DonViTinhService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DonViTinh>> GetDonViTinhsAsync()
    {
        return await _context.DonViTinhs.ToListAsync();
    }

    public async Task<DonViTinh> GetDonViTinhByIdAsync(int id)
    {
        return await _context.DonViTinhs.FindAsync(id);
    }

    public bool DonViTinhExists(string tenDonViTinh)
    {
        return _context.DonViTinhs.Any(it => it.Ten_Don_Vi_Tinh == tenDonViTinh);
    }

    public async Task AddDonViTinhAsync(DonViTinh donViTinh)
    {
        _context.DonViTinhs.Add(donViTinh);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDonViTinhAsync(DonViTinh donViTinh)
    {
        var existingEntity = _context.DonViTinhs.Local.FirstOrDefault(e => e.Auto_ID == donViTinh.Auto_ID);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        }
        _context.Entry(donViTinh).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public bool IsDonViTinhInUse(int donViTinhId)
    {
        return _context.SanPhams.Any(sp => sp.Don_Vi_Tinh_ID == donViTinhId);
    }

    public async Task DeleteDonViTinhAsync(int donViTinhId)
    {
        var donViTinh = await _context.DonViTinhs.FindAsync(donViTinhId);
        if (donViTinh == null)
        {
            throw new ArgumentException("Không tìm thấy đơn vị tính để xóa.");
        }

        var inUse = IsDonViTinhInUse(donViTinhId);
        if (inUse)
        {
            throw new InvalidOperationException("Đơn vị tính đang được sử dụng bởi sản phẩm. Không thể xóa.");
        }

        _context.DonViTinhs.Remove(donViTinh);
        await _context.SaveChangesAsync();
    }

}
