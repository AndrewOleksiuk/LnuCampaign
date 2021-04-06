using System.Collections.Generic;
using AutoMapper;
using LnuCampaign.BLL;
using LnuCampaign.Core.Data.Dto;
using LnuCampaign.Core.Data.Entities;
using LnuCampaign.Core.Interfaces.DataAccess;
using Moq;
using Xunit;

namespace LnuCampaign.Tests.Services
{
    public class UserProfileServiceTests
    {
        Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        Mock<IRepository<ZnoCertificate>> _znoCertificateRepositoryMock = new Mock<IRepository<ZnoCertificate>>();
        Mock<IMapper> _mapperMock = new Mock<IMapper>();

        [Fact]
        public void UpdateUser_AtAnyCondition_ReturnUser()
        {
            // Arrange
            var userDataDto = new UserDataDto() 
            { 
                FirstName = "Andriy",
                LastName = "Oleksiuk",
                ZnoCertificates = new List<ZnoCertificate>()
            };
            var expectedUser = new User() { FirstName = "Andriy", LastName = "Oleksiuk" };
            
            _mapperMock.Setup(m => m.Map<UserDataDto, User>(userDataDto)).Returns(expectedUser);
            _userRepositoryMock.Setup(u => u.Update(expectedUser)).Returns(expectedUser);

            var profileService = new ProfileService(_userRepositoryMock.Object, 
                        _znoCertificateRepositoryMock.Object, _mapperMock.Object);

            // Act
            var result = profileService.UpdateUserData(userDataDto);

            // Assert
            Assert.Equal(expectedUser, result);
        }
    }
}
