using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelRoom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";
            var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
            await _db.SaveChangesAsync();

            return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoomDTO> hotelRoomDTOs = _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms);

                return hotelRoomDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDTO hotelRoomDTO = _mapper.Map<HotelRoom, HotelRoomDTO>(_db.HotelRooms.FirstOrDefault(o => o.Id == roomId));

                return hotelRoomDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // if unique returns null, else returns the room obj.
        public async Task<HotelRoomDTO> IsRoomUnique(string name)
        {
            try
            {
                HotelRoomDTO hotelRoomDTO = _mapper.Map<HotelRoom, HotelRoomDTO>(_db.HotelRooms.FirstOrDefault(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));

                return hotelRoomDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                if (roomId == hotelRoomDTO.Id)
                {
                    // valid
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId); // get current room record from DB.
                    HotelRoom room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomDetails); // map updated dto to db entity obj
                    room.UpdatedBy = ""; // update some fields
                    room.UpdatedDate = DateTime.Now;
                    var updatedRoom = _db.HotelRooms.Update(room); // Update the db entity
                    await _db.SaveChangesAsync(); // save the changes

                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updatedRoom.Entity); // return updated entity as a dto
                }
                else
                {
                    // invalid
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await _db.HotelRooms.FindAsync(roomId);

            if (roomDetails != null)
            {
                _db.HotelRooms.Remove(roomDetails);
                return await _db.SaveChangesAsync(); // returns the no of rows affected.
            }

            return 0;
        }
    }
}
