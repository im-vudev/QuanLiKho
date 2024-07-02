using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Service
{
    public class NCCService
    {
        private readonly ApplicationDbContext _context;
        public NCCService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NCC>> GetNCCs()
        {
            return await _context.NCCs.ToListAsync();
        }

        public async Task<bool> IsNCCInUseAsync(int ncc)
        {

            return await _context.NhapKhos.AnyAsync(sp => sp.NCC_Id == ncc);
        }

        public async Task<NCC> GetNCCsByID( int id)
        {
            return await _context.NCCs.FindAsync(id);
        }

        public async Task<NCC> AddNCC(NCC ncc)
        {
            _context.NCCs.Add(ncc);
            await _context.SaveChangesAsync();
            return ncc; 
        }

        public async Task<NCC> UpdateNCC(NCC ncc)
        {
           
            var existingNCC = await _context.NCCs.FindAsync(ncc.Auto_ID);
            if (existingNCC != null)
            {
               
                _context.Entry(existingNCC).CurrentValues.SetValues(ncc);
                await _context.SaveChangesAsync();
                return existingNCC;
            }
            else
            {
              
                _context.NCCs.Add(ncc);
                await _context.SaveChangesAsync();
                return ncc;
            }
        }

        public async Task<bool> DeleteNCC(int id)
        {
            var ncc1 = await _context.NCCs.FindAsync(id);
            if (ncc1 == null)
            {
                return false;
            }
            _context.NCCs.Remove(ncc1);
            await _context.SaveChangesAsync();
            return true;
        }

        public  async Task<(bool mncc,bool tncc)> NCCExits(string ma,string name)
        {
            var mncc = await _context.NCCs.AnyAsync(x => x.Ma_NCC == ma);
            var tncc = await _context.NCCs.AnyAsync(y => y.Ten_NCC == name);
            return(mncc, tncc);
        }
    }
}
