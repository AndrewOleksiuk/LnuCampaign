using System;
using AutoMapper;
using LnuCampaign.Configuration;
using LnuCampaign.Core.Data.Dto;
using LnuCampaign.Core.Data.Entities;
using LnuCampaign.Core.Interfaces.DataAccess;
using LnuCampaign.Core.Interfaces.Services;
using LnuCampaign.DAL.Repositories;
using Serilog.Core;

namespace LnuCampaign.BLL
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<ZnoCertificate> _znoCertificateRepository;
        private IMapper _mapper;
        private readonly Logger _logger;

        public ProfileService(IUserRepository userRepository, IRepository<ZnoCertificate> znoCertificateRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _znoCertificateRepository = znoCertificateRepository;
            _logger = LoggerConfig.ConfigureLogger();
        }

        public User UpdateUserData(UserDataDto model)
        {
            try
            {
                var user = _mapper.Map<UserDataDto, User>(model);
                var result = _userRepository.Update(user);
                foreach (var certificate in model.ZnoCertificates)
                {
                    _znoCertificateRepository.Add(certificate);
                }
                return result;
            }
            catch (Exception e)
            {
                _logger.Error("@exception", e);
                return null;
            }
        }
    }
}
