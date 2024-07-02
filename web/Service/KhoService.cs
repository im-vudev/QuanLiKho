using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Service
{
    public class KhoService
    {
        private readonly ApplicationDbContext _context;

        public KhoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsKhoInUseAsync(int khoId)
        {
            var isNhapKhoInUse = await _context.NhapKhos.AnyAsync(sp => sp.KhoId == khoId);
            var isXuatKhoInUse = await _context.XuatKhoRawDatas.AnyAsync(sp => sp.XuatKhoId == khoId);
            var isKhoUsersInUse = await _context.KhoUsers.AnyAsync(sp => sp.KhoId == khoId);

            return isNhapKhoInUse || isXuatKhoInUse || isKhoUsersInUse;
        }


        public async Task<bool> KhoHasPermissions(int khoId)
        {
            return await _context.KhoUsers.AnyAsync(ku => ku.KhoId == khoId);
        }

        public async Task<List<Kho>> GetKhoAsync()
        {
            return await _context.Khos.ToListAsync();
        }

        public async Task<Kho> GetKhoAsyncByID(int id)
        {
            return await _context.Khos.FindAsync(id);
        }

        public async Task<Kho> AddKho(Kho kho)
        {
           _context.Khos.Add(kho);
            await _context.SaveChangesAsync();
            return kho;
        }

        public async Task<Kho> UpdateKho(Kho kho)
        {
            var existingKho = await _context.Khos.FindAsync(kho.Auto_ID);
            if (existingKho != null)
            {
                existingKho.Ten_Kho = kho.Ten_Kho;
                existingKho.Ghi_Chu = kho.Ghi_Chu;
               

                await _context.SaveChangesAsync();
                return existingKho;
            }
            else
            {
                throw new Exception("Kho not found"); 
            }
        }



        public async Task<bool> DeleteKhos(int id)
        {
            var deletekho = await _context.Khos.FindAsync(id);
            if (deletekho == null)
            {
                return false;
            }
            _context.Khos.Remove(deletekho);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KhoExits(string name)
        {
            var nkho = await _context.Khos.AnyAsync(x => x.Ten_Kho == name);
           
            return (nkho);
        }

    }
}
