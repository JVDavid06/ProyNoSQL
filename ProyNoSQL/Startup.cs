using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProyNoSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyNoSQL
{
    public class CosmosDb
    {
        public string Account { get; set; }
        public string Key { get; set; }
        public string DatabaseName { get; set; }
        public string ContainerName { get; set; }
    }
    public interface ICosmosDbService
    {
        Task<IEnumerable<Usuario>> GetMultipleAsync();
        Task<Usuario> GetAsync(string id);
        Task AddAsync(Usuario item);
        Task UpdateAsync(string id, Usuario item);
        Task DeleteAsync(string id);

        /*Proveedores*/
        Task AddAsyncProveedor(Proveedor item);
        Task<IEnumerable<Proveedor>> GetMultipleAsyncProviders();
        Task DeleteAsyncProveedor(string id);
        Task<Proveedor> GetAsyncProveedor(string id);
        Task UpdateAsyncProveedor(/*string id, */Proveedor proveedor);

        //Horarios
        Task AddAsyncHorario(Horarios item);
        Task<IEnumerable<Horarios>> GetMultipleAsyncHorarios();
        Task DeleteAsyncHorario(string id);
        Task UpdateAsyncHorario(string id, Horarios horarios);

        //Sucursales
        Task AddAsyncSucursal(Sucursales item);
        Task<IEnumerable<Sucursales>> GetMultipleAsyncSucursales();
        Task DeleteAsyncSucursal(string id);
        Task<Sucursales> GetAsyncSucursal(string id);
        Task UpdateAsyncSucursal(string id, Sucursales sucursales);

        //Inventario
        Task AddAsyncInventario(Inventario item);
        Task<IEnumerable<Inventario>> GetMultipleAsyncInventario();
        Task DeleteAsyncInventario(string id);
        Task<Inventario> GetAsyncInventario(string id);
        Task UpdateAsyncInventario(string id, Inventario inventario);

        //Ordenes
        Task AddAsyncOrden(Ordenes item);
        Task<IEnumerable<Ordenes>> GetMultipleAsyncOrdenes();
        Task DeleteAsyncOrden(string id);
        Task<Ordenes> GetAsyncOrden(string id);
        Task UpdateAsyncOrden(string id, Ordenes ordenes);

        //Pedidos
        Task AddAsyncPedido(Pedidos item);
        Task<IEnumerable<Pedidos>> GetMultipleAsyncPedidos();
        Task DeleteAsyncPedido(string id);
        Task<Pedidos> GetAsyncPedido(string id);
        Task UpdateAsyncPedido(string id, Pedidos pedidos);
    }
    public class CosmosDbService : ICosmosDbService
    {
        public Container _container;
        public Container contenedor;
        public Container contenedorHorario;
        public Container contenedorSucursales;
        public Container contenedorInventario;
        public Container contenedorOrdenes;
        public Container contenedorPedidos;


        public CosmosDbService(
            CosmosClient cosmosDbClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, "Usuarios");
            contenedor = cosmosDbClient.GetContainer(databaseName, "Proveedor");
            contenedorHorario = cosmosDbClient.GetContainer(databaseName, "Horarios");
            contenedorSucursales = cosmosDbClient.GetContainer(databaseName, "Sucursales");
            contenedorInventario = cosmosDbClient.GetContainer(databaseName, "Inventario");
            contenedorOrdenes = cosmosDbClient.GetContainer(databaseName, "Ordenes");
            contenedorPedidos = cosmosDbClient.GetContainer(databaseName, "Pedidos");
        }

        //********************Usuarios********************
        public async Task AddAsync(Usuario item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Usuario>(id, new PartitionKey(id));
        }

        public async Task<Usuario> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Usuario>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling Usuario not found and other exceptions
            {
                return null;
            }
        }

        public async Task<IEnumerable<Usuario>> GetMultipleAsync()
        {
            var query = _container.GetItemQueryIterator<Usuario>(new QueryDefinition("SELECT * FROM Usuarios"));

            var results = new List<Usuario>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateAsync(string id, Usuario Usuario)
        {
            await _container.UpsertItemAsync(Usuario, new PartitionKey(id));
        }


        //*******************Proveedor**********************
        public async Task AddAsyncProveedor(Proveedor item)
        {
            await contenedor.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<Proveedor>> GetMultipleAsyncProviders()
        {
            var query = contenedor.GetItemQueryIterator<Proveedor>(new QueryDefinition("SELECT * FROM Proveedor"));

            var results = new List<Proveedor>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task DeleteAsyncProveedor(string id)
        {
            await contenedor.DeleteItemAsync<Proveedor>(id, new PartitionKey(id));
        }

        public async Task<Proveedor> GetAsyncProveedor(string id)
        {
            try
            {
                var response = await contenedor.ReadItemAsync<Proveedor>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling Usuario not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdateAsyncProveedor(/*string id,*/ Proveedor proveedor)
        {
            await contenedor.UpsertItemAsync(proveedor, new PartitionKey(proveedor.id));
        }

        //*******************Horarios**************************
        public async Task AddAsyncHorario(Horarios item)
        {
            await contenedorHorario.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<Horarios>> GetMultipleAsyncHorarios()
        {
            var query = contenedorHorario.GetItemQueryIterator<Horarios>(new QueryDefinition("SELECT * FROM Horarios"));

            var results = new List<Horarios>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task DeleteAsyncHorario(string id)
        {
            await contenedorHorario.DeleteItemAsync<Horarios>(id, new PartitionKey(id));
        }

        public async Task UpdateAsyncHorario(string id, Horarios horarios)
        {
            await contenedorHorario.UpsertItemAsync(horarios, new PartitionKey(id));
        }

        //*******************Sucursales***********************

        public async Task AddAsyncSucursal(Sucursales item)
        {
            await contenedorSucursales.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<Sucursales>> GetMultipleAsyncSucursales()
        {
            var query = contenedorSucursales.GetItemQueryIterator<Sucursales>(new QueryDefinition("SELECT * FROM Sucursales"));

            var results = new List<Sucursales>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task DeleteAsyncSucursal(string id)
        {
            await contenedorSucursales.DeleteItemAsync<Sucursales>(id, new PartitionKey(id));
        }

        public async Task<Sucursales> GetAsyncSucursal(string id)
        {
            try
            {
                var response = await contenedorSucursales.ReadItemAsync<Sucursales>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling Usuario not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdateAsyncSucursal(string id, Sucursales sucursales)
        {
            await contenedorSucursales.UpsertItemAsync(sucursales, new PartitionKey(id));
        }

        //*******************Inventario***********************

        public async Task AddAsyncInventario(Inventario item)
        {
            await contenedorInventario.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<Inventario>> GetMultipleAsyncInventario()
        {
            var query = contenedorInventario.GetItemQueryIterator<Inventario>(new QueryDefinition("SELECT * FROM Inventario"));

            var results = new List<Inventario>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task DeleteAsyncInventario(string id)
        {
            await contenedorInventario.DeleteItemAsync<Inventario>(id, new PartitionKey(id));
        }

        public async Task<Inventario> GetAsyncInventario(string id)
        {
            try
            {
                var response = await contenedorInventario.ReadItemAsync<Inventario>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling Usuario not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdateAsyncInventario(string id, Inventario inventario)
        {
            await contenedorInventario.UpsertItemAsync(inventario, new PartitionKey(id));
        }

        //*******************Ordenes***********************

        public async Task AddAsyncOrden(Ordenes item)
        {
            await contenedorOrdenes.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<Ordenes>> GetMultipleAsyncOrdenes()
        {
            var query = contenedorOrdenes.GetItemQueryIterator<Ordenes>(new QueryDefinition("SELECT * FROM Ordenes"));

            var results = new List<Ordenes>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task DeleteAsyncOrden(string id)
        {
            await contenedorOrdenes.DeleteItemAsync<Ordenes>(id, new PartitionKey(id));
        }

        public async Task<Ordenes> GetAsyncOrden(string id)
        {
            try
            {
                var response = await contenedorOrdenes.ReadItemAsync<Ordenes>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling Usuario not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdateAsyncOrden(string id, Ordenes ordenes)
        {
            await contenedorOrdenes.UpsertItemAsync(ordenes, new PartitionKey(id));
        }

        //*******************Pedidos***********************

        public async Task AddAsyncPedido(Pedidos item)
        {
            await contenedorPedidos.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task<IEnumerable<Pedidos>> GetMultipleAsyncPedidos()
        {
            var query = contenedorPedidos.GetItemQueryIterator<Pedidos>(new QueryDefinition("SELECT * FROM Pedidos"));

            var results = new List<Pedidos>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task DeleteAsyncPedido(string id)
        {
            await contenedorPedidos.DeleteItemAsync<Pedidos>(id, new PartitionKey(id));
        }

        public async Task<Pedidos> GetAsyncPedido(string id)
        {
            try
            {
                var response = await contenedorPedidos.ReadItemAsync<Pedidos>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling Usuario not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdateAsyncPedido(string id, Pedidos pedidos)
        {
            await contenedorPedidos.UpsertItemAsync(pedidos, new PartitionKey(id));
        }


    }

    public class Startup
    {
        private static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfiguration configurationSection)
        {
            var databaseName = configurationSection["DatabaseName"];
            var containerName = configurationSection["ContainerName"];
            var account = configurationSection["Account"];
            var key = configurationSection["Key"];

            var client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
            var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            var cosmosDbService = new CosmosDbService(client, databaseName, containerName);
            return cosmosDbService;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICosmosDbService>(InitializeCosmosClientInstanceAsync(Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyNoSQL", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyNoSQL v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
