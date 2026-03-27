using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdxFileAttachmentFtp
{
    public uint FileId { get; set; }

    public string FileName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public uint MenuId { get; set; }

    public string UploadTableName { get; set; } = null!;

    public uint CaseId { get; set; }

    public bool? IsPublic { get; set; }

    public uint FileCreateBy { get; set; }

    public DateTime FileCreateDate { get; set; }

    public bool IsDeleted { get; set; }

    public uint FileDeletedBy { get; set; }

    public DateTime? FileDeletedDate { get; set; }

    public string? FileThumbnail { get; set; }
}

