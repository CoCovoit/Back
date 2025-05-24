using System.ComponentModel.DataAnnotations.Schema;

namespace CocovoitAPI.Domain.models;

[Serializable]
public class FolderTag
{
    [Column("folder_id")]
    public long FolderId { get; set; }
    public Folder Folder { get; set; }

    [Column("tag_id")]
    public long TagId { get; set; }
    public Tag Tag { get; set; }
}
