using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelRoomImageRepository : IHotelRoomImageRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public HotelRoomImageRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateHotelRoomImage(HotelRoomImageDTO imageDTO)
        {
            var image = _mapper.Map<HotelRoomImageDTO, HotelRoomImage>(imageDTO);
            await _db.HotelRoomImages.AddAsync(image);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByImageId(int imageId)
        {
            var image = await _db.HotelRoomImages.FindAsync(imageId);
            _db.HotelRoomImages.Remove(image);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            var images = _db.HotelRoomImages.Where(o => o.RoomId == roomId);
            _db.HotelRoomImages.RemoveRange(images);

            return await _db.SaveChangesAsync();
        }

        public IEnumerable<HotelRoomImageDTO> GetHotelRoomImages(int roomId)
        {
            var images = _db.HotelRoomImages.Where(o => o.RoomId == roomId);

            return _mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDTO>>(images);
        }
    }
}
