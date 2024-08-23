using Xunit;
using Moq;
using SocialAPI.Aplicaciones.Servicios;
using SocialAPI.Dominio.Interfaces.Repositorios;
using SocialAPI.Infraestructura.Memoria.Repositorios;
using SocialAPI.Dominio;

namespace SocialAPI.Test
{
    public class UsuarioServiceTest
    {
        private readonly Mock<IRepositorioUser<Usuario, Guid>> _repositorioUsuariosMock;
        private readonly UsuarioServicio _usuarioService;

        public UsuarioServiceTest()
        {
            _repositorioUsuariosMock = new Mock<IRepositorioUser<Usuario, Guid>>();
            _usuarioService = new UsuarioServicio(_repositorioUsuariosMock.Object);
        }

        [Fact]
        public void CrearUsuario_DebeAgregarUsuarioAlRepositorio()
        {
            //Arrange
            var user = new Usuario("nuevoUsuario");

            _repositorioUsuariosMock.Setup(r => r.Agregar(It.IsAny<Usuario>())).Returns(user);

            //Act
            var userCreado = _usuarioService.Agregar(user);

            //Assert
            Assert.Equal("nuevoUsuario", userCreado.Nombre);
            _repositorioUsuariosMock.Verify(r => r.Agregar(user), Times.Once());
        }

        [Fact]
        public void PublicarPost_DebeAñadirPostAlUsuario()
        {
            //Arrange
            var usuario = new Usuario("Usuario");
            var post = "Mi primer post";

            _repositorioUsuariosMock.Setup(r => r.ObtenerPorNombre("Usuario")).Returns(usuario);

            //Act
            _usuarioService.PublicarPost("Usuario", post);

            //Assert
            Assert.Single(usuario.Posts);
            Assert.Equal(post, usuario.Posts[0].Texto);
        }

        [Fact]
        public void SeguirUsuario_DebeAñadirSeguidor()
        {
            //Arrange
            var seguidor = new Usuario("Seguidor");
            var seguido = new Usuario("Seguido");

            _repositorioUsuariosMock.Setup(r => r.ObtenerPorNombre("Seguidor")).Returns(seguidor);
            _repositorioUsuariosMock.Setup(r => r.ObtenerPorNombre("Seguido")).Returns(seguido);

            //Act
            _usuarioService.SeguirUsuario("Seguidor", "Seguido");

            //Asert
            Assert.Contains(seguido, seguidor.Siguiendo);
        }

        [Fact]
        public void ObtenerPostDeSeguidos_DebeRetornarPostsDeFollowinsDelUsuario()
        {
            // Arrange
            var seguidor = new Usuario("Seguidor");
            var seguido = new Usuario("Seguido");
            seguido.PublicarPost("Post de seguido");
            seguidor.SeguirUsuario(seguido);

            _repositorioUsuariosMock.Setup(r => r.ObtenerPorNombre("Seguidor")).Returns(seguidor);

            // Act
            var postsObtenidos = _usuarioService.ObtenerPostsDeSeguidos("Seguidor");

            // Assert
            Assert.Single(postsObtenidos);
            Assert.Equal("Post de seguido", postsObtenidos[0].Texto);
        }
    }
}