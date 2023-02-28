using System;
using System.Collections.Generic;

namespace GeekForLess;

public partial class Folder
{
    public int IdFolder { get; set; }

    public string Name { get; set; } = null!;

    public int? OwnerFolder { get; set; }

    public virtual ICollection<Folder> InverseOwnerFolderNavigation { get; } = new List<Folder>();

    public virtual Folder? OwnerFolderNavigation { get; set; }
}
