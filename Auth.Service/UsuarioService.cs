using Admin.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitOfWork;

        public UsuarioService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
        }
    }
}
