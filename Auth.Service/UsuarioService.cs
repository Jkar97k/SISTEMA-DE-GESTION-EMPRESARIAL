
using Auth.DTO;
using Auth.Entities.Models;
using Auth.Interfaces;
using AutoMapper;

namespace Auth.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public UsuarioService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task<List<UsuarioDTO>> GetAll()
        {
            var data = await _unitOfWork.UsuarioRepository.GetAllAsync();
            return _mapper.Map<List<UsuarioDTO>>(data);
        }
        //public async Task Add(CreateUsuarioDTO dto)
        //{
        //    var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.NumeroDocumento == dto.NumeroDocumento);
        //    if (data != null)
        //    {
        //        return;
        //    }
        //    var entity = _mapper.Map<Usuario>(dto);
        //    await _unitOfWork.UsuarioRepository.Add(entity);
        //    await _unitOfWork.SaveChanges();
        //}
        //public async Task Update(UsuarioDTO dto)
        //{
        //    var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.Id == dto.Id);
        //    if (data == null)
        //    {
        //        return;
        //    }
        //    var entity = _mapper.Map(dto, data);
        //    _unitOfWork.UsuarioRepository.UpdateAsync(entity);
        //    await _unitOfWork.SaveChanges();
        //}
        //public async Task Delete(int id)
        //{
        //    var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.Id == id);
        //    if (data == null)
        //    {
        //        return;
        //    }
        //    _unitOfWork.UsuarioRepository.DeleteAsync(data);
        //    await _unitOfWork.SaveChanges();
        //}
    }
}
