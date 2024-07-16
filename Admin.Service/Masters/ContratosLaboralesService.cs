using Admin.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services.Masters
{
    public class ContratosLaboralesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public ContratosLaboralesService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }

        public async Task Delete(int id)
        {
            var data = await _unitOfWork.ContratosLaboraleRepository.GetOne(x => x.Id == id);
            if (data == null)
            {
                return;
            }
            _unitOfWork.ContratosLaboraleRepository.DeleteAsync(data);
            await _unitOfWork.SaveChanges();
        }
    }
}
