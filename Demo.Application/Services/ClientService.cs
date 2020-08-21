using AutoMapper;
using Resource;
using Demo.Application.Interfaces;
using Demo.Application.Validation;
using Demo.Application.ViewModels;
using Demo.Application.ViewModels.Notifications;
using Demo.Domain.Entity;
using Demo.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Demo.Application.Services
{
    public class ClientService : IDisposable, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public ResultWrap<ClientViewModel> Add(ClientViewModel obj)
        {
            var result = new ResultWrap<ClientViewModel>();
            
            var entity = _mapper.Map<ClientViewModel, Client>(obj);

            var validation = new ClientValidation().Validate(entity);

            if (!validation.IsValid)
            {
                return result.SetError(validation.Errors, EKnowErrors.BusinessError);
            }

            _clientRepository.Add(entity);

            return result.SetSuccess(obj);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var list = _clientRepository.GetAll();

            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(list);
        }

        public ClientViewModel GetById(Guid id)
        {
            var entity = _clientRepository.GetById(id);
            return _mapper.Map<Client, ClientViewModel>(entity);
        }

        public ResultWrap<ClientViewModel> Remove(Guid id)
        {
            var result = new ResultWrap<ClientViewModel>();

            var entity = _clientRepository.GetById(id);

            if(entity == null)
            {
                return result.SetError(string.Format(Geral.NotFound, Geral.Client), EKnowErrors.NotFoundError);
            }

            _clientRepository.Remove(entity);

            return result.SetSuccess();
        }

        public ResultWrap<ClientViewModel> Update(ClientViewModel obj)
        {
            var result = new ResultWrap<ClientViewModel>();

            var current = _clientRepository.GetById(obj.Id.Value);

            if (current == null)
            {
                return result.SetError(string.Format(Geral.NotFound, Geral.Client), EKnowErrors.NotFoundError);
            }

            _mapper.Map<ClientViewModel, Client>(obj, current);

            var validation = new ClientValidation().Validate(current);

            if (!validation.IsValid)
            {
                return result.SetError(validation.Errors, EKnowErrors.BusinessError);
            }

            _clientRepository.Update(current);
            
            return result.SetSuccess(obj);
        }
    }
}
