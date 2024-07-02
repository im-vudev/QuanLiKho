using Microsoft.EntityFrameworkCore;
using web.Components.Pages;
using web.Models;

namespace web.Service
{
    public class LoaiSanPhamService
    {
        private readonly ApplicationDbContext _context;

        public LoaiSanPhamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoaiSanPham>> GetLspAsync()
        {
            return await _context.LoaiSanPhams.ToListAsync();
        }

        public async Task<LoaiSanPham> GetLspByIdAsync(int id)
        {
            return await _context.LoaiSanPhams.FindAsync(id);
        }

        public async Task<LoaiSanPham> AddLspAsync(LoaiSanPham lsp)
        {
            _context.LoaiSanPhams.Add(lsp);
            await _context.SaveChangesAsync();
            return lsp;
        }

        public async Task<LoaiSanPham> UpdateLspAsync(LoaiSanPham loaisp)
        {
            try
            {
              
                var existingEntity = _context.LoaiSanPhams.Local.FirstOrDefault(lsp => lsp.Auto_ID == loaisp.Auto_ID);
                if (existingEntity != null)
                {
                   
                    _context.Entry(existingEntity).State = EntityState.Detached;
                }

              
                _context.Entry(loaisp).State = EntityState.Modified;

               
                await _context.SaveChangesAsync();

                return loaisp;
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
                throw new Exception($"Lỗi khi cập nhật loại sản phẩm: {ex.Message}");
            }
        }

        public async Task<bool> IsLoaiSPUsedAsync(int loaiSPId)
        {
            return await _context.SanPhams.AnyAsync(sp => sp.Loai_San_Pham_ID == loaiSPId);
        }

        public async Task DeleteLspAsync(int loaiSPId)
        {
            try
            {
                var loaiSP = await _context.LoaiSanPhams.FindAsync(loaiSPId);
                if (loaiSP == null)
                    throw new Exception("Loại sản phẩm không tồn tại");

                
                var isUsed = await IsLoaiSPUsedAsync(loaiSPId);
                if (isUsed)
                    throw new Exception("Loại sản phẩm đang được sử dụng bởi sản phẩm. Không thể xóa.");

                _context.LoaiSanPhams.Remove(loaiSP);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($" {ex.Message}");
            }
        }


        public async Task<(bool MaLoaiExists, bool TenLoaiExists)> LoaiSPExistsAsync(string id, string name)
        {
            var maLoaiExists = await _context.LoaiSanPhams.AnyAsync(msp => msp.Ma_LSP == id);
            var tenLoaiExists = await _context.LoaiSanPhams.AnyAsync(lsp => lsp.Ten_LSP == name);
            return (maLoaiExists, tenLoaiExists);
        }
    }
}
