/*using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Service
{

    public class NhapKhoRawService
    {
        private readonly ApplicationDbContext _context;

        public NhapKhoRawService(ApplicationDbContext context)
        {
            _context = context;
        }
        private List<NhapKhoRawData> _temporaryChiTietSanPhams = new List<NhapKhoRawData>();

        public void AddTemporaryChiTietSanPham(NhapKhoRawData chiTiet)
        {
            _temporaryChiTietSanPhams.Add(chiTiet);
        }

        public List<NhapKhoRawData> GetTemporaryChiTietSanPhams()
        {
            return _temporaryChiTietSanPhams;
        }

        public void ClearTemporaryChiTietSanPhams()
        {
            _temporaryChiTietSanPhams.Clear();
        }
    }
}
    
*/