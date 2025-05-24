using System.ComponentModel.DataAnnotations.Schema;

namespace CocovoitAPI.Domain.models;

[Serializable]
public class Folder
{
    public long Id { get; set; }
    public string Name { get; set; }

    [Column("utilisateur_id")]
    public long UtilisateurId { get; set; }

    // Propriété de navigation vers l'Utilisateur
    public virtual Utilisateur Utilisateur { get; set; }

    // Propriété de navigation vers les Reports
    public virtual ICollection<Report> Reports { get; set; }

    public ICollection<FolderTag> FolderTags { get; set; }
}
