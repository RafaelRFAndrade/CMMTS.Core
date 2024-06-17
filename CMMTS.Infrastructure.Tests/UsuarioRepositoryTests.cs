using CMMTS.Domain.Entities;
using CMMTS.Domain.Enums;
using CMMTS.Domain.Interfaces;
using Moq;

namespace CMMTS.Infrastructure.Tests
{
    public class UsuarioRepositoryTests 
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioRepositoryTests()
        {
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(repo => repo.Add(It.IsAny<Usuarios>()));
            usuarioRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Usuarios>());
            usuarioRepositoryMock.Setup(repo => repo.BuscarUsuarioPorNickname(It.IsAny<string>())).Returns((string nickname) => new Usuarios { Nickname = nickname });
            usuarioRepositoryMock.Setup(repo => repo.VerificarExistenciaUsuario(It.IsAny<string>(), It.IsAny<string>())).Returns(0);

            _usuarioRepository = usuarioRepositoryMock.Object;
        }

        [Fact]
        public void AddDeveAdicionar()
        {
            // Arrange
            var usuario = new Usuarios { Codigo = Guid.NewGuid().ToString(), Nickname = "testuser", Email = "test@example.com", Nome = "Teste1", Senha = "teste12321", TipoAcesso = TipoAcesso.Usuario, Status = true };

            // Act
            _usuarioRepository.Add(usuario);

            // Assert
            var usuarioEsperado = _usuarioRepository.BuscarUsuarioPorNickname(usuario.Nickname);

            Assert.NotNull(usuarioEsperado);
            Assert.Equal(usuario.Nickname, usuarioEsperado.Nickname);

            _usuarioRepository.DeletarUsuarioPorNickname(usuario.Nickname);
        }

        [Fact]
        public void GetAll_DeveRetornarTodosUsuarios()
        {
            // Arrange
            var usuario = new Usuarios { Codigo = Guid.NewGuid().ToString(), Nickname = "testuser", Email = "test@example.com", Nome = "Teste1", Senha = "teste12321", TipoAcesso = TipoAcesso.Usuario, Status = true };
            _usuarioRepository.Add(usuario);

            // Act
            var usuarios = _usuarioRepository.GetAll();

            // Assert
            Assert.NotNull(usuarios);
            Assert.Empty(usuarios); 
        }

        [Fact]
        public void BuscarUsuarioPorNickname_DeveRetornarUsuarioCorreto()
        {
            // Arrange
            var expectedUser = new Usuarios { Codigo = Guid.NewGuid().ToString(), Nickname = "testuser", Email = "test@example.com", Nome = "Teste1", Senha = "teste12321", TipoAcesso = TipoAcesso.Usuario, Status = true };
            _usuarioRepository.Add(expectedUser);

            // Act
            var actualUser = _usuarioRepository.BuscarUsuarioPorNickname(expectedUser.Nickname);

            // Assert
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Nickname, actualUser.Nickname);

            _usuarioRepository.DeletarUsuarioPorNickname(expectedUser.Nickname);
        }

        [Fact]
        public void VerificarExclusao_DeveRetornarZero()
        {
            // Arrange
            var expectedUser = new Usuarios { Codigo = Guid.NewGuid().ToString(), Nickname = "testuser", Email = "test@example.com", Nome = "Teste1", Senha = "teste12321", TipoAcesso = TipoAcesso.Usuario, Status = true };
            _usuarioRepository.Add(expectedUser);

            // Act
            _usuarioRepository.DeletarUsuarioPorNickname(expectedUser.Nickname);
            var actualCount = _usuarioRepository.VerificarExistenciaUsuario(expectedUser.Nickname, expectedUser.Email);

            // Assert
            Assert.Equal(0, actualCount);

            _usuarioRepository.DeletarUsuarioPorNickname(expectedUser.Nickname);
        }
    }
}