using AutoMapper;
using CadastroUsuarioAPI.Controllers;
using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Repositories;
using CadastroUsuarioAPI.Repositories.Interface;
using CadastroUsuarioAPI.Services;
using CadastroUsuarioAPI.Services.Interface;
using CadastroUsuarioAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net.Http;
using Xunit;

namespace UnitTests
{
    public class CadastroUsuarioAPITest
    {
        private UsuarioController _controller;
        private readonly Mock<IUserService> _service;
        private readonly Mock<IUserRepository> _repository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<TokenUtils> _token;

        public CadastroUsuarioAPITest()
        {
            _repository = new Mock<IUserRepository>();
            _service = new Mock<IUserService>();
            _controller = new UsuarioController(_service.Object);
        }

        [Fact]  
        public async void CreateUser()
        {
            var user = new Mock<CriaUsuarioDTO>();
            var result = _controller.CreateUser(user.Object);

            Assert.NotNull(result);
        }
    }
}