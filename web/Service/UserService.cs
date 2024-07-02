using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserHasPermissions(int maDangNhap)
        {
            return await _context.KhoUsers.AnyAsync(p => p.UserId == maDangNhap);
        }

        public async Task<List<User>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByID(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Auto_ID == user.Auto_ID);

            if (existingUser == null)
            {
                return null;
            }

            
            if (user.Ma_Dang_Nhap != existingUser.Ma_Dang_Nhap)
            {
               
                if (await _context.Users.AnyAsync(u => u.Ma_Dang_Nhap == user.Ma_Dang_Nhap))
                {
                    throw new Exception("Mã đăng nhập đã tồn tại.");
                }
            }

           
            existingUser.Ma_Dang_Nhap = user.Ma_Dang_Nhap;
            existingUser.Mat_Khau = user.Mat_Khau;
            existingUser.Ho_Ten = user.Ho_Ten;
            existingUser.Ghi_Chu = user.Ghi_Chu;

           
            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingUser;
        }


        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(string ma)
        {
            return await _context.Users.AnyAsync(mdn => mdn.Ma_Dang_Nhap == ma);
        }
    }
}
