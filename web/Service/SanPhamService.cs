using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Service
{
    public class SanPhamService
    {
        private readonly ApplicationDbContext _context;

        public SanPhamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SanPham>> GetSanPhamsAsync()
        {
            return await _context.SanPhams.Include(sp => sp.LoaiSanPham).Include(sp => sp.DonViTinh).ToListAsync();
        }

        public async Task<SanPham> GetSanPhamByIdAsync(int id)
        {
            return await _context.SanPhams.Include(sp => sp.LoaiSanPham).Include(sp => sp.DonViTinh).FirstOrDefaultAsync(sp => sp.Auto_ID == id);
        }

        public async Task<SanPham> AddSanPhamAsync(SanPham sanPham)
        {
            _context.SanPhams.Add(sanPham);
            await _context.SaveChangesAsync();
            return sanPham;
        }
        public async Task<List<LoaiSanPham>> GetLoaiSanPhamsAsync()
        {
            return await  _context.LoaiSanPhams.ToListAsync();
           
        }
        public async Task<List<DonViTinh>> GetDonViTinhsAsync()
        {
            return await _context.DonViTinhs.ToListAsync();
        }

        public async Task<SanPham> UpdateSanPhamAsync(SanPham sanPham)
        {
            try
            {
                
                var existingEntity = _context.SanPhams.Local.FirstOrDefault(sp => sp.Auto_ID == sanPham.Auto_ID);
                if (existingEntity != null)
                {
                    
                    _context.Entry(existingEntity).State = EntityState.Detached;
                }

                
                _context.Entry(sanPham).State = EntityState.Modified;

                
                await _context.SaveChangesAsync();

                return sanPham;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseEntity = entry.GetDatabaseValues();
                if (databaseEntity == null)
                {
                    throw new Exception("Sản phẩm không tồn tại hoặc đã bị xóa.");
                }
                else
                {
                    var databaseValues = (SanPham)databaseEntity.ToObject();
                   
                    throw new Exception("Dữ liệu đã bị thay đổi bởi một người dùng khác. Vui lòng tải lại trang và thử lại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
            }
        }


        public async Task<bool> IsSanPhamInUseAsync(int sanPhamId)
        {

            return await _context.SanPhams.AnyAsync(o => o.Auto_ID == sanPhamId);
        }

        public async Task DeleteSanPhamAsync(int sanPhamId)
        {
            try
            {
                var sanPham = await _context.SanPhams.FindAsync(sanPhamId);
                if (sanPham == null)
                    throw new Exception("Sản phẩm không tồn tại");

               
                var isUsedInPhieuNhapXuat = await _context.NhapKhoRawDatas.AnyAsync(pnx => pnx.SanPhamId == sanPhamId);
                var isUsedInChiTietNhapXuat = await _context.XuatKhoRawDatas.AnyAsync(ctnx => ctnx.SanPhamId == sanPhamId);

                if (isUsedInPhieuNhapXuat || isUsedInChiTietNhapXuat)
                    throw new Exception("Sản phẩm đang được sử dụng trong phiếu nhập xuất. Không thể xóa.");

                _context.SanPhams.Remove(sanPham);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


        public async Task<(bool MaSPExists, bool TenSPExists)> SanPhamExistsAsync(string maSanPham, string tenSanPham)
        {
            var maSPExists = await _context.SanPhams.AnyAsync(sp => sp.Ma_San_Pham == maSanPham);
            var tenSPExists = await _context.SanPhams.AnyAsync(sp => sp.Ten_San_Pham == tenSanPham);
            return (maSPExists, tenSPExists);
        }
    }
}
