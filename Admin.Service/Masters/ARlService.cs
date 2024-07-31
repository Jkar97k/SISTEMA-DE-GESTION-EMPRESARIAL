using AutoMapper;
using Admin.Entities.Models;
using Admin.DTO;
using Admin.Interfaces;

namespace Admin.Services
{

    public class ArlService : IArlService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public ArlService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<GenericDTO>> GetAll()
        {
            var data = await _unitOfWork.ArlRepository.GetAllAsync();
            return _mapper.Map<List<GenericDTO>>(data);
        }
        public async Task Add(CreateGenericDTO dto)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Arl>(dto);
           await  _unitOfWork.ArlRepository.Add(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Update(GenericDTO dto)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.ArlRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }
        public async Task Delete(int id)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == id);
            if (data == null)
            {
                return;
            }
            _unitOfWork.ArlRepository.DeleteAsync(data);
            await _unitOfWork.SaveChanges();
        }
    }
}