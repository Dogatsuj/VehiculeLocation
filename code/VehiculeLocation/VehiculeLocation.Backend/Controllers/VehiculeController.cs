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

    /// <summary>
    /// Récupère la liste de toutes les périodes de location pour un véhicule donné.
    /// GET: api/Vehicule/{vehiculeId}/locations
    /// </summary>
    [HttpGet("{vehiculeId}/locations")]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocationsByVehicule(int vehiculeId)
    {
        // 1. Vérifier si le véhicule existe
        if (!await _context.Vehicules.AnyAsync(v => v.Id == vehiculeId))
        {
            return NotFound($"Véhicule avec l'ID {vehiculeId} non trouvé.");
        }

        // 2. Récupérer toutes les locations liées à cet ID
        var locations = await _context.Locations
                                      .Where(l => l.VehiculeId == vehiculeId)
                                      .ToListAsync();

        return locations;
    }
    /// <summary>
    /// Vérifie si le véhicule ciblé n'a AUCUNE location sur le créneau donné.
    /// GET: api/Vehicule/{vehiculeId}/available?start={dateDebut}&end={dateFin}
    /// </summary>
    /// <param name="vehiculeId">L'ID du véhicule à vérifier.</param>
    /// <param name="dateDebut">Date et heure de début du créneau (format ISO 8601).</param>
    /// <param name="dateFin">Date et heure de fin du créneau (format ISO 8601).</param>
    [HttpGet("{vehiculeId}/available")]
    public async Task<ActionResult<bool>> CheckAvailability(
        int vehiculeId,
        [FromQuery] DateTime dateDebut,
        [FromQuery] DateTime dateFin)
    {
        // 1. Validation de base du créneau
        if (dateDebut >= dateFin)
        {
            return BadRequest("La date de début doit précéder la date de fin.");
        }

        // 2. Vérifier l'existence du véhicule
        if (!await _context.Vehicules.AnyAsync(v => v.Id == vehiculeId))
        {
            return NotFound($"Véhicule avec l'ID {vehiculeId} non trouvé.");
        }

        // 3. Logique de chevauchement de créneau (Overlap Logic) :
        // Un chevauchement existe si : (Début_Actuel < Fin_Nouvelle) ET (Fin_Actuelle > Début_Nouvelle)

        var isBooked = await _context.Locations
            .Where(l => l.VehiculeId == vehiculeId)
            .AnyAsync(l => l.DateStart < dateFin && l.DateEnd> dateDebut);

        // Si isBooked est VRAI, cela signifie qu'une location existe sur ce créneau.
        // On retourne l'inverse : VRAI si aucune location n'est trouvée (DISPONIBLE).
        return !isBooked;
    }
}