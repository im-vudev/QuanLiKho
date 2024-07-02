/*using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Service
{
    public class KhoUserService
    {
        private readonly ApplicationDbContext _context;

        public KhoUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync() ?? new List<User>();
        }

        public async Task<List<Kho>> GetKhosAsync()
        {
            return await _context.Khos.ToListAsync() ?? new List<Kho>();
        }

        public async Task<KhoUser> GetKhoUserByIdAsync(int id)
        {
            return await _context.KhoUsers.FindAsync(id);
        }

        public async Task<KhoUser> AddKhoUserAsync(KhoUser khoUser)
        {
            _context.KhoUsers.Add(khoUser);
            await _context.SaveChangesAsync();
            return khoUser;
        }

        public async Task<KhoUser> UpdateKhoUserAsync(KhoUser khoUser)
        {
            _context.Entry(khoUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return khoUser;
        }

        public async Task<bool> DeleteKhoUserAsync(int id)
        {
            var ku = await _context.KhoUsers.FindAsync(id);
            if (ku == null)
            {
                return false;
            }
            _context.KhoUsers.Remove(ku);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PhanQuyenKhoAsync(KhoUser khoUser)
        {
            if (string.IsNullOrEmpty(khoUser.MaDangNhap) || khoUser.KhoId == 0)
            {
                return false;
            }

            if (await _context.KhoUsers.AnyAsync(ku => ku.MaDangNhap == khoUser.MaDangNhap && ku.KhoId == khoUser.KhoId))
            {
                return false;
            }

            _context.KhoUsers.Add(khoUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<string>> GetMaDangNhapByKhoIdAsync(int khoId)
        {
            var maDangNhapList = await _context.KhoUsers
                .Where(ku => ku.KhoId == khoId)
                .Select(ku => ku.MaDangNhap)
                .ToListAsync();

            return maDangNhapList;
        }

        public async Task<(bool MaDangNhapExists, bool KhoExists)> KhoUserExistsAsync(string maDangNhap, int khoId)
        {
            var maDangNhapExists = await _context.Users.AnyAsync(u => u.Ma_Dang_Nhap == maDangNhap);
            var khoExists = await _context.Khos.AnyAsync(k => k.Auto_ID == khoId);

            return (maDangNhapExists, khoExists);
        }
    }
}
*/