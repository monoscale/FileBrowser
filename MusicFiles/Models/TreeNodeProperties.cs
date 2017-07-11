namespace MusicFiles.Models
{
    /// <summary>
    /// Data class that contains information of deleted TreeView Nodes.
    /// </summary>
    public class TreeNodeProperties
    {
        public string Parent { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int Index { get; set; }
    }
}
