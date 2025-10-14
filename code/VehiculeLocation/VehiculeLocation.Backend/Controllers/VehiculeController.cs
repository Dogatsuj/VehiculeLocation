using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculeLocation.Backend.Data;
using VehiculeLocation.Backend.Models;

[ApiController]
[Route("api/[controller]")] // L'URL de base sera /api/Vehicule
public class VehiculeController : ControllerBase
{
    private readonly AppDbContext _context;

    public VehiculeController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Récupère la liste de tous les véhicules.
    /// GET: api/Vehicule
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicule>>> GetVehicules()
    {
        // Retourne la liste complète des véhicules de la base de données
        return await _context.Vehicules.ToListAsync();
    }
}