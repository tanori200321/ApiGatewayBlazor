using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiGatewayBlazor.Mongo.Models
{
    public class VentasService
    {
        private readonly IMongoCollection<Venta> _ventasCollection;

        public VentasService(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("storeMongoDB");
            _ventasCollection = database.GetCollection<Venta>("Ventas");
        }

        public async Task<List<Venta>> GetAllVentas()
        {
            return await _ventasCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Venta> GetVentaById(int id)
        {
            return await _ventasCollection.Find(venta => venta.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertVenta(Venta venta)
        {
            await _ventasCollection.InsertOneAsync(venta);
        }

        public async Task UpdateVenta(int id, Venta venta)
        {
            await _ventasCollection.ReplaceOneAsync(v => v.Id == id, venta);
        }

        public async Task DeleteVenta(int id)
        {
            await _ventasCollection.DeleteOneAsync(v => v.Id == id);
        }
    }
    }

