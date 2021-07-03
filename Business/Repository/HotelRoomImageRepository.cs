using Business.Repository.IRepository;
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
        public Task<int> CreateHotelRoomImage(HotelRoomImageDTO image)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteHotelRoomImageByImageId(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
