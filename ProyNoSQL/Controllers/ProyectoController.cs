using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyNoSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyNoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;
        private IEnumerable<Usuario> usuarios;
        private IEnumerable<Proveedor> proveedores;
        private IEnumerable<Horarios> horarios;
        private IEnumerable<Sucursales> sucursales;
        private IEnumerable<Inventario> inventario;
        private IEnumerable<Ordenes> ordenes;
        private IEnumerable<Pedidos> pedidos;



        public ProyectoController(ICosmosDbService cosmosDbService)
        {
             _cosmosDbService = cosmosDbService;
        }
        //Usuarios
        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<ActionResult> CrearUsuario(Usuario item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsync(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> VerUsuarios()
        {
             usuarios = await _cosmosDbService.GetMultipleAsync();
            return usuarios.ToList();

        }

        [HttpGet]
        [Route("VerUsuarioEspecifico")]
        public async Task<ActionResult<Usuario>> VerUsuarioEspecifico(string id)
        {
            return await _cosmosDbService.GetAsync(id);
        }

        [HttpPut]
        [Route("EditarUsuario")]
        public async Task<ActionResult<Usuario>> EditarUsuario(string id, Usuario item)
        {
            await _cosmosDbService.UpdateAsync(id, item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public async Task<ActionResult<Usuario>> EliminarUsuario(string id)
        {
            await _cosmosDbService.DeleteAsync(id);
            return Ok("Usuario eliminado");
        }

        /*Proveedor*/
        [HttpPost]
        [Route("CrearProveedor")]
        public async Task<ActionResult> CrearProveedor(Proveedor item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsyncProveedor(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerProveedores")]
        public async Task<ActionResult<IEnumerable<Proveedor>>> VerProveedores()
        {
            proveedores = await _cosmosDbService.GetMultipleAsyncProviders();
            return proveedores.ToList();

        }

        [HttpGet]
        [Route("VerProveedorEspecifico")]
        public async Task<ActionResult<Proveedor>> VerProveedorEspecifico(string id)
        {
            return await _cosmosDbService.GetAsyncProveedor(id);
        }

        [HttpPut]
        [Route("EditarProveedor")]
        public async Task<ActionResult<Proveedor>> EditarProveedor(/*string id,*/ Proveedor item)
        {
            await _cosmosDbService.UpdateAsyncProveedor(/*id,*/ item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarProveedor")]
        public async Task<ActionResult<Proveedor>> EliminarProveedor(string id)
        {
            await _cosmosDbService.DeleteAsyncProveedor(id);
            return Ok("Proveedor eliminado");
        }

        //Horarios

        [HttpPost]
        [Route("CrearHorarios")]
        public async Task<ActionResult> CrearHorarios(Horarios item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsyncHorario(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerHorarios")]
        public async Task<ActionResult<IEnumerable<Horarios>>> VerHorarios()
        {
            horarios = await _cosmosDbService.GetMultipleAsyncHorarios();
            return horarios.ToList();

        }

        [HttpPut]
        [Route("EditarHorario")]
        public async Task<ActionResult<Horarios>> EditarHorario(string id, Horarios item)
        {
            await _cosmosDbService.UpdateAsyncHorario(id, item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarHorario")]
        public async Task<ActionResult<Horarios>> EliminarHorario(string id)
        {
            await _cosmosDbService.DeleteAsyncHorario(id);
            return Ok("Horario eliminado");
        }

        //Sucursales
        [HttpPost]
        [Route("AgregarSucursal")]
        public async Task<ActionResult> AgregarSucursal(Sucursales item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsyncSucursal(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerSucursal")]
        public async Task<ActionResult<IEnumerable<Sucursales>>> VerSucursal()
        {
            sucursales = await _cosmosDbService.GetMultipleAsyncSucursales();
            return sucursales.ToList();

        }

        [HttpGet]
        [Route("VerSucursalEspecifica")]
        public async Task<ActionResult<Sucursales>> VerSucursalEspecifica(string id)
        {
            return await _cosmosDbService.GetAsyncSucursal(id);
        }

        [HttpPut]
        [Route("EditarSucursal")]
        public async Task<ActionResult<Sucursales>> EditarSucursal(string id, Sucursales item)
        {
            await _cosmosDbService.UpdateAsyncSucursal(id, item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarSucursal")]
        public async Task<ActionResult<Sucursales>> EliminarSucursal(string id)
        {
            await _cosmosDbService.DeleteAsyncSucursal(id);
            return Ok("Sucursal eliminada");
        }


        //Inventario
        [HttpPost]
        [Route("AgregarInventario")]
        public async Task<ActionResult> AgregarInventario(Inventario item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsyncInventario(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerInventario")]
        public async Task<ActionResult<IEnumerable<Inventario>>> VerInventario()
        {
            inventario = await _cosmosDbService.GetMultipleAsyncInventario();
            return inventario.ToList();

        }

        [HttpGet]
        [Route("VerProductoEspecifico")]
        public async Task<ActionResult<Inventario>> VerProductoEspecifico(string id)
        {
            return await _cosmosDbService.GetAsyncInventario(id);
        }

        [HttpPut]
        [Route("EditarProducto")]
        public async Task<ActionResult<Inventario>> EditarProducto(string id, Inventario item)
        {
            await _cosmosDbService.UpdateAsyncInventario(id, item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<ActionResult<Inventario>> EliminarProducto(string id)
        {
            await _cosmosDbService.DeleteAsyncInventario(id);
            return Ok("Producto eliminado");
        }

        //Ordenes
        [HttpPost]
        [Route("AgregarOrden")]
        public async Task<ActionResult> AgregarOrden(Ordenes item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsyncOrden(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerOrden")]
        public async Task<ActionResult<IEnumerable<Ordenes>>> VerOrden()
        {
            ordenes = await _cosmosDbService.GetMultipleAsyncOrdenes();
            return ordenes.ToList();

        }

        [HttpGet]
        [Route("VerOrdenEspecifica")]
        public async Task<ActionResult<Ordenes>> VerOrdenEspecifica(string id)
        {
            return await _cosmosDbService.GetAsyncOrden(id);
        }

        [HttpPut]
        [Route("EditarOrden")]
        public async Task<ActionResult<Ordenes>> EditarOrden(string id, Ordenes item)
        {
            await _cosmosDbService.UpdateAsyncOrden(id, item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarOrden")]
        public async Task<ActionResult<Ordenes>> EliminarOrden(string id)
        {
            await _cosmosDbService.DeleteAsyncOrden(id);
            return Ok("Orden eliminada");
        }

        //Pedidos
        [HttpPost]
        [Route("AgregarPedido")]
        public async Task<ActionResult> AgregarPedido(Pedidos item)
        {
            item.id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsyncPedido(item);
            return Ok();
        }

        [HttpGet]
        [Route("VerPedidos")]
        public async Task<ActionResult<IEnumerable<Pedidos>>> VerPedidos()
        {
            pedidos = await _cosmosDbService.GetMultipleAsyncPedidos();
            return pedidos.ToList();

        }

        [HttpGet]
        [Route("VerPedidoEspecifico")]
        public async Task<ActionResult<Pedidos>> VerPedidoEspecifico(string id)
        {
            return await _cosmosDbService.GetAsyncPedido(id);
        }

        [HttpPut]
        [Route("EditarPedido")]
        public async Task<ActionResult<Pedidos>> EditarPedido(string id, Pedidos item)
        {
            await _cosmosDbService.UpdateAsyncPedido(id, item);
            return Ok("Camibio realizado");
        }

        [HttpDelete]
        [Route("EliminarPedido")]
        public async Task<ActionResult<Pedidos>> EliminarPedido(string id)
        {
            await _cosmosDbService.DeleteAsyncPedido(id);
            return Ok("Pedido eliminado");
        }


    }
}
